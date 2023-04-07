import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import Swal from "sweetalert2";

declare function porukaSuccess(a: string):any;

@Component({
  selector: 'app-let-pilot',
  templateUrl: './let-pilot.component.html',
  styleUrls: ['./let-pilot.component.css']
})
export class LetPilotComponent implements OnInit {
  pilotLet:any;
  sub:any;
  noviPilot:any;
  odabraniPilot:any=null;
  private id:number;

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.sub=this.route.params.subscribe(params=>{
      this.id=+params['id'];
      this.preuzmiPodatke();
    });
  }

  private preuzmiPodatke(){
    this.httpKlijent.get(MojConfig.adresa_servera+`/PilotLet/GetByLet?id=${this.id}`,MojConfig.http_opcije())
      .subscribe(x=>{
        this.pilotLet=x;
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
    this.odabraniPilot=s;
    this.odabraniPilot.prikazi=true;
  }

  update() {
    this.httpKlijent.post(MojConfig.adresa_servera+"/PilotLet/Update/"+this.odabraniPilot.id,this.odabraniPilot,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any)=>{
        /*porukaSuccess("uredu.."+povratnaVrijednost.id);*/
        /*this.preuzmiPodatke();*/
        this.SavedChanges();
        this.odabraniPilot=null;
      });
  }

  delete(s: any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/PilotLet/Delete/" + s.id,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        /*const index = this.pilotLet.pilotLet.indexOf(s);
        if (index > -1) {
          this.pilotLet.aerodromLet.splice(index, 1);
        }*/
        /*porukaSuccess("obrisano..." + povratnaVrijednost.id);*/
        this.SavedChanges();
        /*this.preuzmiPodatke();*/
      });
  }

  add(){
    this.httpKlijent.post(MojConfig.adresa_servera+"/PilotLet/Add",this.noviPilot,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any)=>{
        /*porukaSuccess("uredu.."+povratnaVrijednost.id);*/
        /*this.preuzmiPodatke();*/
        this.SavedChanges();
        this.noviPilot=null;
      });
  }

  dodajPilot() {
    this.noviPilot={
      letID:this.pilotLet.letID,
      pilotID:1
    };
  }
}
