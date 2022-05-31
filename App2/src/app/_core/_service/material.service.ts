import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Material } from '../_model/material';
import { UtilitiesService } from './utilities.service';
import { CURDService } from './base/CURD.service';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class MaterialService extends CURDService<Material> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Material", utilitiesService);
  }
  getMaterials(farmGuid): Observable<any> {
    return this.http.get<any>(`${this.base}Material/GetMaterials?farmGuid=${farmGuid}`, {});
  }
}
