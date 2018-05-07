'use strict';

/**
 * @ngdoc function
 * @name yapp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of yapp
 */
angular.module('yapp')
  .controller('ApplicationCtrl', ['$scope', '$http', '$location', '$stateParams', function($scope, $http, $location, $stateParams){
    var applicantId = $stateParams.applicationId;
      
      var applicantReq = {
          method: 'GET',
          url: localStorage.getItem('apiPath') + '/api/application/' + applicantId,
          headers: { Authorization: 'Bearer ' + localStorage.getItem('JWT')},
          data: { }
        }

      $scope.parseJwt = function(token) {
            var base64Url = token.split('.')[1];
            var base64 = base64Url.replace('-', '+').replace('_', '/');
            return JSON.parse(window.atob(base64));
        };

      $scope.logout = function() {
        localStorage.clear();
        $location.path('/');
      }

      $scope.currentUser = $scope.parseJwt(localStorage.getItem('JWT')).Username;
      
      $http(applicantReq).then(function(res) {
        $scope.applicant = res.data;
        console.log($scope.applicant);
        document.getElementById("pdf-object").setAttribute('data', localStorage.getItem('apiPath') + $scope.applicant.ResumePath);
        document.getElementById("pdf-frame").setAttribute('src', localStorage.getItem('apiPath') + $scope.applicant.ResumePath);
      });
  }]);
