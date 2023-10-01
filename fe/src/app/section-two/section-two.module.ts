import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SecFirstComponent } from './sec-first/sec-first.component';
import { SecSecondComponent } from './sec-second/sec-second.component';
import { SecThirdComponent } from './sec-third/sec-third.component';
import { SectionTwoRoutingModule } from './section-two-routing.module';
import { MatButtonModule } from '@angular/material/button';

const matModules = [MatButtonModule];

@NgModule({
  declarations: [SecFirstComponent, SecSecondComponent, SecThirdComponent],
  imports: [CommonModule, SectionTwoRoutingModule, ...matModules],
})
export class SectionTwoModule {}
