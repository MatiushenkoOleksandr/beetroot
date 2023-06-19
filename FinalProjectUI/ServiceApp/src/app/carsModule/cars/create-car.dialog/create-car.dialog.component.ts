import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Car, FuelType } from '../../../httpModals';
import { SelectInput } from '../../../common/models/selectInput';
import { HttpService } from 'src/app/http.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-car.dialog',
  templateUrl: './create-car.dialog.component.html',
  styleUrls: ['./create-car.dialog.component.scss'],
})
export class CreateCarDialogComponent implements OnInit {
  form: FormGroup = new FormGroup({});
  constructor(
    public dialogRef: MatDialogRef<CreateCarDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Car,
    private _httpService: HttpService,
    private fb: FormBuilder
  ) {}
  ngOnInit(): void {
    if (!!this.data) {
      this.form = this.fb.group({
        brand: [null, [Validators.required]],
        model: [null, [Validators.required]],
        milage: [null, [Validators.required]],
        year: [null, [Validators.required]],
        fuelType: [null, [Validators.required]],
        vin: [null, [Validators.required]],
        clientId: [null],
        id: [null],
      });
    }
  }
  onSave(formData: any) {
    let value = formData.value as Car;
    console.log(value);
    this._httpService.createCar(value).subscribe();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  changeFuelType(value: any) {
    this.data.fuelType = value.value;
  }

  fuelOptions: SelectInput<FuelType>[] = [
    {
      viewValue: 'Petrol',
      value: FuelType.Petrol,
    },
    {
      viewValue: 'Diesel',
      value: FuelType.Diesel,
    },
    {
      viewValue: 'Electric',
      value: FuelType.Electric,
    },
    {
      viewValue: 'LPG',
      value: FuelType.LPG,
    },
    {
      viewValue: 'Hybrid',
      value: FuelType.Hybrid,
    },
  ];
}
