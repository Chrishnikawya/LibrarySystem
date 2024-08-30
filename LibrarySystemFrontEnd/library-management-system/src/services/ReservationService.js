import axios from "axios";
import { MainURL } from "@/services/ApiURL";

axios.defaults.headers.common["Authorization"] = "Bearer " + "";

export class Resevations {
  static url = MainURL.mainUrl + "Resevation/";

  static GetAllResevations() {
    let dataUrl = this.url;
    return axios.get(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static CreateResevation(obj) {
    let dataUrl = this.url;
    return axios.post(dataUrl, obj, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static UpdateResevation(obj) {
    let dataUrl = this.url + obj.ResevationID;
    return axios.put(dataUrl, obj, {
      withCredentials: true,
      credentials: "include",
    });
  }
  static DeleteResevation(id) {
    let dataUrl = this.url + id;
    return axios.delete(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }
}
