import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:44384",
});

export default api;
