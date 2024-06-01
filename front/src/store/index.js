import { createStore } from 'vuex';
import auth from './modules/auth';
import access from './modules/access';
import global from './modules/global';
import createPersistedState from 'vuex-persistedstate';

const debug = process.env.NODE_ENV !== 'production';

const store = createStore({  
  plugins: [createPersistedState({ storage: window.sessionStorage })],
  modules: {auth, access, global},
  strict: process.env.NODE_ENV !== 'production'
});

export default store;