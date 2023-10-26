import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NewsMainPageComponent } from './components/news-main-page/news-main-page.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'
import { MatMenuModule } from '@angular/material/menu';
import { MatCardModule } from '@angular/material/card';
import { NewsDetailsPageComponent } from './components/news-details-page/news-details-page.component';

import { NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';@NgModule({
  declarations: [
    AppComponent,
    NewsMainPageComponent,
    NavBarComponent,
    NewsDetailsPageComponent
  ],
  imports: [
    BrowserModule,
    NgbPaginationModule, NgbAlertModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    MatCardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
