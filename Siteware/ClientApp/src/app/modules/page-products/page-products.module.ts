import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PageProductsComponent } from './page-products.component';
import { RouterModule, ROUTES } from '@angular/router';
import { CardProductComponent } from './card-product/card-product.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  imports: [
    CommonModule,
    FontAwesomeModule
  ],
  declarations: [
    PageProductsComponent,
    CardProductComponent
  ]
})
export class PageProductsModule { }
