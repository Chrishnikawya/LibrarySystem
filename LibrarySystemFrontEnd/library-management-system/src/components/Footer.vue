<template>
  <footer>
    <div class="footer-container">
      <div class="footer-item logo">
        <h2 class="icon"></h2><b><sup>LIBRARY</sup>LOGIX</b>
        <img src="@/assets/lib.jpeg" alt="Library Image" class="library-image" />
      </div>
      
      <div class="footer-item">
        <h2>OUR SERVICES</h2>
        <ul>
          <li>Borrowing and Circulation Services</li>
          <li>Reference and Research Assistance</li>
          <li>Access to Digital Resources</li>
          <li>Online Access</li>
          <li>Accessibility Services</li>
          <li>Catalog Management</li>
          <li>Circulation Management</li>
          <li>Self Management</li>
          <li>Fee Management</li>
          <li>Membership Management</li>
        </ul>
      </div>

      <div class="footer-item">
        <h2>QUICK LINKS</h2>
        <ul>
          <li><router-link to="/home">Home</router-link></li>
          <li><router-link to="/book">Book</router-link></li>
          <li><router-link to="/author">Author</router-link></li>
          <li><router-link to="/publisher">Publisher</router-link></li>
          <li><router-link to="/member">Member</router-link></li>
          <li><router-link to="/staff">Staff</router-link></li>
          <li><router-link to="/reservation">Reservation</router-link></li>
          <li><router-link to="/category">Category</router-link></li>
        </ul>
      </div>

      <div class="footer-item">
        <h2>CONTACT US</h2>
        <p><b>Phone:</b> 0117234449 / 0117234458</p>
        <p><b>Email:</b> <a href="mailto:info@librologix.com">info@librologix.com</a></p>
        <p><b>Fax:</b> 0117234449 / 011723447</p>
        <p><b>Address:</b></p>
        <p>
          NO.200/B/1, <br> Galle Road, <br> Bambalapitiya
        </p>
      </div>
    </div>
    <p class="footer-end">&copy; 2024 LibroLogix. All rights reserved.</p>
  </footer>
</template>

<script>
export default {
  name: 'AppFooter',
  methods: {
    logout() {
      localStorage.clear();
      this.$router.push({ name: 'Login' });
    },
  },
};
</script>

<style scoped>
footer {
  background-color: #333;
  color: #fff;
  padding: 40px 20px;
  position: relative;
}

.footer-container {
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
  max-width: 1200px;
  margin: 0 auto;
  gap: 20px;
}

.footer-item {
  flex: 1;
  min-width: 250px;
  margin-bottom: 20px;
}

.footer-item h2 {
  font-size: 18px;
  margin-bottom: 15px;
  color: #f4f4f4;
  border-bottom: 2px solid #fff;
  padding-bottom: 10px;
}

.footer-item ul {
  list-style: none;
  padding: 0;
}

.footer-item ul li {
  font-size: 14px;
  line-height: 1.8;
  color: #ccc;
  margin-bottom: 8px;
}

.footer-item p {
  font-size: 14px;
  line-height: 1.8;
  color: #ccc;
}

.footer-item a {
  color: #f4f4f4;
  text-decoration: none;
}

.footer-item a:hover {
  text-decoration: underline;
}

.library-image {
  width: 150px;
  height: auto;
  margin-top: 10px;
}

.logo {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.footer-end {
  text-align: center;
  margin-top: 30px;
  font-size: 14px;
  color: #ccc;
  border-top: 1px solid #555;
  padding-top: 20px;
}

.footer-item ul li {
  display: block;
  margin: 5px 0;
}

.footer-item ul {
  display: flex;
  flex-direction: column;
}

.footer-item ul li,
.footer-item p {
  font-size: 14px;
  line-height: 1.8;
  margin-bottom: 10px;
}

.footer-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
}

.footer-item {
  flex: none;
  width: 100%;
  max-width: 350px;
}
</style>
