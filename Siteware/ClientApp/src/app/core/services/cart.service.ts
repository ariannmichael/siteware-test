import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import CartItem from 'src/app/shared/models/CartItem';

@Injectable({
    providedIn: 'root'
})
export class CartService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  public fetchAllCartItems(): Observable<CartItem[]> {
    return this.http.get<CartItem[]>(this.baseUrl + 'cartItems/cart?cartId=1');
  }

  public postCarItem(cartItem: CartItem) {
    return this.http.post(this.baseUrl + 'cartItems', cartItem);
  }

  public putCarItem(cartItem: CartItem) {
    return this.http.put(this.baseUrl + `cartItems/${cartItem.id}`, cartItem);
  }

  public deleteCarItem(id: number) {
    return this.http.delete(this.baseUrl + `cartItems/${id}`);
  }
}
