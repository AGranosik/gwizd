import { Component, OnInit } from '@angular/core';

import { slideInAnimation } from './animations';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
  animations: [slideInAnimation],
})
export class LayoutComponent implements OnInit {
  constructor(public data: DataService) {}

  ngOnInit(): void {
    console.log('On mobile:', this.data.isMobile);
  }
}
