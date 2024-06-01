import store from "@/store";

export default function useAuthInterceptor(config) {
    if (store.state.auth.token) {
        config.headers['Authorization'] = `Bearer ${store.state.auth.token}`;
    }    
    return config;
}