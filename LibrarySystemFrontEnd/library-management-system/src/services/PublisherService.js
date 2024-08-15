import axios from "axios";
import { MainURL } from "@/services/ApiURL";

axios.defaults.headers.common["Authorization"] = "Bearer " + "";

export class Publishers {
  static url = MainURL.mainUrl + "Publisher/";

  static GetAllPublishers() {
    let dataUrl = this.url;
    return axios.get(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static GetPublisher(id) {
    let dataUrl = this.url + id;
    return axios.get(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static CreatePublisher(obj) {
    let dataUrl = this.url;
    return axios.post(dataUrl, obj, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static UpdatePublisher(obj) {
    let dataUrl = this.url + obj.PublisherID;
    return axios.put(dataUrl, obj, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static DeletePublisher(id) {
    let dataUrl = this.url + id;
    return axios.delete(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }
}
