import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CURDService } from './base/CURD.service';
import { UtilitiesService } from './utilities.service';
import { Disinfection } from '../_model/disinfection';
@Injectable({
  providedIn: 'root'
})
export class DisinfectionService extends CURDService<Disinfection> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Disinfection", utilitiesService);
  }

}
