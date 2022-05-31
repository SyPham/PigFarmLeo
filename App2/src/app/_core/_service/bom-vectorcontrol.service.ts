import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { UtilitiesService } from './utilities.service';
import { CURDService } from './base/CURD.service';
import { BOMVectorControl } from '../_model/bom-vectorcontrol';
@Injectable({
  providedIn: 'root'
})
export class BOMVectorControlService extends CURDService<BOMVectorControl> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"BOMVectorControl", utilitiesService);
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
