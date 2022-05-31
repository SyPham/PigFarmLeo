import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { UtilitiesService } from './utilities.service';
import { CURDService } from './base/CURD.service';
import { RecordInOut } from '../_model/record-in-out';
@Injectable({
  providedIn: 'root'
})
export class RecordInOutService extends CURDService<RecordInOut> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"RecordInOut", utilitiesService);
  }
  getCheckedData(inOutGuid) {
    return this.http.get<string[]>(`${this.base}RecordInOut/GetCheckedData?inOutGuid=${inOutGuid}`, {});
  }
}
