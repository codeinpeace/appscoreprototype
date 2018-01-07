import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'searchdata',
    templateUrl: './search.component.html'
})
export class SearchDataComponent {
    public result: PeopleSearchResult[];

    public name: string;
   
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

        http.get(baseUrl + 'api/AncestryData/GetAncestors?name=' + name).subscribe(result => {
            this.result = result.json() as PeopleSearchResult[];
        }, error => console.error(error));
        
    }

    searchPeople() {
        console.log('searchin for people')
    }


}
   


interface PeopleSearchResult {
    id: number;
    name: string;
    gender: string;
    birthplaceid: number;
}
    