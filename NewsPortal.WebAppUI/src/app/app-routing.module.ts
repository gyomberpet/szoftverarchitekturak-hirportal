import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewsMainPageComponent } from './components/news-main-page/news-main-page.component';
import { NewsDetailsPageComponent } from './components/news-details-page/news-details-page.component';

const routes: Routes = [ 
{ path: '', redirectTo: 'news', pathMatch: 'full' },
{path:'news',component:NewsMainPageComponent},
{
  path: 'news/:id',
  component: NewsDetailsPageComponent,
},
{
  path: 'news/:id/edit',
  component: NewsMainPageComponent
},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
