import { Component, Inject, inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule, FormGroup, FormBuilder } from '@angular/forms';
import { TodoService } from '../../core/services/todo.service';

@Component({
  selector: 'app-add-toto',
  standalone: true,
  imports: [
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
  ],
  templateUrl: './add-toto.component.html',
  styleUrls: ['./add-toto.component.scss']
})
export class AddTotoComponent implements OnInit {
  addForm: FormGroup;

  constructor(private _fb: FormBuilder,
    private _todoService: TodoService,
    private _dialogRef: MatDialogRef<AddTotoComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {
    this.addForm = this._fb.group({
      taskName: ''
    })
  }
  ngOnInit(): void {
    this.addForm.patchValue(this.data);
  }

  onFormSubmit() {
    if (this.data) {
      if (this.addForm.valid) {
        this._todoService.updateTodo(this.addForm.value).subscribe({
          next: (val: any) => {
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          }
        })
      }
    } else {
      if (this.addForm.valid) {
        this._todoService.addTodo(this.addForm.value).subscribe({
          next: (val: any) => {
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          }
        })
      }
    }

  }
}
