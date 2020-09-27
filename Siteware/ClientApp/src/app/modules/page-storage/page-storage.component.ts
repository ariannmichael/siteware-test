import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-page-storage',
  templateUrl: './page-storage.component.html',
  styleUrls: ['./page-storage.component.scss']
})
export class PageStorageComponent implements OnInit {

  public products = [
    {id: 1, name: "Sabonete", price: 5.00, saleType: "Compre 1 leve 2"},
    {id: 2, name: "Sabão", price: 7.00, saleType: "Compre 1 leve 2"},
    {id: 3, name: "Shampoo", price: 10.00, saleType: "Compre 3 por R$ 10"}
  ];

  constructor() { }

  ngOnInit() {
  }

  addItem() {
    console.log('addItem');
  }

  editItem() {
    console.log('editItem');
  }

  deleteItem() {
    console.log('deleteItem');
  }

}
