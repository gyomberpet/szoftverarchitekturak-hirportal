import { Injectable } from '@angular/core';
import { News } from '../models/news';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments';
import { NewsRequestParams } from '../models/newsRequestParams';

const baseUrl = environment.baseUrl;
@Injectable({
  providedIn: 'root',
})
export class NewsService {
  constructor(private http: HttpClient) {}
  baseUrl: string = `${baseUrl}/news`;

  getNews(requestParams: NewsRequestParams): Observable<News[]> {
    let params = new HttpParams().set(
      'includeImage',
      requestParams.includeImage
    );
    if (requestParams.categoryName)
      params = params.append('categoryName', requestParams.categoryName);
    if (requestParams.searchText)
      params = params.append('searchText', requestParams.searchText);
    if (requestParams.pageIndex)
      params =params.append('pageIndex', requestParams.pageIndex ?? '');
    if (requestParams.pageSize)
      params =params.append('pageSize', requestParams.pageSize ?? '');
    if (requestParams.endDate)
      params =params.append('endDate', requestParams.endDate.toISOString() ?? '');
    
    return this.http.get<News[]>(this.baseUrl, { params: params });
  }

  getNewsById(id: string): Observable<News> {
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
