import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { PigPrescription } from '../../_model/pig-disease';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';

@Injectable({
  providedIn: 'root'
})
export class PigPrescriptionService extends CURDService<PigPrescription> {
  private pigPrescriptionSource = new BehaviorSubject({} );
  currentPigPrescription = this.pigPrescriptionSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"PigPrescription", utilitiesService);
  }
  changePigPrescription(pigPrescription) {
    this.pigPrescriptionSource.next(pigPrescription)
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
