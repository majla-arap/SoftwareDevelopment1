import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import Swal from "sweetalert2";


@Component({
  selector: 'app-drzava',
  templateUrl: './drzava.component.html',
  styleUrls: ['./drzava.component.css']
})
export class DrzavaComponent implements OnInit {
  title:string="Drzave";

  drzavaPodaci:any;
  odabranaDrzava:any=null;
  frmDrzavaPodaci!: FormGroup;
  opis:string="";
  _isShow:boolean =false;
   novaDrzava: any=null;

  constructor(private httpKlijent: HttpClient, private router: Router) { }

  SavedChanges() {
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      title: 'Your work has been saved',
      showConfirmButton: false,
      timer: 1500
    })
    this.GetAll();
  }

  GetAll():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Drzava/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.drzavaPodaci = x;
    });
  }
  getDrzavaPodaci() {
    if (this.drzavaPodaci == null)
      return [];
    return this.drzavaPodaci;
  }


  obrisi(p:any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Drzava/Delete/" + p.id,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        const index = this.drzavaPodaci.indexOf(p);
        if (index > -1) {
          this.drzavaPodaci.splice(index, 1);
        }
        this.SavedChanges();
      });
  }
  ngOnInit(): void {
    this.GetAll();
    this.frmDrzavaPodaci=new FormGroup({
      opis :new FormControl(this.opis,Validators.required),
    });

  }
  validacija(){
    if(this.opis!="")
      return true;
    return false;
  }
  add() {
    this.novaDrzava={
      opis:this.opis,
    };
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Drzava/Add",this.novaDrzava,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        this.SavedChanges();
      });
  }

  btnNovi() {
    this._isShow = !this._isShow;

    /*  this.odabranaDrzava = {
        prikazi:true,
        drzavaID:0,
        opis :""
      }*/
  }
}
