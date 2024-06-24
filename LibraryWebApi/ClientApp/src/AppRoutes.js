import Authors from "./components/Authors";
import Books from "./components/Book";
import Home  from "./components/Home";
import SignInOidc from './auth/SigninOidc';
import SignOutOidc from './auth/SignoutOidc';
import User from './components/User'

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/book',
    element: <Books />
    },
    {
        path: '/author',
        element: <Authors />
    },
    {
        path: '/signout-oidc',
        element: <SignOutOidc />
    },
    {
        path: '/signin-oidc',
        element: <SignInOidc />
    },
    {
        path: '/user',
        element: <User />
    }

];

export default AppRoutes;
