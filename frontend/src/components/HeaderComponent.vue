<template>
  <div class="header">
    <div class="logo">
      <img src="@/assets/images/logo.png" alt="Logo" />
    </div>
    <div class="menu">
      <i class="pi pi-user icon" @click="toggleDropdown"></i>
      <div v-if="isDropdownOpen" class="dropdown-menu">
        <a @click="exit" class="dropdown-item">Sair</a>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import router from "@/router";
import store from "@/store";
import { DO_LOGOUT } from "@/store/actions";

const isDropdownOpen = ref(false);

const toggleDropdown = () => {
  isDropdownOpen.value = !isDropdownOpen.value;
};

const exit = () => {
  if (store && store.dispatch) { 
    store.dispatch(DO_LOGOUT).then(() => {
      router.push("/login");
    });
  }
};
</script>

<style scoped>
.header {
  background-color: #ffffff;
  color: black;
  padding: 10px 20px; 
  display: flex;
  justify-content: space-between;
  align-items: center;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.logo img {
  height: 40px; 
  max-height: 100%; 
}

.menu {
  position: relative;
}

.icon {
  font-size: 1.5rem;
  cursor: pointer;
  color: #333;
}

.dropdown-menu {
  position: absolute;
  right: 0;
  background-color: white;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  border: 1px solid #ddd;
  border-radius: 8px;
  margin-top: 10px;
  width: 180px;
  overflow: hidden;
  z-index: 1000;
  animation: fadeIn 0.3s ease;
}

.dropdown-item {
  display: block;
  padding: 12px 16px;
  color: #333;
  text-decoration: none;
  transition: background-color 0.2s ease, color 0.2s ease;
}

.dropdown-item:hover {
  background-color: #f0f0f0;
  color: #000;
}
</style>
