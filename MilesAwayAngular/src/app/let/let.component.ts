import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
import Swal from "sweetalert2";


@Component({
  selector: 'app-let',
  templateUrl: './let.component.html',
  styleUrls: ['./let.component.css']
})
export class LetComponent implements OnInit {
  title:string='Let';
  frmLetPodaci!:FormGroup;
  _isShow:boolean =false;
  letPodaci:any;
  odabraniLet:any=null;
  povratnaCijena!:number;
  jednosmijernaCijena!:number;
  vrijemeDolaska:string="";
  datumVrijemePolaska:string="";
  destinacijaGradID:number=0;
  polazisteGradID:number=0;
  sifraLeta:string="";
  gradPodaci:any;
  noviLet:any=null;
  trenutnaStranica:number = 1;
  podaci:any;


  constructor(private httpKlijent: HttpClient, private router: Router) { }

  ngOnInit(): void {
    //this.GetAll();
    this.getLetove();
    this.GetGradove();
    this.frmLetPodaci=new FormGroup({
      sifraLeta :new FormControl(this.sifraLeta,Validators.required),
      polazisteGradID :new FormControl(this.polazisteGradID,Validators.required),
      destinacijaGradID :new FormControl(this.destinacijaGradID,Validators.required),
      datumVrijemePolaska :new FormControl(this.datumVrijemePolaska,Validators.required),
      vrijemeDolaska :new FormControl(this.vrijemeDolaska,Validators.required),
      jednosmijernaCijena :new FormControl(this.jednosmijernaCijena,Validators.required),
      povratnaCijena :new FormControl(this.povratnaCijena,Validators.required),
    });
  }

  validacija(){
    if(this.sifraLeta!="" && this.datumVrijemePolaska!="" && this.vrijemeDolaska!="" && this.polazisteGradID!=0 && this.destinacijaGradID!=0
       && this.jednosmijernaCijena!=0 && this.povratnaCijena!=0)
      return true;
    return false;
  }

  btnNovi() {
    this._isShow = !this._isShow;
  }



  GetGradove():void {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Grad/GetByAll",MojConfig.http_opcije()).subscribe(x=>{
      this.gradPodaci = x;
    });
  }

  GetGradovePodatke(){
    if (this.gradPodaci == null)
      return [];
    return this.gradPodaci;
  }

  SavedChanges() {
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      title: 'Your work has been saved',
      showConfirmButton: false,
      timer: 1500
    })
    //this.GetAll();
    this.getLetove();
  }

  add() {
    this.noviLet={
      sifraLeta:this.sifraLeta,
      polazisteGradID:this.polazisteGradID,
      destinacijaGradID:this.destinacijaGradID,
      vrijemePolaska:this.datumVrijemePolaska,
      vrijemeDolaska:this.vrijemeDolaska,
      jednosmijernaCijena:this.jednosmijernaCijena,
      povratnaCijena:this.povratnaCijena,
    };
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Let/Add",this.noviLet,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        /*porukaSuccess("Uredu..."+ povratnaVrijednost.sifraLeta);*/
        this.SavedChanges();
      });
    /*this.GetAll();*/
  }

  /*GetAll():void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Let/GetAll",MojConfig.http_opcije()).subscribe(x=>{
    this.letPodaci = x;
  });
  }*/

  getLetove():void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+`/Let/GetAllPaged?page_number=${this.trenutnaStranica}`,MojConfig.http_opcije()).subscribe(
      x=>{
        this.podaci = x;
        this.letPodaci=this.podaci.dataItems;
      }
    );
  }
  GetLetPodaci(){
    if (this.letPodaci == null)
      return [];
    return this.letPodaci;
  }

  obrisi(s: any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Let/Delete/" + s.id,null,MojConfig.http_opcije()).subscribe(
      (povratnaPoruka:any) =>{
        /*porukaSuccess("uspjesno obrisan let " +povratnaPoruka.sifraLeta);*/
        this.SavedChanges();
      }
    );
    /*this.GetAll();*/
  }

  detalji(s: any) {

    this.odabraniLet= s;
    this.odabraniLet.prikazi = true;

  }

  update() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Let/Update/" + this.odabraniLet.id, this.odabraniLet,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        /*porukaSuccess("uredu..."+ povratnaVrijednost.sifraLeta);*/
        this.SavedChanges();
        this.odabraniLet.prikazi = false;
      });
  }

  aerodrom(s: any) {
    this.router.navigate(['let-aerodrom',s.id]);
  }

  avion(s: any) {
    this.router.navigate(['let-avion',s.id]);
  }

  pilot(s: any) {
    this.router.navigate(['let-pilot',s.id]);
  }

  Preuzmi(stranica:number)
  {
    this.trenutnaStranica=stranica;
    this.getLetove();
  }

}
