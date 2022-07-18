import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule } from '@angular/forms';

import { ComidasRoutingModule } from './comidas-routing.module';
import { MaterialModule } from '../material/material.module';

import { AgregarComponent } from './pages/agregar/agregar.component';
import { ComidaComponent } from './pages/comida/comida.component';
import { HomeComponent } from './pages/home/home.component';
import { ListadoComponent } from './pages/listado/listado.component';
import { ComidaTarjetaComponentComponent } from './components/comida-tarjeta-component/comida-tarjeta-component.component';
import { ComidaImagenPipe } from './pipes/comida-imagen.pipe';
import { ConfirmarComponent } from './components/confirmar-component/confirmar.component';



@NgModule({
  declarations: [
    AgregarComponent,
    ComidaComponent,
    HomeComponent,
    ListadoComponent,
    ComidaTarjetaComponentComponent,
    ComidaImagenPipe,
    ConfirmarComponent
  ],
  imports: [
    CommonModule,
    FlexLayoutModule,
    MaterialModule,
    ComidasRoutingModule,
    FormsModule
  ]
})
export class ComidasModule { }
