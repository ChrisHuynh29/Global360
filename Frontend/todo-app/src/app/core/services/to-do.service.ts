import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, tap } from 'rxjs';
import { TodoItem } from '../models/to-do-item';


@Injectable({
  providedIn: 'root'
})
export class ToDoService {
  private readonly baseUrl = 'https://localhost:7199/api/todo';

  constructor(private http: HttpClient) { }

  getAll(): Observable<TodoItem[]> {
    return this.http.get<any>(this.baseUrl).pipe(
      map(res => res.items.map((i: any) => ({
        Id: i.id,
        Title: i.title
      })))
    );
  }

  add(title: string): Observable<TodoItem> {
    return this.http.post<any>(this.baseUrl, { title }).pipe(
      map(res => ({
        Id: res.id,
        Title: res.title
      }))
    );
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
