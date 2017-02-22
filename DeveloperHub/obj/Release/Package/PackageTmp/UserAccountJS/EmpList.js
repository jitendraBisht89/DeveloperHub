/// <reference path="../Script/angular.min.js" />
/// <reference path="../Script/angular-route.js" />
angular.module('myFormApp', []).controller('updateProfile', function ($http,$scope, UpdateUserProfile) {

    $http({
        method: 'Get',
        url: 'http://localhost:4650/Account/GetUserProfileJson'
    }).then(function(response)
    {
        $scope.UserProfileMapper = response.data;
    })
    $scope.updateProfile = function () {

        alert("i am called");
        UpdateUserProfile.UpdateProfile($scope.UserProfileMapper);
    }
    
})
.factory("UpdateUserProfile", ['$http', function ($http) {
    var fac = {};
    fac.UpdateProfile = function (UserProfileMapper) {
        $http.post
            ('http://localhost:4650/Account/UpdateUserProfile',UserProfileMapper).success(function () {
                alert('hello');

            })
    }
    return fac;
}])