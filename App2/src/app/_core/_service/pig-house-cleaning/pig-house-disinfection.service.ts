﻿import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { OperationResult } from '../../_model/operation.result';
import { PigHouseDisinfection } from '../../_model/pig-house-cleaning';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';

@Injectable({
  providedIn: 'root'
})
export class PigHouseDisinfectionService extends CURDService<PigHouseDisinfection> {
  private pigFarmVectorSource = new BehaviorSubject({} );
  currentPigHouseDisinfection = this.pigFarmVectorSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"PigHouseDisinfection", utilitiesService);
  }
  changePigHouseDisinfection(pigFarmVector) {
    this.pigFarmVectorSource.next(pigFarmVector)
  }
  toggleRecordDate(id): Observable<OperationResult> {
    return this.http.get<OperationResult>(`${this.base}PigHouseDisinfection/ToggleRecordDate?id=${id}`, {});
  }
}
