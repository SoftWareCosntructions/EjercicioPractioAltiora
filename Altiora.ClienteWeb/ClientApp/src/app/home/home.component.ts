import { Component } from '@angular/core';
import { faBars, faUser, faFileInvoiceDollar, faTablet, faCircleNotch } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  faBars = faBars;
  faUser = faUser;
  faFileInvoiceDollar = faFileInvoiceDollar;
  faTablet = faTablet;
  faCircleNotch = faCircleNotch;
}
