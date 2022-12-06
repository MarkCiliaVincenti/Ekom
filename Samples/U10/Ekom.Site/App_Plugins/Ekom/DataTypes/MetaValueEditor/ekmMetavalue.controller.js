(function () {
  "use strict";

  angular.module("umbraco").controller("Ekom.Metavalue", [
    '$scope',
    'Ekom.Resources',
    '$routeParams',
    function ($scope, ekmResources, $routeParams) {

      if ($routeParams.section !== 'content') { return; }

      $scope.promptIsVisible = "-1";

      $scope.languages = [];
      $scope.values = [];

      $scope.model.value = $scope.model.value || [];

      ekmResources.getLanguages().then(function (languages) {

        $scope.languages = languages;
      });

      $scope.sortableOptions = {
        axis: 'y',
        containment: 'parent',
        cursor: 'move',
        items: '> li',
        tolerance: 'pointer',
        disabled: false,
        handle: '.handle ',
        update: function (e, f) {

        }
      };

      $scope.Add = function () {

        var jsonData = {};

        $scope.languages.forEach(function (lang) {
          jsonData[lang.IsoCode] = '';
        });

        $scope.model.value.push(jsonData);
      };

      $scope.$on("formSubmitting", function (ev, args) {

        $scope.model.value = $scope.model.value

      });

      $scope.hidePrompt = function () {
        $scope.promptIsVisible = "-1";
      };

      $scope.remove = function (index) {
        // Make sure not to trigger other prompts when remove is triggered
        $scope.hidePrompt();

        var remainder = [];
        for (var x = 0; x < $scope.model.value.length; x++) {
          if (x !== index) {
            remainder.push($scope.model.value[x]);
          }
        }
        $scope.model.value = remainder;
      };

      $scope.showPrompt = function (idx, item) {
        var i = $scope.model.value.indexOf(item);

        // Make the prompt visible for the clicked tag only
        if (i === idx) {
          $scope.promptIsVisible = i;
        }
      };

    }]
  );

})();
