<template>
  <div id="app">
    <nav>
      <router-link to="/">Home</router-link> |
      <router-link to="/login">Login</router-link> |
      <router-link to="/signup">Signup</router-link> |
      <router-link to="/book">Book</router-link> |
      <router-link to="/author">Author</router-link> |
      <router-link to="/publisher">Publisher</router-link> |
      <router-link to="/member">Member</router-link> |
      <router-link to="/staff">Staff</router-link> |
      <router-link to="/reservation">Reservation</router-link> |
      <router-link to="/category">Category</router-link> |
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
  background-color: #05225b;
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

