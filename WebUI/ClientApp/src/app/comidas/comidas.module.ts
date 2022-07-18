import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgregarComponent } from './pages/agregar/agregar.component';
import { ComidaComponent } from './pages/comida/comida.component';
import { HomeComponent } from './pages/home/home.component';
import { ListadoComponent } from './pages/listado/listado.component';
import { ComidasRoutingModule } from './comidas-routing.module';



@NgModule({
  declarations: [
    AgregarComponent,
    ComidaComponent,
    HomeComponent,
    ListadoComponent
  ],
  imports: [
    CommonModule,
    ComidasRoutingModule
  ]
})
export class ComidasModule { }
