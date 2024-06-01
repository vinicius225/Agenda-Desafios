<template>
  <footer class="footer">
    &copy; {{ getCurrentYear() }} Direitos reservados para Vinicius Andrade
  </footer>
</template>

<script setup>
const getCurrentYear = () => {
  return new Date().getFullYear();
};
</script>

<style scoped>
.footer {
  background-color: #f5f5f5;
  text-align: center;
  padding: 20px;
  position: fixed;
  bottom: 0;
  width: 100%;
}

@media screen and (max-width: 768px) {
  .footer {
    position: static; 
    width: 100%; 
  }
}
</style>
