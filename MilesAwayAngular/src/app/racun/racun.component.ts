import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";


@Component({
  selector: 'app-racun',
  templateUrl: './racun.component.html',
  styleUrls: ['./racun.component.css']
})
export class RacunComponent implements OnInit {
  sub: any;
  sub1: any;
  sub2: any;
  kartaGetVM: any;
  private id: number;
  private id1: number;
  private id2: number;
  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute,private router: Router) { }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number
      this.sub1 = this.route.params.subscribe(params => {
        this.id1 = +params['id1'];
        this.sub2 = this.route.params.subscribe(params => {
          this.id2= +params['id2'];
      this.preuzmiPodakt()
    });});});
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  private preuzmiPodakt() {

    this.httpKlijent.get(MojConfig.adresa_servera+ `/Karta/GetByID?id=${this.id}&PrtljagaID=${this.id1}&TipPutnikaID=${this.id2}`, MojConfig.http_opcije()).subscribe(x=>{
      this.kartaGetVM = x;
    });

  }

  dalje() {
    this.router.navigate(['kupovina-kartica',this.id,this.id1,this.id2]);
  }
}
