import axios from 'axios';
import { ref } from 'vue';
import intimacaoWebApiTokenInterceptor from '@/validations/ApiTokenInterceptor.js';
import { success, error } from '@/validations/ApiTokenValidateInterceptor.js';

const instance = axios.create();
const baseURL = ref(process.env.BACK_API).value;
const headers = {
  'Content-Type': 'application/json',
  'X-Requested-With': 'XMLHttpRequest',
  'X-XSS-Protection': '1; mode=block',
  'X-Content-Type-Options': 'nosniff',
};


instance.interceptors.request.use(intimacaoWebApiTokenInterceptor);
instance.interceptors.response.use(success, error);

import UserAPI from '@/api/userAPI';
import CalendarAPI from '@/api/calendarAPI';

export default {      
    ...UserAPI({ instance, baseURL, headers }),
    ...CalendarAPI({ instance, baseURL, headers }),
};
