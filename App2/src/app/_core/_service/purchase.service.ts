import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Purchase } from '../_model/purchase';
import { UtilitiesService } from './utilities.service';
import { CURDService } from './base/CURD.service';
@Injectable({
  providedIn: 'root'
})
export class PurchaseService extends CURDService<Purchase> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Purchase", utilitiesService);
  }
}
