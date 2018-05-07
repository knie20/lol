  'use strict';

  /**
   * @ngdoc function
   * @name yapp.controller:MainCtrl
   * @description
   * # MainCtrl
   * Controller of yapp
   */
  angular.module('yapp')
    .controller('ApplyFormCtrl', ['$scope', '$http', '$window', '$location', function($scope, $http, $window, $location){
      $http.get(localStorage.getItem('apiPath') + '/api/position').then(function(res) {
        $scope.positions = res.data;
      });

      $scope.uploadFile = function(files) {
          var fd = new FormData();
          //Take the first selected file
          fd.append("file", files[0]);

          $http.post(localStorage.getItem('apiPath') + 'api/application/file', fd, {
              withCredentials: true,
              headers: {'Content-Type': undefined },
              transformRequest: angular.identity
          }).then(function(res) {
            $location.path('/application-success');
          });

      };

      $scope.apply = function() {

        if(!document.getElementById('input-fname').value ||
          !document.getElementById('input-lname').value ||
          !document.getElementById('input-email').value ||
          !document.getElementById('input-file').files){
            alert("You did not fill out all required fields");
          }

        var req = {
          method: 'POST',
          url: localStorage.getItem('apiPath') + '/api/application',
          headers: { },
          data: { 
            application: {
              ApplicationId: -1,
              FirstName: document.getElementById('input-fname').value,
              LastName: document.getElementById('input-lname').value,
              Email: document.getElementById('input-email').value,
              PositionName: document.getElementById('input-position').value,
              ResumePath: document.getElementById('input-file').files[0].name
            }
          }
        }

        $http(req).then(function(res) {
          $scope.uploadFile(document.getElementById('input-file').files);
        });
      };
      
    }]);