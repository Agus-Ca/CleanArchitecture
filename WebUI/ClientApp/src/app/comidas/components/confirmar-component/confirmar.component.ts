import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Comida } from '../../interfaces/comida.interface';

@Component({
  selector: 'app-confirmar',
  templateUrl: './confirmar.component.html',
  styles: [
  ]
})
export class ConfirmarComponent {

  constructor( private dialogRef:MatDialogRef<ConfirmarComponent>,
              @Inject(MAT_DIALOG_DATA) public data:Comida ) { }

  borrar():void {
    this.dialogRef.close(true);
  }

  cerrar():void {
    this.dialogRef.close();
  }

}