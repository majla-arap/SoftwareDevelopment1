import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
import Swal from "sweetalert2";

@Component({
  selector: 'app-tip-putnika',
  templateUrl: './tip-putnika.component.html',
  styleUrls: ['./tip-putnika.component.css']
})
export class TipPutnikaComponent implements OnInit {
  title:string='Tip-putnika';
  putnikPodaci:any;
  tekst: string="";
  frmTipPutnikaPodaci!:FormGroup;
  _isShow:boolean =false;
  naziv:string="";
  cijena!:number;
  noviTip:any=null;
  odabranitip:any=null;

  constructor(private httpKlijent: HttpClient, private router: Router) { }

  GetAll():void{
    this.httpKlijent.get(MojConfig.adresa_servera+"/TipPutnika/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.putnikPodaci=x;
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
    if(this.putnikPodaci==null)
      return [];
    return this.putnikPodaci.filter((x: any)=> x.tekst==""||
      x.naziv.toLowerCase().startsWith(this.tekst.toLowerCase()));
  }
  add() {
    this.noviTip={
      naziv:this.naziv,
      cijena:this.cijena
    };
    this.httpKlijent.post(MojConfig.adresa_servera+"/TipPutnika/Add",this.noviTip,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any)=>{
        /*porukaSuccess("uredu..."+povratnaVrijednost.naziv);*/
        this.SavedChanges();
      });
    /*this.GetAll();*/
  }
  obrisi(p: any) {
    this.httpKlijent.post(MojConfig.adresa_servera+"/TipPutnika/Delete/"+p.id,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any)=>{
        const index = this.putnikPodaci.indexOf(p);
        if (index > -1) {
          this.putnikPodaci.splice(index, 1);
        }
        /*porukaSuccess("obrisano..."+povratnaVrijednost.naziv);*/
        this.SavedChanges();
      });
  }

  ngOnInit(): void {
    this.GetAll();
    this.frmTipPutnikaPodaci=new FormGroup({
      naziv :new FormControl(this.naziv,Validators.required),
      cijena :new FormControl(this.cijena,Validators.required)
    });
  }

  update() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/TipKarte/Update/" + this.odabranitip.id, this.odabranitip,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        this.SavedChanges();
      });
  }

  detalji(p: any) {
    this.odabranitip= p;
    this.odabranitip.prikazi = true;
  }

  validacija(){
    if(this.naziv!="" && this.cijena!=null)
      return true;
    return false;
  }

}
