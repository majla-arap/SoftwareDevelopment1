import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import Swal from "sweetalert2";


@Component({
  selector: 'app-presjedanje',
  templateUrl: './presjedanje.component.html',
  styleUrls: ['./presjedanje.component.css']
})
export class PresjedanjeComponent implements OnInit {
  title:string='Presjedanje';
  letPodaci:any;
  gradPodaci:any;
  presjedanjePodaci:any;
  odabranoPresjedanje:any=null;
  novoPresjedanje:any=null;
  nrSelect:any="";
  frmPresjedanjePodaci!:FormGroup;
  _isShow:boolean =false;
  gradID:number=0;
  letID:number=0;
  vrijemeDolaska:string="";
  vrijemePolaska:string="";

  constructor(private httpKlijent: HttpClient, private router: Router) { }

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
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Presjedanje/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.presjedanjePodaci = x;
    });
  }

  GetGradove():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Grad/GetByAll",MojConfig.http_opcije()).subscribe(x=>{
      this.gradPodaci = x;
    });
  }

  GetLetove():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Let/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.letPodaci = x;
    });
  }

  btnNovi() {
    this._isShow = !this._isShow;
    /*this.odabranoPresjedanje = {
      prikazi:true,
      presjedanjeID:0,
      letID :0,
      gradID:0,
      vrijemeDolaska: "1988-10-01T18:10:12.374",
      vrijemePolaska:  "1988-10-01T18:10:12.374"
    }*/
  }

  basedOnSel(event: any) {
    const value =event.target.value;
    this.nrSelect=value;
    console.log(value);
  }

  GetLetovePodatke() {
    if (this.letPodaci == null)
      return [];
    return this.letPodaci;
  }

  GetGradovePodatke(){
    if (this.gradPodaci == null)
      return [];
    return this.gradPodaci;
  }

  GetPresjedanjePodaci() {
    if (this.presjedanjePodaci == null)
      return [];
    return this.presjedanjePodaci.filter((x: any)=> x.nrSelect==" " ||
      x.sifraLeta .startsWith(this.nrSelect));
  }

  obrisi(p: any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Presjedanje/Delete/" + p.id,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        const index = this.presjedanjePodaci.indexOf(p);
        if (index > -1) {
          this.presjedanjePodaci.splice(index, 1);
        }
        /*porukaSuccess("obrisano..." + povratnaVrijednost.opis);*/
        this.SavedChanges();
      });
  }

  detalji(p: any) {
    this.odabranoPresjedanje = p;
    this.odabranoPresjedanje.prikazi = true;
  }

  ngOnInit(): void {
    this.GetAll();
    this.GetGradove();
    this.GetLetove();
    this.frmPresjedanjePodaci=new FormGroup({
      letID :new FormControl(this.letID,Validators.required),
      gradID :new FormControl(this.gradID,Validators.required),
      vrijemePolaska :new FormControl(this.vrijemePolaska,Validators.required),
      vrijemeDolaska :new FormControl(this.vrijemeDolaska,Validators.required)
    });
  }

  validacija(){
    if(this.vrijemeDolaska!="" && this.vrijemePolaska!="" && this.gradID!=0 && this.letID!=0)
      return true;
    return false;
  }

  add() {
    this.novoPresjedanje={
      letID:this.letID,
      gradID:this.gradID,
      vrijemePolaska:this.vrijemePolaska,
      vrijemeDolaska:this.vrijemeDolaska
    };
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Presjedanje/Add",this.novoPresjedanje,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        /*porukaSuccess("uredu..."+ povratnaVrijednost.presjedanjeID);*/
        this.SavedChanges();
      });
    /*this.GetAll();*/
  }

  update() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Presjedanje/Update/" + this.odabranoPresjedanje.id, this.odabranoPresjedanje,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        /*porukaSuccess("uredu..."+ povratnaVrijednost.presjedanjeID);*/
        this.SavedChanges();
      });
  }

  presjedanjeLet(event: any) {
    const value =event.target.value;
    this.letID=value;
    console.log(value);
  }

  presjedanjeGrad(event: any) {
    const value =event.target.value;
    this.gradID=value;
    console.log(value);
  }

  presjedanjeLetUpdate(event: any) {
    const value =event.target.value;
    this.odabranoPresjedanje.letID=value;
    console.log(value);
  }

  presjedanjeGradUpdate(event: any) {
    const value =event.target.value;
    this.odabranoPresjedanje.gradID=value;
    console.log(value);
  }
}
