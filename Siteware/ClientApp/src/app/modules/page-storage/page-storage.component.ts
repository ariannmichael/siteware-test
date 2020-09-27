import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ProductService } from 'src/app/core/services/product.service';
import { getSaleTypeMessage } from 'src/app/shared/helpers';
import Product from 'src/app/shared/models/Product';

@Component({
  selector: 'app-page-storage',
  templateUrl: './page-storage.component.html',
  styleUrls: ['./page-storage.component.scss']
})
export class PageStorageComponent implements OnInit {

  private selectedProduct: Product = null;
  public products: Product[];
  public modalRef: BsModalRef;
  public productForm: FormGroup;

  constructor(
    private modalService: BsModalService,
    private productService: ProductService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.getProducts();
    this.createForm();
  }

  createForm() {
    this.productForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
      price: ['', Validators.required],
      saletype: ['', Validators.required]
    });
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

  getSaleType(product: Product) {
    return getSaleTypeMessage(product.saletype);
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  openModalAddItem(template: TemplateRef<any>) {
    this.selectedProduct = null;
    this.productForm.reset();
    this.openModal(template);
  }

  openModalEditItem(product: Product, template: TemplateRef<any>) {
    this.selectedProduct = product;
    this.productForm.patchValue(product);
    this.openModal(template);
  }

  addProduct() {
    let newProduct = new Product(this.productForm.value.name, this.productForm.value.price, this.productForm.value.saletype);

    this.productService.postProduct(newProduct).subscribe(
      (product: Product) => {
        this.getProducts();
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  editProduct() {
    this.productService.putProduct(this.productForm.value).subscribe(
      (product: Product) => {
        this.getProducts();
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  deleteItem(product: Product) {
    this.productService.deleteProduct(product.id)
    .subscribe(
      () => {
        this.getProducts();
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  productSubmit() {
    if (this.selectedProduct) {
      this.editProduct();
    } else {
      this.addProduct();
    }

    this.modalRef.hide();
  }

}
