import { Component, OnInit } from '@angular/core';
import { TransactionDto } from 'src/app/_dto/TransactionDto';
import { BalanceDto } from 'src/app/_dto/BalanceDto';
import { TransactionService } from 'src/app/_services/transaction.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-ingresos',
  templateUrl: './ingresos.component.html',
  styleUrls: ['./ingresos.component.css']
})
export class IngresosComponent implements OnInit {

  transactions: TransactionDto[];
  ingresosParam: BalanceDto = { month: 0, type: true, userId: 0};
  total: number;
  constructor(private transactionService: TransactionService,
              private alertify: AlertifyService,
              private router: Router,
              private route: ActivatedRoute,
              private authServices: AuthService) { }
  ngOnInit() {
    this.ingresosParam.type = false;
    this.ingresosParam.month = 5;
    this.ingresosParam.userId = this.authServices.getUserId();
    this.loadTransactions();
  }

  loadTransactions(){
    this.transactionService.getTransactionsByMonthByType(this.ingresosParam)
    .subscribe((transactions: TransactionDto[]) => {

      this.total = transactions.reduce((total, current) => total + current.total, 0);
      this.transactions = transactions;
    }, (error?: any) => {
      this.alertify.error(error);
    });
  }

}
