<template>
  <div>
    <div class="grid">
      <div class="col">
        <Chart type="doughnut" :data="chartData" :options="lightOptions" :plugins="plugins" />
      </div>
      <div class="col">
        <Chart type="doughnut" :data="chartData" :options="lightOptions" :plugins="plugins" />
      </div>
    </div>
    <div class="grid">
      <div class="col">
        <Chart type="doughnut" :data="chartData" :options="lightOptions" :plugins="plugins" />
      </div>
      <div class="col">
        <Chart type="doughnut" :data="chartData" :options="lightOptions" :plugins="plugins" />
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
import Chart from "primevue/chart";

const chartData = ref({
  labels: ["A", "B", "C"],
  datasets: [
    {
      data: [300, 50, 100],
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
