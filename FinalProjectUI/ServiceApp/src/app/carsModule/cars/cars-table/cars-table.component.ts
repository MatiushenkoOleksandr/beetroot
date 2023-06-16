import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Car, FuelType } from 'src/app/httpModals';
import { HttpService } from 'src/app/http.service';
import { MatDialog } from '@angular/material/dialog';
import { UpdateCarDialogComponent } from '../../update-car.dialog/update-car.dialog.component';

@Component({
  selector: 'app-cars-table',
  templateUrl: './cars-table.component.html',
  styleUrls: ['./cars-table.component.scss'],
})
export class CarsTableComponent {
  constructor(private HttpService: HttpService, public dialog: MatDialog) {}

  @Input() cars: Car[] = [];
  displayedColumns = [
    'vin',
    'year',
    'brand',
    'model',
    'milage',
    'fuelType',
    'delete',
  ];
  @Output() onCarDeleted: EventEmitter<any> = new EventEmitter();

  getFuelTypeString(fuelType: number): string {
    return FuelType[fuelType];
  }

  deleteCar(id: string) {
    this.HttpService.deleteCar(id).subscribe(() => {
      this.onCarDeleted.emit(null);
    });
  }

  updateCar(id: string): void {
    const dialogRef = this.dialog.open(UpdateCarDialogComponent, {
      data: id,
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(result);
      this.onCarDeleted.emit(null);
    });
  }
}
