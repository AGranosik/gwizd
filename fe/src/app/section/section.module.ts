import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SectionRoutingModule } from './section-routing.module';
import { ThirdComponent } from './third/third.component';
import { FirstComponent } from './first/first.component';
import { SecondComponent } from './second/second.component';

@NgModule({
  declarations: [FirstComponent, SecondComponent, ThirdComponent],
  imports: [CommonModule, SectionRoutingModule],
})
export class SectionModule {}
