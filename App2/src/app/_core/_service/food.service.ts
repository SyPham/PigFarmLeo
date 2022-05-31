import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Food } from '../_model/food';
import { UtilitiesService } from './utilities.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { OperationResult } from '../_model/operation.result';
import { CURDService } from './base/CURD.service';
@Injectable({
  providedIn: 'root'
})
export class FoodService extends CURDService<Food> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Food", utilitiesService);
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}Food/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
