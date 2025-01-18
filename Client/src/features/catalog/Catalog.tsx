import { useEffect, useState } from "react";
import { Product } from "../../app/models/product";
import ProductList from "./ProductList";

export default function Catalog() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    fetch("https://localhost:7001/api/products")
      .then((res) => res.json())
      .then((data) => setProducts(data));
  }, []);

  // Add setProducts and products as parameters
  return (
    <>
      <ProductList products={products} />
    </>
  );
}
