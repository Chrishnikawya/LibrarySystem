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
          <th>Enrollment Date</th>
          <th>Add or Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="staff in staffMembers" :key="staff.StaffID">
          <td>{{ staff.staffID }}</td>
          <td>{{ staff.staffName }}</td>
          <td>{{ staff.staffEmail }}</td>
          <td>{{ staff.enrollmentDate }}</td>
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
          <label for="EnrollmentDate">Enrollment Date:</label>
          <input v-model="currentStaff.EnrollmentDate" type="enrollemntdate" id="EnrolmentDate" required />
          <button type="submit">{{ isEditing ? 'Save Changes' : 'Add Staff Member' }}</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import {Staffs} from "@/services/StaffService";
export default {
  name: 'StaffView',
  data() {
    return {
      staffs: [],
      staff : { 
        staffID : null,
        staffName: "",
        staffEmail :"",
        enrollmentDate :"",
      },
      ErrorList: [],
      ErrorText: "",
      IsSuccess: false,
      showEditPopup: false,
      //currentStaff: { StaffID: null, StaffName: '', StaffEmail: '', StaffPhoneNumber: '' },
      isEditing: false
    };
  },
  created: async function () {
    await this.getStaffs();
   }, 
  methods: {
    //Get Staffs
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
      this.currentStaff = { StaffID: null, StaffName: '',StaffEmail: '', StaffPhoneNumber: '' };
      this.isEditing = false;
      this.showEditPopup = true;
    },
    //Open Edit Popup
    openEditPopup(staff) {
      this.currentStaff = { ...staff };
      this.isEditing = true;
      this.showEditPopup = true;
    },
    //Close Edit Popup
    closeEditPopup() {
      this.showEditPopup = false;
      this.currentStaff = { StaffID: null, StaffName: '', StaffPosition: '', StaffEmail: '', StaffPhoneNumber: '' };
    },
   //Add Staff
    async addStaff() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await Staffs.CreateStaff(this.staff);
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
    //Edit Staff
    async editStaff() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await Staffs.UpdateStaff(this.staff);
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
    //remove Staff
    async removeStaff(staffId) {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await Staffs.DeleteStaff(staffId);
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

