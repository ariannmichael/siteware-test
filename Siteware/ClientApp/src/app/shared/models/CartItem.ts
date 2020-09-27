import Cart from "./Cart";
import Product from "./Product";

class CartItem {
    id: number;
    quantity: number;
    cartId: number;
    cart: Cart;
    productId: number;
    product: Product;
    productPrice: number;

    constructor(
        quantity: number,
        cartId: number,
        productId: number
    ) {
        this.quantity = quantity;
        this.cartId = cartId;
        this.productId = productId;
    }
}

export default CartItem;
