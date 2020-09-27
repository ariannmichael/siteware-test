import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/core/services/product.service';
import Product from 'src/app/shared/models/Product';

@Component({
  selector: 'app-page-products',
  templateUrl: './page-products.component.html',
  styleUrls: ['./page-products.component.scss']
})
export class PageProductsComponent implements OnInit {

  public products: Product[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getProducts();
  }

  getProducts() {
    this.productService.fetchAllProducts()
      .subscribe((products: Product[]) => {
        this.products = products;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

}
