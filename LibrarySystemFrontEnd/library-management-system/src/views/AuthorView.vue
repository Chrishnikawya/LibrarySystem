<template>
  <div class="author">
    <h1>Authors</h1>

    
    <button @click="openAddPopup">Add New Author</button>

    
    <table>
      <thead>
        <tr>
          <th>Author ID</th>
          <th>Author Name</th>
          <th>Author Address</th>
          <th>Author Email</th>
          <th>Add or Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="author in authors" :key="author.AuthorID">
          <td>{{ author.AuthorID }}</td>
          <td>{{ author.AuthorName }}</td>
          <td>{{ author.AuthorAddress }}</td>
          <td>{{ author.AuthorEmail }}</td>
          <td>
            <button @click="openEditPopup(author)">Edit</button>
            <button @click="removeAuthor(author.AuthorID)">Remove</button>
          </td>
        </tr>
      </tbody>
    </table>

   
    <div v-if="showPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closePopup">&times;</span>
        <h3>Author Details</h3>
        <p><strong>Author ID:</strong> {{ selectedAuthor.AuthorID }}</p>
        <p><strong>Author Name:</strong> {{ selectedAuthor.AuthorName }}</p>
        <p><strong>Author Address:</strong> {{ selectedAuthor.AuthorAddress }}</p>
        <p><strong>Author Email:</strong> {{ selectedAuthor.AuthorEmail }}</p>
      </div>
    </div>

   
    <div v-if="showEditPopup" class="modal">
      <div class="modal-content">
        <span class="close" @click="closeEditPopup">&times;</span>
        <h3>{{ isEditing ? 'Edit Author' : 'Add New Author' }}</h3>
        <form @submit.prevent="saveAuthor">
          <label for="AuthorName">Author Name:</label>
          <input v-model="currentAuthor.AuthorName" type="text" id="AuthorName" required />
          <label for="AuthorAddress">Author Address:</label>
          <input v-model="currentAuthor.AuthorAddress" type="text" id="AuthorAddress" required />
          <label for="AuthorEmail">Author Email:</label>
          <input v-model="currentAuthor.AuthorEmail" type="email" id="AuthorEmail" required />
          <button type="submit">{{ isEditing ? 'Save Changes' : 'Add Author' }}</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'AuthorView',
  data() {
    return {
      authors: [
        { AuthorID: 1, AuthorName: 'J.K Rowling', AuthorAddress: 'Silvan Lane', AuthorEmail: 'rowling12@gmail.com' },
        { AuthorID: 2, AuthorName: 'Enid Blyton', AuthorAddress: 'Perera Road', AuthorEmail: 'enid1@gmail.com' },
      ],
      showPopup: false,
      showEditPopup: false,
      selectedAuthor: null,
      currentAuthor: { AuthorID: null, AuthorName: '', AuthorAddress: '', AuthorEmail: '' },
      isEditing: false
    };
  },
  methods: {
    openPopup(author) {
      this.selectedAuthor = author;
      this.showPopup = true;
    },
    closePopup() {
      this.showPopup = false;
      this.selectedAuthor = null;
    },
    openAddPopup() {
      this.currentAuthor = { AuthorID: null, AuthorName: '', AuthorAddress: '', AuthorEmail: '' };
      this.isEditing = false;
      this.showEditPopup = true;
    },
    openEditPopup(author) {
      this.currentAuthor = { ...author };
      this.isEditing = true;
      this.showEditPopup = true;
    },
    closeEditPopup() {
      this.showEditPopup = false;
      this.currentAuthor = { AuthorID: null, AuthorName: '', AuthorAddress: '', AuthorEmail: '' };
    },
    saveAuthor() {
      if (this.isEditing) {
       
        const index = this.authors.findIndex(author => author.AuthorID === this.currentAuthor.AuthorID);
        if (index !== -1) {
          this.$set(this.authors, index, this.currentAuthor);
        }
      } else {
        
        const newAuthor = { ...this.currentAuthor, AuthorID: this.authors.length + 1 };
        this.authors.push(newAuthor);
      }
      this.closeEditPopup();
    },
    removeAuthor(authorID) {
      this.authors = this.authors.filter(author => author.AuthorID !== authorID);
    }
  }
};
</script>

<style scoped>
</style>
