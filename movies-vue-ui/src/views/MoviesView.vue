<template>
  <div class="container" v-if="moviesFetched">
    <div class="row gy-2">
      <div class="col-md-8">
        <div class="d-flex flex-wrap align-items-center">
          <h6 class="mx-1">Filter by category</h6>
          <label v-for="category in categories" :key="category.name" class="mx-1 badge bg-success d-flex align-items-center">
            <input class="me-1" v-bind:id="category.name" type="checkbox" v-model="category.checked" />
            {{category.name}}
          </label>
        </div>
      </div>
      <div class="col-md-4">
        <div class="d-flex">
            <input v-model="searchText" class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
        </div>
      </div>
    </div>
    <div class="mt-3">
      <div class="row gx-3 gy-3">
        <div class="col-xl-3 col-lg-4 col-md-6 col-sm-12" v-for="movie in filteredMovieList" :key="movie.id">
          <div class="card text-light border-success bg-transparent">
            <div class="card-header d-flex justify-content-between">
              <span><i class="fa-solid fa-star"></i> {{movie.rating}}</span>
              <span>{{movie.year}}</span>
            </div>
            <div class="card-body">
              <h5 class="card-title">{{movie.title}}</h5>
              <h6 class="card-subtitle mb-2 text-muted">{{movie.category}}</h6>
              <router-link :to="{name: 'MovieDetails', params: {movieId: movie.id}}" class="btn btn-success btn-sm">More details <i class="fa-solid fa-angle-right"></i></router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div v-if="!moviesFetched">
    <h6>Loading movies...</h6>
  </div>
</template>

<script>
export default {
  name: 'MoviesView',
  data () {
    return {
      moviesList: [],
      moviesFetched: false,
      categories: [],
      searchText: ''
    }
  },
  async created () {
    this.moviesList = await this.getMovies()
    this.categories = await this.getCategories()
    this.moviesFetched = true
  },
  methods: {
    async getMovies () {
      const moviesResponse = await fetch('/movieapi/api/movies')
      return await moviesResponse.json()
    },

    async getCategories () {
      const result = []
      const categoriesResponse = await fetch('/movieapi/api/categories')
      const categoriesApi = await categoriesResponse.json()
      categoriesApi.forEach(element => {
        result.push({
          name: element.name,
          checked: false
        })
      })
      return result
    }
  },
  computed: {
    filteredMovieList () {
      return this.moviesList.filter(movie => {
        // movie category is checked or no categories are checked at all
        return (this.categories.some(category => category.name === movie.category && category.checked) || !(this.categories.some(category => category.checked))) &&
          (movie.title.toLowerCase().includes(this.searchText.toLowerCase()) || this.searchText === '')
      })
    }
  }
}
</script>

<style scoped>
  label {
    cursor: pointer;
  }
</style>
