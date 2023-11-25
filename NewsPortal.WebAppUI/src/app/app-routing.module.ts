import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewsMainPageComponent } from './components/news-main-page/news-main-page.component';
import { NewsDetailsPageComponent } from './components/news-details-page/news-details-page.component';
import { CreateNewsComponent } from './components/create-news/create-news.component';
import { LoginComponent } from './components/login/login.component';
import { UserTablePageComponent } from './components/user-table-page/user-table-page.component';
import { AdminGuard } from './guard/admin.guard';
import { RegisterComponent } from './components/register/register.component';
import { AuthGuard } from './guard/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'news', pathMatch: 'full' },
  { path: 'news', component: NewsMainPageComponent, canActivate: [AuthGuard] },
  {
    path: 'news/create',
    component: CreateNewsComponent,
    canActivate: [AdminGuard]
  },
  {
    path: 'news/:id',
    component: NewsDetailsPageComponent,
  },
  {
    path: 'news/:id/edit',
    component: CreateNewsComponent,
    canActivate: [AdminGuard]
  },
  { path: '', redirectTo: '/users', pathMatch: 'full' },
  { path: 'users', component: UserTablePageComponent, canActivate: [AdminGuard] },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule {}
