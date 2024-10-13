import { AfterViewInit, Component, inject, OnInit, ViewChild, viewChild } from '@angular/core';
import { TodoService } from '../../core/services/todo.service';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatFormField } from '@angular/material/form-field';
import { MatLabel } from '@angular/material/form-field';
import { MatPaginator } from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { AddTotoComponent } from '../add-toto/add-toto.component';


@Component({
  selector: 'app-todo',
  standalone: true,
  imports: [
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatFormField,
    MatLabel,
    MatPaginator,
    MatTable,
    MatInputModule,
    MatSortModule
  ],
  templateUrl: './todo.component.html',
  styleUrl: './todo.component.scss'
})
export class TodoComponent implements OnInit, AfterViewInit {
  constructor(private _dialog: MatDialog) { }

  displayedColumns: string[] = ['id', 'taskName', 'action'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  todoServices = inject(TodoService);

  ngOnInit(): void {
    this.getTodoList();
  }

  getTodoList() {
    this.todoServices.getTodos().subscribe({
      next: (res) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: console.log,
    })
  }


  deleteTodo(id: string) {
    this.todoServices.deleteTodo(id).subscribe({
      next: (res) => {
        alert('deleted todoTask');
        this.getTodoList();
      },
      error: console.log,
    })
  }
  openEditForm(data: any) {
    this._dialog.open(AddTotoComponent, {
      data,
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
