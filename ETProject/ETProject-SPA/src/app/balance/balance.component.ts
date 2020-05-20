import { Component, OnInit } from '@angular/core';
import { TransactionService } from '../_services/transaction.service';
import { BalanceDto } from '../_dto/BalanceDto';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-balance',
  templateUrl: './balance.component.html',
  styleUrls: ['./balance.component.css']
})
export class BalanceComponent implements OnInit {

  balance: number;
  balanceParams: BalanceDto =  {userId: 0 , month: 0 , type: true}
  constructor(private transactionServices: TransactionService, private authService: AuthService) { }

  ngOnInit() {
    this.balanceParams.userId = this.authService.getUserId();
    this.balanceParams.month = new Date().getMonth() + 1;

    this.transactionServices.getBalance(this.balanceParams).subscribe((balance: number) => {
      this.balance = balance;
    });
  }

}
