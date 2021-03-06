import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ThrowStmt } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router, private alretify: AlertifyService){}
  canActivate(): boolean {
    if(this.authService.loggedIn()){
      return true;
    }

    this.alretify.error('you shall not pass!!!!');
    this.router.navigate(['/home']);
    return false;
  }
  
}
