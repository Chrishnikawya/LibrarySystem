<template>
  <div class="member">
    <h1>Members</h1>

    <button @click="openAddPopup">Add Member</button>

    <table>
      <thead>
        <tr>
          <th>Member ID</th>
          <th>Member Name</th>
          <th>Email</th>
          <th>Phone Number</th>
          <th>Add or Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="member in members" :key="member.MemberID">
          <td>{{ member.MemberID }}</td>
          <td>{{ member.MemberName }}</td>
          <td>{{ member.Email }}</td>
          <td>{{ member.PhoneNumber }}</td>
          <td>
            <button @click="openEditPopup(member)">Edit</button>
            <button @click="removeMember(member.MemberID)">Remove</button>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-if="showPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closePopup">&times;</span>
        <h3>Member Details</h3>
        <p><strong>Member ID:</strong> {{ selectedMember.MemberID }}</p>
        <p><strong>Member Name:</strong> {{ selectedMember.MemberName }}</p>
        <p><strong>Email:</strong> {{ selectedMember.Email }}</p>
        <p><strong>Phone Number:</strong> {{ selectedMember.PhoneNumber }}</p>
      </div>
    </div>

    <div v-if="showEditPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closeEditPopup">&times;</span>
        <h3>{{ isEditing ? 'Edit Member' : 'Add New Member' }}</h3>
        <form @submit.prevent="saveMember">
          <label for="MemberName">Member Name:</label>
          <input v-model="currentMember.MemberName" type="text" id="MemberName" required />
          <label for="Email">Email:</label>
          <input v-model="currentMember.Email" type="email" id="Email" required />
          <label for="PhoneNumber">Phone Number:</label>
          <input v-model="currentMember.PhoneNumber" type="text" id="PhoneNumber" required />
          <button type="submit">{{ isEditing ? 'Save Changes' : 'Add Member' }}</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'MemberView',
  data() {
    return {
      members: [
        { MemberID: 1, MemberName: 'Chrishni', Email: 'chrishni123@gmail.com', PhoneNumber: '1234567890' },
        { MemberID: 2, MemberName: 'Kawya', Email: 'kawya123@gmail.com', PhoneNumber: '0987654321' },
      ],
      showPopup: false,
      showEditPopup: false,
      selectedMember: null,
      currentMember: { MemberID: null, MemberName: '', Email: '', PhoneNumber: '' },
      isEditing: false
    };
  },
  methods: {
    openPopup(member) {
      this.selectedMember = member;
      this.showPopup = true;
    },
    closePopup() {
      this.showPopup = false;
      this.selectedMember = null;
    },
    openAddPopup() {
      this.currentMember = { MemberID: null, MemberName: '', Email: '', PhoneNumber: '' };
      this.isEditing = false;
      this.showEditPopup = true;
    },
    openEditPopup(member) {
      this.currentMember = { ...member };
      this.isEditing = true;
      this.showEditPopup = true;
    },
    closeEditPopup() {
      this.showEditPopup = false;
      this.currentMember = { MemberID: null, MemberName: '', Email: '', PhoneNumber: '' };
    },
    saveMember() {
      if (this.isEditing) {
        const index = this.members.findIndex(member => member.MemberID === this.currentMember.MemberID);
        if (index !== -1) {
          this.$set(this.members, index, this.currentMember);
        }
      } else {
        const newMember = { ...this.currentMember, MemberID: this.members.length + 1 };
        this.members.push(newMember);
      }
      this.closeEditPopup();
    },
    removeMember(memberID) {
      this.members = this.members.filter(member => member.MemberID !== memberID);
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