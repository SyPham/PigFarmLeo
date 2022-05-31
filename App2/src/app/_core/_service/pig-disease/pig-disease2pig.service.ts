﻿import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { PigDisease2pig } from '../../_model/pig-disease';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';

@Injectable({
  providedIn: 'root'
})
export class PigDisease2pigService extends CURDService<PigDisease2pig> {
  private pigDisease2pigSource = new BehaviorSubject({} );
  currentPigDisease2pig = this.pigDisease2pigSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"PigDisease2pig", utilitiesService);
  }
  changePigDisease2pig(pigDisease2pig) {
    this.pigDisease2pigSource.next(pigDisease2pig)
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
