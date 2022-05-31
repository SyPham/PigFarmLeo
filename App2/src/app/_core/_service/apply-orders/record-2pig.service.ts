
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Record2Pig, UpdateWeightParams } from '../../_model/apply-orders/model';
import { OperationResult } from '../../_model/operation.result';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';


@Injectable({
  providedIn: 'root'
})
export class Record2PigService extends CURDService<Record2Pig> {
  private recordSource = new BehaviorSubject({} );
  currentRecord2Pig = this.recordSource.asObservable();

  private recordSource2 = new BehaviorSubject({} );
  currentRecord2Pig2 = this.recordSource2.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Record2Pig", utilitiesService);
  }
  updateWeight(model: UpdateWeightParams): Observable<OperationResult> {
    return this.http
      .put<OperationResult>(`${this.base}Record2Pig/UpdateWeight`, model)
      .pipe(catchError(this.handleError));
  }

}
