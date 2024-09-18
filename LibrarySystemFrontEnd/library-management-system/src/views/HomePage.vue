<template>
<div>
<NavBar/>
  <div class="home-container">
    <h1 class="title">Welcome to the Library Management System!</h1>
    <p class="description">
      Explore our vast collection of books and manage all your library tasks effortlessly.
    </p>
    <div class="image-container">
      <img src="@/assets/lib.jpeg" alt="Library Image" class="library-image" />
    </div>
  </div>
   <Footer />
</div>

</template>

<script>
import NavBar from "@/components/NavBar.vue";
import Footer from "@/components/Footer.vue";
export default {
  name: "HomePage",
  components : {NavBar,Footer},
};
</script>

<style scoped>
.home-container {
  text-align: center;
  padding: 50px;
  background: linear-gradient(135deg, #f2f2f2, #ffffff);
  border-radius: 10px;
  box-shadow: 0 4px 16px rgba(0, 0, 0, 0.1);
  max-width: 800px;
  margin: 50px auto;
  font-family: 'Arial', sans-serif;
}

.title {
  font-size: 3rem;
  color: #333;
  margin-bottom: 20px;
  font-weight: bold;
}

.description {
  font-size: 1.5rem;
  color: #555;
  margin-bottom: 30px;
}

.image-container {
  margin-bottom: 30px;
}

.library-image {
  width: 100%;
  max-width: 500px;
  border-radius: 10px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.2);
}

/* Adjusted media queries for responsiveness */
@media (max-width: 768px) {
  .home-container {
    padding: 20px;
  }

  .title {
    font-size: 2rem;
  }

  .description {
    font-size: 1.25rem;
  }

  .library-image {
    max-width: 100%;
  }
}
</style>
