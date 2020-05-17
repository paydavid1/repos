import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CategoriesComponent } from './categories/categories.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { TransactionsComponent } from './transactions/transactions.component';
import { BalanceComponent } from './balance/balance.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { CategoryComponent } from './categories/category/category.component';


@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      CategoriesComponent,
      CategoryComponent,
      TransactionsComponent,
      BalanceComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      FormsModule,
      ReactiveFormsModule,
      HttpClientModule,
      BsDropdownModule.forRoot(),
      ModalModule.forRoot(),
      BrowserAnimationsModule,
      RouterModule.forRoot(appRoutes),
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
