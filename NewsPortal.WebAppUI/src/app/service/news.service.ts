import { Inject, Injectable } from '@angular/core';
import { News } from '../models/news';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NewsService {
  private TEMP_NEWS: News[] = [

      {
        id:0,
        title: 'Earthquake Shakes California',
        subtitle: 'Residents Urged to Stay Safe',
        category: 'Natural Disasters',
        description:
          'A magnitude 5.5 earthquake rattled Southern California, causing minor damage to some buildings. Authorities are urging residents to remain cautious and prepared for potential aftershocks.',
        imageUrl: 'https://picsum.photos/500/500',
        publishedAt:'1999-09-24',
        expiredAt:'1999-09-24',
        createBy:"PP",
        isTrending: false,
      },
      {
        id:1,
        title: 'New COVID-19 Variant Detected',
        subtitle: 'Health Officials Monitor Situation',
        category: 'Health',
        description:
          'A new variant of the COVID-19 virus has been identified in several countries. Health officials are closely monitoring the situation and advising continued vaccination efforts.',
        imageUrl: 'https://picsum.photos/600/600',
        publishedAt:'1999-09-24',
        expiredAt:'1999-09-24',
        createBy:"PP",
        isTrending: false,
      },
      {id:2,
        title: 'Tech Giant Launches New Smartphone',
        subtitle: 'Features High-Resolution Camera',
        category: 'Technology',
        description:
          'Tech enthusiasts rejoice as the leading tech company unveils its latest smartphone model, featuring a high-resolution camera and advanced AI capabilities.',
        imageUrl: 'https://picsum.photos/700/700',
        publishedAt:'1999-09-24',
        expiredAt:'1999-09-24',
        createBy:"PP",
        isTrending: false,
      },
      {id:3,
        title: 'Record-Breaking Heatwave Hits Europe',
        subtitle: 'Heatwave Expected to Last',
        category: 'Weather',
        description:
          'Europe is sweltering under an unprecedented heatwave, with temperatures soaring above 100°F. Meteorologists predict the heatwave will persist for the next several days.',
        imageUrl: 'https://picsum.photos/800/800',
        publishedAt:'1999-09-24',
        expiredAt:'1999-09-24',
        createBy:"PP",
        isTrending: false,
      },
      {id:4,
        title: 'Olympic Games Begin in Tokyo',
        subtitle: 'Athletes Gear Up for Competition',
        category: 'Sports',
        description:
          'The Tokyo Olympics officially kick off, with athletes from around the world ready to compete in various sports events, albeit under the shadow of COVID-19 precautions.',
        imageUrl: 'https://picsum.photos/900/900',
        publishedAt:'1999-09-24',
        expiredAt:'1999.09.24',
        createBy:"PP",
        isTrending: false,
      },
    
  ];
  generateRandomNewsList(count: number): News[] {
    const randomNewsList: News[] = [];
    for (let i = 0; i < count; i++) {
      const randomIndex = Math.floor(Math.random() * this.TEMP_NEWS.length);
      randomNewsList.push(this.TEMP_NEWS[randomIndex]);
    }
    return randomNewsList;
  }
  getNews(): News[] {
    return this.TEMP_NEWS;
  }

  getNewsById(id: number): News {
    return this.TEMP_NEWS.find((news) => news.id === id) || new News();
  }
/*
  public news: News[] = [];

  private _http: HttpClient;
  private _baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseurl: string) {
      this._http = http;
      this._baseUrl = baseurl;
  }

  getAllSections(id: number): Observable<News[]> {
      return this._http.get<News[]>(this._baseUrl + `section/getall?conferenceId=${id}`);
  }

  createSection(section: News): Observable<News> {
      return this._http.post<News>(this._baseUrl + 'section', section);
  }

  removeSection(sectionId: number): any{
      return this._http.delete<News>(this._baseUrl + `section/delete?id=${sectionId}`);
  }*/
}