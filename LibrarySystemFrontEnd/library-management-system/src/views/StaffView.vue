<template>
  <div class="staff">
    <h1>Staff Members</h1>

    <button @click="openAddPopup">Add Staff</button>

    <table>
      <thead>
        <tr>
          <th>Staff ID</th>
          <th>Staff Name</th>
          <th>Staff Email</th>
          <th>Staff Phone Number</th>
          <th>Add or Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="staff in staffMembers" :key="staff.StaffID">
          <td>{{ staff.StaffID }}</td>
          <td>{{ staff.StaffName }}</td>
          <td>{{ staff.StaffEmail }}</td>
          <td>{{ staff.StaffPhoneNumber }}</td>
          <td>
            <button @click="openEditPopup(staff)">Edit</button>
            <button @click="removeStaff(staff.StaffID)">Remove</button>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-if="showEditPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closeEditPopup">&times;</span>
        <h3>{{ isEditing ? 'Edit Staff Member' : 'Add New Staff Member' }}</h3>
        <form @submit.prevent="saveStaff">
          <label for="StaffName">Staff Name:</label>
          <input v-model="currentStaff.StaffName" type="text" id="StaffName" required />
          <label for="StaffEmail">Staff Email:</label>
          <input v-model="currentStaff.StaffEmail" type="email" id="StaffEmail" required />
          <label for="StaffPhoneNumber">Staff Phone Number:</label>
          <input v-model="currentStaff.StaffPhoneNumber" type="text" id="StaffPhoneNumber" required />
          <button type="submit">{{ isEditing ? 'Save Changes' : 'Add Staff Member' }}</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'StaffView',
  data() {
    return {
      staffMembers: [
        { StaffID: 1, StaffName: 'John ',  StaffEmail: 'john.@gmail.com', StaffPhoneNumber: '1234567890' },
        { StaffID: 2, StaffName: 'Jane ', StaffEmail: 'jane.@gmail.com', StaffPhoneNumber: '9876543210' },
      ],
      showEditPopup: false,
      currentStaff: { StaffID: null, StaffName: '', StaffEmail: '', StaffPhoneNumber: '' },
      isEditing: false
    };
  },
  methods: {
    openAddPopup() {
      this.currentStaff = { StaffID: null, StaffName: '',StaffEmail: '', StaffPhoneNumber: '' };
      this.isEditing = false;
      this.showEditPopup = true;
    },
    openEditPopup(staff) {
      this.currentStaff = { ...staff };
      this.isEditing = true;
      this.showEditPopup = true;
    },
    closeEditPopup() {
      this.showEditPopup = false;
      this.currentStaff = { StaffID: null, StaffName: '', StaffPosition: '', StaffEmail: '', StaffPhoneNumber: '' };
    },
    saveStaff() {
      if (this.isEditing) {
        const index = this.staffMembers.findIndex(staff => staff.StaffID === this.currentStaff.StaffID);
        if (index !== -1) {
          this.$set(this.staffMembers, index, this.currentStaff);
        }
      } else {
        const newStaff = { ...this.currentStaff, StaffID: this.staffMembers.length + 1 };
        this.staffMembers.push(newStaff);
      }
      this.closeEditPopup();
    },
    removeStaff(staffID) {
      this.staffMembers = this.staffMembers.filter(staff => staff.StaffID !== staffID);
    }
  }
};
</script>

<style scoped>
div {
  padding: 20px;
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

