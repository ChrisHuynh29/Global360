import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ToDoComponent } from "./feature/to-do/to-do.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ToDoComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'todo-app';
}
