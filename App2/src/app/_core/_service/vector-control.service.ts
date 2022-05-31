import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CURDService } from './base/CURD.service';
import { UtilitiesService } from './utilities.service';
import { VectorControl } from '../_model/vector-control';
@Injectable({
  providedIn: 'root'
})
export class VectorControlService extends CURDService<VectorControl> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"VectorControl", utilitiesService);
  }

}
