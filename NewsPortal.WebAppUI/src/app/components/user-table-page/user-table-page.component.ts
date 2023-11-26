import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user';
import { UsersService } from 'src/app/service/users.service';

@Component({
  selector: 'app-user-table-page',
  templateUrl: './user-table-page.component.html',
  styleUrls: ['./user-table-page.component.css'],
})
export class UserTablePageComponent implements OnInit {
  users: User[];

  constructor(private usersService: UsersService) {}

  ngOnInit(): void {
    this.usersService.getUsers().subscribe((users) => {
      this.users = users;
      this.users.sort((a,b) => {
        if(a.isAdmin && b.isAdmin)
          return 0;
        if(a.isAdmin)
          return -1;
        return 1;
      })
    });
  }

  promoteUser(user: User): void {
    if (!user.isAdmin) {
      user.isAdmin = true;
      this.usersService.updateUser(user).subscribe({
        next: (res) => console.log(res),
        error: (err) => console.error(err),
      });
    }
  }
}
