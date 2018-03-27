angular.module("router", ["ngRoute"])
  .config(function($routeProvider) {
      $routeProvider
      .when("/", {
          templateUrl : "",
          
      })
      .when("/login", {
          templateUrl : ""
      })
      .when("/dashboard", {
          templateUrl : ""
      })
      .when("/view-application", {
          templateUrl : ""
      })
      .when("/apply", {
        templateUrl : ""
    });
  });