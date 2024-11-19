import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // Necessário para ngModel
import { CreatePostComponent } from './create-post.component';

@NgModule({
  declarations: [CreatePostComponent],
  imports: [
    CommonModule,
    FormsModule, // Importado para permitir o uso de ngModel
  ],
  exports: [CreatePostComponent], // Exporte o componente, se necessário
})
export class CreatePostModule {}
