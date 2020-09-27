import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CartService } from 'src/app/core/services/cart.service';
import { ProductService } from 'src/app/core/services/product.service';
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

  constructor(
    private cartService: CartService,
    private toastr: ToastrService
  ) { }

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

  minusItemQuantity(cartItem: CartItem) {
    cartItem.quantity = cartItem.quantity >= 1 ? cartItem.quantity - 1 : 0;
    this.editCartItem(cartItem);
  }

  addItemQuantity(cartItem: CartItem) {
    cartItem.quantity += 1;
    this.editCartItem(cartItem);
  }

  editCartItem(cartItem: CartItem) {
    this.cartService.putCarItem(cartItem).subscribe(
      (product: Product) => {
        this.getCartItems();
      },
      (error: any) => {
        console.log(error);
        this.toastr.error("Erro ao editar!");
      }
    );
  }

  removeItem(item: CartItem) {
    this.cartService.deleteCarItem(item.id)
    .subscribe(
      () => {
        this.getCartItems();
        this.toastr.success("Item removido com sucesso!");
      },
      (error: any) => {
        console.log(error);
        this.toastr.error("Erro ao remover!");
      }
    );
  }
}
