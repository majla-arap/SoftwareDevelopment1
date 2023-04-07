import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import Swal from "sweetalert2";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-aviokompanija',
  templateUrl: './aviokompanija.component.html',
  styleUrls: ['./aviokompanija.component.css']
})
export class AviokompanijaComponent implements OnInit {
  title:string='Aviokompanija';
  aviokompanijaPodaci:any;
  //odabranaAvikompanija:any=null;
  novaAvikompanija:any=null;
  frmAviokompanijaPodaci!:FormGroup;
  opis:string="";
  _isShow:boolean =false;
  constructor(private httpKlijent: HttpClient, private router: Router) { }

  GetAll():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Aviokompanija/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.aviokompanijaPodaci = x;
    });
  }

  ngOnInit(): void {
    this.GetAll();
    this.frmAviokompanijaPodaci=new FormGroup({
      opis :new FormControl(this.opis,Validators.required)
    });
  }

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

  btnNovi() {
    this._isShow = !this._isShow;
    /*this.odabranaAvikompanija = {
      prikazi:true,
      aviokompanijaID:0,
      opis :""
    }*/
  }

  getAviokompanijaPodaci() {
    if (this.aviokompanijaPodaci == null)
      return [];
    return this.aviokompanijaPodaci;
  }

  add() {
    this.novaAvikompanija={opis:this.opis};
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Aviokompanija/Add",this.novaAvikompanija,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        /*porukaSuccess("uredu..."+ povratnaVrijednost.naziv);*/
        this.SavedChanges();
      });
    /*this.GetAll();*/
  }

  obrisi(p: any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Aviokompanija/Delete/" + p.id,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        const index = this.aviokompanijaPodaci.indexOf(p);
        if (index > -1) {
          this.aviokompanijaPodaci.splice(index, 1);
        }
        /*porukaSuccess("obrisano..." + povratnaVrijednost.naziv);*/
        this.SavedChanges();
      });
  }
  validacija(){
    if(this.opis!="")
      return true;
    return false;
  }

}
