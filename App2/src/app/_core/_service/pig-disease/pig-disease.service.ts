import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { PigDisease } from '../../_model/pig-disease';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';

@Injectable({
  providedIn: 'root'
})
export class PigDiseaseService extends CURDService<PigDisease> {
  private pigDiseaseSource = new BehaviorSubject({} );
  currentPigDisease = this.pigDiseaseSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"PigDisease", utilitiesService);
  }
  changePigDisease(pigDisease) {
    this.pigDiseaseSource.next(pigDisease)
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
