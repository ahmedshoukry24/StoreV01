import classes from "./MainNavBar.module.css";
import { NavLink } from "react-router-dom";

const MainNavBar = (props) => {
  return (
    <div className={classes.headerContainer}>
      <ul className={classes.headerUL}>
        <li>
          <p>Logo</p>
        </li>
        <li>
          <NavLink to="/"
          className={({isActive})=>isActive?classes.active:undefined}
           end>
            Project Name
          </NavLink>
        </li>
      </ul>

      <ul className={classes.headerUL}>
        <li>
          <NavLink to='/Login' className={({isActive})=>isActive?classes.active : undefined}>Login</NavLink>
        </li>
        <li>
          <NavLink to='/Signup' className={({isActive})=>isActive?classes.active : undefined}>Signup</NavLink>
        </li>
      </ul>
    </div>
  );
};

export default MainNavBar;
