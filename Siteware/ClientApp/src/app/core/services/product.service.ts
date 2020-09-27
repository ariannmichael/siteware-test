import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import Product from 'src/app/shared/models/Product';

@Injectable({
    providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  public fetchAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl + 'product');
  }
  
  public postProduct(product: Product) {
    return this.http.post(this.baseUrl + 'product', product);
  }

  public putProduct(product: Product) {
    return this.http.put(this.baseUrl + `product/${product.id}`, product);
  }

  public deleteProduct(id: number) {
    return this.http.delete(this.baseUrl + `product/${id}`);
  }
}
