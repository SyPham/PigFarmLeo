import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {  RfidComponent, SemenComponent, SemenMixComponent } from '.';
import { Inventory2RoutingModule } from './inventory2.routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ButtonModule } from '@syncfusion/ej2-angular-buttons';
import { NgxSpinnerModule } from 'ngx-spinner';
import { Common2Module } from 'src/app/_core/commons/common2.module';
import { SharedModule } from 'src/app/_core/commons/shared.module';
import { CoreDirectivesModule } from 'src/app/_core/_directive/core.directives.module';

@NgModule({
  imports: [
    CommonModule,
    Inventory2RoutingModule,
    ButtonModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgxSpinnerModule,
    NgbModule,
    CoreDirectivesModule,
    SharedModule.forRoot(),
    Common2Module.forRoot(),
  ],
  declarations: [
    RfidComponent,
    SemenComponent,
    SemenMixComponent
  ]
})
export class Inventory2Module { }
