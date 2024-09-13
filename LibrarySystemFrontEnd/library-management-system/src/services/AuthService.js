import axios from "axios";
import { MainURL } from "@/services/ApiURL";

axios.defaults.headers.common["Authorization"] = "Bearer " + "";

export class Auth {
    static url = MainURL.mainUrl + "Authenticate/";

    static Login(obj) {
        let dataUrl = this.url +"login/";
        return axios.post(dataUrl,obj, {
          withCredentials: true,
          credentials: "include",
        });
      }

      static Register(obj) {
        let dataUrl = this.url +"register/";
        return axios.post(dataUrl,obj, {
          withCredentials: true,
          credentials: "include",
        });
      }

}
