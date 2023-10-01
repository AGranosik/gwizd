import { Injectable } from '@angular/core';
import { DeviceDetectorService } from 'ngx-device-detector';
import { Observable, from } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  public isMobile: boolean = false;
  public currentPosition: any;

  constructor(public detector: DeviceDetectorService) {
    this.isMobile = this.detector.isMobile();
  }

  getPosition(): Observable<any> {
    return from(
      new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(
          (resp) => {
            resolve({ lng: resp.coords.longitude, lat: resp.coords.latitude });
          },
          (err) => {
            reject(err);
          }
        );
      })
    );
  }
}
