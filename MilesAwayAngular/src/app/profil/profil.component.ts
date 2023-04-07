import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
import {FormGroup} from "@angular/forms";

declare function porukaSuccess(a: string):any;

@Component({
  selector: 'app-profil',
  templateUrl: './profil.component.html',
  styleUrls: ['./profil.component.css']
})
export class ProfilComponent implements OnInit {
  kupac:any;
  urediKupac:any;
  hide=true;
  closeResult='';

  constructor(private httpKlijent: HttpClient, private router: Router) {
    this.preuzmiPodatke();
  }

  ngOnInit(): void {

  }
  preuzmiPodatke(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/Kupac/GetByKupac",MojConfig.http_opcije())
      .subscribe(x=>{
        this.kupac=x;
      });
  }

  uredi() {
    this.urediKupac={
      ime:this.kupac.ime,
      prezime:this.kupac.prezime,
      email:this.kupac.email,
      korisnickoIme:this.kupac.korisnickoIme,
      lozinka:this.kupac.lozinka
    };
  }

  snimipodatke() {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Kupac/Update",this.urediKupac,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any)=>{
        porukaSuccess("uredu..." + povratnaVrijednost.ime);
        this.urediKupac=null;
        this.preuzmiPodatke();
      });
  }

}

