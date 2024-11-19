import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { Router } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  imports: [FormsModule], // Importação necessária
})
export class RegisterComponent {
  user = {
    email: '',
    password: '',
  };

  constructor(private apiService: ApiService, private router: Router) {}

  register(): void {
    this.apiService.register(this.user.email, this.user.password).subscribe({
      next: (response) => {
        console.log('Usuário registrado com sucesso!', response);
        alert('Usuário registrado com sucesso!');
        this.router.navigate(['/login']); // Redireciona para o login após o registro
      },
      error: (error) => {
        if (error.status === 400) {
          alert('Erro: ' + (error.error || 'Não foi possível registrar.'));
        } else {
          alert('Erro ao registrar. Tente novamente mais tarde.');
        }
      }
    });
  }
}
