// news-main-page.component.ts

import { Component, OnInit } from '@angular/core';
import { News } from 'src/app/models/news';
import { NewsService } from 'src/app/service/news.service';
import { UsersService } from 'src/app/service/users.service';

@Component({
  selector: 'app-news-main-page',
  templateUrl: './news-main-page.component.html',
  styleUrls: ['./news-main-page.component.css'],
})
export class NewsMainPageComponent implements OnInit {
  newsList: News[];

  constructor(private newsService: NewsService, private usersService:UsersService) {}

  ngOnInit(): void {
    this.newsService
      .getNews()
      .subscribe({
        next: (res: News[]) => (this.newsList = res),
        error: (err) => console.error(err),
      });
  }
}
