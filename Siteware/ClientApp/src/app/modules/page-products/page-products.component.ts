import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-page-products',
  templateUrl: './page-products.component.html',
  styleUrls: ['./page-products.component.scss']
})
export class PageProductsComponent implements OnInit {

  public products = [
    {id: 1, name: "Sabonete", price: 5.00, saleType: "Compre 1 leve 2"},
    {id: 2, name: "Sabão", price: 7.00, saleType: "Compre 1 leve 2"},
    {id: 3, name: "Shampoo", price: 10.00, saleType: "Compre 3 por R$ 10"},
    {id: 4, name: "Shampoo", price: 10.00, saleType: "Compre 3 por R$ 10"},
    {id: 5, name: "Shampoo", price: 10.00, saleType: "Compre 3 por R$ 10"}
  ];

  constructor() { }

  ngOnInit() {
  }

}
