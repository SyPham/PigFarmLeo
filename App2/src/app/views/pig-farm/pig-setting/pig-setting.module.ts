import { SharedModule } from 'src/app/_core/commons/shared.module';
import { PigModalComponent } from './pig/pig-modal/pig-modal.component';
import { PigTestingComponent ,
  PigPedigreeComponent,
  PigPedigreeDetailComponent,
PigGeneticComponent ,
PigCodeComponent } from '.';
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

import { CoreDirectivesModule } from 'src/app/_core/_directive/core.directives.module';
import { PigSettingRoutingModule } from './pig-setting.routing.module';
import { PigComponent } from '.';
import { Common2Module } from 'src/app/_core/commons/common2.module';


const PIG_SETTING_COMPONENT = [
  PigComponent,
  PigModalComponent,
  PigCodeComponent,
  PigGeneticComponent,
  PigPedigreeComponent,
  PigTestingComponent,
  PigPedigreeDetailComponent,
]
@NgModule({
  providers: [
    DatePipe,
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
    PigSettingRoutingModule,
    SharedModule.forRoot(),
    Common2Module,

  ],
  declarations: [
    ...PIG_SETTING_COMPONENT
  ]
})
export class PigSettingModule {
  isAdmin = JSON.parse(localStorage.getItem('user'))?.groupCode === 'ADMIN_CANCEL';

  constructor(config: NgbTooltipConfig
    ) {
      if (this.isAdmin === false) {
        config.disableTooltip = true;
      }

    }
}
