angular.module("umbraco").controller("Ekom.Metavalue", function ($scope, assetsService, $http) {

  $scope.currencies = $scope.model.value;
  $scope.model.hideLabel = false;

});
