import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import Swal from "sweetalert2";

declare function porukaSuccess(a: string):any;

@Component({
  selector: 'app-let-avion',
  templateUrl: './let-avion.component.html',
  styleUrls: ['./let-avion.component.css']
})
export class LetAvionComponent implements OnInit {
  avionLet: any;
  noviAvion: any;
  odabraniAvion: any=null;
  sub:any;
  private id:number;
  avioni:any;

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) { }

  SavedChanges() {
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      title: 'Your work has been saved',
      showConfirmButton: false,
      timer: 1500
    })
    this.getAvioni();
  }
  getAvioni(){
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Avion/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.avioni = x;
    });
  }
  ngOnInit(): void {
    this.sub=this.route.params.subscribe(params=>{
      this.id=+params['id'];
      this.preuzmiPodatke();
      this.getAvioni();
    });
  }
private preuzmiPodatke(){
  this.httpKlijent.get(MojConfig.adresa_servera+`/AvionLet/GetByLet?id=${this.id}`, MojConfig.http_opcije()).subscribe(
    x=>{
  this.avionLet=x;
    }
  );
}

  detalji(s: any) {
  this.odabraniAvion=s;
  this.odabraniAvion.prikazi=true;
  }

  delete(s: any) {
  this.httpKlijent.post(MojConfig.adresa_servera+"/AvionLet/Delete/" + s.id,null,MojConfig.http_opcije())
    .subscribe((povratna:any)=>{
     /* const indeks=this.avionLet.avionLet.indexOf(s);
      if(indeks > -1){
        this.avionLet.avionLet.splice(indeks,1);
      }*/
     this.SavedChanges();

      this.preuzmiPodatke();
    });
  }

  dodajAvion() {
    this.noviAvion={
      letID:this.avionLet.letID,
      avionID:1,
    };
  }

  add() {
    this.httpKlijent.post(MojConfig.adresa_servera+"/AvionLet/Add",this.noviAvion,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any)=>{
        porukaSuccess("uredu.."+povratnaVrijednost.id);

        this.preuzmiPodatke();
        this.noviAvion=null;
      });
  }

  update() {
    this.httpKlijent.post(MojConfig.adresa_servera+"/AvionLet/Update/"+this.odabraniAvion.id,this.odabraniAvion,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any)=>{
        this.SavedChanges();
        this.preuzmiPodatke();
        this.odabraniAvion=null;
      });
  }
}
