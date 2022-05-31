import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CURDService } from './base/CURD.service';
import { UtilitiesService } from './utilities.service';
import { Medicine } from '../_model/medicine';
@Injectable({
  providedIn: 'root'
})
export class MedicineService extends CURDService<Medicine> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Medicine", utilitiesService);
  }

}
