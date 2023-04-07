import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import Swal from "sweetalert2";


@Component({
  selector: 'app-popust',
  templateUrl: './popust.component.html',
  styleUrls: ['./popust.component.css']
})
export class PopustComponent implements OnInit {
  odabraniPopust: any=null;
  PopustPodaci:any;
  frmPopust!: FormGroup;
  _isShow: boolean=false;
  naziv: string="";
  popust: number=0;
  aktivan: boolean=false;
noviPopust:any=null;
  saveUsername: any;


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
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Popust/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.PopustPodaci = x;
    });
  }
  ngOnInit(): void {
    this.GetAll();
    this.frmPopust=new FormGroup({
      naziv :new FormControl(this.naziv,Validators.required),
      popust :new FormControl(this.popust,Validators.required),
      aktivan :new FormControl(this.aktivan,Validators.required)
    });
  }

  btnNovi() {
    this._isShow = !this._isShow;

    /*this.odabraniPopust = {
      prikazi:true,
      PopustID:0,
      Naziv :"",
      Popust:null,
      Aktivan:true
    }*/
  }

  getPopustPodaci() {
    if (this.PopustPodaci == null)
      return [];
    return this.PopustPodaci;
  }

  obrisi(p:any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Popust/Delete/" + p.id,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        const index = this.PopustPodaci.indexOf(p);
        if (index > -1) {
          this.PopustPodaci.splice(index, 1);
        }
        this.SavedChanges();
      });
  }

  add() {
    this.noviPopust={
      naziv:this.naziv,
      _popust:this.popust,
      //_popust:parseFloat("popust").toFixed(1),
      _aktivan:this.aktivan,
    };
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Popust/Add",this.noviPopust,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        this.SavedChanges();
      });
  }

  update() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Popust/Update/" + this.odabraniPopust.id, this.odabraniPopust,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        this.SavedChanges();
      });
  }

  detalji(p: any) {
    this.odabraniPopust= p;
    this.odabraniPopust.prikazi = true;
  }
  validacija(){
    if(this.naziv!="" && this.popust!=0)
      return true;
    return false;
  }



}
