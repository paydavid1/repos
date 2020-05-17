import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CategoriesComponent } from './categories/categories.component';
import { TransactionsComponent } from './transactions/transactions.component';
import { BalanceComponent } from './balance/balance.component';
import { AuthGuard } from './_guards/auth.guard';
import { CategoryComponent } from './categories/category/category.component';


export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'categories', component: CategoriesComponent},
            {path: 'transactions', component: TransactionsComponent},
            {path: 'balance', component: BalanceComponent},
            {path: 'addCategory', component: CategoryComponent}
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'},

];
