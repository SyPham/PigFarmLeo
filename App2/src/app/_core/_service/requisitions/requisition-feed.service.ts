import { HttpClient } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { BehaviorSubject } from 'rxjs';
  import { RequisitionFeed } from '../../_model/requisitions';
  import { CURDService } from '../base/CURD.service';
  import { UtilitiesService } from '../utilities.service';


  @Injectable({
    providedIn: 'root'
  })
  export class RequisitionFeedService extends CURDService<RequisitionFeed> {
    private biosSource = new BehaviorSubject({} );
    currentRequisitionFeed = this.biosSource.asObservable();
    constructor( http: HttpClient,utilitiesService: UtilitiesService)
    {
      super(http,"RequisitionFeed", utilitiesService);
    }
    changeRequisitionFeed(farm) {
      this.biosSource.next(farm)
    }
    // toggleIsDefault(id): Observable<OperationResult> {
    //   return this.http.put<OperationResult>(`${this.base}BOM/ToggleIsDefault?id=${id}`, {}).pipe(
    //     catchError(this.handleError)
    //   );
    // }
  }
