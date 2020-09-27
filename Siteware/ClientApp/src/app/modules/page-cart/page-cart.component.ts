import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-page-cart',
  templateUrl: './page-cart.component.html',
  styleUrls: ['./page-cart.component.scss']
})
export class PageCartComponent implements OnInit {

  public cartItems = [
    {id: 1, name: "Sabonete", quantity: 4, price: 5.00, saleType: "Compre 1 leve 2"},
    {id: 2, name: "Sabão", quantity: 2, price: 7.00, saleType: "Compre 1 leve 2"},
    {id: 3, name: "Shampoo", quantity: 3, price: 10.00, saleType: "Compre 3 por R$ 10"}
  ];

  constructor() { }

  ngOnInit() {
  }

  removeItem() {
    console.log("remove item");
    
  }
}
