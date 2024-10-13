import { Component, inject } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { MatToolbar } from '@angular/material/toolbar';
import { MatButton } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { AddTotoComponent } from '../features/add-toto/add-toto.component';
import { TodoComponent } from '../features/todo/todo.component';
import { TodoService } from '../core/services/todo.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [MatIcon, MatToolbar, MatButton],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  constructor(private _dialog: MatDialog) { }
  private todoServices = inject(TodoService);

  openAddTodoDialog() {
    const dialogRef = this._dialog.open(AddTotoComponent);
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.todoServices.refreshTodos();
        }
      }
    })
  }
}
