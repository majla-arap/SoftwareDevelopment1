import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-kupovina-let',
  templateUrl: './kupovina-let.component.html',
  styleUrls: ['./kupovina-let.component.css']
})
export class KupovinaLetComponent implements OnInit {

  letPodaci: any;
  polazisteGrad: any;
  destinacijaGrad:any;
  datumVrijemePolaska: any=null;
  gradPodaci: any;
  prikaz: boolean=false;


  constructor(private httpKlijent: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.GetGradove();

  }

  GetAll():void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ `/Let/GetAllKarte?polaziste=${this.polazisteGrad}&destinacija=${this.destinacijaGrad}&polazak=${this.datumVrijemePolaska}`,MojConfig.http_opcije()).subscribe(x=>{
      this.letPodaci = x;
    });

  }
  GetLetPodaci(){
    if (this.letPodaci == null)
      return [];
      return this.letPodaci.filter((x:any)=> (x.polaziste.toLowerCase().startsWith(this.polazisteGrad.toLowerCase())
        && x.destinacija.toLowerCase().startsWith(this.destinacijaGrad.toLowerCase()))
        &&  x.datumVrijemePolaska.day == this.datumVrijemePolaska.day
        && x.datumVrijemePolaska.month == this.datumVrijemePolaska.month
        && x.datumVrijemePolaska.year == this.datumVrijemePolaska.year);
  }
  GetGradove():void {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Grad/GetByAll",MojConfig.http_opcije()).subscribe(x=>{
      this.gradPodaci = x;
    });
  }

  Trazi() {
    console.log(this.datumVrijemePolaska);
    this.GetAll();
    this.prikaz=true;
  }

  basedOnSel(event:any) {
    const value =event.target.value;
    this.polazisteGrad=value;
    console.log(value);
  }

  basedOnSel2(event:any) {
    const value =event.target.value;
    this.destinacijaGrad=value;
    console.log(value);
  }

  Karte(s: any) {
    this.router.navigate(['kupovina-karte',s.id]);
  }
}
