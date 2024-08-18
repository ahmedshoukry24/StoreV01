import "./App.css";

import { createBrowserRouter, RouterProvider } from "react-router-dom";
import RootElement from "./Components/RootsComponents/RootElement";
import LandingPage from "./Components/Landing/LandingPage";
import SignupPage from "./Pages/Customer/Auth/SignupPage";
import LoginPage from "./Pages/Customer/Auth/LoginPage";
import CustomerRoot from "./Components/RootsComponents/CutomerRoot";
import CustomerHomePage from "./Pages/Customer/Home/CustomerHomePage";
import ProductDetails from "./Pages/Customer/Product/ProductDetails";

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
        {path:'CustomerHomePage', element:<CustomerHomePage/>},
        {path:'Product', element:<ProductDetails/>}
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
