import React from 'react'
import classes from './productCard.module.css'
const ProductCard = (props) => {
    const data = props.data;
    const truncate = (text, maxLength) => {
        if (text.length > maxLength) {
          text = text.substr(0, maxLength) + "...";
        }
        return text;
      };
  return (
    <div key={data.id} className={classes.card}>
            <div className={classes.img}>
              <img src="https://reactjs.org/logo-og.png" alt="" />
            </div>
            <div className={classes.content}>
              <p className={classes.title}>{data.name}</p>
              <p className={classes.description}>{truncate(data.description, 300)}</p>
              <div className={classes.rate}>
                <span className="fa fa-star checked"></span>
                <span className="fa fa-star checked"></span>
                <span className="fa fa-star checked"></span>
                <span className="fa fa-star checked"></span>
                <span className="fa fa-star"></span>
              </div>
             
              <p className={classes.price}>
                {data.price} <span>$</span>
              </p>
            </div>
            <div className={classes.button}>
              <button >Add to cart</button>
            </div>
          </div>
  )
}

export default ProductCard