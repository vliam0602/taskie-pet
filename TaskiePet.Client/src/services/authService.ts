import { authApi } from "../api/apiClient";
import { TOKEN } from "../constants/auth";
import type { LoginRequest, TokenResponse } from "../api/generated";
import type { ApiResponse } from "../api/apiClient";

export const authService = {
  async login(body: LoginRequest): Promise<ApiResponse<TokenResponse>> {
    const res = await authApi.apiAuthLoginPost({ loginRequest: body });
    const payload = res.data as ApiResponse<TokenResponse>;

    if (payload.data?.accessToken) {
      localStorage.setItem(TOKEN, payload.data.accessToken);
    }
    return payload;
  },
  async register(body: LoginRequest): Promise<ApiResponse<string>> {
    const res = await authApi.apiAuthRegisterPost({ loginRequest: body });
    return res.data as ApiResponse<string>;
  },
};
