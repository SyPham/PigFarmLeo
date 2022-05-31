import { NgModule } from '@angular/core';
import { AccountComponent } from './account.component';
import { ProfileComponent } from './profile/profile.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { AccountGroupComponent } from './account-group/account-group.component';
import { RadioButtonModule, CheckBoxAllModule, SwitchModule } from '@syncfusion/ej2-angular-buttons';
import { DatePickerAllModule } from '@syncfusion/ej2-angular-calendars';
import { DropDownListModule, MultiSelectModule } from '@syncfusion/ej2-angular-dropdowns';
import { GridAllModule } from '@syncfusion/ej2-angular-grids';
import { TreeViewAllModule, ToolbarModule } from '@syncfusion/ej2-angular-navigations';
import { TooltipModule } from '@syncfusion/ej2-angular-popups';
import { TreeGridAllModule } from '@syncfusion/ej2-angular-treegrid';
import { TranslateModule } from '@ngx-translate/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const EJ2_MODULE = [
  DropDownListModule,
  DatePickerAllModule,
  TreeGridAllModule,
  GridAllModule,
  RadioButtonModule,
  TooltipModule,
  CheckBoxAllModule,
  MultiSelectModule,
  TreeViewAllModule,
  ToolbarModule,
  SwitchModule
];

@NgModule({
  declarations: [
    AccountComponent,
    ProfileComponent,
    ChangePasswordComponent,
    AccountGroupComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ...EJ2_MODULE,
    TranslateModule
  ],
  exports: [
    AccountComponent,
    ProfileComponent,
    ChangePasswordComponent,
    AccountGroupComponent
  ]
})
export class AccountModule { }
