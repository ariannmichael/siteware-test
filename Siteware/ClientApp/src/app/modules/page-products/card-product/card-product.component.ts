import { Component, Input, OnInit } from '@angular/core';
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons';
import { CartService } from 'src/app/core/services/cart.service';
import CartItem from 'src/app/shared/models/CartItem';
import Product from 'src/app/shared/models/Product';
import { getSaleTypeMessage }  from '../../../shared/helpers';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-card-product',
  templateUrl: './card-product.component.html',
  styleUrls: ['./card-product.component.scss']
})
export class CardProductComponent implements OnInit {

  @Input()
  product: any;

  shoppingCartIcon = faShoppingCart;

  constructor(private cartService: CartService, private toastr: ToastrService) { }

  ngOnInit() {
  }

  get saleType() {
    return getSaleTypeMessage(this.product.saletype);
  }

  buyItem(product: Product) {
    let cartItem = new CartItem(1, 1, product.id);
    this.cartService.postCarItem(cartItem)
      .subscribe(
        () => {
          this.toastr.success("Item adicionado ao carrinho!");
        },
        (error: any) => {
          this.toastr.error("Erro ao adicionar!");
        }
      );
  }
}
