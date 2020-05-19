import { Component, OnInit, Input } from '@angular/core';
import { TransactionDto } from 'src/app/_dto/TransactionDto';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { TransactionService } from 'src/app/_services/transaction.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { CategoryService } from 'src/app/_services/category.service';
import { CategorieDto } from 'src/app/_dto/CategorieDto';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit {

  @Input() TransactionUpdate: TransactionDto;
  transaction: TransactionDto = {id: 0, description: '', dateTransaction: new Date(), total: 0,
                                    categoryId: 0, userId: 0, categoryDescription: '' };
  categories: CategorieDto[];
  title =  'Add Transaction';
  id: number = this.transaction.id;

  transactionForm: FormGroup;

  constructor(private transactionService: TransactionService,
              private router: Router,
              private alertify: AlertifyService,
              private route: ActivatedRoute,
              private categoryService: CategoryService,
              private authServices: AuthService) { }

  ngOnInit() {
    this.loadCategories();
    this.id = this.route.snapshot.params.id;
    this.transactionForm = new FormGroup({
      id:  new FormControl(this.transaction.id),
      description: new FormControl('', Validators.required),
      dateTransaction: new FormControl('', Validators.required),
      total: new FormControl(0, Validators.required),
      categoryId: new FormControl(0, Validators.required),
      userId: new FormControl(0, Validators.required),
      categoryDescription: new FormControl(this.categories, Validators.required)
    });
    if (this.id > 0){
      this.getTransactionById(this.id);
      this.title = 'Edit Transaction';
    }
  }

  getTransactionById(id){
    this.transactionService.getTransaction(id).subscribe(response => {
      this.transaction = response;
      this.setTransactionForm();
    });
  }

  setTransactionForm(){
    console.log(this.transaction);
    this.transactionForm.setValue(this.transaction);
    console.log(this.transactionForm);
  }

  loadCategories(){
    this.categoryService.getCategories().subscribe((categories: CategorieDto[]) => {
      this.categories = categories;
    }, (error?: any) => {
      this.alertify.error(error);
    });
  }

  onSubmit(){

    this.transaction.id = this.transactionForm.get('id').value;
    this.transaction.description = this.transactionForm.get('description').value;
    this.transaction.categoryId = +this.transactionForm.get('categoryDescription').value;
    this.transaction.userId =  this.authServices.getUserId();
    this.transaction.total = +this.transactionForm.get('total').value;
    this.transaction.dateTransaction = this.transactionForm.get('dateTransaction').value;


    if (this.id > 0 ) {
      this.transactionService.updateTransaction(this.transaction).subscribe(next => {
        this.transaction = next;
        this.alertify.success('Transaction updated Succesfully');
        this.router.navigate(['transactions']);
      }, error => {
        this.alertify.warning(error);
      });
    } else {
      this.transactionService.addTransaction(this.transaction).subscribe(() => {
        this.alertify.success('Transaction added Succesfully');
        this.router.navigate(['transactions']);
      }, error => {
        this.alertify.warning(error);
        this.onReset();
      });

    }

  }

  onCancel(){}

  onReset(){
    this.transactionForm.reset();
    this.transaction =  {id: 0, description: '', dateTransaction: new Date(), total: 0,
    categoryId: 0, userId: 0, categoryDescription: '' };
    this.transactionForm.setValue(this.transaction);
  }




}
