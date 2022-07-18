import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorPageComponent } from './shared/error-page/error-page.component';

const routes: Routes = [
  {
    path: 'comidas',
    loadChildren: () => import('./comidas/comidas-routing.module').then(m => m.ComidasRoutingModule)
  },
  {
    path: 'ingredientes',
    loadChildren: () => import('./ingredientes/ingredientes-routing.module').then(m => m.IngredientesRoutingModule)
  },
  {
    path: 'ingredientes',
    loadChildren: () => import('./ingredientes/ingredientes-routing.module').then(m => m.IngredientesRoutingModule)
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