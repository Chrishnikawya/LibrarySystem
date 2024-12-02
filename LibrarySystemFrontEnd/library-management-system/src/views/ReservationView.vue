<template>
<div>
<NavBar/>
  <div class="reservation">
    <h1>Reservations</h1>

    <button @click="openAddPopup">Add New Reservation</button>

    <table>
      <thead>
        <tr>
          <th>Member Name</th>
          <th>Book Name</th>
          <th>Reservation Date</th>
          <th>Staff Name</th>
          <th>Status</th>
          <th>Add or Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="reservation in reservations"
          :key="reservation.reservationID"
        >
          <td>{{ reservation.memberName }}</td>
          <td>{{ reservation.bookName }}</td>
          <td>{{ reservation.reservationDate }}</td>
          <td>{{ reservation.staffName }}</td>
          <td>{{ reservation.status }}</td>

           <td>
              <button @click="openPopup(reservation)" title="Edit">
                <i class="fas fa-edit" style="color: blue; font-size: 20px;"></i>
              </button>
              
              <button @click="confirmDelete(reservation.reservationID)" title="Remove">
                <i class="fas fa-trash" style="color: white; font-size: 20px;"></i>
              </button>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-if="showPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closePopup">&times;</span>
        <h3>{{ isEditing ? "Edit Reservation" : "Add New Reservation" }}</h3>
        <form
          @submit.prevent="isEditing ? editReservation() : addReservation()"
        >
          <label for="MemberID">Member Name:</label>
          <select v-model="member.memberID" id="memberID" required>
            <option
              v-for="member in members"
              :key="member.memberID"
              :value="member.memberID"
            >
              {{ member.memberName }}
            </option>
          </select>
          <label for="BookID">Book Name:</label>
          <select v-model="book.bookID" id="bookID" required>
            <option
              v-for="book in books"
              :key="book.bookID"
              :value="book.bookID"
            >
              {{ book.bookName }}
            </option>
          </select>
          <label for="ReservationDate">Reservation Date:</label>
          <input
            v-model="reservation.reservationDate"
            type="date"
            id="reservationDate"
            required
          />
          <label for="StaffID">Staff Name:</label>
          <select v-model="staff.staffID" id="staffID" required>
            <option
              v-for="staff in staffs"
              :key="staff.staffID"
              :value="staff.staffID">
              {{ staff.staffName }}
            </option>
          </select>

          <label for="Status">Status:</label>
          <select v-model="reservation.status" id="status" required>
            <option value="Reserved">Reserved</option>
            <option value="Not Reserved">Not Reserved</option>
          </select>
          <div class="form-buttons">
            <button type="submit">
              {{ isEditing ? "Save Changes" : "Add Reservation" }}
            </button>
            <button type="button" @click="closePopup">Cancel</button>
          </div>
        </form>
      </div>
    </div>
    <div v-if="showDeleteConfirm" class="modal"> 
        <div class="modal-content"> 
          <h3>Are you sure you want to delete this Reservation?</h3> 
          <button @click="deleteReservation(reservationToDelete)">Yes</button> 
          <button @click="closeDeleteConfirm">No</button> 
        </div> 
      </div> 
     <div v-if="showMessageModal" class="modal">
        <div class="modal-content message-box">
          <span class="close" @click="closeMessageModal">&times;</span>
          <h3>Message</h3>
          <p>{{ messageText }}</p>
          <button @click="closeMessageModal">OK</button>
        </div>
      </div>
  </div>
  </div>
</template>

<script>
import NavBar from "@/components/NavBar.vue";
import { Reservations } from "@/services/ReservationService";
import { Books } from "@/services/BookService";
import { Members } from "@/services/MemberService";
import { Staffs } from "@/services/StaffService";

