import axios from "axios";
import { MainURL } from "@/services/ApiURL";

axios.defaults.headers.common["Authorization"] = "Bearer " + "";

export class Members {
  static url = MainURL.mainUrl + "Member/";

  static GetAllMembers() {
    let dataUrl = this.url;
    return axios.get(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static GetMember(id) {
    let dataUrl = this.url + id;
    return axios.get(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static CreateMember(obj) {
    let dataUrl = this.url;
    return axios.post(dataUrl, obj, {
      withCredentials: true,
      credentials: "include",
    });
  }
  static UpdateMember(obj) {
    let dataUrl = this.url;
    return axios.put(dataUrl, obj, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static DeleteMember(id) {
    let dataUrl = this.url + id;
    return axios.delete(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }
}
