import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class IPFSService {
  constructor(private http: HttpClient) { }

  public manifestAgreement(data): Promise<any> {
    return this.http.post("/api/fares/manifestAgreement/", "{}")
      .toPromise();
  }
  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
  
}
