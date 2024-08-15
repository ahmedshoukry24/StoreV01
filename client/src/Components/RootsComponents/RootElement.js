import { Fragment } from "react";
import MainNavBar from "../Header/MainNavBar";
import { Outlet } from "react-router-dom";

const RootElement = ()=>{

    return (<Fragment>
        <MainNavBar />
        <Outlet />
    </Fragment>);
}

export default RootElement;