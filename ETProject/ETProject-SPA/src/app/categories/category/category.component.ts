import { Component, OnInit } from '@angular/core';
import { CategorieDto } from 'src/app/_dto/CategorieDto';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CategoryService } from 'src/app/_services/category.service';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  category: CategorieDto = {id: 0, description: '', type: true};

  categoryForm: FormGroup;

  constructor(private categoryService: CategoryService, private router: Router, private alertifyService: AlertifyService) { }

  ngOnInit() {
    this.categoryForm = new FormGroup({
      description: new FormControl('', Validators.required),
      type: new FormControl('true', Validators.required)
    });
  }

  onCancel(){}
  onSubmit(){
    this.category.description = this.categoryForm.get('description').value;
    this.category.type = 'true' === this.categoryForm.get('type').value;
    this.categoryService.addCategory(this.category).subscribe(() => {
    this.alertifyService.success('Category added Succesfully');
    this.router.navigate(['categories']);

    }, error => {
      this.alertifyService.error(error);
    });
  }

}
