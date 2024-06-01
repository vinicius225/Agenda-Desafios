<template>
  <div class="layout">
    <Header />
    <div class="layout-content">
      <Sidebar />
      <div class="layout-main">
        <div class="content-box">
          <h2>{{this.$route.meta.description}}</h2>
          <router-view />
        </div>
      </div>
    </div>
    <Footer />
  </div>
</template>

<script>
import Header from "@/components/HeaderComponent.vue";
import Sidebar from "@/components/SideBarComponent.vue";
import Footer from "@/components/FooterComponent.vue";
export default {
  components: {
    Header,
    Sidebar,
    Footer
  }
};
</script>

<style scoped>
.layout {
  display: flex;
  flex-direction: column;
  background-color: #f5f5f5;
  min-height: 100vh;
}

.layout-content {
  display: flex;
  flex: 1;
}
h2{
  color: #333;
}

.layout-main {
  flex: 1;
  display: flex;
  justify-content: center; 
}

.content-box {
  background-color: #ffff;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  width: 98%;
  margin-top: 20px;
  box-sizing: border-box;
}

.content-box h1 {
  margin-top: 0;
}

@media (max-width: 768px) {
  .layout-main {
    padding: 10px; /* Reduce padding on smaller screens */
  }

  .content-box {
    padding: 15px;
  }
}
</style>
