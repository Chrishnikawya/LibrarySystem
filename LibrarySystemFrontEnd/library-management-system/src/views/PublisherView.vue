<template>
  <div class="publisher">
    <h1>Publishers</h1>

    <button @click="openAddPopup">Add Publisher</button>

    <table>
      <thead>
        <tr>
          <th>Publisher ID</th>
          <th>Publisher Name</th>
          <th>Publisher Address</th>
          <th>Publisher Email</th>
          <th>Publisher Phone Number</th>
          <th>Add or Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="publisher in publishers" :key="publisher.PublisherID">
          <td>{{ publisher.PublisherID }}</td>
          <td>{{ publisher.PublisherName }}</td>
          <td>{{ publisher.PublisherAddress }}</td>
          <td>{{ publisher.PublisherEmail }}</td>
          <td>{{ publisher.PublisherPhoneNumber }}</td>
          <td>
            <button @click="openEditPopup(publisher)">Edit</button>
            <button @click="removePublisher(publisher.PublisherID)">Remove</button>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-if="showPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closePopup">&times;</span>
        <h3>Publisher Details</h3>
        <p><strong>Publisher ID:</strong> {{ selectedPublisher.PublisherID }}</p>
        <p><strong>Publisher Name:</strong> {{ selectedPublisher.PublisherName }}</p>
        <p><strong>Publisher Address:</strong> {{ selectedPublisher.PublisherAddress }}</p>
        <p><strong>Publisher Email:</strong> {{ selectedPublisher.PublisherEmail }}</p>
        <p><strong>Publisher Phone Number:</strong> {{ selectedPublisher.PublisherPhoneNumber }}</p>
      </div>
    </div>

    <div v-if="showEditPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closeEditPopup">&times;</span>
        <h3>{{ isEditing ? 'Edit Publisher' : 'Add New Publisher' }}</h3>
        <form @submit.prevent="savePublisher">
          <label for="PublisherName">Publisher Name:</label>
          <input v-model="currentPublisher.PublisherName" type="text" id="PublisherName" required />
          <label for="PublisherAddress">Publisher Address:</label>
          <input v-model="currentPublisher.PublisherAddress" type="text" id="PublisherAddress" required />
          <label for="PublisherEmail">Publisher Email:</label>
          <input v-model="currentPublisher.PublisherEmail" type="email" id="PublisherEmail" required />
          <label for="PublisherPhoneNumber">Publisher Phone Number:</label>
          <input v-model="currentPublisher.PublisherPhoneNumber" type="text" id="PublisherPhoneNumber" required />
          <button type="submit">{{ isEditing ? 'Save Changes' : 'Add Publisher' }}</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'PublisherView',
  data() {
    return {
      publishers: [
        { PublisherID: 1, PublisherName: 'Godage', PublisherAddress: '123 Main Street', PublisherEmail: 'Godage@gmail.com', PublisherPhoneNumber: '1234567890' },
        { PublisherID: 2, PublisherName: 'Sarasavi', PublisherAddress: '456 main Street', PublisherEmail: 'sarasavi@gmail.com', PublisherPhoneNumber: '9876543210' },
      ],
      showPopup: false,
      showEditPopup: false,
      selectedPublisher: null,
      currentPublisher: { PublisherID: null, PublisherName: '', PublisherAddress: '', PublisherEmail: '', PublisherPhoneNumber: '' },
      isEditing: false
    };
  },
  methods: {
    openPopup(publisher) {
      this.selectedPublisher = publisher;
      this.showPopup = true;
    },
    closePopup() {
      this.showPopup = false;
      this.selectedPublisher = null;
    },
    openAddPopup() {
      this.currentPublisher = { PublisherID: null, PublisherName: '', PublisherAddress: '', PublisherEmail: '', PublisherPhoneNumber: '' };
      this.isEditing = false;
      this.showEditPopup = true;
    },
    openEditPopup(publisher) {
      this.currentPublisher = { ...publisher };
      this.isEditing = true;
      this.showEditPopup = true;
    },
    closeEditPopup() {
      this.showEditPopup = false;
      this.currentPublisher = { PublisherID: null, PublisherName: '', PublisherAddress: '', PublisherEmail: '', PublisherPhoneNumber: '' };
    },
    savePublisher() {
      if (this.isEditing) {
        const index = this.publishers.findIndex(publisher => publisher.PublisherID === this.currentPublisher.PublisherID);
        if (index !== -1) {
          this.$set(this.publishers, index, this.currentPublisher);
        }
      } else {
        const newPublisher = { ...this.currentPublisher, PublisherID: this.publishers.length + 1 };
        this.publishers.push(newPublisher);
      }
      this.closeEditPopup();
    },
    removePublisher(publisherID) {
      this.publishers = this.publishers.filter(publisher => publisher.PublisherID !== publisherID);
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

