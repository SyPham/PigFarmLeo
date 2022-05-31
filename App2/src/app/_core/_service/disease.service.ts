import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CURDService } from './base/CURD.service';
import { UtilitiesService } from './utilities.service';
import { Disease } from '../_model/disease';
@Injectable({
  providedIn: 'root'
})
export class DiseaseService extends CURDService<Disease> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Disease", utilitiesService);
  }

}
