import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import Swal from "sweetalert2";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-pilot',
  templateUrl: './pilot.component.html',
  styleUrls: ['./pilot.component.css']
})
export class PilotComponent implements OnInit {
  title:string='Pilot';
  tekst:string='';
  pilotPodaci:any;
  odabraniPilot:any=null;
  noviPilot:any=null;
  ime: string="";
  prezime: string="";
  brojDozvole: string="";
  datumRodjenja: string="";
  datumZaposlenja: string="";
  spol: string="";
  jmbg: string="";
  kontakt: string="";
  adresa: string="";
  frmPilotPodaci!:FormGroup;
  _isShow:boolean =false;

  constructor(private httpKlijent: HttpClient, private router: Router) { }

  GetAll():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Pilot/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.pilotPodaci = x;
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


  getPilotPodaci() {
    if (this.pilotPodaci == null)
      return [];
    return this.pilotPodaci.filter((x: any)=> x.tekst=="" ||
       x.ime.toLowerCase().startsWith(this.tekst.toLowerCase())
      || x.prezime.toLowerCase().startsWith(this.tekst.toLowerCase())
    || x.brojDozvole.toLowerCase().startsWith(this.tekst.toLowerCase()));
  }

  ngOnInit(): void {
   this.GetAll();
    this.frmPilotPodaci=new FormGroup({
      ime :new FormControl(this.ime,Validators.required),
      prezime :new FormControl(this.prezime,Validators.required),
      brojDozvole :new FormControl(this.brojDozvole,Validators.required),
      datumRodjenja :new FormControl(this.datumRodjenja,Validators.required),
      datumZaposlenja :new FormControl(this.datumZaposlenja,Validators.required),
      spol :new FormControl(this.spol,Validators.required),
      jmbg :new FormControl(this.jmbg,Validators.required),
      kontakt :new FormControl(this.kontakt,Validators.required),
      adresa :new FormControl(this.adresa,Validators.required)
    });
  }

  detalji(p:any) {
    this.odabraniPilot= p;
    this.odabraniPilot.prikazi = true;
    /*this.ime=p.ime;
    this.prezime=p.prezime;
    this.brojDozvole=p.brojDozvole;
    this.datumRodjenja=p.datumRodjenja;
    this.datumZaposlenja=p.datumZaposlenja;
    this.spol=p.spol;
    this.jmbg=p.jmbg;
    this.kontakt=p.kontakt;
    this.adresa=p.adresa;*/
    //uz ovo ne radi add upisuje u textboxove podatke
  }

  obrisi(p:any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Pilot/Delete/" + p.pilotID,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        const index = this.pilotPodaci.indexOf(p);
        if (index > -1) {
          this.pilotPodaci.splice(index, 1);
        }
        /*porukaSuccess("obrisano..." + povratnaVrijednost.ime);*/
        this.SavedChanges();
      });
  }
  update() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Pilot/Update/" + this.odabraniPilot.pilotID, this.odabraniPilot,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        /*porukaSuccess("uredu..."+ povratnaVrijednost.ime);*/
        this.SavedChanges();
      });
  }
  validacija(){
    if(this.ime!="" && this.prezime!="" && this.brojDozvole!="" && this.datumRodjenja!=""
      && this.datumZaposlenja!="" && this.spol!="" && this.jmbg!="" && this.kontakt!="" && this.adresa!="")
      return true;
    return false;
  }
  add() {
    this.noviPilot={
      ime:this.ime,
      prezime:this.prezime,
      brojDozvole:this.brojDozvole,
      datumRodjenja:this.datumRodjenja,
      datumZaposlenja:this.datumZaposlenja,
      spol:this.spol,
      jmbg:this.jmbg,
      kontakt:this.kontakt,
      adresa:this.adresa
    };
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Pilot/Add",this.noviPilot,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        /*porukaSuccess("uredu..."+ povratnaVrijednost.ime);*/
        this.SavedChanges();
      });
    /*this.GetAll();*/
  }
  btnNovi() {
    this._isShow = !this._isShow;
    /*this.odabraniPilot = {
      prikazi:true,
      pilotID:0,
      ime :"",
      prezime:"",
      brojDozvole: "bh0000",
      datumRodjenja:  "1988-10-01",
      datumZaposlenja: "2020-11-01",
      spol:'M',
      jmbg:"185203464",
      kontakt:"062598452",
      adresa:"neka"
    }*/
  }
}
