import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationService } from '../notificacao/notification.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  usuario: string;
  constructor(private router: Router,
    private notification: NotificationService) { }

  ngOnInit() {
    this.usuario = JSON.parse(localStorage.getItem('user_cdc')).email;
  }

  logoff() {
    this.notification.notify(`Logoff realizado!`);
    localStorage.clear();
    this.router.navigate(['/acesso']);
  }
}
