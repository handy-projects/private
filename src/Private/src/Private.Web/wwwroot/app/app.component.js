System.register(['angular2/core', './memo/memo.component', 'angular2/router'], function(exports_1) {
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, memo_component_1, router_1;
    var AppComponent, ComponentHelper;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (memo_component_1_1) {
                memo_component_1 = memo_component_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            }],
        execute: function() {
            AppComponent = (function () {
                function AppComponent(router, location) {
                    this.router = router;
                    this.location = location;
                }
                AppComponent.prototype.getLinkStyle = function (path) {
                    if (path === this.location.path()) {
                        return true;
                    }
                    else if (path.length > 0) {
                        return this.location.path().indexOf(path) > -1;
                    }
                };
                AppComponent = __decorate([
                    core_1.Component({
                        selector: 'app',
                        templateUrl: '/app/app.tpl.html',
                        directives: [router_1.ROUTER_DIRECTIVES]
                    }),
                    router_1.RouteConfig([
                        //new Route({ path: '/', component: About, name: 'About', data: { project: 'angular-2-samples' } }),
                        //new Route({ path: '/demo/...', component: DemoPage, name: 'Demo' }),
                        new router_1.Route({ path: '/', component: memo_component_1.MemoComponent, name: 'Memo' }),
                        new router_1.AsyncRoute({
                            path: '/lazy',
                            loader: function () { return ComponentHelper.LoadComponentAsync('LazyLoaded', './components/lazy-loaded/lazy-loaded'); },
                            name: 'Lazy'
                        })
                    ]), 
                    __metadata('design:paramtypes', [router_1.Router, router_1.Location])
                ], AppComponent);
                return AppComponent;
            })();
            exports_1("AppComponent", AppComponent);
            ComponentHelper = (function () {
                function ComponentHelper() {
                }
                ComponentHelper.LoadComponentAsync = function (name, path) {
                    return System.import(path).then(function (c) { return c[name]; });
                };
                return ComponentHelper;
            })();
        }
    }
});
//# sourceMappingURL=app.component.js.map