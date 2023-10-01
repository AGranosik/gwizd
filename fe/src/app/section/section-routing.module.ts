import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FirstComponent } from './first/first.component';
import { SecondComponent } from './second/second.component';
import { ThirdComponent } from './third/third.component';

const routes: Routes = [
  {
    path: '',
    component: FirstComponent,
    // data: {routes: Object.values(ArchitectureRoutes), mainRoute: 'architecture'},
    children: [
      {
        path: '1',
        component: SecondComponent,
        data: { animation: '1' },
      },
      {
        path: '2',
        component: ThirdComponent,
        data: { animation: '2' },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SectionRoutingModule {}
