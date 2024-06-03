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
      :value="cars"
      :scrollable="true"
      scrollHeight="400px"
      responsiveLayout="scroll"
    >
      <Column field="vin" header="Vin" :resizable="true"></Column>
      <Column field="brand" header="Brand" :resizable="true"></Column>
      <Column field="year" header="Year" :resizable="true"></Column>
      <Column field="color" header="Color" :resizable="true"></Column>
      <Column header="Edit" :resizable="true">
        <template #body="{ rowData }">
          <Button
            icon="pi pi-pencil"
            class="edit-button"
            @click="openEditModal(rowData)"
          />
        </template>
      </Column>
    </DataTable>

    <!-- Modal de Edição -->
    <Dialog
      v-model="displayEditModal"
      header="Editar Compromisso"
      :visible="displayEditModal"
      width="500px"
    >
      <!-- Formulário de Edição -->
      <form @submit.prevent="saveChanges">
        <!-- Campos de edição -->
        <div class="p-fluid">
          <div class="p-field">
            <label for="vin">Vin</label>
            <InputText id="vin" v-model="editedItem.vin" />
          </div>
          <div class="p-field">
            <label for="brand">Brand</label>
            <InputText id="brand" v-model="editedItem.brand" />
          </div>
          <div class="p-field">
            <label for="year">Year</label>
            <InputText id="year" v-model="editedItem.year" />
          </div>
          <div class="p-field">
            <label for="color">Color</label>
            <InputText id="color" v-model="editedItem.color" />
          </div>
        </div>
        <!-- Botões de ação -->
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
      v-model="displayCadastroModal"
      header="Cadastrar Compromisso"
      :visible="displayCadastroModal"
      width="500px"
    >
      <!-- Formulário de Cadastro -->
      <form @submit.prevent="saveNew">
        <!-- Campos de cadastro -->
        <div class="p-fluid">
          <div class="p-field">
            <label for="newVin">Titulo</label>
            <InputText id="newVin" v-model="newItem.title" />
          </div>
          <div class="p-field">
            <label for="newBrand">Descrição</label>
            <InputText id="newBrand" v-model="newItem.description" />

          </div>
          <div class="p-field">
            <label for="newYear">Data Inicial</label>
            <InputText id="newYear" v-model="newItem.startEvent" />
          </div>
          <div class="p-field">
            <label for="newYear">Data Inicial</label>
            <InputText id="newYear" v-model="newItem.endEvent" />
          </div>
          <div class="p-field">
            <label for="newColor">Color</label>
            <InputText id="newColor" v-model="newItem.color" />
          </div>
        </div>
        <!-- Botões de ação -->
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
import { onMounted, ref } from "vue";
import DataTable from "primevue/datatable";
import Button from "primevue/button";
import Dialog from "primevue/dialog";
import Column from "primevue/column";
import InputText from "primevue/inputtext";
import WebApi from "@/api";

const calendars = ref();

onMounted(() => {
  listCalendar();
});
const listCalendar = () => {
  WebApi.getCalendarAll()
    .then((res) => {
      calendars = res.data.result;
    })
    .catch((error) => {
      errorInterceptor(error, this, "Gerenciamento externo dos Clientes");
    })
    .then(() => {
      this.mainLoading = false;
    });
};

const displayEditModal = ref(false);
const displayCadastroModal = ref(false);
const editedItem = ref({});

const openEditModal = (rowData) => {
  editedItem.value = { ...rowData }; // Copia o item selecionado para o formulário de edição
  displayEditModal.value = true;
};

const saveChanges = () => {
  closeEditModal();
};

const closeEditModal = () => {
  editedItem.value = {}; // Limpa o item editado
  displayEditModal.value = false; // Fecha o modal de edição
};

const openCadastroModal = () => {
  displayCadastroModal.value = true; // Abre o modal de cadastro
};

const saveNew = () => {
  // Lógica para salvar o novo item
  closeCadastroModal();
};

const closeCadastroModal = () => {
  newItem.value = {}; // Limpa o novo item
  displayCadastroModal.value = false; // Fecha o modal de cadastro
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
.p-datatable-scrollable-wrapper {
  overflow-x: auto;
}
</style>
