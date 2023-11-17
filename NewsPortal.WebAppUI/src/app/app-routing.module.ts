import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewsMainPageComponent } from './components/news-main-page/news-main-page.component';
import { NewsDetailsPageComponent } from './components/news-details-page/news-details-page.component';
import { CreateNewsComponent } from './components/create-news/create-news.component';
import { LoginComponent } from './login/login.component';
import { UserTablePageComponent } from './components/user-table-page/user-table-page.component';

const routes: Routes = [
  { path: '', redirectTo: 'news', pathMatch: 'full' },
  { path: 'news', component: NewsMainPageComponent },
  {
    path: 'news/create',
    component: CreateNewsComponent,
  },
  {
    path: 'news/:id',
    component: NewsDetailsPageComponent,
  },
  {
    path: 'news/:id/edit',
    component: NewsMainPageComponent,
  },
  { path: '', redirectTo: '/users', pathMatch: 'full' },
  { path: 'users', component: UserTablePageComponent },
  {
    path: 'login',
    component: LoginComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
