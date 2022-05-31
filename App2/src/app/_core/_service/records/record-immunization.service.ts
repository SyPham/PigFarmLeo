
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { OperationResult } from '../../_model/operation.result';
import { RecordImmunization } from '../../_model/records';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';


@Injectable({
  providedIn: 'root'
})
export class RecordImmunizationService extends CURDService<RecordImmunization> {
  private recordSource = new BehaviorSubject({} );
  currentRecordImmunization = this.recordSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"RecordImmunization", utilitiesService);
  }
  changeRecordImmunization(farm) {
    this.recordSource.next(farm)
  }
  toggleRecordDate(id): Observable<OperationResult> {
    return this.http.get<OperationResult>(`${this.base}RecordImmunization/toggleRecordDate?id=${id}`, {});
  }
  toggleEstDate(id): Observable<OperationResult> {
    return this.http.get<OperationResult>(`${this.base}RecordImmunization/toggleEstDate?id=${id}`, {});
  }
}
