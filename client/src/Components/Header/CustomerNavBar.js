import classes from "./CustomerNavBar.module.css";
import ProductSearch from "./ProductSearch/ProductSearch";

const CustomerNavBar = () => {

  

  return (
    <header className={classes.header}>
      {/* logo */}
      <p className={classes.logo}>Logo</p>

      {/* search */}
      <ProductSearch className={classes["product-search"]} />

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
