import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-config";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import Swal from "sweetalert2";


@Component({
  selector: 'app-grad',
  templateUrl: './grad.component.html',
  styleUrls: ['./grad.component.css']
})
export class GradComponent implements OnInit {
  title:string="Grad";

  gradPodaci:any;
  OdabraniGrad:any=null;
   drzavaPodaci: any;
  nrSelect: any="";
  frmGradPodaci!: FormGroup;
  _isShow: boolean=false;
  opis: string="";
  drzavaID: number=0;
  noviGrad:any=null;



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
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Grad/GetByAll",MojConfig.http_opcije()).subscribe(x=>{
      this.gradPodaci = x;
    });
  }
  GetDrzava():void{
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Drzava/GetAll",MojConfig.http_opcije()).subscribe(x=>{
      this.drzavaPodaci = x;
    });
  }

  GetDrzavaPodatke(){
    if (this.drzavaPodaci == null)
      return [];
    return this.drzavaPodaci;
  }
  getGradPodaci() {
    if (this.gradPodaci == null)
      return [];
    return this.gradPodaci.filter((x: any)=> x.nrSelect==" " ||
     x.drzava.startsWith(this.nrSelect));
  }

  ngOnInit(): void {
    this.GetAll();
    this.GetDrzava();
    this.frmGradPodaci=new FormGroup({
      opis :new FormControl(this.opis,Validators.required),
      drzava_id :new FormControl(this.drzavaID,Validators.required)
    });
  }

  obrisi(p:any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Grad/Delete/" + p.id,null,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        const index = this.gradPodaci.indexOf(p);
        if (index > -1) {
          this.gradPodaci.splice(index, 1);
        }
        this.SavedChanges();
      });
  }


  add() {
    this.noviGrad={
      opis:this.opis,
      drzavaID:this.drzavaID
    };

    this.httpKlijent.post(MojConfig.adresa_servera+ "/Grad/Add",this.noviGrad,MojConfig.http_opcije())
      .subscribe((povratnaVrijednost:any) =>{
        this.SavedChanges();
      });
  }

  btnNovi() {
    this._isShow = !this._isShow;

    /*this.OdabraniGrad = {
      prikazi:true,
      GradID:0,
      opis :"",
      drzava_id:null
    }*/
  }
  validacija(){
    if(this.opis!="" && this.drzavaID!=0)
      return true;
    return false;
  }
  basedOnSel(event: any) {
    const value =event.target.value;
    this.nrSelect=value;
    console.log(value);
  }
  gradDrzava(event: any) {
    const value =event.target.value;
    this.drzavaID=value;
    console.log(value);
  }
}
