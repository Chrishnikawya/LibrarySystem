<template>
  <div>
    <NavBar />
    <div class="author">
      <h1>Authors</h1>

      <button @click="openAddPopup">Add New Author</button>

      <table>
        <thead>
          <tr>
            <th>Author Name</th>
            <th>Author Address</th>
            <th>Author Email</th>
            <th>Author PhoneNumber</th>
            <th>Add or Edit</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="author in authors" :key="author.authorID">
            <td>{{ author.authorName }}</td>
            <td>{{ author.authorAddress }}</td>
            <td>{{ author.authorEmail }}</td>
            <td>{{ author.authorPhoneNumber }}</td>
            <td>
              <button @click="openPopup(author)" title="Edit">
                <i class="fas fa-edit" style="color: blue; font-size: 20px;"></i>
              </button>
              
              <button @click="removeAuthor(author.authorID)" title="Remove">
                <i class="fas fa-trash" style="color: white; font-size: 20px;"></i>
              </button>
            </td>
          </tr>
        </tbody>
      </table>

      <div v-if="showPopup" class="modal">
        <div class="modal-content">
          <span class="close" @click="closePopup">&times;</span>
          <h3>{{ isEditing ? "Edit Author" : "Add New Author" }}</h3>
          <form @submit.prevent="isEditing ? editAuthor() : addAuthor()">
            <label for="AuthorName">Author Name:</label>
            <input
              v-model="author.authorName"
              type="text"
              id="authorName"
              required
            />
            <label for="AuthorAddress">Author Address:</label>
            <input
              v-model="author.authorAddress"
              type="text"
              id="authorAddress"
              required
            />
            <label for="AuthorEmail">Author Email:</label>
            <input
              v-model="author.authorEmail"
              type="email"
              id="authorEmail"
              required
            />
            <label for="AuthorPhoneNumber">Author PhoneNumber:</label>
            <input
              v-model="author.authorPhoneNumber"
              type="text"
              id="authorPhoneNumber"
              required
            />
            <div class="form-buttons">
              <button type="submit">
                {{ isEditing ? "Save Changes" : "Add Author" }}
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
import { Authors } from "@/services/AuthorService";
export default {
  name: "AuthorView",
  components: { NavBar },
  data() {
    return {
      authors: [],
      author: {
        authorID: null,
        authorName: "",
        authorAddress: "",
        authorEmail: "",
        authorPhoneNumber: "",
      },
      ErrorList: [],
      ErrorText: "",
      IsSuccess: false,
      showPopup: false,
      isEditing: false,
    };
  },
  created: async function () {
    await this.getAuthors();
  },
  methods: {
  //get method
    async getAuthors() {
      try {
        let response = await Authors.GetAllAuthors();
        this.authors = response.data;
      } catch (error) {
        console.log(error);
      }
    },
    openAddPopup() {
      this.isEditing = false;
      this.showPopup = true;
    },
    openPopup(author) {
      this.author = { ...author };
      this.isEditing = true;
      this.showPopup = true;
    },
    closePopup() {
      this.showPopup = false;
      this.author = {
        authorID: null,
        authorName: "",
        authorAddress: "",
        authorEmail: "",
      };
      this.getAuthors();
    },
    //Add Method
    async addAuthor() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        this.author.authorID = 0;
        let response = await Authors.CreateAuthor(this.author);
        if (response.data.IsSuccess) {
          this.IsSuccess = true;
        } else {
          this.ErrorText = response.data.message || "";
          this.ErrorList = response.data.error || [];
        }
      } catch (error) {
        console.log(error);
      }
      this.closePopup();
    },
    //Edit Method
    async editAuthor() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await Authors.UpdateAuthor(this.author);
        if (response.data.IsSuccess) {
          this.IsSuccess = true;
        } else {
          this.ErrorText = response.data.message || "";
          this.ErrorList = response.data.error || [];
        }
      } catch (error) {
        console.log(error);
      }
      this.closePopup();
    },
    //Remove Method
    async removeAuthor(authorId) {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await Authors.DeleteAuthor(authorId);
        if (response.data.IsSuccess) {
          this.IsSuccess = true;
        } else {
          this.ErrorText = response.data.message || "";
          this.ErrorList = response.data.error || [];
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

