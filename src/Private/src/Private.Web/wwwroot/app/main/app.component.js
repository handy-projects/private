(function (app) {
    app.AppComponent =
      ng.core.Component({
          selector: 'private-app',
          templateUrl: '/app/main/main.html'
      })
      .Class({
          constructor: function () { }
      });
})(window.app || (window.app = {}));