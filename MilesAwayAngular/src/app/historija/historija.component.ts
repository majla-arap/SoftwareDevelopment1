import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-historija',
  templateUrl: './historija.component.html',
  styleUrls: ['./historija.component.css']
})
export class HistorijaComponent implements OnInit {
  historijaPodaci:any;
  odabranaKarta:any=null;
  sub: any;
  private id : number;
  trenutnaStranica:number=1;
   podaci: any;

  constructor(private httpKlijent: HttpClient, private router: Router) {

  }

  /*getAll() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/KupljenaKarta/GetByKupac", MojConfig.http_opcije()).subscribe(x=>{
      this.historijaPodaci = x;
    });
  }*/
  getAll():void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ `/KupljenaKarta/GetByKupacPaged?page_number=${this.trenutnaStranica}`,MojConfig.http_opcije()).subscribe(
      x=>{
        this.podaci = x;
        this.historijaPodaci=this.podaci.dataItems;
      });
  }
  getHistorijaPodaci(){
    if(this.historijaPodaci==null)
      return[];
    return this.historijaPodaci;
  }

  ngOnInit(): void {
    this.getAll();
  }

  detalji(s: any) {
    this.odabranaKarta= s;
  }
  Preuzmi(stranica:number)
  {
    this.trenutnaStranica=stranica;
    this.getAll();
  }
}
