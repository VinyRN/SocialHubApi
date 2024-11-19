import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'; // Certifique-se de que está importado corretamente
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.scss'],
})


export class FeedComponent implements OnInit {
  posts: any[] = []; // Lista de posts para o feed

  // Injeção do serviço Router no construtor
  constructor(private postService: PostService, private router: Router) {}

  ngOnInit(): void {
    this.loadPosts(); // Carrega os posts ao inicializar o componente
  }

  loadPosts(): void {
    this.postService.getPosts().subscribe(
      (data) => {
        this.posts = data;
      },
      (error) => {
        console.error('Erro ao carregar posts:', error);
      }
    );
  }

  // Navegação para a página de criação de postagens
  navigateToCreate(): void {
    this.router.navigate(['/create-post']); // Usa o Router para redirecionar
  }
}
