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
    function ($scope, $rootScope, editorState, ekmResources, umbPropEditorHelper, appState) {

      $scope.property = {
        config: {},
        view: ""
      };

      $scope.tabs = [];
      $scope.currentTab = undefined;

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
          console.log(dataType2);

          if (dataType2.preValues.useStores) {
            ekmResources.getStores().then(function (stores) {

              $scope.tabs = stores.map(x => ({ value: x.Alias, text: x.Title }));

            });
          } else {
            ekmResources.getLanguages().then(function (languages) {
              console.log(languages);

              $scope.tabs = languages.map(x => ({ value: x.IsoCode, text: x.CultureName }));

              console.log($scope.tabs );
            });
          }

        });

      });

      $scope.setCurrentTab = function (tab) {
        $scope.currentTab = tab;
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
angular.module("umbraco.directives").directive('vortoProperty',
  function ($compile, $http, umbPropEditorHelper, $timeout, $rootScope, $q) {

    var link = function (scope, element, attrs, ctrl) {
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

      scope.model.alias = scope.propertyAlias + "." + scope.language;
      scope.model.value = scope.value.values ? scope.value.values[scope.language] : undefined;

      var unsubscribe = scope.$on("vortoSyncLanguageValue", function (ev, args) {
        if (args.language === scope.language) {
          scope.$broadcast("formSubmitting", { scope: scope });
          if (!scope.value.values)
            scope.value.values = {};
          scope.value.values[scope.language] = scope.model.value;
        }
      });

      scope.$on('$destroy', function () {
        unsubscribe();
      });
    };

    return {
      require: "^form",
      restrict: "E",
      rep1ace: true,
      link: link,
      template: '<div ng-include="propertyEditorView"></div>',
      scope: {
        propertyEditorView: '=view',
        config: '=',
        language: '=',
        propertyAlias: '=',
        value: '='
      }
    };
  });
