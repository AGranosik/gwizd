import { Component } from '@angular/core';
import { sectionTwoAnimation } from './animations';

@Component({
  selector: 'app-sec-first',
  templateUrl: './sec-first.component.html',
  styleUrls: ['./sec-first.component.scss'],
  animations: [sectionTwoAnimation],
})
export class SecFirstComponent {}
