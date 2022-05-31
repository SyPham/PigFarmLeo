import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Semen } from '../../_model/inventories';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';
@Injectable({
  providedIn: 'root'
})
export class SemenService extends CURDService<Semen> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Semen", utilitiesService);
  }
  getSemens(farmGuid): Observable<any> {
    return this.http.get<any>(`${this.base}Semen/GetSemens?farmGuid=${farmGuid}`, {});
  }
}
