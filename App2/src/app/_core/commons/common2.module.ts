import { BarnDropdownlistComponent } from './../_component/barn-dropdownlist/barn-dropdownlist.component';
import { AreaDropdownlistComponent } from './../_component/area-dropdownlist/area-dropdownlist.component';
import { PenMultiselectComponent } from './../_component/pen-multiselect/pen-multiselect.component';
import { FeedDropdownlistComponent } from 'src/app/_core/_component/feed-dropdownlist/feed-dropdownlist.component';
import { FarmDropdownlistComponent } from './../_component/farm-dropdownlist/farm-dropdownlist.component';
import { PigDropdownlistComponent } from '../_component/pig-dropdownlist/pig-dropdownlist.component';
import { ModuleWithProviders, NgModule } from '@angular/core';
import { DropDownListModule, MultiSelectAllModule } from '@syncfusion/ej2-angular-dropdowns';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PenDropdownlistComponent } from '../_component/pen-dropdownlist/pen-dropdownlist.component';
import { CodeTypeDropdownlistComponent } from '../_component/code-type-dropdownlist/code-type-dropdownlist.component';
import { MaterialDropdownlistComponent } from '../_component/material-dropdownlist/material-dropdownlist.component';
import { MaskedtimetextboxComponent } from '../_component/maskedtimetextbox/maskedtimetextbox.component';
import { MaskedTextBoxModule } from '@syncfusion/ej2-angular-inputs';
import { TranslateModule } from '@ngx-translate/core';
import { DiseaseDropdownlistComponent } from '../_component/disease-dropdownlist/disease-dropdownlist.component';
import { MedicineDropdownlistComponent } from '../_component/medicine-dropdownlist/medicine-dropdownlist.component';
import { BomDropdownlistComponent } from '../_component/bom-dropdownlist/bom-dropdownlist.component';
import { CustomerDropdownlistComponent } from '../_component/customer-dropdownlist/customer-dropdownlist.component';
import { VectorControlDropdownlistComponent } from 'src/app/_core/_component/vector-control-dropdownlist/vector-control-dropdownlist.component';
import { DisinfectionDropdownlistComponent } from 'src/app/_core/_component/disinfection-dropdownlist/disinfection-dropdownlist.component';
import { RoomDropdownlistComponent } from '../_component/room-dropdownlist/room-dropdownlist.component';
import { CullingTankDropdownlistComponent } from '../_component/culling-tank-dropdownlist/culling-tank-dropdownlist.component';
import { PenDropdownlistModalComponent } from '../_component/pen-dropdownlist-modal/pen-dropdownlist-modal.component';
import { MyCheckboxComponent } from '../_component/my-checkbox/my-checkbox.component';
import { CheckBoxAllModule } from '@syncfusion/ej2-angular-buttons';
import { ThingDropdownlistComponent } from '../_component/thing-dropdownlist/thing-dropdownlist.component';
import { AccountDropdownlistComponent } from '../_component/account-dropdownlist/account-dropdownlist.component';
import { MultiPigGridComponent } from '../_component/multi-pig-grid/multi-pig-grid.component';
import { GridAllModule } from '@syncfusion/ej2-angular-grids';
import { Record2PenComponent } from '../_component/record2-pen/record2-pen.component';
import { Record2RoomComponent } from '../_component/record2-room/record2-room.component';
import { MakeorderDropdownlistComponent } from '../_component/makeorder-dropdownlist/makeorder-dropdownlist.component';
import { SelectedpigGridComponent } from '../_component/selectedpig-grid/selectedpig-grid.component';

@NgModule({
  imports: [
    DropDownListModule,
    FormsModule,
    ReactiveFormsModule,
    MaskedTextBoxModule,
    CheckBoxAllModule,
    TranslateModule,
    GridAllModule,
    MultiSelectAllModule
  ],
  declarations: [
    PigDropdownlistComponent,
    PenDropdownlistComponent,
    RoomDropdownlistComponent,
    CodeTypeDropdownlistComponent,
    FarmDropdownlistComponent,
    FeedDropdownlistComponent,
    MaterialDropdownlistComponent,
    MaskedtimetextboxComponent,
    DiseaseDropdownlistComponent,
    MedicineDropdownlistComponent,
    BomDropdownlistComponent,
    CustomerDropdownlistComponent,
    VectorControlDropdownlistComponent,
    DisinfectionDropdownlistComponent,
    CullingTankDropdownlistComponent,
    PenDropdownlistModalComponent,
    MyCheckboxComponent,
    ThingDropdownlistComponent,
    AccountDropdownlistComponent,
    MultiPigGridComponent,
    Record2RoomComponent,
    Record2PenComponent,
    PenMultiselectComponent,
    MakeorderDropdownlistComponent,
    AreaDropdownlistComponent,
    BarnDropdownlistComponent,
    SelectedpigGridComponent
  ],
  exports: [
    PigDropdownlistComponent,
    PenDropdownlistComponent,
    RoomDropdownlistComponent,
    CodeTypeDropdownlistComponent,
    FarmDropdownlistComponent,
    FeedDropdownlistComponent,
    MaterialDropdownlistComponent,
    MaskedtimetextboxComponent,
    DiseaseDropdownlistComponent,
    MedicineDropdownlistComponent,
    BomDropdownlistComponent,
    CustomerDropdownlistComponent,
    VectorControlDropdownlistComponent,
    DisinfectionDropdownlistComponent,
    CullingTankDropdownlistComponent,
    PenDropdownlistModalComponent,
    MyCheckboxComponent,
    ThingDropdownlistComponent,
    AccountDropdownlistComponent,
    MultiPigGridComponent,
    Record2RoomComponent,
    Record2PenComponent,
    PenMultiselectComponent,
    MakeorderDropdownlistComponent,
    AreaDropdownlistComponent,
    BarnDropdownlistComponent,
    SelectedpigGridComponent

  ]
})
export class Common2Module {
  // 1 cach import khac cua module
  static forRoot(): ModuleWithProviders<Common2Module> {
    return {
      ngModule: Common2Module
    }
  }
}
