<template>
<div>
<NavBar/>
  <div class="member">
    <h1>Members</h1>

    <button @click="openAddPopup">Add New Member</button>

    <table>
      <thead>
        <tr>
          <th>Member Name</th>
          <th>Email</th>
          <th>Phone Number</th>
          <th>Add or Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="member in members" :key="member.memberID">
          <td>{{ member.memberName }}</td>
          <td>{{ member.memberEmail }}</td>
          <td>{{ member.memberPhoneNumber }}</td>
            <td>
              <button @click="openPopup(member)" title="Edit">
                <i class="fas fa-edit" style="color: blue; font-size: 20px;"></i>
              </button>
              
              <button @click="confirmDelete(member.memberID)" title="Remove">
                <i class="fas fa-trash" style="color: white; font-size: 20px;"></i>
              </button>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-if="showPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closePopup">&times;</span>
        <h3>{{ isEditing ? "Edit Member" : "Add New Member" }}</h3>
        <form @submit.prevent=" isEditing? editMember():addMember()">
          <label for="MemberName">Member Name:</label>
          <input
            v-model="member.memberName"
            type="text"
            id="memberName"
            required
          />
          <label for="Email">Email:</label>
          <input
            v-model="member.memberEmail"
            type="email"
            id="memberEmail"
            required
          />
          <label for="PhoneNumber">Phone Number:</label>
          <input
            v-model="member.memberPhoneNumber"
            type="text"
            id="memberPhoneNumber"
            required
          />
          <div class="form-buttons">
            <button type="submit">
              {{ isEditing ? "Save Changes" : "Add Member" }}
            </button>
            <button type="button" @click="closePopup">Cancel</button>
          </div>
        </form>
      </div>
    </div>
    <div v-if="showDeleteConfirm" class="modal"> 
        <div class="modal-content"> 
          <h3>Are you sure you want to delete this member?</h3> 
          <button @click="deleteMember(memberToDelete)">Yes</button> 
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
import { Members } from "@/services/MemberService";
export default {
  name: "MemberView",
   components : {NavBar},
  data() {
    return {
      members: [],
      member: {
        memberID: null,
        memberName: "",
        memberEmail: "",
        memberPhoneNumber: "",
      },
      ErrorList: [],
      ErrorText: "",
      IsSuccess: false,
      showPopup: false,
      isEditing: false,
      showMessageModal: false, 
      messageText: "",  
      showDeleteConfirm: false, 
      memberToDelete: null,
    };
  },
  created: async function () {
    await this.getMembers();
  },
  methods: {
    //Get Members
    async getMembers() {
      try {
        let response = await Members.GetAllMembers();
        this.members = response.data;
      } catch (error) {
        console.log(error);
      }
    },

    //Open Add Popup
    openAddPopup() {
      this.isEditing = false;
      this.showPopup = true;
      
      
    },
    // Open Popup
    openPopup(member) {
      this.member = { ...member };
      this.isEditing = true;
      this.showPopup = true;
    },
    //Close Popup
    closePopup() {
      this.showPopup = false;
      this.member = {
        memberID: null,
        memberName: "",
        memberEmail: "",
        memberPhoneNumber: "",
      };
      this.getMembers();
    },
    //Add Members
    async addMember() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        this.member.memberID = 0;
        let response = await Members.CreateMember(this.member);
        if (response.data.isSuccess) {
          this.isSuccess = true; 
         this.showMessage(response.data.message);
        } else {
            this.ErrorText = response.data.message;
            this.ErrorList = response.data.error; 
               this.showMessage(this.ErrorText);
        }
      } catch (error) {
        console.log(error);
      }
      this.closePopup();
    },
    //Edit Members
    async editMember() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await Members.UpdateMember(this.member);
        if (response.data.isSuccess) {
          this.isSuccess = true;
          this.showMessage(response.data.message);
        } else {
            this.ErrorText = response.data.message;
            this.ErrorList = response.data.error;
               this.showMessage(this.ErrorText);
        }
      } catch (error) {
        console.log(error);
      }
      this.closePopup();
    },
    confirmDelete(memberId) { 
      this.memberToDelete = memberId; 
      this.showDeleteConfirm = true; 
    },
    // Close Delete Confirm Popup
    closeDeleteConfirm() { 
      this.showDeleteConfirm = false; 
      this.memberToDelete = null;
    },
    //Remove Members
    async deleteMember(memberId) {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await Members.DeleteMember(memberId);
        if (response.data.isSuccess) {
          this.isSuccess = true;
          this.showMessage(response.data.message);
          this.messageText = "Member successfully deleted!"; 
          this.showMessageModal = true; 
        } else {
          if (response.data.message != "") 
            this.ErrorText = response.data.message;
            this.ErrorList = response.data.error;
            this.showMessage(this.ErrorText);
        }
      } catch (error) {
        console.log(error);
      }
      this.closeDeleteConfirm(); 
      //this.getMembers(); 
      this.closePopup();
    },
     showMessage(message) {
      this.messageText = message;
      this.showMessageModal = true;
       alert(message);
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