import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { News } from 'src/app/models/news';
import { NewsService } from 'src/app/service/news.service';

@Component({
  selector: 'app-news-details-page',
  templateUrl: './news-details-page.component.html',  
  styleUrls: ['./news-details-page.component.css'],  
}) 
export class NewsDetailsPageComponent implements OnInit { 
  news: News = new News();
  randomNewsList: News[] = [];  

  constructor(
    private route: ActivatedRoute,
    private router: Router, 
    private newsService: NewsService
  ) {}

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.news = this.newsService.getNewsById(id);
    // Generate a list of 3 random news articles
    this.randomNewsList = this.newsService.generateRandomNewsList(2);
  
  }
}