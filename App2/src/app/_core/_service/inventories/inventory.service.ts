import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Inventory } from '../../_model/inventories';
import { CURDService } from '../base/CURD.service';
import { UtilitiesService } from '../utilities.service';


@Injectable({
  providedIn: 'root'
})
export class InventoryService extends CURDService<Inventory> {
  private biosSource = new BehaviorSubject({} );
  currentInventory = this.biosSource.asObservable();
  constructor( http: HttpClient,utilitiesService: UtilitiesService)
  {
    super(http,"Inventory", utilitiesService);
  }
  changeInventory(farm) {
    this.biosSource.next(farm)
  }
  getToInventories(farmGuid): Observable<any> {
    return this.http.get<any>(`${this.base}Inventory/GetToInventories?farmGuid=${farmGuid}`, {});
  }
}
