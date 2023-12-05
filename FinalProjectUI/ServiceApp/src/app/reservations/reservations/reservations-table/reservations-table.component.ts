import {
  Component,
  EventEmitter,
  Injector,
  Input,
  Output,
} from '@angular/core';
import {
  PaymentStatus,
  Reservation,
  ReservationListModel,
  ReservationStatus,
} from 'src/app/httpModals';
import { HttpService } from 'src/app/http.service';
import * as moment from 'moment';
import { Router } from '@angular/router';
import { BaseComponent } from 'src/app/base/base.component';
import { ShowInfoDialogComponent } from './show-info.dialog/show-info.dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-reservations-table',
  templateUrl: './reservations-table.component.html',
  styleUrls: ['./reservations-table.component.scss'],
})
export class ReservationsTableComponent extends BaseComponent {
  constructor(
    private HttpService: HttpService,
    private router: Router,
    injector: Injector,
    public dialog: MatDialog
  ) {
    super(injector);
    if (!this.isAdmin) {
      this.displayedColumns = this.displayedColumns.filter(
        (a) => a != 'delete'
      );
    }
  }
  @Input() reservations: ReservationListModel[] = [];
  displayedColumns = [
    'date',
    'hour',
    'price',
    'status',
    'paymentStatus',
    'prepaidAmount',
    'car',
    'customerName',
    'customerPhone',
    'showInfo',
    'delete',
  ];
  @Output() onReservationDeleted: EventEmitter<any> = new EventEmitter();

  getElementsDateString(date: Date): string {
    let valueDate: string = moment(date).format('yyyy-MM-DD');
    return valueDate;
  }

  getStatusString(status: number): string {
    return ReservationStatus[status];
  }
  getPaymentStatusString(status: number): string {
    return PaymentStatus[status];
  }
  deleteReservation(event: any, id: string) {
    event.stopPropagation();
    this.HttpService.deleteReservation(id).subscribe(() => {
      this.onReservationDeleted.emit(null);
    });
  }
  tableElementClicked(event: any, id: string) {
    if (this.isAdmin) {
      this.router.navigate([`reservations/${id}/edit`]);
    }
  }
  showInfo(event: any, comments: string) {
    event.stopPropagation();

    const dialogRef = this.dialog.open(ShowInfoDialogComponent, {
      data: comments,
    });
  }
}
