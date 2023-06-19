import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { SelectInput } from 'src/app/common/models/selectInput';
import { HttpService } from 'src/app/http.service';
import {
  PaymentStatus,
  Reservation,
  ReservationStatus,
} from 'src/app/httpModals';

@Component({
  selector: 'app-edit-reservation',
  templateUrl: './edit-reservation.component.html',
  styleUrls: ['./edit-reservation.component.scss'],
})
export class EditReservationComponent implements OnInit {
  carInputOptions: SelectInput<string>[] = [];
  form: FormGroup = new FormGroup({});
  showForm = false;

  reservationId: string = '';

  treatmentDate = new FormControl(new Date());
  selectedTreatmentDate: Date | null = null;

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _httpService: HttpService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.reservationId = this._activatedRoute.snapshot.paramMap.get('id') ?? '';
    this._httpService
      .getReservationById(this.reservationId)
      .subscribe((result) => {
        this.treatmentDate.setValue(new Date(result.date));
        this.form = this.fb.group({
          date: [this.treatmentDate, [Validators.required]],
          price: [result.price, [Validators.required]],
          hour: [
            result.hour,
            [Validators.required, Validators.min(0), Validators.max(24)],
          ],
          paymentStatus: [result.paymentStatus, [Validators.required]],
          status: [result.status, [Validators.required]],
          prepaidAmount: [result.prepaidAmount],
          carId: [result.carId],
          id: [result.id],
        });

        this.showForm = true;
      });
  }

  onSave(formData: any) {
    let value = formData.value as Reservation;
    console.log(this.selectedTreatmentDate);
    if (!!this.selectedTreatmentDate) {
      value.date = this.selectedTreatmentDate;
      console.log(value.date);
    }

    this._httpService
      .updateReservation(value)
      .subscribe((a) => this.router.navigate([`reservations`]));
  }

  statusOptions: SelectInput<ReservationStatus>[] = [
    {
      viewValue: 'Just Arrived',
      value: ReservationStatus.JustArrived,
    },
    {
      viewValue: 'Completed',
      value: ReservationStatus.Completed,
    },
    {
      viewValue: 'In Progress',
      value: ReservationStatus.InProgress,
    },
    {
      viewValue: 'Waiting For Customer',
      value: ReservationStatus.WaitingForCustomer,
    },
  ];

  paymentStatusOptions: SelectInput<PaymentStatus>[] = [
    {
      viewValue: 'Paid',
      value: PaymentStatus.Paid,
    },
    {
      viewValue: 'Partly Paid',
      value: PaymentStatus.PartlyPaid,
    },
    {
      viewValue: 'Not Paid',
      value: PaymentStatus.NotPaid,
    },
  ];
}
