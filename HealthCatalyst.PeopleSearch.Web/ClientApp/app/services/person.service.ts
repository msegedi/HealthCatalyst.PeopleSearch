import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

import { IPerson } from './person';

@Injectable()
export class PersonService {
    private _peopleSearchUrl = 'http://localhost:51299/api/v1/people/searchByName/';

    constructor(private _http: Http) { }

    searchPeople(searchText: string): Observable<IPerson[]> {
        // ToDo: There should be some null or empty string checking here.

        return this._http.get(this._peopleSearchUrl + encodeURIComponent(searchText))
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .map((res: Response) => {
                return <IPerson[]>res.json();
            })
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'));

    }
}
