import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { UserDetailsComponent } from './pages/user-details/user-details.component';
import { UserListComponent } from './pages/user-list/user-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavbarComponent } from './components/navbar/navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    UserDetailsComponent,
    UserListComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, AppRoutingModule, NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
