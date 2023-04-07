import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import Swal from "sweetalert2";

@Component({
  selector: 'app-avion',
  templateUrl: './avion.component.html',
  styleUrls: ['./avion.component.css']
})
export class AvionComponent implements OnInit {

  title:string='Avion';
  aviokompanijaPodaci: any;

  avionpodaci:any;
  odabraniavion:any=null;
  nrSelect: any="";
  frmAvionPodaci!: FormGroup;
  _isShow: boolean=false;
  naziv: string="";
  brojRegistracije: string="";
  brojMaxSjedista: number=0;
  brojSjedistaBusiness: number=0;
  brojSjedistaPrveKlase: number=0;
  datumZadnjegServisa: string="";
  aviokompanija_ID: number=0;
  noviAvion: any=null;

  constructor(private httpKlijent: HttpClient, private router: Router) {}

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
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Avion/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.avionpodaci = x;
    });
  }
  GetAviokompaniju():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Aviokompanija/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.aviokompanijaPodaci = x;
    });
  }
  GetAviokompanijaPodatke() {
    if (this.aviokompanijaPodaci == null)
      return [];
    return this.aviokompanijaPodaci;
  }


  ngOnInit(): void {
    this.GetAll();
    this.GetAviokompaniju();
    this.frmAvionPodaci=new FormGroup({
     // opis :new FormControl(this.naziv,Validators.required),
      brojRegistracije :new FormControl(this.brojRegistracije,Validators.required),
      brojMaxSjedista :new FormControl(this.brojMaxSjedista,Validators.required),
      brojSjedistaBusiness :new FormControl(this.brojSjedistaBusiness,Validators.required),
      brojSjedistaPrveKlase :new FormControl(this.brojSjedistaPrveKlase,Validators.required),
      datumZadnjegServisa :new FormControl(this.datumZadnjegServisa,Validators.required),
      aviokompanija_ID :new FormControl(this.aviokompanija_ID,Validators.required)
    });
  }
  validacija(){
    if(/*this.naziv!="" &&*/ this.brojRegistracije!="" &&
      this.brojMaxSjedista!=0 && this.brojSjedistaBusiness!=0 &&
      this.brojSjedistaPrveKlase!=0 && this.datumZadnjegServisa!="" &&
      this.aviokompanija_ID!=0
    )
      return true;
    return false;
  }
  obrisi(p:any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Avion/Delete/" + p.id,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        const index = this.avionpodaci.indexOf(p);
        if (index > -1) {
          this.avionpodaci.splice(index, 1);
        }
        this.SavedChanges();
      });
  }

  GetAvionPodaci(){
    if (this.avionpodaci == null)
      return [];
    return this.avionpodaci.filter((x:any)=>x.nrSelect=="" ||
      x.opis.startsWith(this.nrSelect));
    //return this.avionpodaci;
  }

  btnNovi() {
    this._isShow = !this._isShow;

    /*this.odabraniavion = {
      prikazi:true,
      Id:0,
      opis :"",
      brojRegistracije :"",
      brojMaxSjedista:null,
      brojSjedistaBusiness : null,
      brojSjedistaPrveKlase:null,
      datumZadnjegServisa : null,
      aviokompanija_ID : null

    }*/
  }

  add() {
    this.noviAvion={

      //naziv:this.naziv,
      brojRegistracije:this.brojRegistracije,
      brojMaxSjedista:this.brojMaxSjedista,
      brojSjedistaBusiness:this.brojSjedistaBusiness,
      brojSjedistaPrveKlase:this.brojSjedistaPrveKlase,
      datumZadnjegServisa:this.datumZadnjegServisa,
      aviokompanija_ID:this.aviokompanija_ID
    };
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Avion/Add",this.noviAvion,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        this.SavedChanges();
      });
  }

  basedOnSel(event: any) {
    const value =event.target.value;
    this.nrSelect=value;
    console.log(value);
  }
  avionAviokompanija(event: any) {
    const value = event.target.value;
    this.aviokompanija_ID=value;
    console.log(value);
  }

  detalji(s: any) {
    this.odabraniavion= s;
    this.odabraniavion.prikazi = true;
  }

  update() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Avion/Update/" + this.odabraniavion.id, this.odabraniavion,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        this.SavedChanges();
      });
  }
}
