import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Vaccine } from '../_model/vaccine';
import { UtilitiesService } from './utilities.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { OperationResult } from '../_model/operation.result';
import { CURDService } from './base/CURD.service';
@Injectable({
  providedIn: 'root'
})
export class VaccineService extends CURDService<Vaccine> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Vaccine", utilitiesService);
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}Vaccine/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
