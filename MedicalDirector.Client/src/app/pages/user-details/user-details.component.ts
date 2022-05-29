import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RestApiService } from '../../services/rest-api.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {
  UserDetails: any = {};
  id = this.actRoute.snapshot.params['id'];

  constructor(
    public restApi: RestApiService,
    public actRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.loadUser(this.id);
  }

  loadUser(id: number) {
    return this.restApi.getUserDetails(id).subscribe((data: {}) => {
      this.UserDetails = data;
    })
  }
}
