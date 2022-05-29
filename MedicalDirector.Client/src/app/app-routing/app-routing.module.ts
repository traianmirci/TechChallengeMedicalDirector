import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { UserDetailsComponent } from '../pages/user-details/user-details.component';
import { UserListComponent } from '../pages/user-list/user-list.component';

const routes: Routes = [
  { path: '', component: UserListComponent },
  { path: 'details/:id', component: UserDetailsComponent }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
    CommonModule
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
