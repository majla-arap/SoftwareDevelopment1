import {Component} from '@angular/core';
import {MojConfig} from "./moj-config";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

import {AutentifikacijaHelper} from "./helpers/autentifikacija-helper";
import {LoginInformacije} from "./helpers/login-informacije";


declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MilesAwayAngular';

  constructor(private httpKlijent: HttpClient, private router: Router) {

  }


  logoutButton() {
    AutentifikacijaHelper.setLoginInfo(null);

    this.httpKlijent.post(MojConfig.adresa_servera + "/Autentifikacija/Logout/", null, MojConfig.http_opcije())
      .subscribe((x: any) => {
        this.router.navigateByUrl("/login");
        porukaSuccess('Uspjesan login');
      });
  }

  loginInfo():LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }
}
