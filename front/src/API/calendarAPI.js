export default ({ instance, baseURL, headers }) => {
    return {
        getCalendarAll() {
            return instance({
                method: 'get',
                baseURL,
                url: 'calendar',
                responseType: 'json',
                headers: headers
            });
        },
        searchCalendar(user) {
            return instance({
                method: 'get',
                baseURL,
                url: 'calendar',
                responseType: 'json',
                headers: headers,
                params: user
            });
        }
    };
};
