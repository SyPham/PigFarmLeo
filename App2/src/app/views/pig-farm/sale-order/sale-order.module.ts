import { SaleOrderComponent, SaleOrderCheckOutComponent,SaleOrderDetailComponent } from '.';

import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule } from 'ngx-spinner';
import { SharedModule } from 'src/app/_core/commons/shared.module';
import { CoreDirectivesModule } from 'src/app/_core/_directive/core.directives.module';
import { SaleOrderRoutingModule } from './sale-order.routing.module';
import { Common2Module } from 'src/app/_core/commons/common2.module';

const ROUTING_MODULE = [
  SaleOrderRoutingModule
];
const ACCEPTANCE_COMPONENT = [
SaleOrderComponent,
SaleOrderCheckOutComponent,
SaleOrderDetailComponent
]
@NgModule({
  providers: [
    DatePipe
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgxSpinnerModule,
    NgbModule,
    CoreDirectivesModule,
    SharedModule.forRoot(),
    Common2Module.forRoot(),
    ...ROUTING_MODULE,
  ],
  declarations: [...ACCEPTANCE_COMPONENT]
})
export class SaleOrderModule { }
