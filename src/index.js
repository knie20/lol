'use strict';

var app = angular.module("index", [
  "ngRoute",
  "applicationDashboard",
  "applicationInfo",
  "managerLogin",
  "applyForm",
  "front-page"
]);

app
  .component("index", {
    templateUrl: "index.html"
  })
  .config(['$routeProvider', function($routeProvider) {
    $routeProvider
    .when("/", {
        template: "<front-page></front-page>"
    })
    .when("/login", {
        template: ""
    })
    .when("/dashboard", {
        template: ""
    })
    .when("/view-application", {
        template: ""
    })
    .when("/apply", {
      template: ""
    })
  }]);

