<template>
  <div>
    <h1>Sign Up</h1>
    <form @submit.prevent="signup">
      <div>
        <label for="name">Name:</label>
        <input type="text" v-model="name" required>
      </div>
      <div>
        <label for="email">Email:</label>
        <input type="email" v-model="email" required>
      </div>
      <div>
        <label for="password">Password:</label>
        <input type="password" v-model="password" required>
      </div>
      <button type="submit">Sign Up</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      name: '',
      email: '',
      password: ''
    }
  },
  methods: {
    signup() {
      // Handle signup logic here
      console.log('Name:', this.name, 'Email:', this.email, 'Password:', this.password);
    }
  }
}
</script>

<style scoped>
</style>
