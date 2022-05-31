
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { OperationResult } from '../../_model/operation.result';
import { RecordEarTag } from '../../_model/records';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';


@Injectable({
  providedIn: 'root'
})
export class RecordEarTagService extends CURDService<RecordEarTag> {
  private recordSource = new BehaviorSubject({} );
  currentRecordEarTag = this.recordSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"RecordEarTag", utilitiesService);
  }
  changeRecordEarTag(farm) {
    this.recordSource.next(farm)
  }
  toggleRecordDate(id): Observable<OperationResult> {
    return this.http.get<OperationResult>(`${this.base}RecordEarTag/toggleRecordDate?id=${id}`, {});
  }
}
