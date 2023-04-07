import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import Swal from "sweetalert2";



@Component({
  selector: 'app-karta',
  templateUrl: './karta.component.html',
  styleUrls: ['./karta.component.css']
})
export class KartaComponent implements OnInit {
  nrSelect: any="";
  podaci:any;
  trenutnaStranica:number = 1;
   kartaPodaci: any;
  frmKartaPodaci!: FormGroup;
  _isShow: boolean=false;
  vrijemepol: string="";
  vrijemedol: string="";
  Cijena: number=0;
  IsAktivan: boolean=false;
  letID: number=0;
  letPodaci: any;
  tipID: number=0;
  tipPodaci: any;
   novaKarta: any=null;
   odabranaKarta: any=null;

  constructor(private httpKlijent: HttpClient, private router: Router) { }

  SavedChanges() {
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      title: 'Your work has been saved',
      showConfirmButton: false,
      timer: 1500
    })
    this.getKarta();
  }

  ngOnInit(): void {
    this.getKarta();
    this.GetLet();
    this.getTip();
    this.frmKartaPodaci=new FormGroup({
      vrDol :new FormControl(this.vrijemedol,Validators.required),
      vrPol :new FormControl(this.vrijemepol,Validators.required),
      Cijena :new FormControl(this.Cijena,Validators.required),
      IsAktivan :new FormControl(this.IsAktivan,Validators.required),
      letID :new FormControl(this.letID,Validators.required),
      tipID:new FormControl(this.tipID,Validators.required)
    });
  }

  btnNovi() {
    this._isShow = !this._isShow;

  }

  basedOnSel(event: any) {
    const value =event.target.value;
    this.nrSelect=value;
    console.log(value);
  }
/*getKarta():void
{
  this.httpKlijent.get(MojConfig.adresa_servera+"/Karta/GetAll",MojConfig.http_opcije()).subscribe(
    x=>{
      this.kartaPodaci=x;
    }
  );
}*/
  getKarta():void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+`/Karta/GetAllPaged?page_number=${this.trenutnaStranica}`,MojConfig.http_opcije()).subscribe(
      x=>{
        this.podaci = x;
        this.kartaPodaci=this.podaci.dataItems;
      }
    );
  }

  Preuzmi(stranica:number)
  {
    this.trenutnaStranica=stranica;
    this.getKarta();
  }

  getKartaPodaci() {
    if(this.kartaPodaci==null)
    {
      return [];
    }
    return this.kartaPodaci;

  }

  obrisi(s: any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Karta/Delete/" + s.id,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        const index = this.kartaPodaci.indexOf(s);
        if (index > -1) {
          this.kartaPodaci.splice(index, 1);
        }
        this.SavedChanges();
      });
  }

  detalji(p: any) {
    this.odabranaKarta= p;
    this.odabranaKarta.prikazi = true;
  }

  validacija() {
    if(this.vrijemedol!="" &&this.vrijemepol!=""&& this.Cijena!=0&& this.tipID!=0 && this.letID!=0)
      return true;
    return false;
  }

  add() {
    this.novaKarta={
     vrijemePolaska:this.vrijemepol,
      vrijemeDolaska:this.vrijemedol,
      Cijena:this.Cijena,
      Aktivna:this.IsAktivan,
      tipKarteID:this.tipID,
      letID:this.letID
    };

    this.httpKlijent.post(MojConfig.adresa_servera+ "/Karta/Add",this.novaKarta,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        this.SavedChanges();
      });
    this.getKarta();
  }
  GetLet():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Let/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.letPodaci = x;
    });
  }

  GetLetPodaci(){
    if (this.letPodaci == null)
      return [];
    return this.letPodaci;
  }
  getTip():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ "/TipKarte/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.tipPodaci = x;
    });
  }

  getTipPodaci(){
    if (this.tipPodaci == null)
      return [];
    return this.tipPodaci;
  }
  letKarta(event: any) {

    const value =event.target.value;
    this.letID=value;
    console.log(value);
  }

  tipKarta(event: any) {
    const value =event.target.value;
    this.tipID=value;
    console.log(value);
  }

  update() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Karta/Update/" + this.odabranaKarta.id, this.odabranaKarta,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        this.SavedChanges();
      });
  }
}
