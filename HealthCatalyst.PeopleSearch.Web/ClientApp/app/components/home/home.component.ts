import { Component } from '@angular/core';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';

import { IPerson } from '../../services/person';
import { PersonService } from '../../services/person.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {
    searchHasRan: boolean = false;
    searchText: string;
    people: IPerson[] = [];

    constructor(private _personService: PersonService, private _spinnerService: Ng4LoadingSpinnerService) {

    }

    onSearchTextKeyUp(event: KeyboardEvent) {
        this.searchText = (<HTMLInputElement>event.target).value;
    }

    onSearchClicked(message: string): void {
        if (!this.searchText || this.searchText === '') {
            this.people = [];
            alert('Please enter a name to search by.') // ToDo: Create a prettier way to display errors.
            return;
        }

        this.loadingStart();
        this._personService.searchPeople(this.searchText)
            .subscribe(people => {
                this.people = people;
            },
            error => {
                alert(<any>error); // ToDo: Create a prettier way to display errors.
            },
            () => {
                this.searchHasRan = true;
                this.loadingStop();
            });
    }

    private loadingStart() {
        this._spinnerService.show();
    }

    private loadingStop() {
        this._spinnerService.hide();
    }
}
