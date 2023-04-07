import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import Swal from "sweetalert2";

declare function porukaSuccess(a: string):any;

@Component({
  selector: 'app-let-aerodrom',
  templateUrl: './let-aerodrom.component.html',
  styleUrls: ['./let-aerodrom.component.css']
})
export class LetAerodromComponent implements OnInit {
  aerodromLet:any;
  sub:any;
  noviAerodrom:any;
  odabraniAerodrom:any=null;
  private id:number;

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.sub=this.route.params.subscribe(params=>{
      this.id=+params['id'];
      this.preuzmiPodatke();
    });
  }

  private preuzmiPodatke(){
    this.httpKlijent.get(MojConfig.adresa_servera+`/AerodromLet/GetByLet?id=${this.id}`,MojConfig.http_opcije())
      .subscribe(x=>{
        this.aerodromLet=x;
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
    this.preuzmiPodatke();
  }

  detalji(s: any) {
    this.odabraniAerodrom=s;
    this.odabraniAerodrom.prikazi=true;
  }

  update() {
    this.httpKlijent.post(MojConfig.adresa_servera+"/AerodromLet/Update/"+this.odabraniAerodrom.id,this.odabraniAerodrom,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any)=>{
        /*porukaSuccess("uredu.."+povratnaVrijednost.id);*/
        /*this.preuzmiPodatke();*/
        this.SavedChanges();
        this.odabraniAerodrom=null;
      });
  }

  delete(s: any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/AerodromLet/Delete/" + s.id,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        const index = this.aerodromLet.aerodromLet.indexOf(s);
        if (index > -1) {
          this.aerodromLet.aerodromLet.splice(index, 1);
        }
        /*porukaSuccess("obrisano..." + povratnaVrijednost.id);*/
        this.SavedChanges();
        /*this.preuzmiPodatke();*/
      });
  }

  add(){
    this.httpKlijent.post(MojConfig.adresa_servera+"/AerodromLet/Add",this.noviAerodrom,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any)=>{
        /*porukaSuccess("uredu.."+povratnaVrijednost.id);*/
        /*this.preuzmiPodatke();*/
        this.SavedChanges();
        this.noviAerodrom=null;
      });
  }

  dodajAerodrom() {
    this.noviAerodrom={
      letID:this.aerodromLet.letID,
      aerodromID:1,
      aerodrom2_ID:1
    };
  }
}
