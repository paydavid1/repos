import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TransactionDto } from '../_dto/TransactionDto';
import { Observable } from 'rxjs/internal/Observable';


const httpOption = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  baseUrl = environment.apiUrl + 'transaction/';

  constructor(private http: HttpClient) { }

  getTransactions(): Observable<TransactionDto[]>{

    return this.http.get<TransactionDto[]>(this.baseUrl + 'getall/', httpOption);

  }

  getTransaction(id: number): Observable<TransactionDto>{
    return this.http.get<TransactionDto>(this.baseUrl + 'getbyid/' + id, httpOption);
  }
  addTransaction(transaction: TransactionDto){
    return this.http.post(this.baseUrl + 'new/', transaction);
  }

  removeTransaction(id: number){
    return this.http.delete(this.baseUrl + 'delete/' + id);
  }
  updateTransaction(transaction: TransactionDto){
    return this.http.put<TransactionDto>(this.baseUrl + 'update/', transaction);
  }
}
