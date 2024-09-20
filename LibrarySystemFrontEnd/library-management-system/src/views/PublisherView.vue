<template>
<div>
<NavBar/>
  <div class="publisher">
    <h1>Publishers</h1>

    <button @click="openAddPopup">Add Publisher</button>

    <table>
      <thead>
        <tr>
          <th>Publisher Name</th>
          <th>Publisher Address</th>
          <th>Publisher Email</th>
          <th>Publisher PhoneNumber</th>
          <th>Add or Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="publisher in publishers" :key="publisher.publisherID">
          <td>{{ publisher.publisherName }}</td>
          <td>{{ publisher.publisherAddress }}</td>
          <td>{{ publisher.publisherEmail }}</td>
          <td>{{ publisher.publisherPhoneNumber }}</td>
            <td>
              <button @click="openPopup(publisher)" title="Edit">
                <i class="fas fa-edit" style="color: blue; font-size: 20px;"></i>
              </button>
              
              <button @click="removePublisher(publisher.publisherID)" title="Remove">
                <i class="fas fa-trash" style="color: white; font-size: 20px;"></i>
              </button>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-if="showPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closePopup">&times;</span>
        <h3>{{ isEditing ? "Edit Publisher" : "Add New Publisher" }}</h3>
        <form @submit.prevent=" isEditing? editPublisher():addPublisher()">
          <label for="PublisherName">Publisher Name:</label>
          <input
            v-model="publisher.publisherName"
            type="text"
            id="publisherName"
            required
          />
          <label for="PublisherAddress">Publisher Address:</label>
          <input
            v-model="publisher.publisherAddress"
            type="text"
            id="publisherAddress"
            required
          />
          <label for="PublisherEmail">Publisher Email:</label>
          <input
            v-model="publisher.publisherEmail"
            type="email"
            id="publisherEmail"
            required
          />
          <label for="PublisherPhoneNumber">Publisher PhoneNumber:</label>
          <input
            v-model="publisher.publisherPhoneNumber"
            type="text"
            id="publisherPhoneNumber"
            required
          />

          <div class="form-buttons">
            <button type="submit">
              {{ isEditing ? "Save Changes" : "Add Publisher" }}
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
import { Publishers } from "@/services/PublisherService";
export default {
  name: "PublisherView",
   components : {NavBar},
  data() {
    return {
      publishers: [],
      publisher: {
        publisherID: null,
        publisherName: "",
        publisherAddress: "",
        publisherEmail: "",
        PublisherPhoneNumber: "",
      },
      ErrorList: [],
      ErrorText: "",
      IsSuccess: false,
      showPopup: false,
      showPopup: false,
      isEditing: false,
    };
  },
  created: async function () {
    await this.getPublishers();
  },
  methods: {
    //Get Publishers
    async getPublishers() {
      try {
        let response = await Publishers.GetAllPublishers();
        this.publishers = response.data;
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
    openPopup(publisher) {
      this.publisher = { ...publisher };
      this.isEditing = true;
      this.showPopup = true;
    },
    //Close Popup
    closePopup() {
      this.showPopup = false;
      this.publisher = {
        PublisherID: null,
        PublisherName: "",
        PublisherAddress: "",
        PublisherEmail: "",
        PublisherPhoneNumber: "",
      };
      this.getPublishers();
    },
    //Add Publishers
    async addPublisher() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        this.publisher.publisherID = 0;
        let response = await Publishers.CreatePublisher(this.publisher);
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
    //Edit Publishers
    async editPublisher() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await Publishers.UpdatePublisher(this.publisher);
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
    //Remove Publishers
    async removePublisher(publisherId) {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await Publishers.DeletePublisher(publisherId);
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

