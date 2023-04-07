import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-prtljaga',
  templateUrl: './prtljaga.component.html',
  styleUrls: ['./prtljaga.component.css']
})
export class PrtljagaComponent implements OnInit {
  private prtljagPodaci: any;
  tipPutnikaPodaci:any;
   sub: any;
  private id: number;
  prtljagaID:number=0;
  tipPutnikaID:number=0;


  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number

      this.preuzmiPodakt()
    });
    this.getTipPutnika();
  }
  dalje() {
    this.router.navigate(['racun',this.id,this.prtljagaID,this.tipPutnikaID]);
  }

  getTipPutnika():void{
    this.httpKlijent.get(MojConfig.adresa_servera+"/TipPutnika/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.tipPutnikaPodaci=x;
    });
  }
  preuzmiPodakt():void{
    this.httpKlijent.get(MojConfig.adresa_servera+"/Prtljag/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.prtljagPodaci=x;
    });
  }
  getPrtljagaPodaci() {

      if(this.prtljagPodaci==null)
        return [];
      return this.prtljagPodaci;

  }
  getTipPutnikaPodaci(){
    if(this.tipPutnikaPodaci==null)
      return [];
    return this.tipPutnikaPodaci;
  }


  prtljaga(event: any,s:any) {
   this.prtljagaID=s.id;
   const value = event.currentTarget.checked;
   console.log(s.id,s.naziv);
    console.log(value);
    console.log(this.prtljagaID);

  }
  putnik(event: any,s:any) {
    this.tipPutnikaID=s.id;
  }
}
