import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import Swal from "sweetalert2";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-obavijest-kategorija',
  templateUrl: './obavijest-kategorija.component.html',
  styleUrls: ['./obavijest-kategorija.component.css']
})
export class ObavijestKategorijaComponent implements OnInit {
  title:string='Kategorije obavijesti';
  kategorijaPodaci:any;
  novaKategorija:any=null;
  odabranaKategorija:any=null;
  naziv: string="";
  frmKategorijaPodaci!:FormGroup;
  _isShow:boolean =false;

  constructor(private httpKlijent: HttpClient, private router: Router) { }

  GetAll():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ "/ObavijestKategorija/GetByAll",MojConfig.http_opcije()).subscribe(x=>{
      this.kategorijaPodaci = x;
    });
  }

  ngOnInit(): void {
    this.GetAll();
    this.frmKategorijaPodaci=new FormGroup({
      naziv :new FormControl(this.naziv,Validators.required)
    });
  }

  btnNovi() {
    this._isShow = !this._isShow;
    /*this.odabranaKategorija = {
      prikazi:true,
      obavijestKategorijeID:0,
      naziv :""
    };*/
  }

  getKategorijePodaci() {
    if (this.kategorijaPodaci == null)
      return [];
    return this.kategorijaPodaci;
  }

  detalji(s: any) {
    this.odabranaKategorija=s;
    this.odabranaKategorija.prikazi=true;

  }

  obrisi(s: any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/ObavijestKategorija/Delete/"+s.obavijestKategorijeID,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any)=>{
        const index = this.kategorijaPodaci.indexOf(s);
        if (index > -1) {
          this.kategorijaPodaci.splice(index, 1);
        }
        /*porukaSuccess("Obrisano..." + povratnaVrijednost.naziv);*/
        this.SavedChanges();
    });
    this.GetAll();
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

  add(){
    this.novaKategorija = {
        naziv:this.naziv
      };
    this.httpKlijent.post(MojConfig.adresa_servera+ "/ObavijestKategorija/Add",this.novaKategorija,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any)=>{
        /*porukaSuccess("Dodano..." + povratnaVrijednost.naziv);*/
        this.SavedChanges();
      });
    /*this.GetAll();*/
  }

  update(){
    this.httpKlijent.post(MojConfig.adresa_servera+ "/ObavijestKategorija/Update/"+this.odabranaKategorija.obavijestKategorijeID,this.odabranaKategorija,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any)=>{
        /*porukaSuccess("Uređeno..." + povratnaVrijednost.naziv);*/
        this.SavedChanges();
      });
    /*this.GetAll();*/
  }

  validacija(){
    if(this.naziv!="")
      return true;
    return false;
  }
}
