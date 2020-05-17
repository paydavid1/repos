import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { UserDto } from '../_dto/UserDto';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: UserDto = {id: 0, name: '', userId: '', password: ''};
  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }
  login(){
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('logged in Succesfully');
      this.router.navigate(['transactions']);
    }, error => {
      this.alertify.error(error);
    });
  }

  loggedIn(){
       return this.authService.loggedIn();
  }

  loggedOut(){
    localStorage.removeItem('token');
    this.alertify.message('Logged out');
    this.router.navigate(['home']);
  }
}