import { Pipe, PipeTransform } from '@angular/core';
import { Comida } from '../interfaces/comida.interface';

@Pipe({
  name: 'comidaImagen'
})
export class ComidaImagenPipe implements PipeTransform {

  transform(comida: Comida): string {
     if ( !comida.id ) {
      return 'assets/Img-Not-Found.jpg'
     }

     if ( comida.imagenUrl ) {
      return comida.imagenUrl;
     }

     return 'assets/Img-Not-Found.jpg';
  }
}