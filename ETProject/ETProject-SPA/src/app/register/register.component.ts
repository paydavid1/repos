import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UserDto } from '../_dto/UserDto';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: UserDto = {id: 0, name: '', userId: '', password: ''};

  constructor(private authServices: AuthService) { }

  ngOnInit() {
  }

  register(){
    this.authServices.register(this.model).subscribe(() => {
      console.log('Register successful');
    }, error => {
      console.log(error);
    });

  }

  cancel(){
    this.cancelRegister.emit(false);
    // console.log('Cancel');
  }
}
