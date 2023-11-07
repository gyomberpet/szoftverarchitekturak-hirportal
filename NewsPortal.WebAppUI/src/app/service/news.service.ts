import { Injectable } from '@angular/core';
import { News } from '../models/news';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments';

const baseUrl = environment.baseUrl;
@Injectable({
  providedIn: 'root',
})
export class NewsService {
  constructor(private http: HttpClient) {}
  baseUrl: string = `${baseUrl}/news`;

  getNews(): Observable<News[]> {
    return this.http.get<News[]>(this.baseUrl);
  }

  getNewsById(id: number): Observable<News> {
    const url = `${this.baseUrl}/${id}`;

    return this.http.get<News>(url);
  }

  getRandomNewsByCategory(
    category: string,
    amount: number
  ): Observable<News[]> {
    const url = `${this.baseUrl}/random/${category}/${amount}`;

    return this.http.get<News[]>(url);
  }

  getNewsByCategory(category: string): Observable<News[]> {
    const url = `${this.baseUrl}/category/${category}`;

    return this.http.get<News[]>(url);
  }

  createNews(news: News): Observable<News> {
    console.log(news);
    return this.http.post<News>(this.baseUrl, news, {
      headers: { 'Content-Type': 'application/json' },
    });
  }

  updateNews(news: News): Observable<News> {
    return this.http.put<News>(this.baseUrl, news);
  }

  deleteeNews(id: string): Observable<boolean> {
    const url = `${this.baseUrl}/${id}`;

    return this.http.delete<boolean>(url);
  }
}
