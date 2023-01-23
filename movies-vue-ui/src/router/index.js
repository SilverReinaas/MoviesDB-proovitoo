import { createRouter, createWebHistory } from 'vue-router'
import MoviesView from '../views/Movies/MoviesView'
import MovieDetailsView from '../views/MovieDetails/MovieDetailsView'

const routes = [
  {
    path: '/',
    name: 'Movies',
    component: MoviesView
  },
  {
    path: '/movie/:movieId',
    name: 'MovieDetails',
    component: MovieDetailsView,
    props: true
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
