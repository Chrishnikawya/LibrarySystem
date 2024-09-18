<template>
    <router-view />
</template>

<script>
export default {
  name: 'App',
  computed: {
    showNavBar() {
      const currentPath = this.$route.path;
      return currentPath !== '/login' && currentPath !== '/signup';
    }
  }
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
