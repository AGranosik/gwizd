import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthHttpInterceptor, AuthModule } from '@auth0/auth0-angular';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';

import { MatCardModule } from '@angular/material/card';
import { LayoutComponent } from './components/layout/layout.component';
import { SectionModule } from './section/section.module';
import { CategoryComponent } from './components/category/category.component';
import { CategoryTwoComponent } from './components/category-two/category-two.component';
import { SectionTwoModule } from './section-two/section-two.module';
import { HomeComponent } from './components/home/home.component';
import { CardComponent } from './shared/components/card/card.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ServiceWorkerModule } from '@angular/service-worker';
import { NavbarComponent } from './components/navbar/navbar.component';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { AuthComponent } from './components/auth/auth.component';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { LeafletModule } from '@asymmetrik/ngx-leaflet';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';

import { MapContainerComponent } from './components/map-container/map-container.component';
import { MarkerPopupComponent } from './components/map-container/marker-popup/marker-popup.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';

import { CameraComponent } from './components/camera/camera.component';
import { WebcamModule } from 'ngx-webcam';
import { AddComponent } from './components/add/add.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';

const matModules = [
  MatButtonModule,
  MatCardModule,
  MatIconModule,
  MatInputModule,
  MatProgressSpinnerModule,
  MatDialogModule,
  MatFormFieldModule,
  MatGridListModule,
  MatSelectModule,
  MatAutocompleteModule,
];

const standalone = [CardComponent];
@NgModule({
  declarations: [
    AppComponent,
    CategoryComponent,
    CategoryTwoComponent,
    LayoutComponent,
    HomeComponent,
    NavbarComponent,
    MapContainerComponent,
    AuthComponent,
    CameraComponent,
    AddComponent,
  ],
  imports: [
    BrowserModule,
    LeafletModule,
    AppRoutingModule,
    CommonModule,
    SectionModule,
    WebcamModule,
    SectionTwoModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ...matModules,
    ...standalone,
    AuthModule.forRoot({
      domain: 'dev-b8sfyb91.us.auth0.com',
      clientId: 'Z5yAH5junMOuqG3RgJLdX6kqc95MNajA',
      authorizationParams: {
        redirect_uri: window.location.origin,
      },
    }),
    ServiceWorkerModule.register('ngsw-worker.js', {
      enabled: !isDevMode(),
      registrationStrategy: 'registerWhenStable:30000',
    }),
  ],

  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthHttpInterceptor, multi: true },
    {
      provide: MatDialogRef,
      useValue: {},
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
