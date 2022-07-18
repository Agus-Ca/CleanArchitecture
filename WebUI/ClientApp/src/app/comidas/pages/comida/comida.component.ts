import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Comida } from '../../interfaces/comida.interface';
import { ComidasService } from '../../services/comidas.service';

@Component({
  selector: 'app-comida',
  templateUrl: './comida.component.html',
  styles: [`
  img {
    width: 100%;
    border-radius: 5px;
  }
  `]
})
export class ComidaComponent implements OnInit {

  constructor( 
    private activatedRoute: ActivatedRoute,
    private comidaService: ComidasService,
    private router: Router ) { }

  ngOnInit(): void {
    this.activatedRoute.params
      .subscribe( ({id}) => this.comidaService.getComidaById(id)
        .subscribe( comida => this.comida = comida) 
      );
  }

  comida!: Comida;

  regresar() {
    this.router.navigate(['/comidas/listado']);
  }
}