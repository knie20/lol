'use strict';

/**
 * @ngdoc function
 * @name yapp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of yapp
 */
angular.module('yapp')
  .controller('DashboardCtrl', ['$scope', '$http', '$location', function($scope, $http, $location){
        
    $http.get(localStorage.getItem('apiPath') + '/api/position').then( function(res) {
      $scope.positions = res.data;
      $scope.positions.unshift({positionName: 'Position'});
      console.log($scope.positions);
    });
  
    var req = {
        method: 'GET',
        url: localStorage.getItem('apiPath') + '/api/application',
        headers: { Authorization: 'Bearer ' + localStorage.getItem('JWT') },
        data: { }
      };

    $http(req).then( function(res) {
      $scope.applications = res.data;
      $scope.filteredApplications = $scope.applications;
      console.log($scope.applications);
    });

    $scope.filterApplications = function() {
      var searchStr = document.getElementById('input-search-name').value;
        var position = document.getElementById('input-position').value;
      $scope.filteredApplications = $scope.applications.filter( function(a){
        return  a.LastName.toLowerCase().includes(searchStr.toLowerCase()) == true  ||
                a.Email.toLowerCase().includes(searchStr.toLowerCase()) == true
      });

      if(position != 'Position'){
        $scope.filteredApplications = $scope.filteredApplications.filter( function(a) {
          console.log($scope.positions)
          return a.PositionId == $scope.positions.find( function(p) {
            return p.positionName == position;
          }).positionId;
        })
      } 
    }

    $scope.parseJwt = function(token) {
        var base64Url = token.split('.')[1];
        var base64 = base64Url.replace('-', '+').replace('_', '/');
        return JSON.parse(window.atob(base64));
    };

    $scope.currentUser = $scope.parseJwt(localStorage.getItem('JWT')).Username;

    $scope.logout = function() {
    localStorage.clear();
    $location.path('/');
    }

    $scope.getPositionName = function(id) {
     return $scope.positions.find(function(position){
              return position.positionId == id;
            }).positionName;
    }

    $scope.goToApplication = function(id) {
      $location.path('/dashboard/application/' + id);
    }
  }]);
