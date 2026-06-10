module.exports = {
  apps: [
    {
      name: "addavargas.me",
      script: "npx",
      args: "serve . -l 4000",
      cwd: "./",
      env: {
        NODE_ENV: "production"
      }
    }
  ]
};
