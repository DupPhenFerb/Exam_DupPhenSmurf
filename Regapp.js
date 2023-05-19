// create the app module
var app = angular.module('myApp', []);

// create the controller
app.controller('myCtrl', function($scope, $window) {
  $scope.submitForm = function() {
    // check if the form is valid
    if ($scope.registrationForm.$valid) {
      // submit the form
      console.log('Registration form submitted');
    }
  };

  $scope.checkPassword = function() {
    // check if the password match
    $scope.passwordMustBeEqual = $scope.password !== $scope.repeatPassword;
  };
  $scope.redirectToLogin = function() {
    // redirect to login page
    $window.location.href = 'login.html';
  };
});