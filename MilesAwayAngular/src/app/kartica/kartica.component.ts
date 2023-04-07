import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import {MojConfig} from "../moj-config";
import Swal from "sweetalert2";


@Component({
  selector: 'app-kartica',
  templateUrl: './kartica.component.html',
  styleUrls: ['./kartica.component.css']
})
export class KarticaComponent implements OnInit {

  show: boolean=false;
  frmKarticaPodaci!: FormGroup;
  brojKartice: string="";
  imeVlasnika: string="";
  verifikacijskiKod: string="";
  datumIsteka: any;
  novaKartica:any;
  imaNema: boolean;
  sub: any;
  sub1: any;
  private id: number;
  private id1: number;
  karticaPodaci: any;



  constructor(private httpKlijent: HttpClient, private router: ActivatedRoute,private fb: FormBuilder,private route: Router) { }

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
    this.sub = this.router.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number
      this.sub1 = this.router.params.subscribe(params => {
        this.id1 = +params['id1'];
      });});
    this.GetAll();


    this.frmKarticaPodaci=new FormGroup({
      imeVlasnika :new FormControl(this.imeVlasnika,Validators.required),
      brojKartice :new FormControl(this.brojKartice,Validators.required),
      datumIsteka :new FormControl(this.datumIsteka,Validators.required),
      verifikacijskiKod :new FormControl(this.verifikacijskiKod,Validators.required)
    });
  }

  Dodaj() {
    this.show=!this.show;
    this.karticaPodaci=this.karticaPodaci;
  }

  /* validacija() {
     if(this.imeVlasnika!="" && (this.brojKartice!="" && this.brojKartice.length==16) && (this.verifikacijskiKod!="" && this.verifikacijskiKod.length==3) && this.datumIsteka!=null)
     {
         return true;
     }
     return false;
   }*/


  add() {
    this.novaKartica={
      datumIsteka:this.datumIsteka,
      verifikacijskiKod:this.verifikacijskiKod,
      brojKartice:this.brojKartice
    }
    this.httpKlijent.post(MojConfig.adresa_servera+"/Kartica/AddByKupac",this.novaKartica,MojConfig.http_opcije()).subscribe(
      (x:any)=>{
        this.SavedChanges();
      }
    )
  }


  GetAll():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Kartica/GetByKupac",MojConfig.http_opcije()).subscribe(x=>{
      this.karticaPodaci = x;
    });

  }


  GetKarticaPodaci() {
    if (this.karticaPodaci == null)
      return [];

    return this.karticaPodaci;
  }

 obrisi(s:any){
    this.httpKlijent.post(MojConfig.adresa_servera+"/Kartica/Delete/"+s.id,null,MojConfig.http_opcije()).subscribe(
      (povratnaVrijednost:any) =>{
        const index = this.karticaPodaci.indexOf(s);
        if (index > -1) {
          this.karticaPodaci.splice(index, 1);
        }
        this.SavedChanges();
      }
    )
 }

}
