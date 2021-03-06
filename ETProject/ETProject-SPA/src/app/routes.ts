import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CategoriesComponent } from './categories/categories.component';
import { TransactionsComponent } from './transactions/transactions.component';
import { BalanceComponent } from './balance/balance.component';
import { AuthGuard } from './_guards/auth.guard';
import { CategoryComponent } from './categories/category/category.component';
import { TransactionComponent } from './transactions/Transaction/transaction/transaction.component';
import { IngresosComponent } from './balance/Ingresos/ingresos/ingresos.component';
import { EgresosComponent } from './balance/Egresos/egresos/egresos.component';


export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'categories', component: CategoriesComponent},
            {path: 'transactions/:id', component: TransactionsComponent},
            {path: 'balance', component: BalanceComponent},
            {path: 'saveCategory/:id', component: CategoryComponent, data : {type : 'saveCategory'}},
            {path: 'saveTransaction/:id', component: TransactionComponent, data : {type : 'saveTransaction'}},
            {path: 'ingresos', component: IngresosComponent},
            {path: 'egresos', component: EgresosComponent}
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'},

];
