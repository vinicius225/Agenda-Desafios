import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";
import PrimeVue from 'primevue/config';
import 'primeflex/primeflex.css'; 
import 'primevue/resources/themes/saga-blue/theme.css'; 
import 'primevue/resources/primevue.min.css'; 
import 'primeicons/primeicons.css';
import 'primeflex/primeflex.css';                  
import router from "./router";

createApp(App)
.use(router)
.use(PrimeVue)
.mount("#app");
