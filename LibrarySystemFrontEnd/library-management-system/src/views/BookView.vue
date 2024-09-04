<template>
  <div class="book">
    <h1>Books</h1>

    <button @click="openAddPopup">Add Book</button>

    <table>
      <thead>
        <tr>
          <th>Book ID</th>
          <th>Book Name</th>
          <th>Category</th>
          <th>Author ID</th>
          <th>Publisher ID</th>
          <th>Add or Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="book in books" :key="book.bookID">
          <td>{{ book.bookID }}</td>
          <td>{{ book.bookName }}</td>
          <td>{{ book.category }}</td>
          <td>{{ book.authorID }}</td>
          <td>{{ book.publisherID }}</td>
          <td>
            <button @click="openPopup(book)">Edit</button>
            <button @click="removeBook(book.bookID)">Remove</button>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-if="showPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closePopup">&times;</span>
        <h3>{{ isEditing ? "Edit Book" : "Add New Book" }}</h3>
        <form @submit.prevent="addBook">
          <label for="BookName">Book Name:</label>
          <input v-model="book.bookName" type="text" id="bookName" required />
          <label for="Category">Category:</label>
          <select v-model="book.category" id="category" required>
            <option value="novels">Novels</option>
            <option value="fiction">Fiction</option>
            <option value="non-fiction">Non-Fiction</option>
            <option value="science-fiction">Science Fiction</option>
            <option value="fantasy">Fantasy</option>
            <option value="historical-fiction">Historical Fiction</option>
            <option value="biography">Biography</option>
            <option value="autobiography">Autobiography</option>
            <option value="mystery">Mystery</option>
            <option value="thriller">Thriller</option>
            <option value="romance">Romance</option>
            <option value="horror">Horror</option>
            <option value="self-help">Self-Help</option>
            <option value="philosophy">Philosophy</option>
            <option value="science">Science</option>
            <option value="technology">Technology</option>
            <option value="poetry">Poetry</option>
            <option value="drama">Drama</option>
            <option value="childrens-literature">Children's Literature</option>
            <option value="young-adult">Young Adult</option>
            <option value="travel">Travel</option>
            <option value="cooking">Cooking</option>
            <option value="art">Art</option>
            <option value="graphic-novels">Graphic Novels</option>
            <option value="religious-spiritual">Religious/Spiritual</option>
          </select>
          <label for="AuthorID">Author ID:</label>
          <select v-model="author.authorID" id="authorID" required>
            <option
              v-for="author in authors"
              :key="author.authorID"
              :value="author.authorID"
            >
              {{ author.authorID }}
            </option>
          </select>
          <label for="PublisherID">Publisher ID:</label>
          <select v-model="publisher.publisherID" id="publisherID" required>
            <option
              v-for="publisher in publishers"
              :key="publisher.publisherID"
              :value="publisher.publisherID"
            >
              {{ publisher.publisherID }}
            </option>
          </select>

          <div class="form-buttons">
            <button type="submit">
              {{ isEditing ? "Save Changes" : "Add Book" }}
            </button>
            <button type="button" @click="closePopup">Cancel</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { Books } from "@/services/BookService";
import { Authors } from "@/services/AuthorService";
import { Publishers } from "@/services/PublisherService";
export default {
  name: "BookView",
  data() {
    return {
      books: [],
      book: {
        bookID: null,
        bookName: "",
        category: "",
        authorID: "",
        publisherID: "",
      },
      authors: [],
      author: {
        authorID: null,
        authorName: "",
      },
      publishers: [],
      publisher: {
        publisherID: null,
        publisherName: "",
      },
      ErrorList: [],
      ErrorText: "",
      IsSuccess: false,
      showPopup: false,
      isEditing: false,
    };
  },
  created: async function () {
    await this.getBooks();
    await this.getAuthors();
    await this.getPublishers();
  },
  methods: {
    //Get Books
    async getBooks() {
      try {
        let response = await Books.GetAllBooks();
        this.books = response.data;
      } catch (error) {
        console.log(error);
      }
    },
    //Get Authors
    async getAuthors() {
      try {
        let response = await Authors.GetAllAuthors();
        this.authors = response.data;
      } catch (error) {
        console.log(error);
      }
    },
    //Get Publishers
    async getPublishers() {
      try {
        let response = await Publishers.GetAllPublishers();
        this.publishers = response.data;
      } catch (error) {
        console.log(error);
      }
    },
    //Open Popup
    openAddPopup() {
      this.isEditing = false;
      this.showPopup = true;
    },

    //Open popup
    openPopup(book) {
      this.book = { ...book };
      this.isEditing = true;
      this.showPopup = true;
    },
    //Close  Popup
    closePopup() {
      this.showPopup = false;
      this.book = {
        bookID: null,
        bookName: "",
        category: "",
        authorID: null,
        publisherID: null,
      };
      this.getBooks();
    },
    // Edit Books
    async editBook() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await Books.UpdateBook(this.book);
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
    // Add Books
    async addBook() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        this.book.bookID = 0;
        this.book.authorID = this.author.authorID;
        this.book.publisherID = this.publisher.publisherID;
        let response = await Books.CreateBook(this.book);
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
    // Remove Books
    async removeBook(bookId) {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
        let response = await Books.DeleteBook(bookId);
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

.page {
  margin-bottom: 20px;
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