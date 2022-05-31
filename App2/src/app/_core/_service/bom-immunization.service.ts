import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { UtilitiesService } from './utilities.service';
import { CURDService } from './base/CURD.service';
import { BOMImmunization } from '../_model/bom-immunization';
@Injectable({
  providedIn: 'root'
})
export class BOMImmunizationService extends CURDService<BOMImmunization> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"BOMImmunization", utilitiesService);
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
