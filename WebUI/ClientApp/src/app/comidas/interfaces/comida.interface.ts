export interface Comida {
    id?:               number;
    nombre:            string;
    imagenUrl?:        string;
    descripcion:       string;
    fechaFinVigencia?: Date;
    ingredientes?:     any[];
}