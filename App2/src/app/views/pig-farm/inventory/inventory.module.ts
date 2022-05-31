import { InventoryScrapComponent } from './inventory-scrap/inventory-scrap.component';
import { InventoryChangeComponent } from './inventory-change/inventory-change.component';
import { InventoryDetailComponent } from './inventory-detail/inventory-detail.component';

import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { InventoryComponent } from './inventory.component';
import { InventoryRoutingModule } from './inventory.routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule } from 'ngx-spinner';
import { SharedModule } from 'src/app/_core/commons/shared.module';
import { CoreDirectivesModule } from 'src/app/_core/_directive/core.directives.module';
import { InventoryChangeMaterialComponent } from './inventory-change-material/inventory-change-material.component';
import { Common2Module } from 'src/app/_core/commons/common2.module';

const ROUTING_MODULE = [
  InventoryRoutingModule
];
const INVENTORY_COMPONENT = [
  InventoryComponent,
  InventoryDetailComponent,
  InventoryChangeComponent,
  InventoryChangeMaterialComponent,
  InventoryScrapComponent

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
  declarations: [...INVENTORY_COMPONENT]
})
export class InventoryModule { }
