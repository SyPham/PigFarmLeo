

// Angular
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgxSpinnerModule } from 'ngx-spinner';
// Components Routing

import { NgbModule, NgbTooltipConfig } from '@ng-bootstrap/ng-bootstrap';
// Import ngx-barcode module

import { ButtonModule } from '@syncfusion/ej2-angular-buttons';


import { HttpClient } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
// AoT requires an exported function for factories
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

import { DatePipe } from '@angular/common';

import { InfiniteScrollService } from '@syncfusion/ej2-angular-grids';


import { CoreDirectivesModule } from 'src/app/_core/_directive/core.directives.module';
import { SharedModule } from 'src/app/_core/commons/shared.module';
import { Common2Module } from 'src/app/_core/commons/common2.module';
import { BatchWorkRoutingModule } from './batch-work.routing.module';
import {
  RecordCullingComponent,
  RecordDeathComponent,
  RecordDisinfectionComponent,
  RecordFeedingComponent,
  RecordImmunizationComponent,
  RecordMoveComponent,
  RecordPigEarComponent,
  RecordTreatmentComponent,
  RecordVectorControlComponent,
  RecordWeighingComponent,
} from ".";
import { BatchWorkComponent } from './batch-work.component';
const ROUTING_MODULE = [
  BatchWorkRoutingModule
];
const BATCH_WORK_COMPONENT = [
  RecordCullingComponent,
  RecordDeathComponent,
  RecordDisinfectionComponent,
  RecordFeedingComponent,
  RecordImmunizationComponent,
  RecordMoveComponent,
  RecordPigEarComponent,
  RecordTreatmentComponent,
  RecordVectorControlComponent,
  RecordWeighingComponent
]
@NgModule({
  providers: [
    DatePipe,
    InfiniteScrollService,
    NgbTooltipConfig
  ],
  imports: [
    ButtonModule,
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
  declarations: [
    BatchWorkComponent,
    ...BATCH_WORK_COMPONENT
  ]
})
export class BatchWorkModule {
}
