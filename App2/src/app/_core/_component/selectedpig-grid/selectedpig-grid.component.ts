import { Component, EventEmitter, Input, OnInit, Output, ViewChild,  SimpleChanges, AfterViewInit , ChangeDetectorRef } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { GridComponent } from '@syncfusion/ej2-angular-grids';
import { takeWhile } from 'rxjs/operators';
import { RecordEarTagService } from '../../_service/apply-orders';

@Component({
  selector: 'app-selectedpig-grid',
  templateUrl: './selectedpig-grid.component.html',
  styleUrls: ['./selectedpig-grid.component.scss']
})
export class SelectedpigGridComponent implements OnInit, AfterViewInit  {
  @Input() selectedPigDataSource: any = [];
  @Input() recordNextDataSource: any = ['CullingSale','Chemical','Buried'];
  searchOptions = { fields: ["name"], operator: "contains", ignoreCase: true };
  @ViewChild("grid") public grid: GridComponent;
  @Output() avgWeightChange = new EventEmitter()
  @Output() totalWeightChange = new EventEmitter()
  @Output() avgAmountChange = new EventEmitter()
  @Output() totalAmountChange = new EventEmitter()
  @Output() selectedPigDataSourceChange = new EventEmitter()
  pageSettings: any;
  @Input() visibleNext = true;
  @Input() visibleAmount = true;
  @Input() visibleDisease = true;
  @Input() visibleWeight= true;
  @Input() visibleValue = false;
  @Input() valueLabel = '';
  editSettingsPig = {
    showDeleteConfirmDialog: false,
    allowEditing: true,
    allowAdding: true,
    allowDeleting: true,
    mode: "Normal",
  };
  @Input() avgWeight: number;
  @Input() totalWeight: number;
  @Input() totalAmount: number;
  @Input() avgAmount: number;
  index: any;
  diseaseItem: any;
  recordNext: any;
  recordNextndex: any;
  constructor(
    private trans: TranslateService,
    private cd: ChangeDetectorRef,
    private service: RecordEarTagService,
  ) {
    let user = JSON.parse(localStorage.getItem('user'));
    let pageSize = Number(user?.pageSizeSettingValue) || 10;
    let pageSizesTemp = user?.pageSizeSettingList || ['5', '10', '12', '20'];
    let pageSizes = pageSizesTemp.map(x=> +x);
    this.pageSettings = {  pageSizes: pageSizes, enableQueryString: true,  pageSize: pageSize, currentPage: 1, enableScroll: true };

  }
  ngAfterViewInit (): void {
    this.cd.detectChanges();
  }
  ngOnChanges(changes: SimpleChanges): void {

  }
  created() {
    this.service.currentRecordLabel
    .subscribe((data: any) => {
         this.valueLabel = data
         this.grid?.refreshColumns();
      });
  }
  ngOnInit() {
  }
  actionBeginPig(e) {
    if (e.action === 'edit' && e.requestType === 'save') {
      e.data.recordDisease = this.diseaseItem?.guid;
      e.data.recordDiseaseName = this.diseaseItem?.name;
      e.data.recordNext = this.recordNext;
      const index = e.rowIndex;
      if (index !== -1) {
        this.selectedPigDataSource[index].recordValue = e.data.recordValue;
        this.selectedPigDataSource[index].recordAmount = e.data.recordAmount;
        this.selectedPigDataSource[index].recordWeight = e.data.recordWeight;
        const weights = this.selectedPigDataSource.filter(x=> x.recordWeight > 0).map(x=> x.recordWeight);
        const amounts = this.selectedPigDataSource.filter(x=> x.recordAmount > 0).map(x=> x.recordAmount);
        let length = this.selectedPigDataSource.length
        this.avgWeight = +this.average(weights, length).toFixed(0);
        this.avgAmount = +this.average(amounts, length).toFixed(0);
        this.totalWeight = +this.total(weights).toFixed(0);
        this.totalAmount = +this.total(amounts).toFixed(0);
        this.selectedPigDataSourceChange.emit(this.selectedPigDataSource);
        this.avgAmountChange.emit(this.avgAmount);
        this.avgWeightChange.emit(this.avgWeight);
        this.totalAmountChange.emit(this.totalAmount);
        this.totalWeightChange.emit(this.totalWeight);
      }
    }
  }
  onChangeRecordNext(e, data) {
    if(e.isInteracted) {
      data.recordNext = e.value;
      this.recordNext = e.value;
      this.recordNextndex = this.selectedPigDataSource.findIndex((obj => obj.pigGuid === data.pigGuid));
      if (this.recordNextndex !== -1) {
        this.selectedPigDataSource[this.recordNextndex].recordNext = e.value;
        //  this.selectedPigDataSourceChange.emit(this.selectedPigDataSource);
        }
    }
  }
  onChangeDisease(e, data) {
    if(e.isInteracted) {
      data.recordDisease = e.itemData.guid;
      data.recordDiseaseName = e.itemData.name;
      this.diseaseItem = e.itemData;
      this.index = this.selectedPigDataSource.findIndex((obj => obj.pigGuid === data.pigGuid));
      if (this.index !== -1) {
        this.selectedPigDataSource[this.index].recordDisease = e.itemData.guid;
        this.selectedPigDataSource[this.index].recordDiseaseName = e.itemData.name;
        // this.selectedPigDataSourceChange.emit(this.selectedPigDataSource);
      }
    }
  }
   average = (nums, length) => {
    if ((nums as []).length > 0) {
      return nums.reduce((a, b) => (a + b)) / length;
    }
    return 0;
  }
  total = (nums) => {
    if ((nums as []).length > 0) {
    return nums.reduce((a, b) => (a + b));
    }
    return 0;
  }
}
