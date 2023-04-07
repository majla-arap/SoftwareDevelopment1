import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";

declare function porukaSuccess(a: string):any;

@Component({
  selector: 'app-registracija',
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})
export class RegistracijaComponent implements OnInit {
  frmRegistracijaPodaci!: FormGroup;
  txtKorisnickoIme: string="";
  txtLozinka: string="";
  txtIme: string="";
  txtPrezime: string="";
  txtEmail: string="";

  constructor(private httpKlijent: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.frmRegistracijaPodaci=new FormGroup({
      txtKorisnickoIme :new FormControl(this.txtKorisnickoIme,Validators.required),
      txtLozinka :new FormControl(this.txtLozinka,Validators.required),
      txtIme:new FormControl(this.txtIme,Validators.required),
      txtPrezime:new FormControl(this.txtPrezime,Validators.required),
      txtEmail:new FormControl(this.txtEmail,Validators.required),
    });
  }
  validacija(){
    if(this.txtKorisnickoIme!="" && this.txtLozinka!="" && this.txtIme!="" && this.txtPrezime!="" && this.txtEmail!="")
      return true;
    return false;
  }
  Add() {
    let saljemo = {
      ime:this.txtIme,
      prezime:this.txtPrezime,
      email:this.txtEmail,
      korisnickoIme:this.txtKorisnickoIme,
      lozinka: this.txtLozinka
    };
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Registracija/Add/", saljemo)
      .subscribe((x:any) =>{
        porukaSuccess("Uspješna registracija korisnika "+ x.korisnickoIme);
      });
  }
}
