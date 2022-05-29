import { Component, OnInit } from '@angular/core';
import { RestApiService } from '../../services/rest-api.service';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  UsersList: any = [];

  constructor(public restApi: RestApiService) { }

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers() {
    return this.restApi.getUsersList().subscribe((data: {}) => {
      this.UsersList = data;
    })
  }

  exportCSV() {
    const columns = { "id": "id", "name": "name", "username": "username", "postCount": "postCount" };
    const data = [columns].concat(this.UsersList);
    const csvData = data.map(e => Object.values(e).join(",")).join("\n");
    const blob = new Blob([csvData], { type: "text/csv;charset=utf-8" });
    saveAs(blob, "usersList.csv");
  }
}
