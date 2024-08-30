<template>
  <div>
    <h1>Sign Up</h1>
    <form @submit.prevent="signup">
      <div>
        <label for="name">Name:</label>
        <input type="text" v-model="name" required />
      </div>
      <div>
        <label for="email">Email:</label>
        <input type="email" v-model="email" required />
      </div>
      <div>
        <label for="password">Password:</label>
        <input type="password" v-model="password" required />
      </div>
      <button type="submit">Sign Up</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      name: "",
      email: "",
      password: "",
    };
  },
  methods: {
    signup() {
      console.log(
        "Name:",
        this.name,
        "Email:",
        this.email,
        "Password:",
        this.password
      );
    },
  },
};
</script>

<style scoped>
nav {
  background-color: #333;
  padding: 10px;
}

ul {
  list-style: none;
  padding: 0;
  margin: 0;
  display: flex;
  align-items: center;
}

li {
  margin-right: 200px;
}

a {
  text-decoration: none;
  color: white;
}

a.router-link-active {
  font-weight: bold;
}
</style>
