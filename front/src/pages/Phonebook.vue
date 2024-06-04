<template>
  <div>
    <div class="grid">
      <div class="col">
        <h1></h1>
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
      :value="contacts"
      :scrollable="true"
      scrollHeight="400px"
      responsiveLayout="scroll"
    >
      <Column field="name" header="Nome" :resizable="true"></Column>
      <Column field="email" header="W-mail" :resizable="true"></Column>
      <Column field="phone" header="Numero" :resizable="true">
      </Column>
      <Column header="Edit" :resizable="true">
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
            <label for="name">Nome</label>
            <InputText id="title" required v-model="editedItem.name" />
          </div>
          <div class="p-field">
            <label for="phone">Telefone</label>
            <InputText required id="phone" v-model="editedItem.phone" />
          </div>
          <div class="p-field">
            <label for="phone">E-mail</label>
            <InputText required id="phone" v-model="editedItem.phone" />
          </div>
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
            <label for="name">Nome</label>
            <InputText id="title" required v-model="editedItem.name" />
          </div>
          <div class="p-field">
            <label for="phone">Telefone</label>
            <InputText required id="phone" v-model="editedItem.phone" />
          </div>
          <div class="p-field">
            <label for="phone">E-mail</label>
            <InputText required id="phone" v-model="editedItem.phone" />
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
import Checkbox from "primevue/checkbox";
import Calendar from "primevue/calendar";
import WebApi from "@/api";
import { maskDate } from "@/utils/masks";

const contacts = ref([]);
const displayEditModal = ref(false);
const displayCadastroModal = ref(false);
const editedItem = ref({
  name: "",
  email: "",
  phone: ""
});
const newItem = ref({
  name: "",
  email: "",
  phone: ""
});

const listCalendar = () => {
  WebApi.getAllPhonebook()
    .then((res) => {
      contacts.value = res.data.result;
    })
    .catch((error) => {
      console.error("Error fetching calendars:", error);
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
    name: "",
  email: "",
  phone: ""
  };
  displayCadastroModal.value = true;
};

const saveChanges = () => {
  updateCalendar(editedItem.value);
  closeEditModal();
};

const closeEditModal = () => {
  editedItem.value = {};
  displayEditModal.value = false;
};

const saveNew = () => {
  WebApi.addPhonebook(newItem.value)
    .then(() => {
      listCalendar()
    })
    .catch((error) => {
      console.error("Erro ao atualizar:", error);
    });
};

const closeCadastroModal = () => {
  newItem.value = {};
  display
  displayCadastroModal.value = false;
};

const deleteCalendar = (rowData) => {
  if (!rowData || !rowData.id) {
    return;
  }

  WebApi.deletePhonebook(rowData.id)
    .then(() => {
      calendars.value = calendars.value.filter(
        (calendar) => calendar.id !== rowData.id
      );
    })
    .catch((error) => {
      console.error("Error deleting calendar:", error);
    });
};


const updateCalendar = (calendar) => {
  WebApi.updateCalendar(calendar)
    .then(() => {
      const index = calendars.value.findIndex((c) => c.id === calendar.id);
      calendars.value.splice(index, 1, calendar);
    })
    .catch((error) => {
      console.error("Erro ao atualizar o calendário:", error);
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
.button {
  display: flex;
  justify-content: flex-end;
}
</style>
