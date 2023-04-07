import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule, ReactiveFormsModule} from "@angular/forms"
import { AppComponent } from './app.component';
import { HttpClientModule} from "@angular/common/http";
import {RouterModule} from "@angular/router";
import { DrzavaComponent } from './drzava/drzava.component';
import { PilotComponent } from './pilot/pilot.component';
import { AvionComponent } from './avion/avion.component';
import { AviokompanijaComponent } from './aviokompanija/aviokompanija.component';
import { AerodromComponent } from './aerodrom/aerodrom.component';
import { GradComponent } from './grad/grad.component';
import { MenadzerComponent } from './menadzer/menadzer.component';
import { PresjedanjeComponent } from './presjedanje/presjedanje.component';
import { PopustComponent } from './popust/popust.component';
import { TipKarteComponent } from './tip-karte/tip-karte.component';
import { TipPrtljageComponent } from './tip-prtljage/tip-prtljage.component';
import {AutorizacijaLoginProvjera} from "./guards/autorizacija-login-provjera.service";
import {AutorizacijaAdminProvjera} from "./guards/autorizacija-admin-provjera.service";
import {AutorizacijaKupacProvjera} from "./guards/autorizacija-kupac-provjera.service";
import {AutorizacijaMenadzerProvjera} from "./guards/autorizacija-menadzer-provjera.service";
import { LoginComponent } from './login/login.component';
import { RegistracijaComponent } from './registracija/registracija.component';
import { HomeComponent } from './home/home.component';
import { HomeAdminComponent } from './home-admin/home-admin.component';
import { HomeKupacComponent } from './home-kupac/home-kupac.component';
import { HomeMenadzerComponent } from './home-menadzer/home-menadzer.component';
import { LetComponent } from './let/let.component';
import { LetAerodromComponent } from './let-aerodrom/let-aerodrom.component';
import { LetAvionComponent } from './let-avion/let-avion.component';
import { LetPilotComponent } from './let-pilot/let-pilot.component';
import { ObavijestKategorijaComponent } from './obavijest-kategorija/obavijest-kategorija.component';
import { ObavijestComponent } from './obavijest/obavijest.component';
import { KartaComponent } from './karta/karta.component';
import { HistorijaComponent } from './historija/historija.component';
import { KupovinaKarteComponent } from './kupovina-karte/kupovina-karte.component';
import { KupovinaLetComponent } from './kupovina-let/kupovina-let.component';
import { RacunComponent } from './racun/racun.component';
import { KarticaComponent } from './kartica/kartica.component';
import { KupovinaKarticaComponent } from './kupovina-kartica/kupovina-kartica.component';
import { PrtljagaComponent } from './prtljaga/prtljaga.component';
import {MatFormFieldModule} from "@angular/material/form-field";
import { ProfilComponent } from './profil/profil.component';
import { UspjesnaKupovinaComponent } from './uspjesna-kupovina/uspjesna-kupovina.component';
import { TipPutnikaComponent } from './tip-putnika/tip-putnika.component';




// @ts-ignore
@NgModule({
  declarations: [
    AppComponent,
    DrzavaComponent,
    PilotComponent,
    AvionComponent,
    AviokompanijaComponent,
    AerodromComponent,
    GradComponent,
    MenadzerComponent,
    PresjedanjeComponent,
    PopustComponent,
    TipKarteComponent,
    TipPrtljageComponent,
    LoginComponent,
    RegistracijaComponent,
    HomeComponent,
    HomeAdminComponent,
    HomeKupacComponent,
    HomeMenadzerComponent,
    LetComponent,
    LetAerodromComponent,
    LetAvionComponent,
    LetPilotComponent,
    ObavijestKategorijaComponent,
    ObavijestComponent,
    KartaComponent,
    HistorijaComponent,
    KupovinaKarteComponent,
    KupovinaLetComponent,
    RacunComponent,
    KarticaComponent,
    KupovinaKarticaComponent,
    PrtljagaComponent,
    ProfilComponent,
    UspjesnaKupovinaComponent,
    TipPutnikaComponent,

  ],
  imports: [
    BrowserModule,

    RouterModule.forRoot([

      {path: 'pilot', component: PilotComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'drzava', component: DrzavaComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'aerodrom', component: AerodromComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'grad', component: GradComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'aviokompanija', component: AviokompanijaComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'avion', component: AvionComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'presjedanje', component: PresjedanjeComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'popust', component: PopustComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'tipKarte', component: TipKarteComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'tipPrtljage', component: TipPrtljageComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'tipPutnika', component: TipPutnikaComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'let', component: LetComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'let-aerodrom/:id', component: LetAerodromComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'let-avion/:id', component: LetAvionComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'let-pilot/:id', component: LetPilotComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {
        path: 'obavijest-kategorija',
        component: ObavijestKategorijaComponent,
        canActivate: [AutorizacijaMenadzerProvjera]
      },
      {path: 'obavijest', component: ObavijestComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'karta', component: KartaComponent, canActivate: [AutorizacijaMenadzerProvjera]},
      {path: 'historija', component: HistorijaComponent, canActivate: [AutorizacijaKupacProvjera]},
      {path: 'profil', component: ProfilComponent, canActivate:[AutorizacijaKupacProvjera]},
      {path: 'kupovina-karte/:id', component: KupovinaKarteComponent, canActivate: [AutorizacijaKupacProvjera]},
      {path: 'kupovina-kartica/:id/:id1/:id2', component: KupovinaKarticaComponent, canActivate: [AutorizacijaKupacProvjera]},
      {path: 'kupovina', component: KupovinaLetComponent, canActivate: [AutorizacijaKupacProvjera]},
      {path: 'racun/:id/:id1/:id2', component: RacunComponent, canActivate: [AutorizacijaKupacProvjera]},
      {path: 'kartica', component: KarticaComponent, canActivate: [AutorizacijaKupacProvjera]},
      {path: 'prtljaga/:id', component: PrtljagaComponent, canActivate: [AutorizacijaKupacProvjera]},

      {path: 'login', component: LoginComponent},
      {path: 'registracija', component: RegistracijaComponent},
      {path: 'home', component: HomeComponent},
      {path: '', component: HomeComponent, canActivate: [AutorizacijaMenadzerProvjera]},


    ]),
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatFormFieldModule
  ],
  providers: [
    AutorizacijaAdminProvjera,
    AutorizacijaLoginProvjera,
    AutorizacijaKupacProvjera,
    AutorizacijaMenadzerProvjera,

  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
