import { AfterViewInit, ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { NgbTooltipConfig } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs';
import { BaseDetailComponent } from 'src/app/_core/_component/base-detail.component';
import { MakeOrder } from 'src/app/_core/_model/records';
import { AlertifyService } from 'src/app/_core/_service/alertify.service';
import { MakeOrderService } from 'src/app/_core/_service/records';

@Component({
  selector: 'app-make-order-detail',
  templateUrl: './make-order-detail.component.html',
  styleUrls: ['./make-order-detail.component.scss']
})
export class MakeOrderDetailComponent extends BaseDetailComponent implements OnInit,OnDestroy,AfterViewInit {
  isAdmin = JSON.parse(localStorage.getItem('user'))?.groupCode === 'ADMIN_CANCEL';
  model: MakeOrder;
  subscription: Subscription;
  localLang =  (window as any).navigator.userLanguage || (window as any).navigator.language;
  isLoadding = false;
  roomGuid = '';
  constructor(
    private service: MakeOrderService,
    private alertify: AlertifyService,
    private cd: ChangeDetectorRef,
    translate: TranslateService
    ) { super(translate) }
    ngAfterViewInit (): void {
      this.cd.detectChanges();
    }
  ngOnInit() {
    this.subscription = this.service.currentMakeOrder.subscribe((value: any) => {
      this.model = {...value};
      this.roomGuid = value.roomGuid || '';
      if (value.id > 0) {
        this.service.getById(value.id).subscribe(x=> {
          this.model = {...x};
          this.model.roomGuid = this.model.roomGuid || ''
          this.roomGuid = this.model.roomGuid || ''
        });
        this.getAudit(this.model.id);
      }
    });

  }
  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }
  typeChange(value) { this.model.orderType = value; }
  onChangeRoom(e) {
    this.roomGuid = e.itemData.guid;
  }
  save() {
    this.alertify.confirm4(
       this.alert.yes_message,
       this.alert.no_message,
       this.alert.updateTitle,
       this.alert.updateMessage,
       () => {
        this.isLoadding = true;
        this.model.roomGuid = this.roomGuid || ''

         this.service.update(this.model as any).subscribe(
           (res) => {
             if (res.success === true) {
               this.alertify.success(this.alert.updated_ok_msg);
               this.loadData();
             } else {
               this.alertify.warning(this.alert.system_error_msg);
             }
             this.isLoadding = false;
           },
           (error) => {
             this.alertify.warning(this.alert.system_error_msg);
             this.isLoadding = false;
           }
         );
       }, () => {
         this.alertify.error(this.alert.cancelMessage);
       }
     );


   }
  loadData() {
    this.service.getById(this.model.id).subscribe( data => {
      this.model = data;
    })
  }

  getAudit(id) {
    this.service.getAudit(id).subscribe(data => {
      this.audit = data;
    });

  }
}
