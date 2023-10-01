import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { format } from 'date-fns';

@Injectable({
  providedIn: 'root',
})
export class QueryService {
  api = 'https://hackyeah.azurewebsites.net/WeatherForecast ';
  constructor(private http: HttpClient) {}

  public testConnection(): Observable<any> {
    return this.http.get(this.api);
  }

  public postImg(image: any): Observable<any> {
    const data = { image: image };

    const incidentApi = 'https://hackyeah.azurewebsites.net/Incident';
    return this.http.post(incidentApi, data);
  }

  public postPoint(
    x,
    y,
    spieciesCategory,
    concreteSpecies,
    type,
    incidentLevel,
    description,
    image
  ): Observable<any> {
    const incidentType = {
      incidentLevel,
      type,
    };
    const data = {
      x: x + this.getOffset(),
      y: y + this.getOffset(),
      spieciesCategory,
      concreteSpecies,
      incidentType,
      description,
      image,
      creationDate: new Date().toISOString(),
    };

    const incidentApi = 'https://hackyeah.azurewebsites.net/Incident/add';
    return this.http.post(incidentApi, data);
  }

  public getPoints(): Observable<any> {
    const incidentApi = 'https://hackyeah.azurewebsites.net/Incident';
    return this.http.get(incidentApi);
  }

  public getPointById(id: string): Observable<any> {
    const incidentApi = `https://hackyeah.azurewebsites.net/Incident/byId?id=${id}`;
    return this.http.get(incidentApi);
  }

  public getOffset() {
    const odd = Math.random() >= 0.5;

    return odd ? this.getRandom() : -this.getRandom();
  }

  public getRandom(): number {
    return Math.floor(Math.random() * 10) / 1000;
  }
}
