<template>
  <div class="sidebar" :class="{ 'sidebar-open': isOpen }">
    <div class="sidebar-header">
      <button @click="toggleSidebar" class="sidebar-toggle-button">
        <i class="pi" :class="isOpen ? 'pi-times' : 'pi-bars'"></i>
      </button>
    </div>
    <ul class="sidebar-menu" v-show="isOpen">
      <li>
        <i class="pi pi-home"></i>
        <router-link to="/home" class="sidebar-link">Home</router-link>
      </li>
      <li>
        <i class="pi pi-info-circle"></i>
        <router-link to="/calendar" class="sidebar-link">Calendario</router-link>
      </li>
      <li>
        <i class="pi pi-envelope"></i>
        <router-link to="/phonebook" class="sidebar-link">Contatos</router-link>
      </li>
    </ul>
  </div>
</template>

<script setup>
import { ref } from 'vue';

const isOpen = ref(false);

const toggleSidebar = () => {
  isOpen.value = !isOpen.value;
};
</script>

<style scoped>
.sidebar {
  background-color: #001529;
  color: white;
  padding: 10px;
  width: 45px;
  transition: width 0.3s ease;
}

.sidebar-header {
  display: flex;
  justify-content: flex-end;
}

.sidebar-toggle-button {
  background: none;
  color: white;
  border: none;
  cursor: pointer;
}

.sidebar-toggle-button i {
  font-size: 1.5rem;
}

.sidebar-menu {
  list-style-type: none;
  padding: 0;
}

.sidebar-menu li {
  margin-bottom: 10px;
}

.sidebar-menu li i {
  margin-right: 10px; 
}

.sidebar-link {
  color: white;
  text-decoration: none;
  transition: color 0.3s ease; 
}

.sidebar-link:hover {
  color: #fff; 
}

.sidebar-open {
  width: 25vh;
}
</style>
