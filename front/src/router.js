import { createWebHashHistory, createRouter } from "vue-router";
import store from "./store"; 
import DefaultLayout from '@/layouts/DefaultLayout.vue';
import Home from '@/pages/Home.vue';
import Calendar from "@/pages/Calendar.vue";
import Phonebook from "@/pages/Phonebook.vue";
import Login from '@/pages/Login.vue';

const routes = [
    {
        path: "/",
        name: "/",
        meta: { description: 'Calendario', requiresAuth: true, grantAll: true },
        component: DefaultLayout,
        children: [
            { path: "/home", name: "home", component: Home, meta: { description: 'Home', requiresAuth: false, grantAll: false } },
            { path: "/Phonebook", name: "Phonebook", component: Phonebook, meta: { description: 'Contatos', requiresAuth: true, grantAll: true } },
            { path: "/Calendar", name: "Calendar", component: Calendar, meta: { description: 'Calendario', requiresAuth: true, grantAll: true } },
        ],
    },
    {
        path: "/login",
        name: "login",
        component: Login,
        meta: { description: 'Login', requiresAuth: false, grantAll: false },
    },
];

const router = createRouter({
    history: createWebHashHistory(),
    routes,
});

router.beforeEach((to, from, next) => {
    if (to.matched.some((record) => record.meta.requiresAuth) && !store.getters.isAuthenticated) {
        next({ name: "login" });
    } else {
        next();
    }
});

export default router;
