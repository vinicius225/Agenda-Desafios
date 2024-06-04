<template>
  <div>
    <div class="grid">
      <div class="col">
        <h2 style="text-align: center;">Media de Atrasos nos Compromissos</h2>
        <Chart type="doughnut" :data="chartData1" :options="lightOptions" :plugins="plugins" />
      </div>
      <div class="col">
        <h2 style="text-align: center;">Media de Compromissos Cancelados</h2>
        <Chart type="doughnut" :data="chartData2" :options="lightOptions" :plugins="plugins" />
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
import Chart from "primevue/chart";

const chartData1 = ref({
  labels: ["Atraso", "Presença"],
  datasets: [
    {
      data: [300, 196],
    },
  ],
});
const chartData2 = ref({
  labels: ["Presentes", "Cancelados"],
  datasets: [
    {
      data: [500, 50],
    },
  ],
});

const lightOptions = ref({
  plugins: {
    legend: {
      display: true,
    },
    datalabels: {
      color: "blue",
      labels: {
        title: {
          font: {
            weight: "bold",
            size: 48,
          },
        },
        value: {
          color: "green",
          font: {
            weight: "bold",
            size: 48,
          },
        },
      },
    },
  },
});
</script>

<style scoped>

</style>
