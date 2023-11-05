// news-main-page.component.ts

import { Component, OnInit } from '@angular/core';
import { News } from 'src/app/models/news';
import { NewsService } from 'src/app/service/news.service';


@Component({
  selector: 'app-news-main-page',
  templateUrl: './news-main-page.component.html',
  styleUrls: ['./news-main-page.component.css'],
})
export class NewsMainPageComponent implements OnInit {
  newsList: News[];

  constructor(private newsService: NewsService) {}

  ngOnInit(): void {
    this.newsList = this.newsService.getNews();
  }
}