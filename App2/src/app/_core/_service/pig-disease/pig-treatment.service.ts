﻿import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { OperationResult } from '../../_model/operation.result';
import { PigTreatment } from '../../_model/pig-disease';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';

@Injectable({
  providedIn: 'root'
})
export class PigTreatmentService extends CURDService<PigTreatment> {
  private pigTreatmentSource = new BehaviorSubject({} );
  currentPigTreatment = this.pigTreatmentSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"PigTreatment", utilitiesService);
  }
  changePigTreatment(pigTreatment) {
    this.pigTreatmentSource.next(pigTreatment)
  }
  toggleRecordDate(id): Observable<OperationResult> {
    return this.http.get<OperationResult>(`${this.base}PigTreatment/toggleRecordDate?id=${id}`, {});
  }
}
