<template>
  <div class="reservation">
    <h1>Reservations</h1>

    <button @click="openAddPopup">Add Reservation</button>

    <table>
      <thead>
        <tr>
          <th>Reservation ID</th>
          <th>member ID</th>
          <th>Book ID</th>
          <th>Reservation Date</th>
          <th>Staff ID</th>
          <th>Status</th>
          <th>Add or Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="reservation in reservations"
          :key="reservation.ReservationID"
        >
          <td>{{ reservation.reservationID }}</td>
          <td>{{ reservation.memberID }}</td>
          <td>{{ reservation.bookID }}</td>
          <td>{{ reservation.reservationDate }}</td>
          <td>{{ reservation.staffID }}</td>
          <td>{{ reservation.status}}</td>

          <td>
            <button @click="openEditPopup(reservation)">Edit</button>
            <button @click="removeReservation(reservation.ReservationID)">
              Remove
            </button>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-if="showEditPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closeEditPopup">&times;</span>
        <h3>{{ isEditing ? "Edit Reservation" : "Add New Reservation" }}</h3>
        <form @submit.prevent="saveReservation">
          <label for="ReservationID">ReservationID:</label>
          <input v-model="currentReservation.ReservationID" type="number" id="ReservationID" required/>
          <label for="MemberID">Member ID:</label>
          <input  v-model="currentReservation.MemberID" type="number" id="MemberID" required/>
          <label for="BookID">Book ID:</label>
          <input v-model="currentReservation.BookID" type="number" id="BookID" required />
          <label for="ReservationDate">Reservation Date:</label>
          <input v-model="currentReservation.ReservationDate" type="date" id="ReservationDate" required/>
          <label for="StaffID">Staff ID:</label>
          <input v-model="currentReservation.StaffID" type="number" id="StaffID" required/>
          <label for="Status">Status:</label>
          <input  v-model="currentReservation.Status" type="number" id="Status"  required />
          <button type="submit">
            {{ isEditing ? "Save Changes" : "Add Reservation" }}
          </button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { Resevations } from "@/services/ReservationService";
export default {
  name: "ReservationView",
  data() {
    return {
      reservations: [],
      reservation: {
        reservationID: null,
        reservationDate: "",
        status: "",
        memberID: "",
        staffID: "",
        bookID: "",
      },
      ErrorList: [],
      ErrorText: "",
      IsSuccess: false,
      showEditPopup: false,
      //currentReservation: { ReservationID: null, MemberID: '', BookID: '', ReservationDate: '' },
      isEditing: false,
    };
  },
  created: async function () {
    await this.getReservations();
  },
  methods: {
    //Get Reservations
    async getReservations() {
      try {
        let response = await Resevations.GetAllResevations();
        this.resevations = response.data;
      } catch (error) {
        console.log(error);
      }
    },
    //Open Add Popup
    openAddPopup() {
      this.currentReservation = {
        ReservationID: null,
        MemberID: "",
        BookID: "",
        ReservationDate: "",
      };
      this.isEditing = false;
      this.showEditPopup = true;
    },
    //Open Edit Popup
    openEditPopup(reservation) {
      this.currentReservation = { ...reservation };
      this.isEditing = true;
      this.showEditPopup = true;
    },
    //Close Edit Popup
    closeEditPopup() {
      this.showEditPopup = false;
      this.currentReservation = {
        ReservationID: null,
        MemberID: "",
        BookID: "",
        ReservationDate: "",
      };
    },
    //Add Reservations
    async addResevation() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await this.Reservations.CreateReservation(this.resevation);
        if (response.data.IsSuccess) {
          this.IsSuccess = true;
        } else {
          if (response.data.message != "") {
            this.ErrorText = response.data.message;
          } else {
            this.ErrorList = response.data.error;
          }
        }
      } catch (error) {
        console.log(error);
      }
      this.closeEditPopup();
    },
    //Edit Reservations
    async editResevation() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await this.Reservations.UpdateReservation(
          this.resevation
        );
        if (response.data.IsSuccess) {
          this.IsSuccess = true;
        } else {
          if (response.data.message != "") {
            this.ErrorText = response.data.message;
          } else {
            this.ErrorList = response.data.error;
          }
        }
      } catch (error) {
        console.log(error);
      }
      this.closeEditPopup();
    },
    //Remove Reservations
    async removeResevation(resevationId) {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await this.Reservations.CreateReservation(resevationId);
        if (response.data.IsSuccess) {
          this.IsSuccess = true;
        } else {
          if (response.data.message != "") {
            this.ErrorText = response.data.message;
          } else {
            this.ErrorList = response.data.error;
          }
        }
      } catch (error) {
        console.log(error);
      }
      this.closeEditPopup();
    },
  },
};
</script>

<style scoped>
div {
  padding: 10px;
  font-family: Arial, sans-serif;
}
table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
}

th,
td {
  border: 1px solid #ddd;
  padding: 8px;
  text-align: left;
}

th {
  background-color: #f2f2f2;
}

tbody tr {
  cursor: pointer;
}

tbody tr:hover {
  background-color: #f2f2f2;
}

button {
  background-color: #007bff;
  color: white;
  border: none;
  padding: 8px 16px;
  border-radius: 4px;
  cursor: pointer;
  font-size: 14px;
}
button:hover {
  background-color: #0056b3;
}
table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 2px;
}
th {
  background-color: #f9f9f9;
}
.modal {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1000;
}

.modal-content {
  background-color: white;
  padding: 20px;
  border-radius: 4px;
  width: 80%;
  max-width: 500px;
  position: relative;
}

.close {
  position: absolute;
  top: 10px;
  right: 10px;
  font-size: 18px;
  cursor: pointer;
}
.close:hover {
  color: #007bff;
}
form {
  display: flex;
  flex-direction: column;
}
label {
  margin-top: 10px;
}
input {
  padding: 8px;
  margin-top: 4px;
  border: 1px solid #ddd;
  border-radius: 4px;
}
button[type="submit"] {
  margin-top: 20px;
  background-color: #28a745;
  color: white;
}
button[type="submit"]:hover {
  background-color: #218838;
}
</style>
