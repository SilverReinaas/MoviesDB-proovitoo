
module.exports = {
  transpileDependencies: true,
  devServer:{
    port:8080,
    proxy: {
        '^/movieapi': {
            target:"http://localhost:28373",            
            changeOrigin: true,
            pathRewrite: { "^/movieapi": "/"},
            logLevel: "debug"
        }
    }
  }
}
