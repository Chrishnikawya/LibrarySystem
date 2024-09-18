<template>
  <div id="app">
    <nav>
      <ul class="nav-links">
        <li><router-link to="/home">Home</router-link></li>
        <li><router-link to="/book">Book</router-link></li>
        <li><router-link to="/author">Author</router-link></li>
        <li><router-link to="/publisher">Publisher</router-link></li>
        <li><router-link to="/member">Member</router-link></li>
        <li><router-link to="/staff">Staff</router-link></li>
        <li><router-link to="/reservation">Reservation</router-link></li>
        <li><router-link to="/category">Category</router-link></li>
      </ul>
      <div class="logout">
        <button @click="logout">Logout</button>
      </div>
    </nav>
  </div>
</template>

<script>
export default {
  methods: {
    logout() {
      localStorage.removeItem('token');
      this.$router.push('/');
    }
  },
   mounted() {
    this.username = localStorage.getItem('username') || 'Guest';
  }
}
</script>

<style scoped>
nav {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 10px 20px;
  background-color: #333; 
}

.nav-links {
  display: flex;
  list-style-type: none;
  margin: 0;
  padding: 0;
}

.nav-links li {
  margin-right: 15px;
}

.nav-links a {
  color: white;
  text-decoration: none;
  padding: 5px 10px;
}

.nav-links a:hover {
  background-color: #555; 
  border-radius: 3px;
}

.logout {
  margin-left: auto; 
}

button {
  cursor: pointer;
  background-color: rgb(0, 255, 195); 
  color: white;
  border: none;
  padding: 5px 15px;
  border-radius: 3px; 
  font-size: 16px; 
}

button:hover {
  background-color: rgb(0, 200, 150);
}
</style>
