import { Component, Input } from '@angular/core';
import { Comida } from '../../interfaces/comida.interface';

@Component({
  selector: 'app-comida-tarjeta-component',
  templateUrl: './comida-tarjeta-component.component.html',
  styles: [`
  mat-card {
    margin-top: 20px;
  }`]
})
export class ComidaTarjetaComponentComponent {

  @Input() comida!: Comida;

}