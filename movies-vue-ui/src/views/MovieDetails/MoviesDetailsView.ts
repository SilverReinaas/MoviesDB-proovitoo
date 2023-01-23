export default {
  name: "MovieDetailsView",
  props: {
    movieId: String,
  },
  data() {
    return {
      movie: Object,
      movieFetched: false,
    };
  },
  async created() {
    this.movie = await this.getMovieById(this.movieId);
    this.movieFetched = true;
  },
  methods: {
    async getMovieById(id) {
      const movieResponse = await fetch("/movieapi/api/movies/" + id);
      return await movieResponse.json();
    },
  },
};
