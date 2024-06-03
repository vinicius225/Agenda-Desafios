<template>
  <div class="content">
    <div class="login-container">
      <div class="login-card p-card p-shadow-5">
        <div class="p-card-header">
          <div class="logo">
            <img src="@/assets/images/logo.png" />
          </div>
          <h2>Login</h2>
        </div>
        <div class="p-card-body">
          <p-toast ref="toast"></p-toast>
          <form @submit.prevent="onSubmit">
            <div class="flex flex-column gap-2">
              <label for="login">Login</label>
              <InputText id="login" v-model="user.login" required />
            </div>
            <div class="flex flex-column gap-2">
              <label for="password">Senha</label>
              <InputText
                id="password"
                v-model="user.password"
                type="password"
                required
              />
            </div>
            <div class="btn flex flex-column gap-2">
              <Button label="Logar" type="submit" class="p-button" />
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, reactive, toRaw, onMounted } from "vue";
import InputText from "primevue/inputtext";
import Button from "primevue/button";
import store from "@/store";
import router from "@/router";
import { DO_LOGIN } from "@/store/actions";

const user = reactive({
  login: "",
  password: "",
});

const onSubmit = () => {
  if (user.login && user.password) {
    debugger;
    store.dispatch(DO_LOGIN, toRaw(user)).then((res) => {
      if (res.message ==  "Sucesso") router.push("/home");
      else if(res.result.httpStatusCode >= 500){
        alert('Estamos com problema.');
      }else{
        alert("Login ou senh errada")
      }
    });
  }
};
</script>

<style scoped>
h2 {
  text-align: center;
}
.btn {
  padding-top: 20px;
}
.logo {
  display: flex;
  justify-content: center;
  align-items: center;
}
.content {
  position: relative;
  height: 100vh; /* Define a altura total da tela */
  background: url("@/assets/images/background.jpg") no-repeat center center
    fixed;
  background-size: cover;
  overflow: hidden;
}
.login-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  border-radius: 30px;
  padding: 0 10px;
}
.login-card {
  width: 400px;
  padding: 2em;
}

@media only screen and (max-width: 600px) {
  .login-card {
    width: 90%;
    max-width: 400px;
  }
  .content {
    background-color: #145ca6;
  }
  .login-container {
    height: 80vh;
  }
}
</style>
