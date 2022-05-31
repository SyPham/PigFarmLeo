
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { RepairRecord } from '../../_model/repairs';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';


@Injectable({
  providedIn: 'root'
})
export class RepairRecordService extends CURDService<RepairRecord> {
  private biosSource = new BehaviorSubject({} );
  currentRepairRecord = this.biosSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"RepairRecord", utilitiesService);
  }
  changeRepairRecord(farm) {
    this.biosSource.next(farm)
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
