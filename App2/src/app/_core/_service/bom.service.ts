import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Bom } from '../_model/bom';
import { UtilitiesService } from './utilities.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { OperationResult } from '../_model/operation.result';
import { CURDService } from './base/CURD.service';
@Injectable({
  providedIn: 'root'
})
export class BOMService extends CURDService<Bom> {
  private bomSource = new BehaviorSubject({} as Bom);
  currentBOM = this.bomSource.asObservable();
  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Bom", utilitiesService);
  }
  changeBOM(bom: Bom) {
    this.bomSource.next(bom)
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}Bom/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
