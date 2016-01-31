import {Component} from 'angular2/core';
import {MemoComponent} from './memo/memo.component'
import {ROUTER_DIRECTIVES, RouteConfig, Location, ROUTER_PROVIDERS, LocationStrategy, HashLocationStrategy, Route, AsyncRoute, Router} from 'angular2/router';

declare var System: any;


@Component({
    selector: 'app',
    templateUrl: '/app/app.tpl.html',
    directives: [ROUTER_DIRECTIVES]
})


@RouteConfig([
    //new Route({ path: '/', component: About, name: 'About', data: { project: 'angular-2-samples' } }),
        //new Route({ path: '/demo/...', component: DemoPage, name: 'Demo' }),
        new Route({ path: '/', component: MemoComponent, name: 'Memo' }),
    new AsyncRoute({
        path: '/lazy',
        loader: () => ComponentHelper.LoadComponentAsync('LazyLoaded', './components/lazy-loaded/lazy-loaded'),
        name: 'Lazy'
    })
])

export class AppComponent {

    router: Router;
    location: Location;

    constructor(router: Router, location: Location) {
        this.router = router;
        this.location = location;
    }

    getLinkStyle(path) {

        if (path === this.location.path()) {
            return true;
        }
        else if (path.length > 0) {
            return this.location.path().indexOf(path) > -1;
        }
    }
}


class ComponentHelper {

    static LoadComponentAsync(name, path) {
        return System.import(path).then(c => c[name]);
    }
}