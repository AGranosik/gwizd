import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryComponent } from './components/category/category.component';
import { CategoryTwoComponent } from './components/category-two/category-two.component';
import { HomeComponent } from './components/home/home.component';
import { CameraComponent } from './components/camera/camera.component';
import { AuthComponent } from './components/auth/auth.component';
import { AuthGuard } from '@auth0/auth0-angular';
import { MapContainerComponent } from './components/map-container/map-container.component';
import { AddComponent } from './components/add/add.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    data: { animation: '0' },
  },
  {
    path: '1',
    loadChildren: () =>
      import('./section/section.module').then((m) => m.SectionModule),
    data: { animation: '1' },
  },
  {
    path: '2',
    loadChildren: () =>
      import('./section-two/section-two.module').then(
        (m) => m.SectionTwoModule
      ),
    data: { animation: '2' },
  },
  {
    path: 'map',
    component: MapContainerComponent,
    data: { animation: '3' },
  },
  {
    path: 'camera',
    component: CameraComponent,
    data: { animation: '4' },
  },
  {
    path: 'add',
    component: AddComponent,
    data: { animation: '4' },
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
