import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PageStorageComponent } from './page-storage.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  declarations: [PageStorageComponent]
})
export class PageStorageModule { }
