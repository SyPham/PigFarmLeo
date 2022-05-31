import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { UtilitiesService } from './utilities.service';
import { CURDService } from './base/CURD.service';
import { BOMWeighing } from '../_model/bom-weighing';
@Injectable({
  providedIn: 'root'
})
export class BOMWeighingService extends CURDService<BOMWeighing> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"BOMWeighing", utilitiesService);
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
