import { Component } from '@angular/core';
import { sectionFirstAnimation } from './animations';

@Component({
  selector: 'first',
  templateUrl: './first.component.html',
  styleUrls: ['./first.component.scss'],
  animations: [sectionFirstAnimation],
})
export class FirstComponent {}
