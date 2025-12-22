import { TOKEN, USER } from "../constants/auth";
import type { User } from "../types/index.ts";

export const useAuth = () => {
  const token = localStorage.getItem(TOKEN);
  const userStr = localStorage.getItem(USER);

  const user: User | null = userStr ? JSON.parse(userStr) : null;

  const isLoggedIn = Boolean(token);

  return { token, user, isLoggedIn };
};
