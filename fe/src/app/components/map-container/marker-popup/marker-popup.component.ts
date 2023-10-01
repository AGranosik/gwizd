import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-marker-popup',
  templateUrl: './marker-popup.component.html',
  styleUrls: ['./marker-popup.component.scss'],
  standalone: true,
  imports: [CommonModule, MatDialogModule, MatButtonModule, MatIconModule],
})
export class MarkerPopupComponent implements OnInit {
  public concreteSpecies: any;
  public creationDate: any;
  public description: any;
  public id: any;
  public image: any;
  public incidentType: any;
  public spieciesCategory: any;
  public x: any;
  public y: any;
  public type;
  public icon;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<MarkerPopupComponent>,
    public cdr: ChangeDetectorRef
  ) {
    console.log(this.data);
    if (this.data) {
    }

    setTimeout(() => {
      const {
        concreteSpecies,
        creationDate,
        description,
        id,
        image,
        incidentType,
        spieciesCategory,
        x,
        y,
        type,
      } = this.data;

      this.concreteSpecies = concreteSpecies;
      this.creationDate = creationDate;
      this.description = description;
      this.id = id;
      this.image = image;
      this.incidentType = incidentType;
      this.spieciesCategory = spieciesCategory;
      this.x = x;
      this.y = y;
      this.type = incidentType?.incidentLevel;
      this.icon = this.getIcon();
    });
  }

  public ngOnInit(): void {
    console.log(this.data);
  }

  public getContent(): void {
    console.log(1231414);
    return this.concreteSpecies ? this.concreteSpecies[0] : '';
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  public getIcon(): string {
    if (this.type === 0) {
      return 'pets';
    } else if (this.type === 1) {
      return 'notification_important';
    } else {
      return 'warning';
    }
  }
}
