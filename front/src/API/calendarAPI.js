export default ({ instance, baseURL, headers }) => {
  return {
    getCalendarAll() {
      return instance({
        method: "get",
        baseURL,
        url: "calendar",
        responseType: "json",
        headers: headers,
      });
    },
    searchCalendar(calendar) {
      return instance({
        method: "get",
        baseURL,
        url: "calendar",
        responseType: "json",
        headers: headers,
        params: calendar,
      });
    },
    addCalendar(calendar) {
      return instance({
        method: "post",
        baseURL,
        url: "calendar",
        responseType: "json",
        headers: headers,
        params: calendar,
      });
    },
    putCalendar(calendar) {
      return instance({
        method: "put",
        baseURL,
        url: "calendar",
        responseType: "json",
        headers: headers,
        params: calendar,
      });
    },
    deleteCalendar(calendar) {
      return instance({
        method: "delete",
        baseURL,
        url: "calendar",
        responseType: "json",
        headers: headers,
        params: calendar,
      });
    },
  };
};
