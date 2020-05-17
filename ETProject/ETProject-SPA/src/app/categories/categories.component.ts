import { Component, OnInit } from '@angular/core';
import { CategorieDto } from '../_dto/CategorieDto';
import { CategoryService } from '../_services/category.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

 categories: CategorieDto[];
 

  constructor(private categoryService: CategoryService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.loadCategories();
  }

  loadCategories(){
    this.categoryService.getCategories().subscribe((categories: CategorieDto[]) => {
      this.categories = categories;
    }, (error?: any) => {
      this.alertify.error(error);
    });
  }

  onAddRecipe() {
    this.router.navigate(['addCategory']);
    // this.router.navigate(['../', this.id, 'edit'], {relativeTo: this.route});
  }
  onEditRecipe(){
    this.router.navigate(['addCategory']);
  }

}
