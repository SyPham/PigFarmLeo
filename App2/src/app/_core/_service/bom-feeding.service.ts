import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { UtilitiesService } from './utilities.service';
import { CURDService } from './base/CURD.service';
import { BomFeeding } from '../_model/bom-feeding';
@Injectable({
  providedIn: 'root'
})
export class BOMFeedingService extends CURDService<BomFeeding> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"BomFeeding", utilitiesService);
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
