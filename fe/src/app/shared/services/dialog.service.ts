import { Injectable, NgZone } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from 'src/app/components/confirm-dialog/confirm-dialog.component';
import { MarkerPopupComponent } from 'src/app/components/map-container/marker-popup/marker-popup.component';

@Injectable({
  providedIn: 'root',
})
export class DialogService {
  constructor(public zone: NgZone, public dialog: MatDialog) {}

  public openMarkerDialog(data): void {
    this.zone.run(() => {
      this.dialog.open(MarkerPopupComponent, {
        maxHeight: '80vh',
        maxWidth: '80vw',
        data,
        panelClass: 'custom-container',
      });
    });
  }

  public openSuccessDialog(callback: any): void {
    this.zone.run(() => {
      this.dialog.open(ConfirmDialogComponent, {
        maxHeight: '80vh',
        maxWidth: '80vw',
        data: {
          callback,
        },
        panelClass: 'custom-container',
      });
    });
  }
}
