import { createStore } from 'vuex';
import auth from './modules/auth';
import createPersistedState from 'vuex-persistedstate';

const debug = process.env.NODE_ENV !== 'production';

const store = createStore({  
  plugins: [createPersistedState({ storage: window.sessionStorage })],
  modules: {auth},
  strict: process.env.NODE_ENV !== 'production'
});

export default store;