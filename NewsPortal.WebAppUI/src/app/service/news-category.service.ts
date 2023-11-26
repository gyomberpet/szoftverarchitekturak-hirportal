import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments';
import { NewsCategory } from '../models/newsCategory';

const baseUrl = environment.baseUrl;
@Injectable({
  providedIn: 'root',
})
export class NewsCategoryService {
  constructor(private http: HttpClient) {}
  baseUrl: string = `${baseUrl}/newscategories`;
  
  getCategories(): Observable<NewsCategory[]> {
    return this.http.get<NewsCategory[]>(this.baseUrl);
  }

  addNewCategory(category: NewsCategory): Observable<NewsCategory> {
    return this.http.post<NewsCategory>(this.baseUrl, category);
  }
}