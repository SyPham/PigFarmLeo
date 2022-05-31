import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CURDService } from './base/CURD.service';
import { UtilitiesService } from './utilities.service';
import { FeedMaterial } from '../_model/feed-material';
@Injectable({
  providedIn: 'root'
})
export class FeedMaterialService extends CURDService<FeedMaterial> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"FeedMaterial", utilitiesService);
  }

}
