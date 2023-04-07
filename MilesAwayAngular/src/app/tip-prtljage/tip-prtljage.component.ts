import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import Swal from "sweetalert2";



@Component({
  selector: 'app-tip-prtljage',
  templateUrl: './tip-prtljage.component.html',
  styleUrls: ['./tip-prtljage.component.css']
})
export class TipPrtljageComponent implements OnInit {
  title:string='Tip-prtljage';
  tekst: string="";
  prtljagPodaci:any;
  //odabranaPrtljaga:any=null;
  frmTipPrtljagePodaci!:FormGroup;
  _isShow:boolean =false;
  naziv:string="";
  dodatak!:number;
  noviTip:any=null;

  constructor(private httpKlijent: HttpClient, private router: Router) { }

  GetAll():void{
    this.httpKlijent.get(MojConfig.adresa_servera+"/Prtljag/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.prtljagPodaci=x;
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

  btnNovi() {
    this._isShow = !this._isShow;
   /*this.odabranaPrtljaga={
     prikaz:true,
     tipID:0,
     naziv:"",
     cijenaDodatak:null
   }*/
  }

  getPrtljagaPodaci() {
    if(this.prtljagPodaci==null)
      return [];
    return this.prtljagPodaci.filter((x: any)=> x.tekst==""||
    x.naziv.toLowerCase().startsWith(this.tekst.toLowerCase()));
  }
  add() {
    this.noviTip={
      naziv:this.naziv,
      dodatak:this.dodatak
    };
    this.httpKlijent.post(MojConfig.adresa_servera+"/Prtljag/Add",this.noviTip,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any)=>{
        /*porukaSuccess("uredu..."+povratnaVrijednost.naziv);*/
        this.SavedChanges();
      });
    /*this.GetAll();*/
  }
  obrisi(p: any) {
   this.httpKlijent.post(MojConfig.adresa_servera+"/Prtljag/Delete/"+p.id,null,MojConfig.http_opcije())
     .subscribe((povratnaVrijednost:any)=>{
       const index = this.prtljagPodaci.indexOf(p);
       if (index > -1) {
         this.prtljagPodaci.splice(index, 1);
       }
       /*porukaSuccess("obrisano..."+povratnaVrijednost.naziv);*/
       this.SavedChanges();
     });
  }

  ngOnInit(): void {
    this.GetAll();
    this.frmTipPrtljagePodaci=new FormGroup({
      naziv :new FormControl(this.naziv,Validators.required),
      dodatak :new FormControl(this.dodatak,Validators.required)
    });
  }

  validacija(){
    if(this.naziv!="" && this.dodatak!=null)
      return true;
    return false;
  }

}
