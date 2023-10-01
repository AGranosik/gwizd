import { CommonModule } from '@angular/common';
import { Component, HostListener } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { WebcamModule } from 'ngx-webcam';
import { Observable, Subject } from 'rxjs';
import { CardComponent } from '../../shared/components/card';
import { QueryService } from 'src/app/http/query.service';
import { Router } from '@angular/router';
import { DialogService } from 'src/app/shared/services/dialog.service';

@Component({
  selector: 'camera',
  templateUrl: './camera.component.html',
  styleUrls: ['./camera.component.scss'],
})
export class CameraComponent {
  public trigger: Subject<void> = new Subject<void>();
  imageTaken: null;
  width: number;
  height: number;

  @HostListener('window:resize', ['$event'])
  onResize(event?: Event) {
    const win = !!event ? (event.target as Window) : window;
    this.width = win.innerWidth;
    this.height = win.innerHeight;
  }

  constructor(
    public queryService: QueryService,
    public router: Router,
    public dialogService: DialogService
  ) {
    this.onResize();
  }

  public onImageCapture(event) {
    this.imageTaken = event.imageAsBase64;
    console.log(event);
    this.queryService.postImg(this.imageTaken).subscribe((data) => {
      this.router.navigate(['/add'], {
        state: {
          concreteSpecies: data?.concreteSpecies ?? [],
          spieciesCategory: data?.spieciesCategory ?? [],
          incidentType: data?.incidentType,
          image: this.imageTaken,
        },
      });
    });
  }

  public handleInitError($event): void {
    console.log($event);
  }

  public importFile($event) {
    const file = $event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      const result = reader.result.slice(23);
      this.imageTaken = result as any;
      this.queryService.postImg(result).subscribe((data) => {
        this.router.navigate(['/add'], {
          state: {
            concreteSpecies: data?.concreteSpecies ?? [],
            spieciesCategory: data?.spieciesCategory ?? [],
            incidentType: data?.incidentType,
            image: this.imageTaken,
          },
        });
      });
    };
  }
}
