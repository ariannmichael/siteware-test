import SaleTypes from "./SaleType";

class Product {
    id: number;
    name: string;
    price: number;
    saletype: SaleTypes

    constructor(
        name: string,
        price: number,
        saletype: SaleTypes
    ) {
        this.name = name;
        this.price = price;
        this.saletype= saletype;
    }
}

export default Product;
