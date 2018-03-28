angular.module("app", [
  "ngRoute",
  "applicationDashboard",
  "applicationInfo",
  "managerLogin",
  "applyForm",
  "frontPage"
])
  .component("index", {
    templateUrl: "index.html"
  })
  .config(function($routeProvider) {
    $routeProvider
    .when("/", {
        template: "<front-page></front-page>",
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
    });
  });

