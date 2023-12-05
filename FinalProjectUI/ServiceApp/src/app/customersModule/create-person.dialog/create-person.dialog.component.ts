import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Customer } from '../../httpModals';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpService } from 'src/app/http.service';

@Component({
  selector: 'app-create-person.dialog',
  templateUrl: './create-person.dialog.component.html',
  styleUrls: ['./create-person.dialog.component.scss'],
})
export class CreatePersonDialogComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<CreatePersonDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Customer,
    private fb: FormBuilder,
    private _httpService: HttpService
  ) {}
  form: FormGroup = new FormGroup({});
  ngOnInit(): void {
    this.form = this.fb.group({
      name: [null, [Validators.required]],
      surname: [null, [Validators.required]],
      phoneNumber: [null, [Validators.required]],
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
  onSave(formData: any) {
    let value = formData.value as Customer;

    this._httpService
      .createPerson(value)
      .subscribe(() => this.dialogRef.close());
  }
}
