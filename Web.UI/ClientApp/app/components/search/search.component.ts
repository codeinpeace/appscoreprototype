import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'searchdata',
    templateUrl: './search.component.html'
})
export class SearchDataComponent {
    public http: Http;
    public baseUrl: string;

    public result: PeopleSearchResult[];
        
    public searchText: string;
   
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.searchPeople();
    }

    public searchPeople() {
        console.log('searching for people')

        this.http.get(this.baseUrl + 'api/AncestryData/GetAncestors?name=' + this.searchText).subscribe(result => {
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
    