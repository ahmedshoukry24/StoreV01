import { Outlet } from "react-router-dom";
import CustomerNavBar from "../Header/CustomerNavBar";

const CustomerRoot = () => {
  return (
    <>
      <CustomerNavBar />
      <Outlet />
    </>
  );
};

export default CustomerRoot;
