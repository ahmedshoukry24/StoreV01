import "./App.css";

import { createBrowserRouter, RouterProvider } from "react-router-dom";
import RootElement from "./Components/RootsComponents/RootElement";
import LandingPage from "./Components/Landing/LandingPage";
import SignupPage from "./Components/AuthComponent/SignupPage";
import LoginPage from "./Components/AuthComponent/LoginPage";
import CustomerRoot from "./Components/RootsComponents/CutomerRoot";
import CustomerHomePage from "./Components/Dashboard/CustomerHomePage";

function App() {
  const router = createBrowserRouter([
    {
      path: "/",
      element: <RootElement />,
      children: [
        { path: "/", element: <LandingPage /> },
        { path: "/SignUp", element: <SignupPage /> },
        { path: "/Login", element: <LoginPage /> },
      ],
    },
    {
      path:'/Customer',
      element:<CustomerRoot/>,
      children:[
        {path:'CustomerHomePage', element:<CustomerHomePage/>}
      ]
    }
  ]);

  return (
    <>
      <RouterProvider router={router} />
    </>
  );
}

export default App;
