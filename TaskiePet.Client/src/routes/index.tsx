import { createBrowserRouter } from "react-router-dom";
import AuthRedirect from "./auth-redirect.tsx";
import { AUTH_URL, HOME_PAGE_URL } from "../constants/url.ts";
import LoginPage from "../pages/LoginPage.tsx";

const Router = createBrowserRouter([
  {
    path: "/",
    Component: AuthRedirect,
  },
  {
    path: AUTH_URL.BASE,
    children: [
      { index: true, Component: LoginPage },
      { path: AUTH_URL.LOGIN, Component: LoginPage },
      { path: AUTH_URL.REGISTER, Component: LoginPage },
    ],
  },
  {
    path: HOME_PAGE_URL.HOME,
    Component: AuthRedirect,
  },
]);

export default Router;
