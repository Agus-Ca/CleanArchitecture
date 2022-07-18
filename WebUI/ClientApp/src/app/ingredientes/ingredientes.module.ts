import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgregarComponent } from './pages/agregar/agregar.component';
import { IngredienteComponent } from './pages/ingrediente/ingrediente.component';
import { HomeComponent } from './pages/home/home.component';
import { ListadoComponent } from './pages/listado/listado.component';



@NgModule({
  declarations: [
    AgregarComponent,
    IngredienteComponent,
    HomeComponent,
    ListadoComponent
  ],
  imports: [
    CommonModule
  ]
})
export class IngredientesModule { }
