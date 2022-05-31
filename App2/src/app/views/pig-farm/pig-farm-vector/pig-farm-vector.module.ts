
import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { PigFarmVectorRoutingModule } from './pig-farm-vector.routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule } from 'ngx-spinner';
import { SharedModule } from 'src/app/_core/commons/shared.module';
import { CoreDirectivesModule } from 'src/app/_core/_directive/core.directives.module';
import {
  PigFarmVectorComponent,
  PigFarmVectorcontrolComponent,
  PigFarmVectorDetailComponent,
  PigFarmVectorPlanComponent,
  PigFarmVectorRecordComponent,
  PigFarmVectorScheduleComponent,

} from '.';
import { Common2Module } from 'src/app/_core/commons/common2.module';

const ROUTING_MODULE = [
  PigFarmVectorRoutingModule
];
const PIG_DISEASE_COMPONENT = [
  PigFarmVectorComponent,
  PigFarmVectorDetailComponent,
  PigFarmVectorPlanComponent,
  PigFarmVectorRecordComponent,
  PigFarmVectorScheduleComponent,
  PigFarmVectorcontrolComponent,
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
  declarations: [...PIG_DISEASE_COMPONENT]
})
export class PigFarmVectorModule { }
