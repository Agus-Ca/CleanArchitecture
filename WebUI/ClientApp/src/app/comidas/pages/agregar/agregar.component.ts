import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

import { ComidasService } from '../../services/comidas.service';
import { Comida } from '../../interfaces/comida.interface';
import { ConfirmarComponent } from '../../components/confirmar-component/confirmar.component';

@Component({
  selector: 'app-agregar',
  templateUrl: './agregar.component.html',
  styles: [`
  img {
    width: 100%;
    border-radius: 5px;
  }
  `]
})
export class AgregarComponent implements OnInit {

  constructor(
    private comidaService: ComidasService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private snackbar: MatSnackBar,
    private dialog: MatDialog ) { }

  ngOnInit(): void {
    if( this.router.url.includes('editar')) {
      this.activatedRoute.params
        .subscribe( ({id}) => this.comidaService.getComidaById( id )
          .subscribe(
            comida => this.comida = comida
          )
        );
    }
  }

  comida: Comida = {
    nombre: '',
    imagenUrl: '',
    descripcion: ''
  }

  guardarComida():void {
    if( this.comida.nombre.trim().length === 0 || this.comida.descripcion.trim().length === 0 || this.comida.imagenUrl?.trim().length === 0) {
      this.mostrarSnackbar('Por favor, complete todos los campos!');
      return;
    }

    if( this.comida.id ){
      this.comidaService.updateComida( this.comida )
        .subscribe({
          next: () => this.mostrarSnackbar('Registro actualizado')
        });
    } else {
      this.comidaService.addComida( this.comida )
        .subscribe(
          comida => {
            this.router.navigate(['/comidas/editar', comida.id]);
            this.mostrarSnackbar(('Registro creado'));
          }
        );
    }
  }

  borrarComida() {
    const dialog = this.dialog.open( ConfirmarComponent, 
                                     { 
                                       width:'250px', 
                                       data:{...this.comida} 
                                     });

    dialog.afterClosed().subscribe({
      next: (rtdo) => {
        if(rtdo) {
          this.comidaService.deleteComida( this.comida.id! )
            .subscribe({
              next: () => {
                this.router.navigate(['/comidas/listado']);
              }
            })
        }
      }});
  }

  mostrarSnackbar( mensaje:string ) {
    this.snackbar.open( mensaje, 'Ok!', { duration:2500 })
  }
}