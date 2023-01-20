<template>
<div class="container">
<div v-if="movieFetched">
  <h1>{{movie.title}} ({{movie.year}})</h1>
  <h5><i class="fa-solid fa-star"></i> {{movie.rating}}</h5>
  <h5 class="mt-5">Description</h5>
  <p>{{movie.description}}</p>
</div>
<div v-if="!movieFetched">
  <h6>Loading movie details...</h6>
</div>
<router-link to="/" class="btn btn-success btn-sm"><i class="fa-solid fa-angle-left"></i> Back to movies</router-link>
</div>
</template>

<script>
export default {
  name: 'MovieDetailsView',
  props: {
    movieId: String
  },
  data () {
    return {
      movie: Object,
      movieFetched: false
    }
  },
  async created () {
    this.movie = await this.getMovieById(this.movieId)
    this.movieFetched = true
  },
  methods: {
    async getMovieById (id) {
      const movieResponse = await fetch('/movieapi/api/movies/' + id)
      return await movieResponse.json()
    }
  }
}
</script>
<style scoped>
 .container{
   text-align: left;
 }
</style>
