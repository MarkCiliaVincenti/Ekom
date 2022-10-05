(function () {
  "use strict";

  angular.module("umbraco").controller("Ekom.PropertyEditorPicker", [
    '$scope',
    'Ekom.PropertyEditorResources',
    function ($scope, ekmResources) {

      $scope.model.dataTypes = [];
      $scope.model.value = $scope.model.value || {
        guid: "0cc0eba1-9960-42c9-bf9b-60e150b429ae",
        name: "Textstring",
        propertyEditorAlias: "Umbraco.Textbox"
      };

      ekmResources.getNonEkomDataTypes().then(function (data) {
        $scope.model.dataTypes = data;
      });

    }]
  );

  angular.module("umbraco").controller("Ekom.PropertyEditor", [
    '$scope',
    '$rootScope',
    'editorState',
    'Ekom.PropertyEditorResources',
    'umbPropEditorHelper',
    'appState',
    '$routeParams',
    function ($scope, $rootScope, editorState, ekmResources, umbPropEditorHelper, appState, $routeParams) {

      if ($routeParams.section !== 'content') { return; }

      $scope.model.hideLabel = $scope.model.config.hideLabel == 1;

      $scope.property = {
        config: {},
        view: ""
      };

      $scope.tabs = [];
      $scope.currentTab = undefined;

      if (!angular.isObject($scope.model.value))
        $scope.model.value = undefined;

      $scope.model.value = $scope.model.value || {
        values: {},
        dtdGuid: "00000000-0000-0000-0000-000000000000"
      };

      var currentSection = appState.getSectionState("currentSection");
      var parentScope = $scope;
      var nodeContext = undefined;

      while (!nodeContext && parentScope.$id !== $rootScope.$id) {
        parentScope = parentScope.$parent;
        nodeContext = parentScope.nodeContext;
      }
      if (!nodeContext) {
        nodeContext = editorState.current;
      }

      ekmResources.getDataTypeById($scope.model.config.dataType.guid).then(function (dataType) {

        // Stash the config in scope for reuse
        $scope.property.config = dataType.preValues;

        // Get the view path
        $scope.property.viewPath = umbPropEditorHelper.getViewPath(dataType.view);

        // Get the property alias
        var propAlias = $scope.model.propertyAlias || $scope.model.alias;

        ekmResources.getDataTypeByAlias(currentSection, nodeContext.contentTypeAlias, propAlias).then(function (dataType2) {

          $scope.model.value.dtdGuid = dataType2.guid;

          if (dataType2.preValues.useLanguages) {

            ekmResources.getLanguages().then(function (languages) {

              $scope.tabs = languages.map(x => ({ value: x.IsoCode, text: x.CultureName }));

              $scope.setValues();

            });

          } else {

            ekmResources.getStores().then(function (stores) {

              $scope.tabs = stores.map(x => ({ value: x.Alias, text: x.Title }));

              $scope.setValues();

            });

          }

        });

      });

      $scope.setCurrentTab = function (tab) {
        $scope.currentTab = tab;
      }

      $scope.$on("formSubmitting", function (ev, args) {

        $scope.$broadcast("ekomValuesEvent", { tab: $scope.currentTab.value });

        // Strip out empty entries
        var cleanValue = {};
        _.each($scope.tabs, function (tab) {

          cleanValue[tab.value] = $scope.model.value.values[tab.value];

        });

        $scope.model.value.values = !_.isEmpty(cleanValue) ? cleanValue : undefined;

      });

      $scope.setValues = function () {

        $scope.currentTab = $scope.tabs[0];

        if (!$scope.model.value.values) {
          $scope.model.value.values = {};
        }

        _.each($scope.tabs, function (tab) {
          if (!$scope.model.value.values.hasOwnProperty(tab.value)) {
            $scope.model.value.values[tab.value] = $scope.model.value.values[tab.value];
          }
        });

      }

    }]
  );

})();


/* Resources */
angular.module('umbraco.resources').factory('Ekom.PropertyEditorResources',
  function ($q, $http, umbRequestHelper) {
    return {
      getNonEkomDataTypes: function () {
        return umbRequestHelper.resourcePromise(
          $http.get(Umbraco.Sys.ServerVariables.ekom.apiEndpoint + "GetNonEkomDataTypes"),
          'Failed to retrieve datatypes'
        );
      },
      getDataTypeById: function (id) {
        return umbRequestHelper.resourcePromise(
          $http.get(Umbraco.Sys.ServerVariables.ekom.apiEndpoint + "GetDataTypeById?id=" + id),
          'Failed to retrieve datatype'
        );
      },
      getDataTypeByAlias: function (contentType, contentTypeAlias, propertyAlias) {
        return umbRequestHelper.resourcePromise(
          $http.get(Umbraco.Sys.ServerVariables.ekom.apiEndpoint + "GetDataTypeByAlias?contentType=" + contentType + "&contentTypeAlias=" + contentTypeAlias + "&propertyAlias=" + propertyAlias),
          'Failed to retrieve datatype'
        );
      },
      getLanguages: function () {
        return umbRequestHelper.resourcePromise(
          $http.get(Umbraco.Sys.ServerVariables.ekom.apiEndpoint + "GetLanguages"),
          'Failed to retrieve languages'
        );
      },
      getStores: function () {
        return umbRequestHelper.resourcePromise(
          $http.get(Umbraco.Sys.ServerVariables.ekom.apiEndpoint + "GetStores"),
          'Failed to retrieve stores'
        );
      }
    };
  }
);


/* Directives */
angular.module("umbraco.directives").directive('ekomProperty',
  function () {

    var link = function (scope, ctrl) {
      scope[ctrl.$name] = ctrl;

      scope.model = {};

      // Some core property editors update the prevalues
      // but then fail to check them incase the config
      // is in the desired format, so to get round this
      // we give each instance a clone of the original
      // config so that changes made aren't remebered
      // between tab loads
      // bug here http://issues.umbraco.org/issue/U4-8266
      scope.model.config = angular.copy(scope.config);

      scope.model.alias = scope.propertyAlias + "." + scope.tab;
      scope.model.value = scope.value.values ? scope.value.values[scope.tab] : undefined;

      var unsubscribe = scope.$on("ekomValuesEvent", function (ev, args) {

        scope.$broadcast("formSubmitting", { scope: scope });
        if (!scope.value.values)
          scope.value.values = {};

        scope.value.values[scope.tab] = scope.model.value;

      });

      scope.$on('$destroy', function () {
        unsubscribe();
      });
    };

    return {
      require: "^form",
      restrict: "E",
      replace: true,
      link: link,
      template: '<div ng-include="propertyEditorView"></div>',
      scope: {
        propertyEditorView: '=view',
        config: '=',
        tab: '=',
        propertyAlias: '=',
        value: '='
      }
    };
  });
