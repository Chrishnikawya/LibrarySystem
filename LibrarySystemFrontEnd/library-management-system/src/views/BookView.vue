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
          <td>{{ book.BookID }}</td>
          <td>{{ book.BookName }}</td>
          <td>{{ book.Category }}</td>
          <td>{{ book.AuthorID }}</td>
          <td>{{ book.PublisherID }}</td>
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
        <h3>{{ isEditing ? 'Edit Book' : 'Add New Book' }}</h3>
        <form @submit.prevent="saveBook">
          <label for="BookName">Book Name:</label>
          <input v-model="currentBook.BookName" type="text" id="BookName" required />
          <label for="Category">Category:</label>
          <input v-model="currentBook.Category" type="text" id="Category" required />
          <label for="AuthorID">Author ID:</label>
          <input v-model="currentBook.AuthorID" type="number" id="AuthorID" required />
          <label for="PublisherID">Publisher ID:</label>
          <input v-model="currentBook.PublisherID" type="number" id="PublisherID" required />
          <button type="submit">{{ isEditing ? 'Save Changes' : 'Add Book' }}</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'BookView',
  data() {
    return {
      books: [
        { BookID: 1, BookName: 'Harry Potter', Category: 'Fantasy', AuthorID: 1, PublisherID: 1 },
        { BookID: 2, BookName: 'Famous Five', Category: 'Adventure', AuthorID: 3, PublisherID: 2 },
      ],
      showPopup: false,
      showEditPopup: false,
      selectedBook: null,
      currentBook: { BookID: null, BookName: '', Category: '', AuthorID: null, PublisherID: null },
      isEditing: false
    };
  },
  methods: {
    openPopup(book) {
      this.selectedBook = book;
      this.showPopup = true;
    },
    closePopup() {
      this.showPopup = false;
      this.selectedBook = null;
    },
    openAddPopup() {
      this.currentBook = { BookID: null, BookName: '', Category: '', AuthorID: null, PublisherID: null };
      this.isEditing = false;
      this.showEditPopup = true;
    },
    openEditPopup(book) {
      this.currentBook = { ...book };
      this.isEditing = true;
      this.showEditPopup = true;
    },
    closeEditPopup() {
      this.showEditPopup = false;
      this.currentBook = { BookID: null, BookName: '', Category: '', AuthorID: null, PublisherID: null };
    },
    saveBook() {
      if (this.isEditing) {
        const index = this.books.findIndex(book => book.BookID === this.currentBook.BookID);
        if (index !== -1) {
          this.$set(this.books, index, this.currentBook);
        }
      } else {
        const newBook = { ...this.currentBook, BookID: this.books.length + 1 };
        this.books.push(newBook);
      }
      this.closeEditPopup();
    },
    removeBook(bookID) {
      this.books = this.books.filter(book => book.BookID !== bookID);
    }
  }
};
</script>

<style scoped>
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

.modal {
  display: flex;
  justify-content: center;
  align-items: center;
  position: fixed;
  z-index: 1;
  left: 0;
  top: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
}

.modal-content {
  background-color: white;
  padding: 20px;
  border-radius: 4px;
  width: 400px;
}

.close {
  color: red;
  float: right;
  font-size: 28px;
  cursor: pointer;
}

</style>
