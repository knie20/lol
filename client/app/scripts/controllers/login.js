'use strict';

/**
 * @ngdoc function
 * @name yapp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of yapp
 */
angular.module('yapp')
  .controller('LoginCtrl', ['$scope', '$http', '$window', '$location', function($scope, $http, $window, $location){

    $scope.login = function() {
      var req = {
        method: 'POST',
        url: localStorage.getItem('apiPath') + '/api/auth/login',
        headers: {},
        data: { 
          Username: document.getElementById('input-login-name').value,
          Pw: document.getElementById('input-login-pass').value
        }
      };

      $http(req).then( function(res) {
        if (res.data.status === 'SUCCESS'){
          localStorage.setItem('JWT', res.data.token);
          $location.path('/dashboard');
        } else if (res.data.status === 'FAILURE'){
          document.getElementById('error-pass-msg').style.display = 'inline';
        } else {
          //TODO: redirect to unknown error page
        }
      });
    }
    
    $scope.register = function() {
      var req = {
        method: 'POST',
        url: localStorage.getItem('apiPath') + '/api/auth/register',
        headers: {},
        data: { 
          Username: document.getElementById('input-reg-name').value,
          Email: document.getElementById('input-reg-email').value,
          Pw: document.getElementById('input-reg-pass').value
        }
      }

      $http(req).then(function(res) {
        if (res.data.status === 'SUCCESS'){
          $location.path('/register-success');
        } else if (res.data.status === 'FAILURE'){
          alert(res.data.message);
        }
      });
    }

    $scope.apply = function() {
      $location.path('/apply-form');
    }
  }]);
