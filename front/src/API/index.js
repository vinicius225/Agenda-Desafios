import axios from 'axios';
import { ref } from 'vue';
import intimacaoWebApiTokenInterceptor from '@/validations/ApiTokenInterceptor.js';
import { success, error } from './dApiTokenValidateInterceptor';

const instance = axios.create();
const baseURL = ref(process.env.BACK_API).value;
//DEV
const headers = {
  'Content-Type': 'application/json',
  'X-Requested-With': 'XMLHttpRequest',
  'X-XSS-Protection': '1; mode=block',
  'X-Content-Type-Options': 'nosniff',
};


instance.interceptors.request.use(intimacaoWebApiTokenInterceptor);
instance.interceptors.response.use(success, error);

import UserAPI from '@/API/userAPI';

export default {      
    ...UserAPI({ instance, baseURL, headers }),
};
