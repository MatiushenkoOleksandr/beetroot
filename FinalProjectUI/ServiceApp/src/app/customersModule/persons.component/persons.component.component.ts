import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../http.service';
import { Customer } from '../../httpModals';
import { CreatePersonDialogComponent } from '../create-person.dialog/create-person.dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.component.html',
  styleUrls: ['./persons.component.component.scss'],
})
export class PersonsComponentComponent implements OnInit {
  constructor(private HttpService: HttpService, public dialog: MatDialog) {}
  customers: Customer[] = [];
  ngOnInit(): void {
    this.HttpService.getPersons().subscribe((result) => {
      this.customers = result;
    });
  }
  customerModel: Customer = {
    name: '',
    surname: '',
    phoneNumber: '',
    id: undefined,
  };
  refreshPersons() {
    this.HttpService.getPersons().subscribe((result) => {
      this.customers = result;
    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(CreatePersonDialogComponent, {
      data: this.customerModel,
    });

    dialogRef.afterClosed().subscribe(() => {
      this.refreshPersons();
    });
  }
}
