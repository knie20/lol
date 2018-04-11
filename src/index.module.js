var indexModule = angular.module("index", []);

indexModule.controller("indexCtrl", ['$scope', '$http', function($scope, $http){
  $scope.navigateToLogin = $http.get("login.html");
  $scope.navigateToApply = $http.get("apply.html");
  $http.get("/api/auth/current-user")
    .then(function(res) {
      $scope.currentUser = res.data;
    });
  $scope.foo = "bar";
}]);