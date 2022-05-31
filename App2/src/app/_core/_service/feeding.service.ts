import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Feeding } from '../_model/feeding';
import { UtilitiesService } from './utilities.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { OperationResult } from '../_model/operation.result';
import { CURDService } from './base/CURD.service';
@Injectable({
  providedIn: 'root'
})
export class FeedingService extends CURDService<Feeding> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Feeding", utilitiesService);
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}Feeding/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
