import axios from "axios";
import { MainURL } from "@/services/ApiURL";

axios.defaults.headers.common["Authorization"] = "Bearer " + "";

export class Staffs {
  static url = MainURL.mainUrl + "Staff/";

  static GetAllStaffss() {
    let dataUrl = this.url;
    return axios.get(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static GetStaff(id) {
    let dataUrl = this.url + id;
    return axios.get(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static CreateStaff(obj) {
    let dataUrl = this.url;
    return axios.post(dataUrl, obj, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static UpdateStaff(obj) {
    let dataUrl = this.url + obj.StaffID;
    return axios.put(dataUrl, obj, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static DeleteStaff(id) {
    let dataUrl = this.url + id;
    return axios.delete(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }
}
