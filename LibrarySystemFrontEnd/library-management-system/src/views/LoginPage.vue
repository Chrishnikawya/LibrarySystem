<template>
  <div class="login-container">
    <h1>Login</h1>
    <form @submit.prevent="login">
      <div class="form-group">
        <input 
          type="text" 
          v-model="user.username" 
          placeholder="Username" 
          required 
        />
      </div>
      <div class="form-group">
        <input 
          :type="showPassword ? 'text' : 'password'" 
          v-model="user.password" 
          placeholder="Password" 
          required 
        />
      </div>
      <div class="form-group inline-options">
        <label>
          <input 
            type="checkbox" 
            v-model="showPassword" 
          />
          Show Password
        </label>
        <a href="#" class="forgot-password">Forgot Password?</a>
      </div>
      <button type="submit" class="login-btn">LOGIN</button>
    </form>
    <div class="signup-link">
      Don't have an account? <router-link to="/signup">Sign up</router-link>
    </div>
  </div>
</template>

<script>
import { Auth } from "@/services/AuthService";

export default {
  name: "LoginPage",
  data() {
    return {
      user: {
        username: "",
        password: "",
      },
      showPassword: false,
    };
  },
  methods: {
    async login() {
      try {
        const response = await Auth.Login(this.user);
        localStorage.setItem('token', response.token);
        this.$router.push('/home');
      } catch (error) {
        console.error(error);
      }
    },
  },
};
0</script>

<style scoped>
.login-container {
  max-width: 400px;
  margin: 50px auto;
  padding: 30px;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  background-color: white;
  text-align: center;
}

h1 {
  margin-bottom: 20px;
  font-size: 24px;
  color: #333;
}

.form-group {
  margin-bottom: 15px;
}

input[type="text"],
input[type="password"] {
  width: 100%;
  padding: 12px;
  font-size: 14px;
  border-radius: 4px;
  border: 1px solid #ccc;
}

.inline-options {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 15px;
}

label {
  font-size: 12px;
  color: #333;
  margin-right: auto;
}

input[type="checkbox"] {
  margin-right: 5px;
}

.forgot-password {
  font-size: 12px;
  color: #6c63ff;
  text-decoration: none;
  margin-left: auto;
}

.login-btn {
  width: 100%;
  padding: 12px;
  background-color: #4e5bf0;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 16px;
}

.login-btn:hover {
  background-color: #3c4dce;
}

.signup-link {
  margin-top: 10px;
  font-size: 14px;
  color: #333;
}

.signup-link a {
  color: #6c63ff;
  text-decoration: none;
}
</style>
