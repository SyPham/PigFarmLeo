import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { UtilitiesService } from './utilities.service';
import { CURDService } from './base/CURD.service';
import { BOMTreatment } from '../_model/bom-treatment';
@Injectable({
  providedIn: 'root'
})
export class BOMTreatmentService extends CURDService<BOMTreatment> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"BOMTreatment", utilitiesService);
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
