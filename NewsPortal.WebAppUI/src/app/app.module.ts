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
import { MatDialogModule } from '@angular/material/dialog';
import { NewsDetailsPageComponent } from './components/news-details-page/news-details-page.component';
import { JwtModule } from '@auth0/angular-jwt';


import { NgbPaginationModule, NgbAlertModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DeleteNewsComponent } from './components/delete-news/delete-news.component';import { NewsService } from './service/news.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CreateNewsComponent } from './components/create-news/create-news.component';
import { LoginComponent } from './components/login/login.component';
import { UserTablePageComponent } from './components/user-table-page/user-table-page.component';
import { RegisterComponent } from './components/register/register.component';
import { environment } from './environments';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    NewsMainPageComponent,  
    NavBarComponent,
    NewsDetailsPageComponent,
    DeleteNewsComponent,
    CreateNewsComponent,
    LoginComponent,
    UserTablePageComponent,
    RegisterComponent
  ],
  imports: [
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains : ["localhost:"+ environment.port],
        disallowedRoutes: []
      }
    }),
    NgbModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    NgbPaginationModule, NgbAlertModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    MatCardModule,
    MatDialogModule
  ],
  providers: [NewsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
