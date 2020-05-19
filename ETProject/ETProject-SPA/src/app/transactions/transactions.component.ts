import { Component, OnInit } from '@angular/core';
import { TransactionDto } from '../_dto/TransactionDto';
import { TransactionService } from '../_services/transaction.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnInit {

  transactions: TransactionDto[];

  constructor(private transactionService: TransactionService,
              private alertify: AlertifyService,
              private router: Router) { }

  ngOnInit() {
    this.loadTransactions();
  }

  loadTransactions(){
    this.transactionService.getTransactions().subscribe((transactions: TransactionDto[]) => {
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
