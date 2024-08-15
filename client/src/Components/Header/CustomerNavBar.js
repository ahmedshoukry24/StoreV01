import classes from "./CustomerNavBar.module.css";

const CustomerNavBar = () => {
  return (
    <header className={classes.header}>
      {/* logo */}
      <p className={classes.logo}>Logo</p>

      {/* search */}
      <div>
        <form>
          <input className={classes["form-search-input"]} type="text" />
          <button type="submit">
            <i className="fa fa-search"></i>
          </button>
        </form>
      </div>

      {/* right part */}
      <nav>
        <a>Home</a>
        <a>Home</a>
        <a>Home</a>
        <a>Home</a>
      </nav>
    </header>
  );
};

export default CustomerNavBar;
