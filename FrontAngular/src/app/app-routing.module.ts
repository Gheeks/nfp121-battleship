import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './account/account.component';
import { GridComponentComponent } from './grid-component/grid-component.component';

const routes: Routes = [
  { path: 'grid', component: GridComponentComponent },
  { path: 'account', component: AccountComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
