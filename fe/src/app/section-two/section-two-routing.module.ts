import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SecFirstComponent } from './sec-first/sec-first.component';
import { SecSecondComponent } from './sec-second/sec-second.component';
import { SecThirdComponent } from './sec-third/sec-third.component';

const routes: Routes = [
  {
    path: '',
    component: SecFirstComponent,
    // data: {routes: Object.values(ArchitectureRoutes), mainRoute: 'architecture'},
    children: [
      {
        path: '1',
        component: SecSecondComponent,
        data: { animation: '21' },
      },
      {
        path: '2',
        component: SecThirdComponent,
        data: { animation: '22' },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SectionTwoRoutingModule {}
