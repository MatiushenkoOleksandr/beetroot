import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Car, FuelType } from '../../../httpModals';
import { SelectInput } from '../../../common/models/selectInput';

@Component({
  selector: 'app-create-car.dialog',
  templateUrl: './create-car.dialog.component.html',
  styleUrls: ['./create-car.dialog.component.scss'],
})
export class CreateCarDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<CreateCarDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Car
  ) {}

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
