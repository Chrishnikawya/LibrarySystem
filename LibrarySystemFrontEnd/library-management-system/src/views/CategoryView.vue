<template>
  <div class="category">
    <h1>Categorys</h1>

    <button @click="openAddPopup">Add New Category</button>

    <table>
      <thead>
        <tr>
          <th>Category Name</th>
          <th>Add or Edit</th>


        </tr>
      </thead>
      <tbody>
        <tr v-for="category in categorys" :key="category.categoryID">
          <td>{{ category.categoryName }}</td>
          <td>
            <button @click="openPopup(category)">Edit</button>
            <button @click="removeCategory(category.categoryID)">Remove</button>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-if="showPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closePopup">&times;</span>
        <h3>{{ isEditing ? "Edit Category" : "Add New Category" }}</h3>
        <form @submit.prevent=" isEditing? editCategory():addCategory()">
          <label for="CategoryName">Category Name:</label>
          <input
            v-model="category.categoryName"
            type="text"
            id="categoryName"
            required
          />
          <div class="form-buttons">
            <button type="submit">
              {{ isEditing ? "Save Changes" : "Add Category" }}
            </button>
            <button type="button" @click="closePopup">Cancel</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { Categorys } from "@/services/CategoryService";
export default {
  name: "CategoryView",
  data() {
    return {
      categorys: [],
      category: {
        categoryID: null,
        categoryName: "",
      },
      ErrorList: [],
      ErrorText: "",
      IsSuccess: false,
      showPopup: false,
      isEditing: false,
    };
  },
  created: async function () {
    await this.getCategorys();
  },

  methods: {
    //Get Categorys
    async getCategorys() {
      try {
        let response = await Categorys.GetAllCategorys();
        this.categorys = response.data;
      } catch (error) {
        console.log(error);
      }
    },
    //Open Popup
    openAddPopup() {
      this.isEditing = false;
      this.showPopup = true;
    },

    //Open Popup
    openPopup(category) {
      this.category = { ...category };
      this.isEditing = true;
      this.showPopup = true;
    },
    //close popup
    closePopup() {
      this.showPopup = false;
      this.category = {
        categoryID: null,
        categoryName: "",
      };
      this.getCategorys();
    },
    // Add Categorys
    async addCategory() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        this.category.categoryID = 0;
        let response = await Categorys.CreateCategory(this.category);
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
    // Edit Categorys
    async editCategory() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await Categorys.UpdateCategory(this.category);
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
    //Remove Categorys
    async removeCategory(categoryId) {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await Categorys.DeleteCategory(categoryId);
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

