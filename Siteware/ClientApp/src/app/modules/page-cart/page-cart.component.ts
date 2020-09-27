import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/core/services/cart.service';
import { getSaleTypeMessage } from 'src/app/shared/helpers';
import CartItem from 'src/app/shared/models/CartItem';
import Product from 'src/app/shared/models/Product';

@Component({
  selector: 'app-page-cart',
  templateUrl: './page-cart.component.html',
  styleUrls: ['./page-cart.component.scss']
})
export class PageCartComponent implements OnInit {

  public cartItems: CartItem[];

  constructor(private cartService: CartService) { }

  ngOnInit() {
    this.getCartItems();
  }

  getCartItems() {
    this.cartService.fetchAllCartItems()
      .subscribe((cartItems: CartItem[]) => {
        this.cartItems = cartItems;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  getSaleType(product: Product) {
    return getSaleTypeMessage(product.saletype);
  }

  getTotalPrice() {
    if (!this.cartItems) {
      return 0;
    }

    return this.cartItems.reduce((accumulator, current) => {
      accumulator += current.productPrice;
      return accumulator;
    }, 0);
  }

  removeItem(item: CartItem) {
    this.cartService.deleteCarItem(item.id)
    .subscribe(
      () => {
        this.getCartItems();
      },
      (error: any) => {
        console.log(error);
      }
    );
  }
}
