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

<script src="./MoviesDetailsView.ts" />
<style scoped src="./MovieDetailsView.css"/>
