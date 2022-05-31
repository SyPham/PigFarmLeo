import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { UtilitiesService } from './utilities.service';
import { CURDService } from './base/CURD.service';
import { BOMDisinfection } from '../_model/bom-disinfection';
@Injectable({
  providedIn: 'root'
})
export class BOMDisinfectionService extends CURDService<BOMDisinfection> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"BOMDisinfection", utilitiesService);
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
