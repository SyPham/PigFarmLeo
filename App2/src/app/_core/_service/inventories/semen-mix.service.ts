import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';
import { SemenMix } from '../../_model/inventories';
@Injectable({
  providedIn: 'root'
})
export class SemenMixService extends CURDService<SemenMix> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"SemenMix", utilitiesService);
  }
  getSemenMixes(farmGuid): Observable<any> {
    return this.http.get<any>(`${this.base}SemenMix/GetSemenMixes?farmGuid=${farmGuid}`, {});
  }
}
