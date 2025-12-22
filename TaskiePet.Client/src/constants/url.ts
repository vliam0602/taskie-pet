// AUTH
const AUTH_BASE = "/auth";

export const AUTH_URL = {
  BASE: AUTH_BASE,
  LOGIN: `${AUTH_BASE}/login`,
  REGISTER: `${AUTH_BASE}/register`,
} as const;

export const HOME_PAGE_URL = {
  HOME: `home`,
};
