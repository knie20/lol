'use strict';

/**
 * @ngdoc overview
 * @name yapp
 * @description
 * # yapp
 *
 * Main module of the application.
 */

localStorage.setItem('apiPath', 'http://localhost:5000');

angular
  .module('yapp', [
    'ui.router',
    'ngAnimate'
  ])
  .config(function($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.when('/dashboard', '/dashboard/overview');
    $urlRouterProvider.otherwise('/login');

    $stateProvider
      .state('base', {
        abstract: true,
        url: '',
        templateUrl: 'views/base.html'
      })
        .state('login', {
          url: '/login',
          parent: 'base',
          templateUrl: 'views/login.html',
          controller: 'LoginCtrl'
        })
        .state('dashboard', {
          url: '/dashboard',
          parent: 'base',
          templateUrl: 'views/dashboard.html',
          controller: 'DashboardCtrl'
        })
          .state('overview', {
            url: '/overview',
            parent: 'dashboard',
            templateUrl: 'views/dashboard/overview.html'
          })
          .state('application', {
            url: '/application/:applicationId',
            parent: 'dashboard',
            templateUrl: 'views/dashboard/application.html',
            controller: 'ApplicationCtrl'
          })
        .state('apply-form', {
          url: '/apply-form',
          parent: 'base',
          templateUrl: 'views/apply-form.html',
          controller: 'ApplyFormCtrl'
        });

  });
