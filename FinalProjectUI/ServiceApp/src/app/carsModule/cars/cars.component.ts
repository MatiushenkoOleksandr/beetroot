import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car, FuelType } from '../../httpModals';
import { HttpService } from '../../http.service';
import { MatDialog } from '@angular/material/dialog';
import { CreateCarDialogComponent } from './create-car.dialog/create-car.dialog.component';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.scss'],
})
export class CarsComponent implements OnInit {
  constructor(
    private _activatedRoute: ActivatedRoute,
    private HttpService: HttpService,
    public dialog: MatDialog
  ) {}
  customerId: string = '';
  cars: Car[] = [];
  carModel: Car = {
    brand: '',
    clientId: '',
    fuelType: FuelType.Petrol,
    id: undefined,
    milage: 0,
    model: '',
    vin: '',
    year: 0,
  };
  ngOnInit(): void {
    this.customerId = this._activatedRoute.snapshot.paramMap.get('id') ?? '';
    this.carModel.clientId = this.customerId;
    this.refreshCars();
  }

  refreshCars() {
    this.HttpService.getCustomersCars(this.customerId).subscribe((result) => {
      this.cars = result;
    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(CreateCarDialogComponent, {
      data: this.carModel,
    });

    dialogRef.afterClosed().subscribe(() => {
      this.refreshCars();
    });
  }
}
