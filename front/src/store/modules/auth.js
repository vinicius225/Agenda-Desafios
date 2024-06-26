import { ref } from 'vue';
import { DO_LOGIN, DO_LOGOUT } from '@/store/actions';
import { SET_AUTH} from '@/store/mutations';
import WebApi from "@/api";

export default {
    state: {
        user: {
            id: null,
            login: null,
            name: null
        },
        token: null
    },
    getters: {
        isAuthenticated(state){
            return !!state.token;
        },
        getUser(state) {
            return state.user;
        },
    },
    actions: {
		[DO_LOGIN]({ commit }, payload) {            
            return new Promise((resolve, reject) => {
                WebApi.login(payload)
                    .then(res => {                        
                        if (res.data.httpStatusCode === 200) {
                            commit(SET_AUTH, res.data.result);
                            resolve(res.data);
                        } else {
                            reject(res.data.message);
                        }
                    })
                    .catch(erro => {
                        reject(erro);                        
                    });
            })
        },
        [DO_LOGOUT]({ commit }) {            
            return new Promise((resolve) => {                
                commit(SET_AUTH, {
                    id: null,
                    login: null,
                    name: null,
                    token: null
                }),
                resolve({
                    id: null,
                    login: null,
                    name: null
                });
            })
        }
    },
    mutations: {
        [SET_AUTH](state, payload) {
            state.user.id = payload.id;
            state.user.login = payload.login;
            state.user.name = payload.name;
            state.token = payload.token;
        },
    }
};