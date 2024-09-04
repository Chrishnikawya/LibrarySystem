import axios from "axios";
import { MainURL } from "@/services/ApiURL";

axios.defaults.headers.common["Authorization"] = "Bearer " + "";

export class Categorys {
  static url = MainURL.mainUrl + "Category/";

  static GetAllCategorys() {
    let dataUrl = this.url;
    return axios.get(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static CreateCategory(obj) {
    let dataUrl = this.url;
    return axios.post(dataUrl, obj, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static UpdateCategory(obj) {
    let dataUrl = this.url;
    return axios.put(dataUrl, obj, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static DeleteCategory(id) {
    let dataUrl = this.url + id;
    return axios.delete(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }
}
