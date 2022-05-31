
import { DataManager, Query, UrlAdaptor } from '@syncfusion/ej2-data';
import { Component, Input, OnInit, ViewChild, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { DropDownListComponent } from '@syncfusion/ej2-angular-dropdowns';
import { environment } from 'src/environments/environment';
import { TranslateService } from '@ngx-translate/core';
import { MakeOrderService } from '../../_service/apply-orders';

@Component({
  selector: 'app-makeorder-dropdownlist',
  templateUrl: './makeorder-dropdownlist.component.html',
  styleUrls: ['./makeorder-dropdownlist.component.scss']
})
export class MakeorderDropdownlistComponent  implements OnInit, OnChanges {
  @Input() id = "makeorder-remote";
  @Input() selectedValue: any = '';
  @Input() placeholder = "";
  @Input() disabled = false;
  @Output() change = new EventEmitter<any>();
  @Output() selectedValueChange = new EventEmitter<any>();
  @ViewChild('remote') public dropdownObj: DropDownListComponent
  public data: any;
  public query: Query ;
  public remoteFields: Object = { text: 'orderName', value: 'guid' };
  baseUrl = environment.apiUrl;

  constructor(public trans: TranslateService,
    public makeOrderService: MakeOrderService) {}
  ngOnInit() {
    this.makeOrderService.getMakeOrderByFarmGuid(localStorage.getItem('farmGuid')).subscribe(x=> {
      this.data = x;
    })
  }
  ngOnChanges(changes: SimpleChanges): void {
    this.selectedValue = this.selectedValue || "";
    if (changes['selectedValue']) {
      this.selectedValueChange.emit(this.selectedValue);
    }
  }
  onChange(args) {
    this.change.emit(args);
    this.selectedValueChange.emit(args.value);
  }

}
