module.exports = {
  devServer: {
    proxy: {
      '^/api': {
        target: 'https://localhost:44315/',
		pathRewrite: {'^/api': '/api'},
        changeOrigin: true,
      },
    }
  }
}