import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CURDService } from './base/CURD.service';
import { UtilitiesService } from './utilities.service';
import { Nutrition } from '../_model/nutrition';
@Injectable({
  providedIn: 'root'
})
export class NutritionService extends CURDService<Nutrition> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Nutrition", utilitiesService);
  }

}
