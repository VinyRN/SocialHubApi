import { Component, OnInit } from '@angular/core';
import { PostService } from '../services/post.service';


@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
})
export class PostComponent implements OnInit {
  posts: any[] = [];
  newPost = { title: '', content: '' };

  constructor(private postService: PostService) {}

  ngOnInit(): void {
    this.loadPosts();
  }

  // Carregar todas as postagens
  loadPosts(): void {
    this.postService.getPosts().subscribe((data) => {
      this.posts = data;
    });
  }

  // Criar uma nova postagem
  createPost(): void {
    if (this.newPost.title && this.newPost.content) {
      this.postService.createPost(this.newPost).subscribe((post) => {
        this.posts.unshift(post); // Adiciona o novo post no início da lista
        this.newPost = { title: '', content: '' }; // Limpa o formulário
      });
    }
  }
}
