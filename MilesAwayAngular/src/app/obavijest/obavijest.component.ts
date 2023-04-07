import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import Swal from "sweetalert2";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-obavijest',
  templateUrl: './obavijest.component.html',
  styleUrls: ['./obavijest.component.css']
})
export class ObavijestComponent implements OnInit {
  tekst:string='';
  trenutnaStranica:number = 1;
  podaci:any;
  obavijestPodaci:any;
  odabranaObavijest2:any=null;
  odabranaObavijest:any=null;
  novaObavijest:any=null;
  obavijestKategorijeID:number=0;
  obavijestKategorijaPodaci:any;
  _isShow:boolean =false;
  datumKreiranja:string="";
  opis:string="";
  podNaslov:string="";
  naslov:string="";
  prikaz:boolean=false;
  formData:any;

  constructor(private httpKlijent: HttpClient, private router: Router) { }

  /*GetAll():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Obavijest/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.obavijestPodaci = x;
    });
  }*/

  GetAll():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ `/Obavijest/GetAllPaged?filter=${this.tekst}&page_number=${this.trenutnaStranica}`,MojConfig.http_opcije()).subscribe(x=>{
      this.podaci=x;
      this.obavijestPodaci = this.podaci.dataItems;
    });
  }


  GetObavijestKategorije():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ "/ObavijestKategorija/GetByAll",MojConfig.http_opcije()).subscribe(x=>{
      this.obavijestKategorijaPodaci = x;
    });
  }

  ngOnInit(): void {
    this.GetAll();
    this.GetObavijestKategorije();
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

  ConfirmBox() {
    Swal.fire(
      'Good job!',
      'You added the photo!',
      'success'
    )
    this.GetAll();
  }

  getObavijestPodatke(){
    if (this.obavijestPodaci == null)
      return [];
    return this.obavijestPodaci.filter((x: any)=> x.tekst==""
      || x.naslov.toLowerCase().startsWith(this.tekst.toLowerCase())
      || x.podNaslov.toLowerCase().startsWith(this.tekst.toLowerCase())
      || x.opis.toLowerCase().startsWith(this.tekst.toLowerCase()));
  }

  obrisi(s: any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Obavijest/Delete/" + s.obavijestID,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        const index = this.obavijestPodaci.indexOf(s);
        if (index > -1) {
          this.obavijestPodaci.splice(index, 1);
        }
        /*porukaSuccess("obrisano..." + povratnaVrijednost.naslov);*/
        this.SavedChanges();
      });
  }

  Preuzmi(stranica:number)
  {
    this.trenutnaStranica=stranica;
    this.GetAll();
  }

  detalji(s: any) {
    this.odabranaObavijest= s;
    //this.odabranaObavijest.prikazi = true;
  }

  btnNovi() {
    this._isShow = !this._isShow;
    /*this.odabranaObavijest = {
      prikazi:true,
      obavijestID:0,
      naslov :"",
      podNaslov:"",
      opis:"",
      datumZaposlenja: new Date(),
      obavijestKategorijeID:1
    };*/
  }

  add() {
    this.novaObavijest={
      naslov :this.naslov,
      podNaslov:this.podNaslov,
      opis:this.opis,
      datumZaposlenja: this.datumKreiranja,
      obavijestKategorijeID:this.obavijestKategorijeID
    };
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Obavijest/Add",this.novaObavijest,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        /*porukaSuccess("uredu..."+ povratnaVrijednost.naslov);*/
        this.SavedChanges();
      });
    /*this.GetAll();*/
  }

  update() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Obavijest/Update/" + this.odabranaObavijest.obavijestID, this.odabranaObavijest,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        /*porukaSuccess("uredu..."+ povratnaVrijednost.naslov);*/
        this.SavedChanges();
      });
    /*this.GetAll();*/
  }

  slika(s: any) {
    this.prikaz = !this.prikaz;
    this.odabranaObavijest2= s;
  }

  uploadImage(){
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Obavijest/AddImage/" + this.odabranaObavijest2.obavijestID,this.formData,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        /*porukaSuccess("uredu..."+ povratnaVrijednost.naslov);*/
        this.ConfirmBox();
      });
  }

  handleFileInput(data: any):void {
    const files=data.files as File[];
    this.formData = new FormData();
    Array.from(files).forEach((f) => this.formData.append('file', f));

  }
}
