import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Customer } from '../../httpModals';

@Component({
  selector: 'app-create-person.dialog',
  templateUrl: './create-person.dialog.component.html',
  styleUrls: ['./create-person.dialog.component.scss'],
})
export class CreatePersonDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<CreatePersonDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Customer
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}
