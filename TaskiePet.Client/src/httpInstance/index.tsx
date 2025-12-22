import axios from "axios";
import { TOKEN } from "../constants/auth";

const HttpInstance = axios.create({
  baseURL: import.meta.env.VITE_API_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

// Add token to header request
HttpInstance.interceptors.request.use((config) => {
  const token = localStorage.getItem(TOKEN);
  if (token) {
    config.headers = config.headers ?? {};
    config.headers.set?.("Authorization", `Bearer ${token}`);
  }
  return config;
});

// Catch global error
HttpInstance.interceptors.response.use(
  (response) => response,
  async (error) => {
    error.message =
      error.response?.data?.message || error.message || "Unknown error";
    return Promise.reject(error);
  }
);

export default HttpInstance;
