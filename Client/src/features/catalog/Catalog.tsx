import { Product } from "../../app/models/product";
import ProductList from "./ProductList";

type Props = {
  products: Product[];
};

export default function Catalog({ products }: Props) {
  // Add setProducts and products as parameters
  return (
    <>
      <ProductList products={products} />
    </>
  );
}
