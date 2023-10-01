import { Component, Input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';

import { CommonModule } from '@angular/common';
import { DataService } from '../../services/data.service';
import { Dialog } from '@angular/cdk/dialog';
import { MarkerPopupComponent } from 'src/app/components/map-container/marker-popup/marker-popup.component';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'card',
  standalone: true,
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss'],
  imports: [CommonModule, MatCardModule, MatIconModule, MatButtonModule],
})
export class CardComponent {
  @Input() header: string;
  @Input() icon: string;
  @Input() iconLeft: boolean = false;
  @Input() iconRight: boolean = false;
  @Input() column: boolean = false;
  @Input() content: boolean = false;

  openDialog(): void {
    this.dialog.open(MarkerPopupComponent);
  }
  constructor(public data: DataService, public dialog: Dialog) {}
}
