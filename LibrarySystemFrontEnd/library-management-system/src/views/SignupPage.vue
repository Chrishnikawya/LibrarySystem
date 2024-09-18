<template>
  <div class="signup-container">
    <div class="signup-box">
      <h1>Sign Up</h1>
      <form @submit.prevent="register">
        <div class="form-group">
          <label for="username">Username:</label>
          <input
            id="username"
            name="username"
            type="text"
            v-model="user.username"
            placeholder="Enter your username"
            required
          />
        </div>

        <div class="form-group">
          <label for="email">Email:</label>
          <input
            id="email"
            name="email"
            type="email"
            v-model="user.email"
            placeholder="Enter your email"
            required
          />
        </div>

        <div class="form-group">
          <label for="password">Password:</label>
          <input
            id="password"
            name="password"
            type="password"
            v-model="user.password"
            placeholder="Enter your password"
            required
          />
        </div>

        <button type="submit" class="signup-btn">Sign Up</button>
      </form>
    </div>
  </div>
</template>

<script>
import { Auth } from "@/services/AuthService";

export default {
  name: "SignupPage",
  data() {
    return {
      user: {
        username: "",
        email: "",
        password: "",
      },
      ErrorList: [],
      ErrorText: "",
      IsSuccess: false,
    };
  },
  //handling user registration
  methods: {
    async register() {
      try {
        let response = await Auth.Register(this.user);
        localStorage.setItem("token", response.token);
        this.$router.push("/");
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>

<style scoped>
.signup-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background: linear-gradient(135deg, #f5f7fa, #c3cfe2); /* Light gradient background */
}

.signup-box {
  background: white;
  padding: 40px;
  border-radius: 10px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  max-width: 400px;
  width: 100%;
  text-align: center;
}

.signup-box h1 {
  font-size: 2rem;
  margin-bottom: 20px;
  color: #333;
}

.form-group {
  margin-bottom: 20px;
}

.form-group label {
  display: block;
  font-size: 1rem;
  color: #666;
  margin-bottom: 5px;
}

.form-group input {
  width: 100%;
  padding: 10px;
  border: 1px solid #ddd;
  border-radius: 5px;
  font-size: 1rem;
}

.form-group input:focus {
  border-color: #007bff;
  outline: none;
  box-shadow: 0 0 5px rgba(0, 123, 255, 0.2);
}

.signup-btn {
  background-color: #007bff;
  color: white;
  border: none;
  padding: 12px 20px;
  font-size: 1rem;
  border-radius: 5px;
  cursor: pointer;
  width: 100%;
  margin-top: 10px;
}

.signup-btn:hover {
  background-color: #0056b3;
}
</style>
