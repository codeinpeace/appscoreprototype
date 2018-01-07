import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'searchdata',
    templateUrl: './search.component.html'
})
export class SearchDataComponent {
    public result: PeopleSearchResult[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/AncestryData/GetAncestors').subscribe(result => {
            this.result = result.json() as PeopleSearchResult[];
        }, error => console.error(error));
    }
}

interface PeopleSearchResult {
    id: number;
    name: string;
    gender: string;
    birthplaceid: number;
}
    