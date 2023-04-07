import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import Swal from "sweetalert2";

@Component({
  selector: 'app-aerodrom',
  templateUrl: './aerodrom.component.html',
  styleUrls: ['./aerodrom.component.css']
})
export class AerodromComponent implements OnInit {
  title:string='Aerodrom';
  gradPodaci:any;
  aerodromPodaci:any;
 //odabraniAerodrom:any=null;
  nrSelect:any="";
  noviAerodrom:any=null;
  frmAerodromPodaci!:FormGroup;
  _isShow:boolean =false;
  naziv:string="";
  gradID:number=0;

  constructor(private httpKlijent: HttpClient, private router: Router) { }

  GetAll():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Aerodrom/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.aerodromPodaci = x;
    });
  }

  GetGradove():void{
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
    this.GetAll();
  }

  ngOnInit(): void {
    this.GetAll();
    this.GetGradove();
    this.frmAerodromPodaci=new FormGroup({
      naziv :new FormControl(this.naziv,Validators.required),
      gradID :new FormControl(this.gradID,Validators.required)
    });
  }

  obrisi(p:any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Aerodrom/Delete/" + p.aerodromID,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        const index = this.aerodromPodaci.indexOf(p);
        if (index > -1) {
          this.aerodromPodaci.splice(index, 1);
        }
        /*porukaSuccess("obrisano..." + povratnaVrijednost.opis);*/
        this.SavedChanges();
      });
  }

  GetAerodromPodaci() {
    if (this.aerodromPodaci == null)
      return [];
    return this.aerodromPodaci.filter((x: any)=> x.nrSelect==" " ||
      x.grad.startsWith(this.nrSelect));
    //filter((x: any)=> x.gradID==this.nrSelect);

  }
  validacija(){
    if(this.naziv!="" && this.gradID!=0)
      return true;
    return false;
  }
  btnNovi() {
    this._isShow = !this._isShow;
    /*this.odabraniAerodrom = {
      prikazi:true,
      aerodromID:0,
      naziv :"",
      gradID:0
    }*/
  }

  add() {
    this.noviAerodrom={
      naziv:this.naziv,
      gradID:this.gradID
    };
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Aerodrom/Add",this.noviAerodrom,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        /*porukaSuccess("uredu..."+ povratnaVrijednost.ime);*/
        this.SavedChanges();
      });
    /*this.GetAll();*/
  }


  basedOnSel(event:any) {
    const value =event.target.value;
    this.nrSelect=value;
    console.log(value);
  }

  aerodromGrad(event: any) {
    const value = event.target.value;
    this.gradID=value;
    console.log(value);
  }
}
