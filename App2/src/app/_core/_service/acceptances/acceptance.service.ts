
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Acceptance } from '../../_model/acceptances';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';


@Injectable({
  providedIn: 'root'
})
export class AcceptanceService extends CURDService<Acceptance> {
  private acceptanceSource = new BehaviorSubject({} );
  currentAcceptance = this.acceptanceSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Acceptance", utilitiesService);
  }
  changeAcceptance(acceptance) {
    this.acceptanceSource.next(acceptance)
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
