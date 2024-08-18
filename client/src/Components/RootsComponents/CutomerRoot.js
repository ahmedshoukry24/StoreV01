import { Outlet } from "react-router-dom";
import CustomerNavBar from "../Header/CustomerNavBar";

const CustomerRoot = () => {
  return (
    <>
      <div>
        <CustomerNavBar />
      </div>
      <div style={{padding: '11vh 1vw 0 1vw', boxSizing:"border-box"}}>
        <Outlet />
      </div>
    </>
  );
};

export default CustomerRoot;
