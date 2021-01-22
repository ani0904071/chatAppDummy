import { Component, OnInit } from '@angular/core';
import { User } from './user';
import { UserService } from '../user.service';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  data: User[] = [];
  displayedColumns: string[] = ['userId', 'firstName', 'lastName', 'email'];
  isLoadingResults = true;

  constructor(private userService: UserService, private authService: AuthService, private router: Router) { }

  // tslint:disable-next-line:typedef
  ngOnInit() {
    this.getUsers();
  }

  getUsers(): void {
    this.userService.getUsers()
      .subscribe(users => {
        this.data = users;
        console.log('UserComponent', this.data);
        this.isLoadingResults = false;
      }, err => {
        console.log(err);
        this.isLoadingResults = false;
      });
  }

  // tslint:disable-next-line:typedef
  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }

  openChatHead(userId) {
    console.log('user:', userId);
  }

}
