import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  private apiUrl = 'https://localhost:7171/api/post'; // Altere para o endpoint da sua API

  constructor(private http: HttpClient) {}

  // Recuperar todas as postagens
  getPosts(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  // Criar uma nova postagem
  createPost(post: { Title: string; Content: string; UserId: string; CreatedAt: string }): Observable<any> {
    const token = localStorage.getItem('token'); // Token de autenticação
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post(this.apiUrl, post, { headers });
  }
  
}
