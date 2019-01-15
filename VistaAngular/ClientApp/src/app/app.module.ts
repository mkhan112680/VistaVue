import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component'
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SideNavComponent } from './side-nav/side-nav.component';
import { PayeeFormComponent } from './payee-form/payee-form.component';
import { MouComponent } from './mou/mou.component';

@NgModule({
  declarations: [
    AppComponent,
    //NavMenuComponent,
    SideNavComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PayeeFormComponent,
    MouComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'payee-form', component: PayeeFormComponent },
      { path: 'mou', component: MouComponent } 
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
