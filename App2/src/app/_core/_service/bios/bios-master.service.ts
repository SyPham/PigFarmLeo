
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { BioSMaster } from '../../_model/bios';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';


@Injectable({
  providedIn: 'root'
})
export class BioSMasterService extends CURDService<BioSMaster> {
  private biosSource = new BehaviorSubject({} );
  currentBioSMaster = this.biosSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"BioSMaster", utilitiesService);
  }
  changeBioSMaster(farm) {
    this.biosSource.next(farm)
  }
  getOrders(farmGuid) {
    return this.http.get(`${this.base}BioSMaster/GetOrders?farmGuid=${farmGuid}`, {});
  }
}
