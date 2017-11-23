import { Component, OnInit } from '@angular/core';
import {trigger, state, style, transition, animate} from '@angular/animations';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/timer';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/switchMap';
import { NotificationService } from './notification.service';

@Component({
  selector: 'app-notificacao',
  templateUrl: './notificacao.component.html',
  styleUrls: ['./notificacao.component.css'],
  animations: [
    trigger('snack-visibility', [
      state('hidden', style({
        opacity: 0,
        bottom: '0px'
      })),
      state('visible', style({
        opacity: 1,
        bottom: '30px'
      })),
      transition('hidden => visible', animate('500ms 0s ease-in')),
      transition('visible => hidden', animate('500ms 0s ease-out'))
    ])
  ]
})
export class NotificacaoComponent implements OnInit {

  message = 'Hellooooooooooooooooooo!';

    snackVisibility = 'hidden';

    constructor(private notification: NotificationService) { }

    ngOnInit() {
      this.notification.notifier
        .do(message => {
          this.message = message;
          this.snackVisibility = 'visible';
          // Observable.timer(3000).subscribe(timer => this.snackVisibility = 'hidden')
      }).switchMap(message => Observable.timer(3000))
        .subscribe(timer => this.snackVisibility = 'hidden');
    }
  }
