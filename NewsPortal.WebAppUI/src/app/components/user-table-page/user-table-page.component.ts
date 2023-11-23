import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user';
import { UsersService } from 'src/app/service/users.service'; 

@Component({
  selector: 'app-user-table-page',
  templateUrl: './user-table-page.component.html',
  styleUrls: ['./user-table-page.component.css']
})

export class UserTablePageComponent implements OnInit {
  users: User[];

  constructor(private usersService: UsersService) {}

  ngOnInit(): void {
    this.usersService.getUsers().subscribe(users => {
      this.users = users;
    });
  }

  promoteUser(user: User): void {
    this.usersService.promoteUser(user.id).subscribe(
      (promotedUser) => {
        if (!user.isAdmin) {
          user.isAdmin = true;
        }
      }
    );
  }
}