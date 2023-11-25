import { Injectable } from '@angular/core';
import { environment } from '../environments';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { LoginInfo } from '../models/loginInfo';
import { LoginResponse } from '../models/loginResponse';

const baseUrl = environment.baseUrl;

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  constructor(private http: HttpClient) {}
  baseUrl: string = `${baseUrl}/users`;

  login(loginInfo: LoginInfo): Observable<LoginResponse> {
    const url = `${this.baseUrl}/login`;

    return this.http.post<LoginResponse>(url, loginInfo);
  }

  register(loginInfo: LoginInfo): Observable<LoginResponse> {
    const url = `${this.baseUrl}/register`;

    return this.http.post<LoginResponse>(url, loginInfo);
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl);
  }

  getUserById(id: number): Observable<User> {
    const url = `${this.baseUrl}/${id}`;

    return this.http.get<User>(url);
  }

  getUserByEmail(email: string): Observable<User> {
    const url = `${this.baseUrl}/email/${email}`;

    return this.http.get<User>(url);
  }

  updateUser(user: User): Observable<User> {
    return this.http.put<User>(this.baseUrl, user);
  }
  

  deleteeUser(id: string): Observable<boolean> {
    const url = `${this.baseUrl}/${id}`;

    return this.http.delete<boolean>(url);
  }
}
