﻿import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { OperationResult } from '../../_model/operation.result';
import { PigFarmVectorRecord } from '../../_model/pig-farm-vector';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';

@Injectable({
  providedIn: 'root'
})
export class PigFarmVectorRecordService extends CURDService<PigFarmVectorRecord> {
  private pigFarmVectorRecordSource = new BehaviorSubject({} );
  currentPigFarmVectorRecord = this.pigFarmVectorRecordSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"PigFarmVectorRecord", utilitiesService);
  }
  changePigFarmVectorRecord(pigFarmVectorRecord) {
    this.pigFarmVectorRecordSource.next(pigFarmVectorRecord)
  }
  toggleRecordDate(id): Observable<OperationResult> {
    return this.http.get<OperationResult>(`${this.base}PigFarmVectorRecord/toggleRecordDate?id=${id}`, {});
  }
}
