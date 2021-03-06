import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import { MatListModule } from '@angular/material/list';

import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { FaresListComponent } from './pages/fares/fares.component';

import { AppService } from './services/app.service';
import { FaresService } from './services/fares.service';
import { FareComponent } from './pages/fares/fare.component';
import { IPFSService } from './services/ipfs.service';

const appRoutes: Routes = [
  {
    path: 'bulma',
    component: HomeComponent
  },
  {
    path: '',
    component: FareComponent
  },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FaresListComponent,
    FareComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MatListModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // debugging purpose
    )
  ],
  providers: [
    AppService,
    FaresService,
    IPFSService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
