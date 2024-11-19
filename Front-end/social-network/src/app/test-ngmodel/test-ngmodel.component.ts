import { Component } from '@angular/core';

@Component({
  selector: 'app-test-ngmodel',
  templateUrl: './test-ngmodel.component.html',
  styleUrls: ['./test-ngmodel.component.scss'],
})
export class TestNgmodelComponent {
  testInput: string = ''; // Propriedade para ngModel
}
