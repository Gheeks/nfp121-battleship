import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './components/struct/footer/footer.component';
import { HeaderComponent } from './components/struct/header/header.component';
import { GridComponentComponent } from './grid-component/grid-component.component';
import { AccountComponent } from './account/account.component';
import { RegisterComponent } from './account/register/register.component';
import { LoginComponent } from './account/login/login.component';
import { AgGridModule } from 'ag-grid-angular';
import { StatsGridComponent } from './components/stats-grid/stats-grid.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    GridComponentComponent,
    AccountComponent,
    RegisterComponent,
    StatsGridComponent,
    LoginComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    BrowserModule,
    AgGridModule.withComponents([]),
    AppRoutingModule,
    ReactiveFormsModule,
    RouterModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
