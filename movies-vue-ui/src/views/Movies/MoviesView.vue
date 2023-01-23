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

<script src="./MoviesView.ts"/>

<style scoped src="./MoviesView.css" />
