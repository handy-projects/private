import {Component} from 'angular2/core';
import {ROUTER_DIRECTIVES, RouteConfig, Location, ROUTER_PROVIDERS, LocationStrategy, HashLocationStrategy, Route, AsyncRoute, Router} from 'angular2/router';


@Component({
    selector: 'memo',
    templateUrl: '/app/memo/memo.tpl.html',
    directives: [ROUTER_DIRECTIVES]
})

    
export class MemoComponent {
    
    location: Location;

    constructor(location: Location) {
        this.location = location;
    }

    getLinkStyle(path) {
        return this.location.path().indexOf(path) > -1;
    }
}