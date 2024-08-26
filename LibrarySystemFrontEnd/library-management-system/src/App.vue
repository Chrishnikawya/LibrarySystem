<template>
  <div id="app">
    <nav>
      <router-link to="/">Home</router-link> |
      <router-link to="/login">Login</router-link> |
      <router-link to="/signup">Signup</router-link>
      <li><router-link to="/book">Book</router-link></li>
        <li><router-link to="/author">Author</router-link></li>
        <li><router-link to="/publisher">Publisher</router-link></li>
        <li><router-link to="/member">Member</router-link></li>
        <li><router-link to="/staff">Staff</router-link></li>
        <li><router-link to="/reservation">Reservation</router-link></li>
    </nav>
    <router-view/>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
nav {
  background-color: #333;
  padding: 10px;
}

ul {
  list-style: none;
  padding: 10;
}

li {
  display: inline;
  margin-right: 10px;
}

a {
  text-decoration: none;
  color: #f3f4f0;
}

a.router-link-active {
  font-weight: bold;
}

.page {
  margin-bottom: 20px;
  }

  .spacer {
  flex-grow: 11; 
}

</style>

