<template>
  <div class="reservation">
    <h1>Reservations</h1>

    <button @click="openAddPopup">Add Reservation</button>

    <table>
      <thead>
        <tr>
          <th>Reservation ID</th>
          <th>Member ID</th>
          <th>Book ID</th>
          <th>Reservation Date</th>
          <th>Add or Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="reservation in reservations" :key="reservation.ReservationID">
          <td>{{ reservation.ReservationID }}</td>
          <td>{{ reservation.MemberID }}</td>
          <td>{{ reservation.BookID }}</td>
          <td>{{ reservation.ReservationDate }}</td>
          
          <td>
            <button @click="openEditPopup(reservation)">Edit</button>
            <button @click="removeReservation(reservation.ReservationID)">Remove</button>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-if="showEditPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closeEditPopup">&times;</span>
        <h3>{{ isEditing ? 'Edit Reservation' : 'Add New Reservation' }}</h3>
        <form @submit.prevent="saveReservation">
          <label for="MemberID">Member ID:</label>
          <input v-model="currentReservation.MemberID" type="number" id="MemberID" required />
          <label for="BookID">Book ID:</label>
          <input v-model="currentReservation.BookID" type="number" id="BookID" required />
          <label for="ReservationDate">Reservation Date:</label>
          <input v-model="currentReservation.ReservationDate" type="date" id="ReservationDate" required />
          <button type="submit">{{ isEditing ? 'Save Changes' : 'Add Reservation' }}</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ReservationView',
  data() {
    return {
      reservations: [
        { ReservationID: 1, MemberID: 1, BookID: 101, ReservationDate: '2024-08-01' },
        { ReservationID: 2, MemberID: 2, BookID: 102, ReservationDate: '2024-08-02'},
      ],
      showEditPopup: false,
      currentReservation: { ReservationID: null, MemberID: '', BookID: '', ReservationDate: '' },
      isEditing: false
    };
  },
  methods: {
    openAddPopup() {
      this.currentReservation = { ReservationID: null, MemberID: '', BookID: '', ReservationDate: '' };
      this.isEditing = false;
      this.showEditPopup = true;
    },
    openEditPopup(reservation) {
      this.currentReservation = { ...reservation };
      this.isEditing = true;
      this.showEditPopup = true;
    },
    closeEditPopup() {
      this.showEditPopup = false;
      this.currentReservation = { ReservationID: null, MemberID: '', BookID: '', ReservationDate: '' };
    },
    saveReservation() {
      if (this.isEditing) {
        const index = this.reservations.findIndex(reservation => reservation.ReservationID === this.currentReservation.ReservationID);
        if (index !== -1) {
          this.$set(this.reservations, index, this.currentReservation);
        }
      } else {
        const newReservation = { ...this.currentReservation, ReservationID: this.reservations.length + 1 };
        this.reservations.push(newReservation);
      }
      this.closeEditPopup();
    },
    removeReservation(reservationID) {
      this.reservations = this.reservations.filter(reservation => reservation.ReservationID !== reservationID);
    }
  }
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

th, td {
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
