import { LocationComponent } from './Components/location/location.component';
import { CoordinatesComponent } from './Components/coordinates/coordinates.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path:'coordinates', component: CoordinatesComponent},
  {path: 'location', component: LocationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
