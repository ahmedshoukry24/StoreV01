import { useEffect, useState, React } from "react";
import { GetSearchProductChange } from "../../../Services/Products/ProductServices";
import classes from "./ProductSearch.module.css";

function ProductSearch(props) {
  const [searchText, setSearchText] = useState("");
  const [searchResult, setSeachResult] = useState([]);

  useEffect(() => {
    const timer = setTimeout(async () => {
      if (searchText.length > 0) {
        const result = await GetSearchProductChange(searchText);

        setSeachResult(result);
      }
    }, 500);

    return () => {
      clearTimeout(timer);
    };
  }, [searchText]);

  const SearchInputChange = (event) => {
    setSearchText(event.target.value);
  };

  return (
    <div className={props.className}>
      <form>
        <div className={classes["search-container"]}>
          <div className={classes["search-bar"]}>
            <input
              className={classes["form-search-input"]}
              type="text"
              value={searchText}
              onChange={SearchInputChange}
            />
            <button type="submit" className={classes["search-button"]}>
              <i className="fa fa-search"></i>
            </button>
          </div>
          <div className={classes["search-results"]}>
            {searchResult.map((item, index) => {
              return (
                <div key={item.serial}>
                  <p>{item.name}</p>
                  <span>{item.description}</span>
                </div>
              );
            })}
          </div>
        </div>
      </form>
    </div>
  );
}

export default ProductSearch;
