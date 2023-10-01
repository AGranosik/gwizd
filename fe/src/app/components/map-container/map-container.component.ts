import { Dialog } from '@angular/cdk/dialog';
import {
  Component,
  ViewChildren,
  QueryList,
  OnInit,
  NgZone,
} from '@angular/core';
import * as Leaflet from 'leaflet';
import { MarkerPopupComponent } from './marker-popup/marker-popup.component';
import { MatDialog } from '@angular/material/dialog';
import { Observable, from } from 'rxjs';
import { DataService } from 'src/app/shared/services/data.service';
import { QueryService } from 'src/app/http/query.service';
import { DialogService } from 'src/app/shared/services/dialog.service';

Leaflet.Icon.Default.imagePath = 'assets/';

Leaflet.Icon.Default.imagePath = 'assets/';

@Component({
  selector: 'app-map-container',
  templateUrl: './map-container.component.html',
  styleUrls: ['./map-container.component.scss'],
})
export class MapContainerComponent implements OnInit {
  map!: Leaflet.Map;
  markers: Leaflet.Marker[] = [];
  options = null;

  ngOnInit(): void {
    this.dataService.getPosition().subscribe((data: any) => {
      this.dataService.currentPosition = data;

      const { lat, lng } = this.dataService.currentPosition;

      this.options = {
        layers: [
          Leaflet.tileLayer(
            'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
            {
              attribution:
                '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a>',
            }
          ),
        ],
        zoom: 16,
        center: { lat, lng },
      };
    });
  }

  initMarkers() {
    // const initialMarkers = [
    //   {
    //     position: { lat: 28.625485, lng: 79.821091 },
    //     draggable: true,
    //   },
    //   {
    //     position: { lat: 28.625293, lng: 79.817926 },
    //     draggable: false,
    //   },
    //   {
    //     position: { lat: 28.625182, lng: 79.81464 },
    //     draggable: true,
    //   },
    // ];
    // for (let index = 0; index < initialMarkers.length; index++) {
    //   const data = initialMarkers[index];
    //   this.addMarker(data.position.lat, data.position.lng);
    // }
  }

  addMarker(lat: number, lng: number, type: any, id?: string): void {
    const data = {
      position: { lat, lng },
      draggable: false,
      id,
    };

    let icon;

    const marker = this.generateMarker(data);

    if (type === 'user') {
      icon = this.getUserIcon();
    } else if (type === 0) {
      icon = this.getPetsIcon(id);
    } else if (type === 1) {
      icon = this.getWarningIcon(id);
    } else {
      icon = this.getDangerIcon(id);
    }

    marker.addTo(this.map).setIcon(icon);
    // .bindPopup(`<b>${data.position.lat},  ${data.position.lng}</b>`);
    // this.map.panTo(data.position);
    this.markers.push(marker);
  }

  generateMarker(data: any) {
    return Leaflet.marker(data.position, { draggable: data.draggable })
      .on('click', (event) => this.markerClicked(event))
      .on('dragend', (event) => this.markerDragEnd(event));
  }

  onMapReady($event: Leaflet.Map) {
    this.map = $event;

    this.addMarker(
      this.dataService.currentPosition.lat,
      this.dataService.currentPosition.lng,
      'user'
    );

    this.queryService.getPoints().subscribe((points: any) => {
      console.log(points);
      points.forEach((point) => {
        if (point.x !== this.dataService.currentPosition.lat) {
          // const type = point.
          this.addMarker(
            point.x,
            point.y,
            point.incidentType.incidentLevel,
            point.id
          );
        }
      });
    });
  }

  mapClicked($event: any) {
    console.log($event.latlng.lat, $event.latlng.lng);
  }

  markerClicked($event: any) {
    console.log($event);
    const id = $event?.target?.options?.icon?.id;

    if (id) {
      this.queryService.getPointById(id).subscribe((data) => {
        this.dialogService.openMarkerDialog(data);
      });
    }
  }

  markerDragEnd($event: any) {
    console.log($event.target.getLatLng());
  }

  constructor(
    private dialogService: DialogService,
    private dataService: DataService,
    private queryService: QueryService,
    private zone: NgZone
  ) {}

  private getUserIcon(): any {
    return Leaflet.divIcon({
      className: 'custom-div-icon blinking',
      html: "<div style='background-color:#8bc34a;' class='marker-pin '></div><i class='material-icons'>person_pin</i>",
      iconSize: [30, 42],
      iconAnchor: [15, 42],
    });
  }

  private getPetsIcon(id: string): any {
    const icon: any = Leaflet.divIcon({
      className: 'custom-div-icon',
      html: "<div style='background-color:#8bc34a;' class='marker-pin '></div><i class='material-icons'>pets</i>",
      iconSize: [30, 42],
      iconAnchor: [15, 42],
    });

    icon.id = id;
    return icon;
  }

  private getWarningIcon(id: string): any {
    const icon: any = Leaflet.divIcon({
      className: 'custom-div-icon',
      html: "<div style='background-color:#FFFF66;' class='marker-pin '></div><i class='material-icons'>notification_important</i>",
      iconSize: [30, 42],
      iconAnchor: [15, 42],
    });

    icon.id = id;
    return icon;
  }

  private getDangerIcon(id: string): any {
    const icon: any = Leaflet.divIcon({
      className: 'custom-div-icon',
      html: "<div style='background-color:#f44336;' class='marker-pin '></div><i class='material-icons'>warning</i>",
      iconSize: [30, 42],
      iconAnchor: [15, 42],
    });

    icon.id = id;
    return icon;
  }
}
