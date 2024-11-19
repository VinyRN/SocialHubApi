import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PostService } from '../services/post.service';
import { FormsModule } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.scss'],
  imports: [FormsModule],
})
export class CreatePostComponent {
  newPost = {
    Title: '',
    Content: '',
    UserId: '', // ID do usuário autenticado
    CreatedAt: '', // Data da criação
  };

  constructor(private postService: PostService, private router: Router) {}

  createPost(): void {
    // Obtenha o ID do usuário do localStorage (ou de outro lugar)
    const userId = localStorage.getItem('userId'); // Certifique-se de que este valor está sendo salvo no login

    // Popule o objeto com a data atual e o ID do usuário
    this.newPost.UserId = userId ? userId : ''; // Verifica se o ID está disponível
    this.newPost.CreatedAt = new Date().toISOString(); // Data no formato ISO

    if (this.newPost.Title && this.newPost.Content) {
      this.postService.createPost(this.newPost).subscribe(
        () => {
          this.router.navigate(['/feed']);
        },
        (error) => {
          console.error('Erro ao criar postagem:', error);
        }
      );
    }
  }
}
