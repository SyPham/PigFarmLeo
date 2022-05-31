import { HttpClient } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { BehaviorSubject } from 'rxjs';
  import { Requisition } from '../../_model/requisitions';
  import { CURDService } from '../base/CURD.service';
  import { UtilitiesService } from '../utilities.service';

  @Injectable({
    providedIn: 'root'
  })
  export class RequisitionService extends CURDService<Requisition> {
    private requisitionSource = new BehaviorSubject({} );
    currentRequisition = this.requisitionSource.asObservable();
    constructor( http: HttpClient,utilitiesService: UtilitiesService)
    {
      super(http,"Requisition", utilitiesService);
    }
    changeRequisition(requisition) {
      this.requisitionSource.next(requisition)
    }
    getRequisitions(farmGuid) {
      return this.http.get<any>(`${this.base}Requisition/getRequisitions?farmGuid=${farmGuid}`, {});
    }
  }
