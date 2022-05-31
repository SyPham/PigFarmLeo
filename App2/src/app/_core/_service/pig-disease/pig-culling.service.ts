import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { PigCulling } from '../../_model/pig-disease';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';

@Injectable({
  providedIn: 'root'
})
export class PigCullingService extends CURDService<PigCulling> {
  private pigCullingSource = new BehaviorSubject({} );
  currentPigCulling = this.pigCullingSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"PigCulling", utilitiesService);
  }
  changePigCulling(pigCulling) {
    this.pigCullingSource.next(pigCulling)
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
