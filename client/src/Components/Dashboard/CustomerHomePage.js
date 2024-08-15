import { useEffect, useState } from "react";
import { GetProducts } from "../../Services/Products/ProductServices";
import classes from "./CustomerHomePage.module.css";
import ProductCard from "../Cards/ProductCard/ProductCard";

const CustomerHomePage = () => {
  
  const [produts, setProducts] = useState([]);


  // useEffect(()=>{
  //   const prodService =async ()=>{
  //     const result = await GetProducts();
  //     setProducts(result);
  //   };

  //   prodService();
  // },[]);

  useEffect(() => {
    const fetchProducts = async () => {
        try {
            const result = await GetProducts();
            setProducts(result);
        } catch (error) {
            console.error("Failed to fetch products", error);
        }
    };

    fetchProducts();
}, []);


  return (
    <div className={classes.container}>
      {produts.map((item,index) => {
        return (
          <ProductCard data={item} />
        );
      })}
    </div>
  );
};

export default CustomerHomePage;
