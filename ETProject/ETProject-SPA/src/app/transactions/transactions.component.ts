import { Component, OnInit } from '@angular/core';
import { TransactionDto } from '../_dto/TransactionDto';
import { TransactionService } from '../_services/transaction.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnInit {

  transactions: TransactionDto[];
  userId: number;

  constructor(private transactionService: TransactionService,
              private alertify: AlertifyService,
              private router: Router,
              private authServices: AuthService) { }

  ngOnInit() {
    this.userId = this.authServices.getUserId();
    this.loadTransactions();
  }

  loadTransactions(){
    this.transactionService.getTransactions(this.userId).subscribe((transactions: TransactionDto[]) => {
      this.transactions = transactions;
    }, (error?: any) => {
      this.alertify.error(error);
    });
  }

  onAddTransaction(){
    this.router.navigate(['saveTransaction/' + 0]);

  }

  onEditTransaction(id: number){
    this.router.navigate(['saveTransaction/' + id]);
  }

  onDelete(id: number){
    this.alertify.confirm('Are you sure you want to delelet this transaction', () => {
      this.transactionService.removeTransaction(id).subscribe(() => {
        this.loadTransactions();
        this.alertify.success('Transaction was deleted');
      }, (error?: any) => {
        this.alertify.error('Failed to delete Transaction');
      });
    });
  }

}
