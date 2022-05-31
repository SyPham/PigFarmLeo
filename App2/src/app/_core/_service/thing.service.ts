import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Thing } from '../_model/thing';
import { UtilitiesService } from './utilities.service';
import { CURDService } from './base/CURD.service';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ThingService extends CURDService<Thing> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Thing", utilitiesService);
  }
  getThings(farmGuid): Observable<any> {
    return this.http.get<any>(`${this.base}Thing/GetThings?farmGuid=${farmGuid}`, {});
  }
}
