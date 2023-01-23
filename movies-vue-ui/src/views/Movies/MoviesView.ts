export default {
  name: "MoviesView",
  data() {
    return {
      moviesList: [],
      moviesFetched: false,
      categories: [],
      searchText: "",
    };
  },
  async created() {
    this.moviesList = await this.getMovies();
    this.categories = await this.getCategories();
    this.moviesFetched = true;
  },
  methods: {
    async getMovies() {
      const moviesResponse = await fetch("/movieapi/api/movies");
      return await moviesResponse.json();
    },

    async getCategories() {
      const result = [];
      const categoriesResponse = await fetch("/movieapi/api/categories");
      const categoriesApi = await categoriesResponse.json();
      categoriesApi.forEach((element) => {
        result.push({
          name: element.name,
          checked: false,
        });
      });
      return result;
    },
  },
  computed: {
    filteredMovieList() {
      return this.moviesList.filter((movie) => {
        // movie category is checked or no categories are checked at all
        return (
          (this.categories.some(
            (category) => category.name === movie.category && category.checked
          ) ||
            !this.categories.some((category) => category.checked)) &&
          (movie.title.toLowerCase().includes(this.searchText.toLowerCase()) ||
            this.searchText === "")
        );
      });
    },
  },
};
