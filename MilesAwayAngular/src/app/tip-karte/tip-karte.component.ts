import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import Swal from "sweetalert2";


interface Aktivnost {
  value: boolean;
  viewValue: string;
}

@Component({
  selector: 'app-tip-karte',
  templateUrl: './tip-karte.component.html',
  styleUrls: ['./tip-karte.component.css']
})
export class TipKarteComponent implements OnInit {
odabranitip:any=null;
tipPodaci:any;
//isActive=true;
frmTipKarte!: FormGroup;
  _isShow: boolean=false;
  naziv: string="";
  Cijena: number=0;
  IsAktivan: boolean=false;
  noviTip: any=null;
  /*aktivnost: Aktivnost[] = [
    {value: false, viewValue: 'False'},
    {value: true, viewValue: 'True'},
  ];*/

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
    this.httpKlijent.get(MojConfig.adresa_servera+ "/TipKarte/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.tipPodaci = x;
    });
  }
  ngOnInit(): void {
    this.GetAll();
    this.frmTipKarte=new FormGroup({
      naziv :new FormControl(this.naziv,Validators.required),
      Cijena :new FormControl(this.Cijena,Validators.required),
      IsAktivan :new FormControl(this.IsAktivan,Validators.required)
    });
  }
  btnNovi() {
    this._isShow = !this._isShow;

    /*this.odabranitip = {
      prikazi:true,
      TipID:0,
      Naziv :"",
      Cijena:null,
      IsAktivan:true
    }*/
  }

  getTipPodaci() {
    if (this.tipPodaci == null)
      return [];
    return this.tipPodaci;
  }

  obrisi(p: any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/TipKarte/Delete/" + p.id,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        const index = this.tipPodaci.indexOf(p);
        if (index > -1) {
          this.tipPodaci  .splice(index, 1);
        }
        this.SavedChanges();
      });
  }

  add() {
    this.noviTip={
      naziv:this.naziv,
      Cijena:this.Cijena,
      Aktivan:this.IsAktivan,
    };
    this.httpKlijent.post(MojConfig.adresa_servera+ "/TipKarte/Add",this.noviTip,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        this.SavedChanges();
      });
  }
  update() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/TipKarte/Update/" + this.odabranitip.id, this.odabranitip,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        this.SavedChanges();
      });
  }
  /*checked($event: any) {
    const isChecked = (<HTMLInputElement>$event.target).checked;
    console.log(isChecked)
  }*/

  detalji(p: any) {
    this.odabranitip= p;
    this.odabranitip.prikazi = true;
  }
  validacija(){
    if(this.naziv!="" && this.Cijena!=0 && this.IsAktivan!=false)
      return true;
    return false;
  }


}
