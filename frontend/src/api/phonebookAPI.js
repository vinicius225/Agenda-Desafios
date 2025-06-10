export default ({ instance, baseURL, headers }) => {
    return {
      getAllPhonebook() {
        return instance({
          method: "get",
          baseURL,
          url: "phonebook",
          responseType: "json",
          headers: headers,
        });
      },
      searchPhonebook(query) {
        return instance({
          method: "get",
          baseURL,
          url: "phonebook",
          responseType: "json",
          headers: headers,
          params: query,
        });
      },
      addPhonebook(data) {
        return instance({
          method: "post",
          baseURL,
          url: "phonebook",
          responseType: "json",
          headers: headers,
          data: data,
        });
      },
      updatePhonebook(data) {
        return instance({
          method: "put",
          baseURL,
          url: "phonebook",
          responseType: "json",
          headers: headers,
          data: data,
        });
      },
      deletePhonebook(id) {
        return instance({
          method: "delete",
          baseURL,
          url: `phonebook/${id}`,
          responseType: "json",
          headers: headers,
        });
      },
    };
  };
  