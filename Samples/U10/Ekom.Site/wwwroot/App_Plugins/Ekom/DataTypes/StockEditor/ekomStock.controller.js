angular.module('umbraco').controller('Ekom.Stock', function ($scope, assetsService, contentEditingHelper, $routeParams, editorState, $http, notificationsService, contentResource) {
  $scope.storeList = [];
  $scope.content = null;
  $scope.stockValue = 0;
  $scope.storeSelected = '';
  $scope.config = null;
  $scope.perStoreStock = false;

  $scope.GetStores = function () {
    $http.get(Umbraco.Sys.ServerVariables.ekom.apiEndpoint + 'getAllStores').then(function (results) {

      $scope.storeList = results.data;

      if ($scope.storeList.length > 0) {
        $scope.storeSelected = $scope.storeList[0].Alias;
        $scope.GetStock($scope.storeList[0].Alias);
      }

    });
  };

  $scope.GetStock = function (storeAlias) {

    if (storeAlias !== '') {
      $http.get(Umbraco.Sys.ServerVariables.ekom.backofficeApiEndpoint + 'GetStockByStore?id=' + $scope.content.key + "&storeAlias=" + storeAlias)
        .then(function (result) {

          $scope.stockValue = parseInt(result.data);

        });
    } else {
      $http.get(Umbraco.Sys.ServerVariables.ekom.backofficeApiEndpoint + 'GetStock?id=' + $scope.content.key).then(function (result) {

        $scope.stockValue = parseInt(result.data);

      });
    }


  };

  $scope.UpdateStock = function () {

    $http.post(Umbraco.Sys.ServerVariables.ekom.backofficeApiEndpoint + 'setStock?id=' + $scope.content.key + "&stock=" + $scope.stockValue + "&storeAlias=" + $scope.storeSelected)
      .then(
        function () {
          notificationsService.success("Success", "Stock has been updated");
        },
        function () {
          notificationsService.error("Update Failed.", "Stock update failed");
        });
  };

  $scope.UpdateStore = function () {
    $scope.GetStock($scope.storeSelected);
  };

  if ($routeParams.section !== 'settings') {

    contentResource.getById($routeParams.id)
      .then(function (data) {
        $scope.content = data;

        $http.get(Umbraco.Sys.ServerVariables.ekom.backofficeApiEndpoint + 'GetConfig').then(function (result) {

          $scope.config = result.data;

          if ($scope.config.PerStoreCache) {

            $scope.perStoreStock = true;

            $scope.GetStores();
          } else {
            $scope.GetStock('');
          }

        });

      });
  }


});
