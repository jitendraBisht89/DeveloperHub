/// <reference path="../Scripts/angular.min.js" />
/// <reference path="../Scripts/angular-route.js" />
angular.module('myFormApp', []).
controller('CustList', function ($scope, $http) {
    $http.get('http://localhost:4650/Account/GetUserProfileJson').success(function (data) {
        $scope.cust = data;

    }).error(function (data, status) {
        console.error('failure loading the student record', status, data);
        $scope.students = {}; //return blank record if something goes wrong
    });

});