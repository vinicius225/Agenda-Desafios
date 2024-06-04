export default ({ instance, baseURL, headers }) => {
    const apiCalls = {
        login(user) {
            return instance({
                method: 'post',
                baseURL,
                url: 'auth',
                responseType: 'json',
                headers: headers,
                data: user,
            });
        },
    }
    return apiCalls;
};