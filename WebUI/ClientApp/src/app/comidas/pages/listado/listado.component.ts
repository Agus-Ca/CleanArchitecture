import { Component, OnInit } from '@angular/core';
import { Comida } from '../../interfaces/comida.interface';
import { ComidasService } from '../../services/comidas.service';

@Component({
  selector: 'app-listado',
  templateUrl: './listado.component.html',
  styles: [
  ]
})
export class ListadoComponent implements OnInit {

  constructor( private comidaService: ComidasService) { }

  ngOnInit(): void {
    this.comidaService.getComidas()
      .subscribe(comidas => 
        this.comidas = comidas
      );
  }

  comidas: Comida[] = [];
}