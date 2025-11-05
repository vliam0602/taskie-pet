import api from "../api/axiosInstance";
import type { Weather } from "../App";

export const weatherService = {
  getWeather: async (): Promise<Weather[]> => {
    const response = await api.get<Weather[]>("/weatherforecast");
    return response.data;
  },
};
