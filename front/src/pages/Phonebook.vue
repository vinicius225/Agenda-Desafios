<template>
    <div>
      <div class="grid">
        <div class="col">
          <h1>Exemplo de DataTable Responsivo com PrimeVue</h1>
        </div>
        <div class="col">
          <button @click="cadastrar">Cadastrar</button>
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
      </DataTable>
    </div>
  </template>
  
  <script setup>
  import { ref } from "vue";
  import DataTable from "primevue/datatable";
  import Column from "primevue/column";
  
  const cars = ref([
    { vin: "1234", brand: "Toyota", year: 2020, color: "Blue" },
    { vin: "5678", brand: "Honda", year: 2019, color: "Red" },
    { vin: "9012", brand: "Ford", year: 2021, color: "Black" },
    { vin: "3456", brand: "BMW", year: 2018, color: "White" },
  ]);
  
  const cadastrar = () => {
    // Lógica para abrir o formulário de cadastro
  };
  </script>
  
  <style scoped>
  .p-datatable-scrollable-wrapper {
    overflow-x: auto;
  }
  </style>
  