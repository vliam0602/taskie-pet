import HttpInstance from "../httpInstance";
import { Configuration } from "../api/generated";
import { AuthApi, DailyTaskApi } from "../api/generated";
import type { ApiResponseOfObject } from "../api/generated/models";

const configuration = new Configuration({
  basePath: import.meta.env.VITE_API_URL,
});

export type ApiResponse<T> = Omit<ApiResponseOfObject, "data"> & {
  data?: T | null;
};

export const authApi = new AuthApi(configuration, undefined, HttpInstance);
export const dailyTaskApi = new DailyTaskApi(
  configuration,
  undefined,
  HttpInstance
);
