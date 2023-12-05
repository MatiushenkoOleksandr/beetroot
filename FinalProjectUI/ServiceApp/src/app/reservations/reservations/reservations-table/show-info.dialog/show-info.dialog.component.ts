import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-show-info.dialog',
  templateUrl: './show-info.dialog.component.html',
  styleUrls: ['./show-info.dialog.component.scss'],
})
export class ShowInfoDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<ShowInfoDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}