export default {
  name: "ReservationView",
   components : {NavBar},
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
        bookName:"",
        memberName:"",
        staffName:""
      },
      books: [],
      book: {
        bookID: null,
        bookName: "",
      },
      staffs: [],
      staff: {
        staffID: null,
        staffName: "",
      },
      members: [],
      member: {
        memberID: null,
        memberName: "",
      },
      ErrorList: [],
      ErrorText: "",
      IsSuccess: false,
      showPopup: false,
      isEditing: false,
      showMessageModal: false, 
      messageText: "",  
      showDeleteConfirm: false, 
      reservationToDelete: null,
    };
  },
  created: async function () {
    await this.getReservationDetails();
    await this.getBooks();
    await this.getMembers();
    await this.getStaffs();
  },
  computed: {},
  methods: {
    //Get the local time
    getLocalTime(utcDate) {
      console.log(utcDate);
      const localDate = new Date(utcDate);
      return localDate.toLocaleDateString();
    },
    // Convert to UTC
    convertToUtc(localDate) {
      const newLocalDate = new Date(localDate);
      return newLocalDate.toISOString();
    },
    //Get Reservations
    async getReservations() {
      try {
        let response = await Reservations.GetAllReservations();
        this.reservations = response.data.map((reservation) => {
          const localDateTime = this.getLocalTime(reservation.reservationDate);
          return {
            ...reservation,
            reservationDate: localDateTime,
          };
        });
      } catch (error) {
        console.log(error);
      }
    },
    //Get ReservationsDetails
    async getReservationDetails() {
      try {
        let response = await Reservations.GetReservationDetails();
        this.reservations = response.data.map((reservation) => {
          const localDateTime = this.getLocalTime(reservation.reservationDate);
          return {
            ...reservation,
            reservationDate: localDateTime,
          };
        });
      } catch (error) {
        console.log(error);
      }
    },
    //Get Books
    async getBooks() {
      try {
        let response = await Books.GetAllBooks();
        this.books = response.data;
      } catch (error) {
        console.log(error);
      }
    },
    //Get Members
    async getMembers() {
      try {
        let response = await Members.GetAllMembers();
        this.members = response.data;
      } catch (error) {
        console.log(error);
      }
    },
    //Get Staff
    async getStaffs() {
      try {
        let response = await Staffs.GetAllStaffs();
        this.staffs = response.data;
      } catch (error) {
        console.log(error);
      }
    },
    //Open Add Popup
    openAddPopup() {
      this.isEditing = false;
      this.showPopup = true;
    },
    //Open Popup
    openPopup(reservation) {
      this.reservation = { ...reservation };
      this.isEditing = true;
      this.showPopup = true;
    },
    //Close Popup
    closePopup() {
      this.showPopup = false;
      this.reservation = {
        reservationID: null,
        memberID: "",
        bookID: "",
        reservationDate: "",
      };
      this.getReservationDetails();
      
    },
    //Add Reservations
    async addReservation() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        const utcDate = this.convertToUtc(this.reservation.reservationDate);
        this.reservation.reservationID = 0;
        this.reservation.bookID = this.book.bookID;
        this.reservation.staffID = this.staff.staffID;
        this.reservation.memberID = this.member.memberID;
        this.reservation.reservationDate = this.utcDate;
        let response = await Reservations.CreateReservation(this.reservation);
        if (response.data.isSuccess) {
          this.isSuccess = true;
          this.showMessage(response.data.message);
        } else {
          //  (response.data.message != "")
            this.ErrorText = response.data.message || "";
            this.ErrorList = response.data.error || [];
               this.showMessage(this.ErrorText);
        }
      } catch (error) {
        console.log(error);
      }
      this.closePopup();
    },
    //Edit Reservations
    async editReservation() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        const utcDate = this.convertToUtc(this.reservation.reservationDate);
        this.reservation.bookID = this.book.bookID;
        this.reservation.staffID = this.staff.staffID;
        this.reservation.memberID = this.member.memberID;
        this.reservation.reservationDate = this.utcDate;
        let response = await Reservations.UpdateReservation(this.reservation);
        if (response.data.isSuccess) {
          this.isSuccess = true;
          this.showMessage(response.data.message); 
        } else { 
            this.ErrorText = response.data.message ||"";
            this.ErrorList = response.data.error ||[];
               this.showMessage(this.ErrorText);
        }
      } catch (error) {
        console.log(error);
      }
      this.getReservations();
      this.closePopup();
    },
    confirmDelete(reservationId) { 
      this.reservationToDelete = reservationId; 
      this.showDeleteConfirm = true; 
    },
    // Close Delete Confirm Popup
    closeDeleteConfirm() { 
      this.showDeleteConfirm = false; 
      this.reservationToDelete = null;
    },
    //Remove Reservations
    async deleteReservation(reservationId) {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        this.reservation.bookID = this.book.bookID;
        this.reservation.staffID = this.staff.staffID;
        this.reservation.memberID = this.member.memberID;
        let response = await Reservations.DeleteReservation(reservationId);
        if (response.data.isSuccess) {
          this.isSuccess = true;
          this.messageText = "Reservation successfully deleted!"; 
          this.showMessageModal = true; 
        } else {
            this.ErrorText = response.data.message  || "";
            this.ErrorList = response.data.error  || [];
          
        }
      } catch (error) {
        console.log(error);
      }
      this.closeDeleteConfirm(); 
      this.closePopup();
    },
     showMessage(message) {
      this.messageText = message;
      this.showMessageModal = true;
    },
    closeMessageModal() {
      this.showMessageModal = false;
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
.form-buttons {
  display: flex;
  justify-content: space-between;
  margin-top: 20px;
}

button[type="submit"] {
  background-color: #28a745;
  color: white;
}

button[type="submit"]:hover {
  background-color: #218838;
}

button[type="button"] {
  background-color: #28a745;
  color: white;
}

button[type="button"]:hover {
  background-color: #218838;
}
</style>
