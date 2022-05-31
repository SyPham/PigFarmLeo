import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { OperationResult } from '../../_model/operation.result';
import { PigFarmVectorControl } from '../../_model/pig-farm-vector';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';

@Injectable({
  providedIn: 'root'
})
export class PigFarmVectorControlService extends CURDService<PigFarmVectorControl> {
  private pigFarmVectorcontrolSource = new BehaviorSubject({} );
  currentPigFarmVectorcontrol = this.pigFarmVectorcontrolSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"PigFarmVectorControl", utilitiesService);
  }
  changePigFarmVectorcontrol(pigFarmVectorcontrol) {
    this.pigFarmVectorcontrolSource.next(pigFarmVectorcontrol)
  }
  toggleRecordDate(id): Observable<OperationResult> {
    return this.http.get<OperationResult>(`${this.base}PigFarmVectorControl/ToggleRecordDate?id=${id}`, {});
  }
}
