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
      .when("/applications", {
          templateUrl : ""
      })
      .when("/apply", {
        templateUrl : ""
    });
  });