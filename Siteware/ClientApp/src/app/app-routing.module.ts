  
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageCartComponent } from './modules/page-cart/page-cart.component';
import { PageProductsComponent } from './modules/page-products/page-products.component';
import { PageStorageComponent } from './modules/page-storage/page-storage.component';


const routes: Routes = [
    { path: 'products', component: PageProductsComponent },
    { path: 'storage', component: PageStorageComponent },
    { path: 'cart', component: PageCartComponent },
    { path: '', redirectTo: 'products', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }