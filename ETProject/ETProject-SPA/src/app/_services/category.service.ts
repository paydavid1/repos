import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CategorieDto } from '../_dto/CategorieDto';

const httpOption = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  baseUrl = environment.apiUrl + 'category/';

  constructor(private http: HttpClient) { }

  getCategories(): Observable<CategorieDto[]>{

    return this.http.get<CategorieDto[]>(this.baseUrl + 'getall/', httpOption);

  }

  getCategory(id: number): Observable<CategorieDto>{
    return this.http.get<CategorieDto>(this.baseUrl + id, httpOption);
  }
  addCategory(categoy: CategorieDto){
    return this.http.post(this.baseUrl + 'new/', categoy);
  }
}

