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
        data: calendar,
      });
    },
    putCalendar(calendar) {
      return instance({
        method: "put",
        baseURL,
        url: `calendar/${calendar.id}`,
        responseType: "json",
        headers: headers,
        data: calendar,
      });
    },
    deleteCalendar(id) {
      return instance({
        method: "delete",
        baseURL,
        url: `calendar/${id}`, 
        responseType: "json",
        headers: headers,
      });
    },
  };
};
