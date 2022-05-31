import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { DailyFeeding } from '../_model/daily-feeding';
import { UtilitiesService } from './utilities.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { OperationResult } from '../_model/operation.result';
import { CURDService } from './base/CURD.service';
@Injectable({
  providedIn: 'root'
})
export class DailyFeedingService extends CURDService<DailyFeeding> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"DailyFeeding", utilitiesService);
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}DailyFeeding/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
