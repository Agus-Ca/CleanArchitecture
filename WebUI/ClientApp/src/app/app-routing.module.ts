import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorPageComponent } from './shared/error-page/error-page.component';

const routes: Routes = [
  {
    path: 'comidas',
    loadChildren: () => import('./comidas/comidas.module').then(m => m.ComidasModule)
  },
  {
    path: 'ingredientes',
    loadChildren: () => import('./ingredientes/ingredientes.module').then(m => m.IngredientesModule)
  },
  {
    path: '404',
    component: ErrorPageComponent
  },
  {
    path: '**',
    redirectTo: '404'
  }
]

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }