import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { Router } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  imports: [FormsModule], // Importa FormsModule para usar [(ngModel)]
})
export class LoginComponent {
  credentials = { email: '', password: '' };

  constructor(private apiService: ApiService, private router: Router) {}

  login() {
    if (!this.credentials.email || !this.credentials.password) {
      alert('Por favor, preencha todos os campos.');
      return;
    }
  
    this.apiService.login(this.credentials.email, this.credentials.password).subscribe({
      next: (response) => {
        if (response && response.token) {
          // Salva o token e os dados do usuário no localStorage
          localStorage.setItem('token', response.token);
          localStorage.setItem('user', JSON.stringify(response.user));
  
          // Redireciona para o feed
          this.router.navigate(['/feed']);
        } else {
          alert('Erro inesperado. Nenhum token foi retornado.');
        }
      },
      error: (err) => {
        if (err.status === 401) {
          alert('Credenciais inválidas.');
        } else {
          alert(`Erro ao fazer login: ${err.error || 'Erro desconhecido.'}`);
        }
      },
    });
  }  
  
  navigateToRegister(): void {
    this.router.navigate(['/register']);
  }
  
      
}
