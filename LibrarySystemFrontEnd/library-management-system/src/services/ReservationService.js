import axios from "axios";
import { MainURL } from "@/services/ApiURL";

axios.defaults.headers.common["Authorization"] = "Bearer " + "";

export class Reservations {
  static url = MainURL.mainUrl + "Reservation/";

  static GetAllReservations() {
    let dataUrl = this.url;
    return axios.get(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static CreateReservation(obj) {
    let dataUrl = this.url;
    return axios.post(dataUrl, obj, {
      withCredentials: true,
      credentials: "include",
    });
  }

  static UpdateReservation(obj) {
    let dataUrl = this.url ;
    return axios.put(dataUrl, obj, {
      withCredentials: true,
      credentials: "include",
    });
  }
  static DeleteReservation(id) {
    let dataUrl = this.url + id;
    return axios.delete(dataUrl, {
      withCredentials: true,
      credentials: "include",
    });
  }
}
