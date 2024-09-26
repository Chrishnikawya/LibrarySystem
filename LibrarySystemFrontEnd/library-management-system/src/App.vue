<template>
    <router-view />
</template>

<script>
export default {
  data() {
    return {
     user: null 
    };
  },
  methods: {
  saveData() {
    const data = { username: 'Chrishni', password: '1234' };
    localStorage.setItem('userData', JSON.stringify(data));
  },

  retrieveData() {
    const storedData = localStorage.getItem('userData');
    if (storedData) {
      const parsedData = JSON.parse(storedData);
      console.log(parsedData); 
    }
  }
},
  name: 'App',
  computed: {
    showNavBar() {
      const currentPath = this.$route.path;
      return currentPath !== '/' && currentPath !== '/signup';
    }
  },
  created:function(){
    const userString = sessionStorage.getItem('user');
    if (user)  { 
     this.user = JSON.parse(userString)
     } 

  },
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
