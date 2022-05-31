import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Vendor } from '../_model/vendor';
import { UtilitiesService } from './utilities.service';
import { CURDService } from './base/CURD.service';
@Injectable({
  providedIn: 'root'
})
export class VendorService extends CURDService<Vendor> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Vendor", utilitiesService);
  }

  getVendors(farmGuid) {
    return this.http.get<any>(`${this.base}Vendor/getVendors?farmGuid=${farmGuid}`, {});
  }
}
