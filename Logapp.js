var app = angular.module('myApp', []);
app.controller('myCtrl', function($scope, $window) {
    $scope.submitForm = function() {
      // check if the form is valid
      if ($scope.loginForm.$valid) {
        // submit the form
        console.log('Login form submitted');
      }
    };
  });