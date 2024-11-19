import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.scss'],
  imports: [CommonModule], // Inclua o CommonModule aqui
})
export class FeedComponent {
  posts = [
    { title: 'Post 1', content: 'Conteúdo do Post 1' },
    { title: 'Post 2', content: 'Conteúdo do Post 2' },
    { title: 'Post 3', content: 'Conteúdo do Post 3' },
  ];
}
