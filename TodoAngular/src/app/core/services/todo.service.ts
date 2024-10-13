import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Todo } from '../../shared/models/toto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;

  getTodos(): Observable<any> {
    return this.http.get<Todo>(this.baseUrl + "Todo/AllTasks");
  }
  refreshTodos() {
    this.getTodos();
  }

  deleteTodo(id: string): Observable<any> {
    return this.http.delete(this.baseUrl + "Todo/DeleteTask?id=" + id);
  }

  addTodo(todo: any): Observable<any> {
    return this.http.post(this.baseUrl + "Todo/AddTask", todo);

  }

  updateTodo(todo: any): Observable<any> {
    return this.http.put(this.baseUrl + "Todo/UpdateTask", todo);

  }
  constructor() { }
}
