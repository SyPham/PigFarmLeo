import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { UtilitiesService } from './utilities.service';
import { CURDService } from './base/CURD.service';
import { BOMMove } from '../_model/bom-move';
@Injectable({
  providedIn: 'root'
})
export class BOMMoveService extends CURDService<BOMMove> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"BOMMove", utilitiesService);
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
