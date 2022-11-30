angular.module("umbraco").controller("Ekom.Metafield", function ($scope, assetsService, $http) {

  $scope.currencies = $scope.model.value;
  $scope.model.hideLabel = false;

});
