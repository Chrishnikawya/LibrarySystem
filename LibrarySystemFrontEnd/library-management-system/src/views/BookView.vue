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
        <tr v-for="book in books" :key="book.BookID">
          <td>{{ book.bookID }}</td>
          <td>{{ book.bookName }}</td>
          <td>{{ book.category }}</td>
          <td>{{ book.authorID }}</td>
          <td>{{ book.publisherID }}</td>
          <td>
            <button @click="openEditPopup(book)">Edit</button>
            <button @click="removeBook(book.BookID)">Remove</button>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-if="showPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closePopup">&times;</span>
        <h3>Book Details</h3>
        <p><strong>Book ID:</strong> {{ selectedBook.BookID }}</p>
        <p><strong>Book Name:</strong> {{ selectedBook.BookName }}</p>
        <p><strong>Category:</strong> {{ selectedBook.Category }}</p>
        <p><strong>Author ID:</strong> {{ selectedBook.AuthorID }}</p>
        <p><strong>Publisher ID:</strong> {{ selectedBook.PublisherID }}</p>
      </div>
    </div>

    <div v-if="showEditPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closeEditPopup">&times;</span>
        <h3>{{ isEditing ? "Edit Book" : "Add New Book" }}</h3>
        <form @submit.prevent="saveBook">
          <label for="BookName">Book Name:</label>
          <input v-model="book.BookName" type="text" id="BookName" required />
          <label for="Category">Category:</label>
          <input v-model="book.Category" type="text" id="Category" required />
          <label for="AuthorID">Author ID:</label>
          <input v-model="book.AuthorID" type="number" id="AuthorID" required />
          <label for="PublisherID">Publisher ID:</label>
          <input v-model="book.PublisherID" type="number" id="PublisherID" required/>
          <label for="PublisherID">Book ID:</label>
          <input v-model="book.BookID" type="number" id="BookID" required/>
          <button type="submit">
            {{ isEditing ? "Save Changes" : "Add Book" }}
          </button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { Books } from "@/services/BookService";
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
      ErrorList: [],
      ErrorText: "",
      IsSuccess: false,
      showPopup: false,
      showEditPopup: false,
      selectedBook: null,
      //currentBook: { BookID: null, BookName: '', Category: '', AuthorID: null, PublisherID: null },
      isEditing: false,
    };
  },
  created: async function () {
    await this.getBooks();
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
    //Open Popup
    openPopup(book) {
      this.selectedBook = book;
      this.showPopup = true;
    },
    //Close Popup
    closePopup() {
      this.showPopup = false;
      this.selectedBook = null;
    },
    //Open Add Popup
    openAddPopup() {
      this.book = {
        BookID: null,
        BookName: "",
        Category: "",
        AuthorID: null,
        PublisherID: null,
      };
      this.isEditing = false;
      this.showEditPopup = true;
    },
    //Open Edit popup
    openEditPopup(book) {
      this.book = { ...book };
      this.isEditing = true;
      this.showEditPopup = true;
    },
    //Close Edit Popup
    closeEditPopup() {
      this.showEditPopup = false;
      this.book = {
        BookID: null,
        BookName: "",
        Category: "",
        AuthorID: null,
        PublisherID: null,
      };
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
      this.closeEditPopup();
    },
    // Add Books
    async addBook() {
      this.ErrorText = null;
      this.ErrorList = [];
      try {
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
      this.closeEditPopup();
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
      this.closeEditPopup();
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
button[type="submit"] {
  margin-top: 20px;
  background-color: #28a745;
  color: white;
}
button[type="submit"]:hover {
  background-color: #218838;
}

.page {
  margin-bottom: 20px;
}
</style>