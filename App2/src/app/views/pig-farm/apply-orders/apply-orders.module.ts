import { RecordEarTagService } from './../../../_core/_service/records/record-ear-tag.service';
import { TranslateModule } from '@ngx-translate/core';
import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule } from 'ngx-spinner';
import { SharedModule } from 'src/app/_core/commons/shared.module';
import { CoreDirectivesModule } from 'src/app/_core/_directive/core.directives.module';
import { Common2Module } from 'src/app/_core/commons/common2.module';
import { ApplyOrdersRoutingModule } from './apply-orders.routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RecordBuriedComponent, RecordChemicalComponent, RecordCullingComponent, RecordCullingSaleComponent, RecordDeathComponent, RecordDiagnosisComponent, RecordDisinfectionComponent, RecordDonateComponent, RecordEarTagComponent, RecordFeedingComponent, RecordGeneralComponent, RecordImmunizationComponent, RecordInOutComponent, RecordInventoryCheckComponent, RecordKillComponent, RecordMoveComponent, RecordPatrolComponent, RecordPiginComponent, RecordPigoutComponent, RecordRepairComponent, RecordSaleComponent, RecordSiloComponent, RecordStolenComponent, RecordTowerComponent, RecordVectorControlComponent, RecordWeighingComponent } from '.';
import { MultiSelectAllModule } from '@syncfusion/ej2-angular-dropdowns';

const ROUTING_MODULE = [
  ApplyOrdersRoutingModule
];
const APPLY_ORDER_COMPONENT = [
RecordGeneralComponent,
RecordTowerComponent,
RecordInventoryCheckComponent,
RecordDiagnosisComponent,
RecordRepairComponent,
RecordPatrolComponent,

RecordCullingComponent,
RecordDeathComponent,
RecordDisinfectionComponent,
RecordDonateComponent,
RecordEarTagComponent,
RecordFeedingComponent,
RecordImmunizationComponent,
RecordMoveComponent,
RecordSaleComponent,
RecordVectorControlComponent,
RecordWeighingComponent,
RecordInOutComponent,

RecordPiginComponent,
RecordPigoutComponent,
RecordKillComponent,
RecordStolenComponent,
RecordChemicalComponent,
RecordSiloComponent,
RecordBuriedComponent,
RecordCullingSaleComponent
]
@NgModule({
  providers: [
    DatePipe,
    RecordEarTagService
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgxSpinnerModule,
    NgbModule,
    CoreDirectivesModule,
    MultiSelectAllModule,
    TranslateModule,
    SharedModule.forRoot(),
    Common2Module.forRoot(),
    ...ROUTING_MODULE,
  ],
  declarations: [...APPLY_ORDER_COMPONENT]
})
export class ApplyOrdersModule { }
