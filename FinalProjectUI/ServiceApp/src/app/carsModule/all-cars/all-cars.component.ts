import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car, FuelType } from 'src/app/httpModals';
import { HttpService } from 'src/app/http.service';

@Component({
  selector: 'app-all-cars',
  templateUrl: './all-cars.component.html',
  styleUrls: ['./all-cars.component.scss'],
})
export class AllCarsComponent {
  constructor(private HttpService: HttpService) {}

  cars: Car[] = [];

  ngOnInit(): void {
    this.refreshCars();
  }

  refreshCars() {
    this.HttpService.getCars().subscribe((result) => {
      this.cars = result;
    });
  }
}
