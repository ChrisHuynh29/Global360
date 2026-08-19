import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ToDoService } from '../../core/services/to-do.service';
import { TodoItem } from '../../core/models/to-do-item';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-to-do',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule],
  templateUrl: './to-do.component.html',
  styleUrl: './to-do.component.css'
})
export class ToDoComponent implements OnInit  {
  todos: TodoItem[] = [];
  isLoading = false;
  errorMessage = '';
  newTitle = '';

  constructor(private todoService: ToDoService) {}

  ngOnInit(): void {
    this.loadTodos();
  }

  loadTodos(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.todoService.getAll().subscribe({
      next: items => {
        this.todos = items;
        console.log('items from API:', items);
        this.isLoading = false;
      },
        error: err => {
          console.error('API error:', err);
          this.errorMessage = 'Failed to load TODO items.';
          this.isLoading = false;
        }
      });
  }

  addTodo() {
    this.errorMessage = '';
    const title = this.newTitle.trim();
    if (title !== '') {
      this.todoService.add(title).subscribe({
        next: item => {
          console.log('POST returned:', item);
          this.todos.push(item);
          this.newTitle = '';
        },
        error: () => {
          this.errorMessage = 'Failed to add TODO item.';
        }
      });
    }
  }

  deleteTodo(todo : TodoItem) {
      this.todoService.delete(todo.Id).subscribe({
      next: () => {
        this.todos = this.todos.filter(t => t.Id !== todo.Id);
        this.errorMessage = '';
      },
      error: () => {
        this.errorMessage = 'Failed to delete TODO item.';
      }
    });
  }
}
