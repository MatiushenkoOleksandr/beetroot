import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SelectInput } from 'src/app/common/models/selectInput';
import { Car, FuelType } from 'src/app/httpModals';
import { HttpService } from 'src/app/http.service';

@Component({
  selector: 'app-update-car.dialog',
  templateUrl: './update-car.dialog.component.html',
  styleUrls: ['./update-car.dialog.component.scss'],
})
export class UpdateCarDialogComponent {
  form: FormGroup = new FormGroup({});
  showForm = false;

  constructor(
    public dialogRef: MatDialogRef<UpdateCarDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string,
    private _httpService: HttpService,
    private fb: FormBuilder
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
  ngOnInit(): void {
    if (!!this.data) {
      this._httpService.getCarById(this.data).subscribe((res) => {
        this.form = this.fb.group({
          brand: [res.brand],
          model: [res.model],
          milage: [res.milage],
          year: [res.year],
          fuelType: [res.fuelType],
          vin: [res.vin],
          clientId: [res.clientId],
          id: [res.id],
        });
        this.showForm = true;
      });
    }
  }

  onSave(formData: any) {
    let value = formData.value as Car;
    this._httpService.saveUpdateCar(value).subscribe();
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
