import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { HierarchyNode, OC } from '../_model/oc';
import { UtilitiesService } from './utilities.service';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    Authorization: 'Bearer ' + localStorage.getItem('token')
  })
};
@Injectable({
  providedIn: 'root'
})
export class OcService {
  baseUrl = environment.apiUrl;
  messageSource = new BehaviorSubject<number>(0);
  currentMessage = this.messageSource.asObservable();
  // method này để change source message
  changeMessage(message) {
    this.messageSource.next(message);
  }
  constructor(private http: HttpClient, private utilitiesService: UtilitiesService) { }
  delete(id) { return this.http.delete(`${this.baseUrl}Oc/Delete?id=${id}`); }
  rename(edit) { return this.http.post(`${this.baseUrl}Oc/rename`, edit); }
  getOCs() {
    return this.http.get(`${this.baseUrl}Oc/GetListTree`);
  }
  getAll() {
    return this.http.get<any[]>(`${this.baseUrl}Oc/getAll`);
  }
  createMainOC(oc) { return this.http.post(`${this.baseUrl}Oc/createMainOC`, oc); }
  createSubOC(oc) { return this.http.post(`${this.baseUrl}Oc/CreateSubOC`, oc); }
  getOCAsTreeView() {
    return this.http.get<Array<HierarchyNode<OC>>>(`${this.baseUrl}Oc/GetAllAsTreeView`);
  }
  getOCAsTreeViewByFarmID(farmID) {
    return this.http.get<Array<HierarchyNode<OC>>>(`${this.baseUrl}Oc/GetAllAsTreeViewByFarm?farmID=${farmID}`);
  }
  getFarms() {
    return this.http.get<any>(`${this.baseUrl}Oc/getFarms`);
  }
  update(model) {
    const file = model.file;
    delete model.file;
    const params = this.utilitiesService.ToFormData(model);
    params.append("file", file);
    return this.http.put(`${this.baseUrl}Oc/update`, params);
   }
  createMainOCForm(model: OC): Observable<any> {

    const file = model.file;
    delete model.file;
    const params = this.utilitiesService.ToFormData(model);
    params.append("file", file);
    return this.http.post<any>(`${this.baseUrl}Oc/createMainOCForm`, params);
  }
  createSubOCForm(model: OC): Observable<any> {

    const file = model.file;
    delete model.file;
    const params = this.utilitiesService.ToFormData(model);
    params.append("file", file);
    return this.http.post<any>(`${this.baseUrl}Oc/CreateSubOCForm`, params);
  }
}
