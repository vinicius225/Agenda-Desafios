import router from "@/router";
import store from "@/store";
import { DO_LOGOUT } from "@/store/actions";

export const success = (response) => {
    return response;
};

export const error = (res) => {    
    if (res.response != undefined && (res.response.status === 401 || res.response.status === 400)) {
        store.dispatch(DO_LOGOUT);
        router.push({ name: 'login', params: { error: "Sessão expirou" } });
        return { data: { httpStatusCode: 200, message: res.message, result: res.response.data } };
    };

    if (res.code.includes("ERR_")) {
        if (res.response != undefined)
            return { data: { httpStatusCode: res.response.data.httpStatusCode, message: res.response.data.message, result: null } };
        else
            return { data: { httpStatusCode: res.code, message: res.message, result: null } };
    };

    return res;
};