<template>
<div>
<NavBar/>
  <div class="staff">
    <h1>Staff Members</h1>

    <button @click="openAddPopup">Add New Staff</button>

    <table>
      <thead>
        <tr>
          <th>Staff Name</th>
          <th>Staff Email</th>
          <th>Enrollment Date</th>
          <th>Add or Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="staff in staffs" :key="staff.staffID">
          <td>{{ staff.staffName }}</td>
          <td>{{ staff.staffEmail }}</td>
          <td>{{ staff.enrollmentDate }}</td>
           <td>
              <button @click="openPopup(staff)" title="Edit">
                <i class="fas fa-edit" style="color: blue; font-size: 20px;"></i>
              </button>
              
              <button @click="removeStaff(staff.staffID)" title="Remove">
                <i class="fas fa-trash" style="color: white; font-size: 20px;"></i>
              </button>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-if="showPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closePopup">&times;</span>
        <h3>{{ isEditing ? "Edit Staff Member" : "Add New Staff Member" }}</h3>
        <form @submit.prevent=" isEditing? editStaff():addStaff()">
          <label for="StaffName">Staff Name:</label>
          <input
            v-model="staff.staffName"
            type="text"
            id="staffName"
            required
          />
          <label for="StaffEmail">Staff Email:</label>
          <input
            v-model="staff.staffEmail"
            type="email"
            id="staffEmail"
            required
          />
          <label for="EnrollmentDate">Enrollment Date:</label>
          <input
            v-model="staff.enrollmentDate"
            type="date"
            id="enrollmentDate"
            required
          />
          <div class="form-buttons">
            <button type="submit">
              {{ isEditing ? "Save Changes" : "Add Staff" }}
            </button>
            <button type="button" @click="closePopup">Cancel</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import NavBar from "@/components/NavBar.vue";
import { Staffs } from "@/services/StaffService";
export default {
  name: "StaffView",
   components : {NavBar},
  data() {
    return {
      staffs: [],
      staff: {
        staffID: null,
        staffName: "",
        staffEmail: "",
        enrollmentDate: "",
      },
      ErrorList: [],
      ErrorText: "",
      IsSuccess: false,
      showPopup: false,
      //staff: { StaffID: null, StaffName: '', StaffEmail: '', StaffPhoneNumber: '' },
      isEditing: false,
    };
  },
  created: async function () {
    await this.getStaffs();
  },
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
    //Get Staffs
    async getStaffs() {
      try {
        let response = await Staffs.GetAllStaffs();
        this.staffs = response.data.map((staff) => {
          const localDateTime = this.getLocalTime(staff.enrollmentDate);
          return {
            ...staff,
            enrollmentDate: localDateTime,
          };
        });
      } catch (error) {
        console.log(error);
      }
    },
    //Open Add Popup
    openAddPopup() {
      this.showPopup = true;
      this.isEditing = false;
    },
    //Open Popup
    openPopup(staff) {
      this.staff = { ...staff };
      this.isEditing = true;
      this.showPopup = true;
    },
    //Close Popup
    closePopup() {
      this.showPopup = false;
      this.staff = {
        staffID: null,
        staffName: "",
        staffEmail: "",
        enrollmentDate: "",
      };
      this.getStaffs();
    },
    //Add Staff
    async addStaff() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        const utcDate = this.convertToUtc(this.staff.enrollmentDate);
        this.staff.staffID = 0;
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
      this.closePopup();
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
      this.closePopup();
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
      this.closePopup();
    },
  },
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

