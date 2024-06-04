<template>
  <div>
    <div class="grid">
      <div class="col">
        <h1>Compromissos</h1>
      </div>
      <div class="col button">
        <Button
          @click="openCadastroModal"
          label="Cadastrar"
          class="custom-button"
          severity="info"
        />
      </div>
    </div>
    <DataTable
      :value="calendars"
      :scrollable="true"
      scrollHeight="400px"
      responsiveLayout="scroll"
    >
      <Column field="title" header="Título" :resizable="true"></Column>
      <Column field="description" header="Descrição" :resizable="true"></Column>
      <Column field="startEvent" header="Data Inicial" :resizable="true">
        <template #body="{ data }">
          {{ maskDate(data.startEvent) }}
        </template>
      </Column>
      <Column field="endEvent" header="Data Final" :resizable="true">
        <template #body="{ data }">
          {{ maskDate(data.endEvent) }}
        </template>
      </Column>
      <Column header="Ações" :resizable="true">
        <template #body="{ data }">
          <Button
            icon="pi pi-pencil"
            class="edit-button"
            @click="openEditModal(data)"
          />
          <Button
            icon="pi pi-trash"
            class="delete-button"
            @click="deleteCalendar(data)"
          />
        </template>
      </Column>
    </DataTable>

    <!-- Modal de Edição -->
    <Dialog
      v-model:visible="displayEditModal"
      header="Editar Compromisso"
      style="width: 50%"
    >
      <!-- Formulário de Edição -->
      <form @submit.prevent="saveChanges">
        <div class="p-fluid">
          <div class="p-field">
            <label for="title">Título</label>
            <InputText id="title" required v-model="editedItem.title" />
          </div>
          <div class="p-field">
            <label for="description">Descrição</label>
            <InputText
              required
              id="description"
              v-model="editedItem.description"
            />
          </div>
          <div class="p-field">
            <label for="startDate">Data Inicial</label>
            <Calendar
              id="startDate"
              required
              v-model="editedItem.startEvent"
              :showTime="true"
            />
          </div>
          <div class="p-field">
            <label for="endDate">Data Final</label>
            <Calendar
              id="endDate"
              required
              v-model="editedItem.endEvent"
              :showTime="true"
            />
          </div>
        </div>
        <div class="p-dialog-footer">
          <Button
            label="Cancelar"
            icon="pi pi-times"
            class="p-button-text"
            @click="closeEditModal"
          />
          <Button
            type="submit"
            label="Salvar"
            icon="pi pi-check"
            class="p-button-text"
          />
        </div>
      </form>
    </Dialog>

    <!-- Modal de Cadastro -->
    <Dialog
      v-model:visible="displayCadastroModal"
      header="Cadastrar Compromisso"
      style="width: 50%"
    >
      <!-- Formulário de Cadastro -->
      <form @submit.prevent="saveNew">
        <div class="p-fluid">
          <div class="p-field">
            <label for="newTitle">Título</label>
            <InputText id="newTitle" required v-model="newItem.title" />
          </div>
          <div class="p-field">
            <label for="newDescription">Descrição</label>
            <InputText
              id="newDescription"
              required
              v-model="newItem.description"
            />
          </div>
          <div class="p-field">
            <label for="newStartDate">Data Inicial</label>
            <Calendar
              id="newStartDate"
              v-model="newItem.startEvent"
              required
              :showTime="true"
            />
          </div>
          <div class="p-field">
            <label for="newEndDate">Data Final</label>
            <Calendar
              id="newEndDate"
              required
              v-model="newItem.endEvent"
              :showTime="true"
            />
          </div>
        </div>
        <div class="p-dialog-footer">
          <Button
            label="Cancelar"
            icon="pi pi-times"
            class="p-button-text"
            @click="closeCadastroModal"
          />
          <Button
            type="submit"
            label="Salvar"
            icon="pi pi-check"
            class="p-button-text"
          />
        </div>
      </form>
    </Dialog>
  </div>
</template>

<script setup>
import { ref, onMounted } from "vue";
import DataTable from "primevue/datatable";
import Button from "primevue/button";
import Dialog from "primevue/dialog";
import Column from "primevue/column";
import InputText from "primevue/inputtext";
import Calendar from "primevue/calendar";
import WebApi from "@/api";
import { maskDate } from "@/utils/masks";

const calendars = ref([]);
const displayEditModal = ref(false);
const displayCadastroModal = ref(false);
const editedItem = ref({
  title: "",
  description: "",
  startEvent: "",
  endEvent: "",
  sendEmail: false,
});
const newItem = ref({
  title: "",
  description: "",
  startEvent: "",
  endEvent: "",
  sendEmail: false,
  status: 1,
});

const listCalendar = () => {
  WebApi.getCalendarAll()
    .then((res) => {
      calendars.value = res.data.result;
    })
    .catch((error) => {
      console.error("Erro ao buscar compromissos:", error);
    });
};

onMounted(() => {
  listCalendar();
});

const openEditModal = (rowData) => {
  editedItem.value = { ...rowData };
  displayEditModal.value = true;
};

const openCadastroModal = () => {
  newItem.value = {
    title: "",
    description: "",
    startEvent: "",
    endEvent: "",
    sendEmail: false,
    status: 1,
  };
  displayCadastroModal.value = true;
};

const saveChanges = () => {
  updateCalendar(editedItem.value);
};

const closeEditModal = () => {
  editedItem.value = {};
  displayEditModal.value = false;
};

const saveNew = () => {
  if (new Date(newItem.value.endEvent) < new Date(newItem.value.startEvent)) {
    alert("Data final maior que a data inicial");
    return;
  }
  WebApi.addCalendar(newItem.value)
    .then(() => {
      listCalendar();
      closeCadastroModal();
    })
    .catch((error) => {
      listCalendar();
      closeCadastroModal();
      console.error("Erro ao cadastrar compromisso:", error);
    });
};

const closeCadastroModal = () => {
  newItem.value = {};
  displayCadastroModal.value = false;
};

const deleteCalendar = (rowData) => {
  if (!rowData || !rowData.id) {
    return;
  }

  WebApi.deleteCalendar(rowData.id)
    .then(() => {
      calendars.value = calendars.value.filter(
        (calendar) => calendar.id !== rowData.id
      );
    })
    .catch((error) => {
      console.error("Erro ao deletar compromisso:", error);
    });
};

const updateCalendar = (calendar) => {
  if (new Date(calendar.endEvent) < new Date(calendar.startEvent)) {
    alert("Data final maior que a data inicial");
    return;
  }
  WebApi.putCalendar(calendar)
    .then(() => {
      const index = calendars.value.findIndex((c) => c.id === calendar.id);
      calendars.value.splice(index, 1, calendar);
      closeEditModal();
    })
    .catch((error) => {
      console.error("Erro ao atualizar compromisso:", error);
      closeEditModal();
    });
};
</script>

<style scoped>
.button {
  display: flex;
  justify-content: flex-end;
}

.custom-button {
  width: 120px;
  height: 40px;
}

.edit-button {
  margin-right: 5px;
}

.delete-button {
  margin-right: 5px;
}

.p-datatable-scrollable-wrapper {
  overflow-x: auto;
}
</style>
