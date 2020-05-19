import { Component, OnInit, Input } from '@angular/core';
import { CategorieDto } from 'src/app/_dto/CategorieDto';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CategoryService } from 'src/app/_services/category.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  @Input() categoryUpdate: CategorieDto;
  category: CategorieDto = {id: 0, description: '', type: true};
  title =  'Add Category';
  id: number = this.category.id;

  categoryForm: FormGroup;
  constructor(private categoryService: CategoryService,
              private router: Router,
              private alertifyService: AlertifyService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.id = this.route.snapshot.params.id;
    this.categoryForm = new FormGroup({
      id:  new FormControl(this.category.id),
      description: new FormControl('', Validators.required),
      type: new FormControl('true', Validators.required)
    });
    if (this.id > 0){
      this.getCategoryById(this.id);
      this.title = 'Edit Category';
    }
   }

  getCategoryById(id){
    this.categoryService.getCategory(id).subscribe(response => {
      this.category = response;
      this.setCategoryForm();
    });
  }

  setCategoryForm(){
    this.categoryForm.setValue(this.category);
  }

  onCancel(){
    this.router.navigate(['categories']);
  }

  onSubmit(){
    this.category.id = this.categoryForm.get('id').value;
    this.category.description = this.categoryForm.get('description').value;
    this.category.type = 'true' === this.categoryForm.get('type').value;
    if (this.id > 0) {
        this.categoryService.updateCategory(this.category).subscribe(next => {
        this.category = next;
        this.alertifyService.success('Category updated Succesfully');
        this.router.navigate(['categories']);
      }, error => {
        this.alertifyService.warning(error);
      });
    } else{
      this.categoryService.addCategory(this.category).subscribe(() => {
        this.alertifyService.success('Category added Succesfully');
        this.router.navigate(['categories']);
      }, error => {
        this.onReset();
      });
    }
  }

  onReset(){

    this.categoryForm.reset();
  }



}
