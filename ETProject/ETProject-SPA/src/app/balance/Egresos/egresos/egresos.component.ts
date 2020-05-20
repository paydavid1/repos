import { Component, OnInit } from '@angular/core';
import { TransactionService } from 'src/app/_services/transaction.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Router, ActivatedRoute } from '@angular/router';
import { TransactionDto } from 'src/app/_dto/TransactionDto';
import { BalanceDto } from 'src/app/_dto/BalanceDto';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-egresos',
  templateUrl: './egresos.component.html',
  styleUrls: ['./egresos.component.css']
})
export class EgresosComponent implements OnInit {


  transactions: TransactionDto[];
  egresoParam: BalanceDto = { month: 0, type: false, userId: 0};
  total: number;

  constructor(private transactionService: TransactionService,
              private alertify: AlertifyService,
              private router: Router,
              private route: ActivatedRoute,
              private authServices: AuthService) { }
  ngOnInit() {
    this.egresoParam.type = true;
    this.egresoParam.month = 5;
    this.egresoParam.userId = this.authServices.getUserId();
    this.loadTransactions();
  }

  loadTransactions(){
    this.transactionService.getTransactionsByMonthByType(this.egresoParam)
    .subscribe((transactions: TransactionDto[]) => {
      this.total = transactions.reduce((total, current) => total + current.total, 0);
      this.transactions = transactions;
    }, (error?: any) => {
      this.alertify.error(error);
    });
  }

}
