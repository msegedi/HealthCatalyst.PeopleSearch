import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { PersonService } from './services/person.service';

@NgModule({
    declarations: [
        AppComponent,
        FetchDataComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        Ng4LoadingSpinnerModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        PersonService
    ]
})
export class AppModuleShared {
}
