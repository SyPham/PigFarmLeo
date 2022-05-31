﻿import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { PigFarmVectorPlan } from '../../_model/pig-farm-vector';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';

@Injectable({
  providedIn: 'root'
})
export class PigFarmVectorPlanService extends CURDService<PigFarmVectorPlan> {
  private pigFarmVectorPlanSource = new BehaviorSubject({} );
  currentPigFarmVectorPlan = this.pigFarmVectorPlanSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"PigFarmVectorPlan", utilitiesService);
  }
  changePigFarmVectorPlan(pigFarmVectorPlan) {
    this.pigFarmVectorPlanSource.next(pigFarmVectorPlan)
  }
  // toggleIsDefault(id): Observable<OperationResult> {
  //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
  //     catchError(this.handleError)
  //   );
  // }
}
