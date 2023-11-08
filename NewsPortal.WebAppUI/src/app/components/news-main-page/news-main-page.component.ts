// news-main-page.component.ts

import { Component, OnInit } from '@angular/core';
import { News } from 'src/app/models/news';
import { NewsRequestParams } from 'src/app/models/newsRequestParams';
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
    let requestParams: NewsRequestParams = {
      includeImage: true,
    } as NewsRequestParams;

    this.newsService
      .getNews(requestParams)
      .subscribe({
        next: (res: News[]) => (this.newsList = res),
        error: (err) => console.error(err),
      });
  }
}
