import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Fare } from '../pages/fares/fares.models';

@Injectable()
export class EthereumService {

  constructor(private http: HttpClient) { }

  public getAllFares(): Promise<Fare[]> {
    return this.http.get('/api/fares')
        .toPromise()
        .catch(e => this.handleError(e));
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}
