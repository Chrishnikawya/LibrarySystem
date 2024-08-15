import axios from "axios";
import { MainURL } from "@/services/ApiURL";

axios.defaults.headers.common["Authorization"] = "Bearer " + "";

export class Books {
  static url = MainURL.mainUrl + "Book/";

  static GetAllBookss() {
    let dataUrl = this.url;
    return axios.get(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static GetBook(id) {
    let dataUrl = this.url + id;
    return axios.get(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static CreateBook(obj) {
    let dataUrl = this.url;
    return axios.post(dataUrl, obj, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static UpdateBook(obj) {
    let dataUrl = this.url + obj.BookID;
    return axios.put(dataUrl, obj, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static DeleteBook(id) {
    let dataUrl = this.url + id;
    return axios.delete(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }
}
