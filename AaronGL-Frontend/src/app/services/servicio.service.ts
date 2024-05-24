import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BitacoraSalesInterface, SaleDataRequestInterface, SalesDataInterface } from '../interfaces/sales-data-interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServicioService {
  private base_url:string = "http://localhost:5254/api/Bitacora";

  constructor(private http: HttpClient) { }

  public getAllSales():Observable<BitacoraSalesInterface []> {
    return this.http.get<BitacoraSalesInterface[]>(this.base_url);
  }

  public getSaleById(id:number) {
    return this.http.get(`${this.base_url}/${id}`);
  }

  public setSale(sale:SalesDataInterface):Observable<SalesDataInterface> {
    return this.http.post<SalesDataInterface>(`${this.base_url}`, sale);
  }

  public getSalesAPI(saleDataRequest: SaleDataRequestInterface):Observable<BitacoraSalesInterface[]> {
    console.log("[request payload]: " + JSON.stringify(saleDataRequest));

    return this.http.post<BitacoraSalesInterface[]>(`${this.base_url}/report`, saleDataRequest);
  }


}
