<template>
  <div>
    <div class="grid">
      <div class="col">
        <h1>Agenda de Contatos</h1>
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
      <Column field="email" header="E-mail" :resizable="true"></Column>
      <Column field="phone" header="Número" :resizable="true"></Column>
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
      header="Editar Contato"
      style="width: 50%"
    >
      <!-- Formulário de Edição -->
      <form @submit.prevent="saveChanges">
        <div class="p-fluid">
          <div class="p-field">
            <label for="editName">Nome</label>
            <InputText id="editName" required v-model="editedItem.name" />
          </div>
          <div class="p-field">
            <label for="editPhone">Telefone</label>
            <InputText required id="editPhone" v-model="editedItem.phone" />
          </div>
          <div class="p-field">
            <label for="editEmail">E-mail</label>
            <InputText required id="editEmail" v-model="editedItem.email" />
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
      header="Cadastrar Contato"
      style="width: 50%"
    >
      <!-- Formulário de Cadastro -->
      <form @submit.prevent="saveNew">
        <div class="p-fluid">
          <div class="p-field">
            <label for="newName">Nome</label>
            <InputText id="newName" required v-model="newItem.name" />
          </div>
          <div class="p-field">
            <label for="newPhone">Telefone</label>
            <InputText required id="newPhone" v-model="newItem.phone" />
          </div>
          <div class="p-field">
            <label for="newEmail">E-mail</label>
            <InputText required id="newEmail" v-model="newItem.email" />
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
import WebApi from "@/api";

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
  phone: "",
  status : 1
});

const listContacts = () => {
  WebApi.getAllPhonebook()
    .then((res) => {
      contacts.value = res.data.result;
    })
    .catch((error) => {
      console.error("Erro ao buscar contatos:", error);
    });
};

onMounted(() => {
  listContacts();
});

const openEditModal = (rowData) => {
  editedItem.value = { ...rowData };
  displayEditModal.value = true;
};

const openCadastroModal = () => {
  newItem.value = {
    name: "",
    email: "",
    phone: "",
    status : 1
  };
  displayCadastroModal.value = true;
};

const saveChanges = () => {
  updateContact(editedItem.value);
  closeEditModal();
};

const closeEditModal = () => {
  editedItem.value = {};
  displayEditModal.value = false;
};

const saveNew = () => {
  WebApi.addPhonebook(newItem.value)
    .then(() => {
      listContacts();
      closeCadastroModal();
    })
    .catch((error) => {
      console.error("Erro ao cadastrar:", error);
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

  WebApi.deletePhonebook(rowData.id)
    .then(() => {
      listContacts()
    })
    .catch((error) => {
      console.error("Erro ao deletar contato:", error);
    });
};

const updateContact = (contact) => {
  WebApi.updatePhonebook(contact)
    .then(() => {
      const index = contacts.value.findIndex((c) => c.id === contact.id);
      contacts.value.splice(index, 1, contact);
    })
    .catch((error) => {
      console.error("Erro ao atualizar contato:", error);
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
