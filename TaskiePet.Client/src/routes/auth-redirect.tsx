import { AUTH_URL, HOME_PAGE_URL } from "../constants/url.ts";
import { Navigate } from "react-router-dom";
import { useAuth } from "../hooks/useAuth.ts";

function AuthRedirect() {
  const { isLoggedIn } = useAuth();
  if (!isLoggedIn) return <Navigate to={AUTH_URL.LOGIN} replace />;

  return <Navigate to={HOME_PAGE_URL.HOME} replace />;
}

export default AuthRedirect;
