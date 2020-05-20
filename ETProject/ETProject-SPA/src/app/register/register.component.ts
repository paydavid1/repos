import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UserDto } from '../_dto/UserDto';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: UserDto = {id: 0, name: '', userId: '', password: ''};

  constructor(private authServices: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  register(){
    this.authServices.register(this.model).subscribe(() => {
      this.alertify.success('Register successful');
      this.cancel();
    }, error => {
      this.alertify.error(error);
    });

  }

  cancel(){
    this.cancelRegister.emit(false);
    this. model = {id: 0, name: '', userId: '', password: ''};
  }
}
