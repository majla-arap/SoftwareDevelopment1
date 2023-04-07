import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-kupovina-karte',
  templateUrl: './kupovina-karte.component.html',
  styleUrls: ['./kupovina-karte.component.css']
})
export class KupovinaKarteComponent implements OnInit {

  gradPodaci: any;
  podaci:any;
  putanjaID: string="Jednosmjerna";
  putanjaPodaci: any;
  trenutnaStranica:number = 1;
  prikaz: boolean=false;
  kartaPodaci: any;
  kupi: boolean=false;
   sub: any;
  private id : number;

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.GetGradove();
    this.GetPutanju();



  }
  GetGradove():void {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Grad/GetByAll",MojConfig.http_opcije()).subscribe(x=>{
      this.gradPodaci = x;
    });
  }

  private GetPutanju() :void{
    this.httpKlijent.get(MojConfig.adresa_servera+"/PutanjaKarte/GetAll",MojConfig.http_opcije()).subscribe(
      x=>{
      this.putanjaPodaci=x;
      }
    );
  }

  /*GetAll():void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ `/Karta/GetByLet?id=${this.id}`,MojConfig.http_opcije()).subscribe(
      x=>{
      this.kartaPodaci = x;
    });
  }*/

  GetAll():void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ `/Karta/GetByLetPaged?id=${this.id}&page_number=${this.trenutnaStranica}`,MojConfig.http_opcije()).subscribe(
      x=>{
        this.podaci = x;
        this.kartaPodaci=this.podaci.dataItems;
      });
  }

  GetKartaPodaci(){
    if (this.kartaPodaci == null)
      return [];
    return this.kartaPodaci.filter((x:any)=>x.putanja.startsWith(this.putanjaID)
  );
  }

  Preuzmi(stranica:number)
  {
    this.trenutnaStranica=stranica;
    this.GetAll();
  }

  Trazi() {

    this.sub=this.route.params.subscribe(params=>{
      this.id=+params['id'];
      this.GetAll();
    });
    this.prikaz=true;
  }

  odabir(event: any) {
    this.kupi=!this.kupi;
  }

  dalje(s: any) {
    this.router.navigate(['prtljaga',s.id]);
  }
}
