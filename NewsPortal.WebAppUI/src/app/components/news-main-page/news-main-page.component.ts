// news-main-page.component.ts

import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged, fromEvent, tap } from 'rxjs';
import { News } from 'src/app/models/news';
import { NewsRequestParams } from 'src/app/models/newsRequestParams';
import { NewsService } from 'src/app/service/news.service';
import { UsersService } from 'src/app/service/users.service';

@Component({
  selector: 'app-news-main-page',
  templateUrl: './news-main-page.component.html',
  styleUrls: ['./news-main-page.component.css'],
})
export class NewsMainPageComponent implements OnInit, AfterViewInit {
  @ViewChild('search') search: ElementRef;

  newsList: News[];


  constructor(private newsService: NewsService, private usersService:UsersService) {}

  ngOnInit(): void {
    let requestParams: NewsRequestParams = {
      includeImage: true,
      endDate: new Date()
    } as NewsRequestParams;   

    this.fetchData(requestParams);
  }

  ngAfterViewInit(): void {
    this.subscribeToKeyUpEvent(this.search);
  }

  subscribeToKeyUpEvent(elementRef: ElementRef) {
    fromEvent(elementRef.nativeElement, 'keyup')
      .pipe(
        debounceTime(500),
        distinctUntilChanged(),
        tap(() => {
          let params: NewsRequestParams = {
            includeImage: true,
            searchText: this.search.nativeElement.value
          } as NewsRequestParams;   
          this.fetchData(params)
        })
      )
      .subscribe();
  }

  fetchData(requestParams: NewsRequestParams){
    this.newsService
      .getNews(requestParams)
      .subscribe({
        next: (res: News[]) => (this.newsList = res),
        error: (err) => console.error(err),
      });
  }
}
