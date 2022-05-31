import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CURDService } from './base/CURD.service';
import { UtilitiesService } from './utilities.service';
import { Feed } from '../_model/feed';
@Injectable({
  providedIn: 'root'
})
export class FeedService extends CURDService<Feed> {

  constructor(http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Feed", utilitiesService);
  }

}
