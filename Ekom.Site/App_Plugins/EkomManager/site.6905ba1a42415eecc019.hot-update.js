webpackHotUpdate("site",{

/***/ "./src/components/orders/orders.js":
/*!*****************************************!*\
  !*** ./src/components/orders/orders.js ***!
  \*****************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Orders; });\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react */ \"./node_modules/react/index.js\");\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! lodash */ \"./node_modules/lodash/lodash.js\");\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(lodash__WEBPACK_IMPORTED_MODULE_1__);\n/* harmony import */ var stores_orderStore__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! stores/orderStore */ \"./src/stores/orderStore.js\");\n/* harmony import */ var react_table__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! react-table */ \"./node_modules/react-table/es/index.js\");\nfunction _typeof(obj) { if (typeof Symbol === \"function\" && typeof Symbol.iterator === \"symbol\") { _typeof = function _typeof(obj) { return typeof obj; }; } else { _typeof = function _typeof(obj) { return obj && typeof Symbol === \"function\" && obj.constructor === Symbol && obj !== Symbol.prototype ? \"symbol\" : typeof obj; }; } return _typeof(obj); }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function\"); } _setPrototypeOf(subClass.prototype, superClass && superClass.prototype); if (superClass) _setPrototypeOf(subClass, superClass); }\n\nfunction _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }\n\nfunction _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }\n\nfunction _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }\n\nfunction _possibleConstructorReturn(self, call) { if (call && (_typeof(call) === \"object\" || typeof call === \"function\")) { return call; } return _assertThisInitialized(self); }\n\nfunction _getPrototypeOf(o) { _getPrototypeOf = Object.getPrototypeOf || function _getPrototypeOf(o) { return o.__proto__; }; return _getPrototypeOf(o); }\n\nfunction _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return self; }\n\n\n\n\n\n\nvar Orders =\n/*#__PURE__*/\nfunction (_Component) {\n  function Orders(props) {\n    var _this;\n\n    _classCallCheck(this, Orders);\n\n    _this = _possibleConstructorReturn(this, _getPrototypeOf(Orders).call(this, props));\n    _this.state = {\n      defaultData: [],\n      orders: [],\n      pages: null,\n      loading: true,\n      filtered: []\n    };\n    _this.dataChange = _this.dataChange.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    _this.updateData = _this.updateData.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    _this.filterData = _this.filterData.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    return _this;\n  }\n\n  _createClass(Orders, [{\n    key: \"componentDidMount\",\n    value: function componentDidMount() {\n      var _this2 = this;\n\n      this.getOrders().then(function (orders) {\n        _this2.setState({\n          defaultData: orders,\n          orders: orders,\n          loading: false\n        });\n      });\n    }\n  }, {\n    key: \"getOrders\",\n    value: function getOrders() {\n      return fetch('/umbraco/backoffice/ekom/managerapi/getorders', {\n        credentials: 'include'\n      }).then(function (response) {\n        return response.json();\n      }).then(function (result) {\n        return result;\n      });\n    }\n  }, {\n    key: \"dataChange\",\n    value: function dataChange(filtered, column) {\n      console.log(filtered);\n      this.setState({\n        filtered: filtered\n      });\n      /*\r\n      this.setState({ loading: true });\r\n      this.filterData(\r\n        filtered\r\n      ).then(res => {\r\n        console.log(res)\r\n        this.setState({\r\n          orders: res,\r\n          loading: false\r\n        })\r\n      }).then(() => {\r\n        console.log(this.state)\r\n      })\r\n      */\n    }\n  }, {\n    key: \"filterData\",\n    value: function filterData(filtered) {\n      // You can retrieve your data however you want, in this case, we will just use some local data.\n      var filteredData = this.state.defaultData; // You can use the filters in your request, but you are responsible for applying them.\n\n      if (filtered.length) {\n        filteredData = filtered.reduce(function (filteredSoFar, nextFilter) {\n          return filteredSoFar.filter(function (row) {\n            return (row[nextFilter.id] + \"\").includes(nextFilter.value);\n          });\n        }, filteredData);\n      }\n    }\n  }, {\n    key: \"updateData\",\n    value: function updateData(pageSize, page, sorted, filtered) {\n      var _this3 = this;\n\n      return new Promise(function (resolve, reject) {\n        // You can retrieve your data however you want, in this case, we will just use some local data.\n        var filteredData = _this3.state.defaultData; // You can use the filters in your request, but you are responsible for applying them.\n\n        if (filtered.length) {\n          filteredData = filtered.reduce(function (filteredSoFar, nextFilter) {\n            return filteredSoFar.filter(function (row) {\n              return (row[nextFilter.id] + \"\").includes(nextFilter.value);\n            });\n          }, filteredData);\n        } // You can also use the sorting in your request, but again, you are responsible for applying it.\n\n\n        var sortedData = lodash__WEBPACK_IMPORTED_MODULE_1___default.a.orderBy(filteredData, sorted.map(function (sort) {\n          return function (row) {\n            if (row[sort.id] === null || row[sort.id] === undefined) {\n              return -Infinity;\n            }\n\n            return typeof row[sort.id] === \"string\" ? row[sort.id].toLowerCase() : row[sort.id];\n          };\n        }), sorted.map(function (d) {\n          return d.desc ? \"desc\" : \"asc\";\n        })); // You must return an object containing the rows of the current page, and optionally the total pages number.\n\n\n        var res = {\n          rows: sortedData.slice(pageSize * page, pageSize * page + pageSize),\n          pages: Math.ceil(filteredData.length / pageSize)\n        }; // Here we'll simulate a server response with 500ms of delay.\n\n        setTimeout(function () {\n          return resolve(res);\n        }, 500);\n      });\n    }\n  }, {\n    key: \"render\",\n    value: function render() {\n      var _this$state = this.state,\n          loading = _this$state.loading,\n          defaultData = _this$state.defaultData,\n          orders = _this$state.orders,\n          pages = _this$state.pages,\n          filtered = _this$state.filtered;\n      var columns = [{\n        Header: 'Orders',\n        columns: [{\n          Header: 'Order Number',\n          accessor: 'OrderNumber'\n        }, {\n          Header: 'Status',\n          accessor: 'OrderStatus'\n        }, {\n          Header: 'Email',\n          accessor: 'CustomerEmail'\n        }, {\n          Header: 'Name',\n          accessor: 'CustomerName'\n        }, {\n          Header: 'Country',\n          accessor: 'CustomerCountry'\n        }, {\n          Header: 'Created',\n          accessor: 'CreateDate'\n        }, {\n          Header: 'Paid',\n          accessor: 'PaidDate'\n        }, {\n          Header: 'Total',\n          accessor: 'TotalAmount'\n        }]\n      }];\n      return react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"main\", null, react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react_table__WEBPACK_IMPORTED_MODULE_3__[\"default\"], {\n        data: orders,\n        filterable: true,\n        pages: pages,\n        columns: columns,\n        onFilteredChange: this.dataChange,\n        defaultPageSize: 2,\n        loading: loading,\n        className: \"-striped -highlight\"\n      }));\n    }\n  }]);\n\n  _inherits(Orders, _Component);\n\n  return Orders;\n}(react__WEBPACK_IMPORTED_MODULE_0__[\"Component\"]);\n\n//# sourceURL=[module]\n//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vLi9zcmMvY29tcG9uZW50cy9vcmRlcnMvb3JkZXJzLmpzPzA5OGYiXSwibmFtZXMiOlsiT3JkZXJzIiwicHJvcHMiLCJzdGF0ZSIsImRlZmF1bHREYXRhIiwib3JkZXJzIiwicGFnZXMiLCJsb2FkaW5nIiwiZmlsdGVyZWQiLCJkYXRhQ2hhbmdlIiwiYmluZCIsInVwZGF0ZURhdGEiLCJmaWx0ZXJEYXRhIiwiZ2V0T3JkZXJzIiwidGhlbiIsInNldFN0YXRlIiwiZmV0Y2giLCJjcmVkZW50aWFscyIsInJlc3BvbnNlIiwianNvbiIsInJlc3VsdCIsImNvbHVtbiIsImNvbnNvbGUiLCJsb2ciLCJmaWx0ZXJlZERhdGEiLCJsZW5ndGgiLCJyZWR1Y2UiLCJmaWx0ZXJlZFNvRmFyIiwibmV4dEZpbHRlciIsImZpbHRlciIsInJvdyIsImlkIiwiaW5jbHVkZXMiLCJ2YWx1ZSIsInBhZ2VTaXplIiwicGFnZSIsInNvcnRlZCIsIlByb21pc2UiLCJyZXNvbHZlIiwicmVqZWN0Iiwic29ydGVkRGF0YSIsIl8iLCJvcmRlckJ5IiwibWFwIiwic29ydCIsInVuZGVmaW5lZCIsIkluZmluaXR5IiwidG9Mb3dlckNhc2UiLCJkIiwiZGVzYyIsInJlcyIsInJvd3MiLCJzbGljZSIsIk1hdGgiLCJjZWlsIiwic2V0VGltZW91dCIsImNvbHVtbnMiLCJIZWFkZXIiLCJhY2Nlc3NvciJdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7QUFBQTtBQUNBO0FBQ0E7QUFDQTs7SUFFcUJBLE07OztBQUVuQixrQkFBWUMsS0FBWixFQUFtQjtBQUFBOztBQUFBOztBQUNqQixnRkFBTUEsS0FBTjtBQUVBLFVBQUtDLEtBQUwsR0FBYTtBQUNYQyxtQkFBYSxFQURGO0FBRVhDLGNBQVEsRUFGRztBQUdYQyxhQUFPLElBSEk7QUFJWEMsZUFBUyxJQUpFO0FBS1hDLGdCQUFVO0FBTEMsS0FBYjtBQU9BLFVBQUtDLFVBQUwsR0FBa0IsTUFBS0EsVUFB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WCxPQURZLENBQWQ7QUF3Q0EsYUFDRSx5RUFDRSwyREFBQyxtREFBRDtBQUNJLGNBQU1yRCxNQURWO0FBRUksd0JBRko7QUFHSSxlQUFPQyxLQUhYO0FBSUksaUJBQVNrRCxPQUpiO0FBS0ksMEJBQWtCLEtBQUsvQyxVQUwzQjtBQU1JLHlCQUFpQixDQU5yQjtBQU9JLGlCQUFTRixPQVBiO0FBUUksbUJBQVU7QUFSZCxRQURGLENBREY7QUFjRDs7Ozs7O0VBakxpQywrQyIsImZpbGUiOiIuL3NyYy9jb21wb25lbnRzL29yZGVycy9vcmRlcnMuanMuanMiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgUmVhY3QsIHsgQ29tcG9uZW50IH0gZnJvbSAncmVhY3QnO1xyXG5pbXBvcnQgXyBmcm9tIFwibG9kYXNoXCI7XHJcbmltcG9ydCBvcmRlclN0b3JlIGZyb20gJ3N0b3Jlcy9vcmRlclN0b3JlJztcclxuaW1wb3J0IFJlYWN0VGFibGUgZnJvbSAncmVhY3QtdGFibGUnO1xyXG5cclxuZXhwb3J0IGRlZmF1bHQgY2xhc3MgT3JkZXJzIGV4dGVuZHMgQ29tcG9uZW50IHtcclxuXHJcbiAgY29uc3RydWN0b3IocHJvcHMpIHtcclxuICAgIHN1cGVyKHByb3BzKTtcclxuXHJcbiAgICB0aGlzLnN0YXRlID0ge1xyXG4gICAgICBkZWZhdWx0RGF0YTogW10sXHJcbiAgICAgIG9yZGVyczogW10sXHJcbiAgICAgIHBhZ2VzOiBudWxsLFxyXG4gICAgICBsb2FkaW5nOiB0cnVlLFxyXG4gICAgICBmaWx0ZXJlZDogW10sXHJcbiAgICB9XHJcbiAgICB0aGlzLmRhdGFDaGFuZ2UgPSB0aGlzLmRhdGFDaGFuZ2UuYmluZCh0aGlzKTtcclxuICAgIHRoaXMudXBkYXRlRGF0YSA9IHRoaXMudXBkYXRlRGF0YS5iaW5kKHRoaXMpO1xyXG4gICAgdGhpcy5maWx0ZXJEYXRhID0gdGhpcy5maWx0ZXJEYXRhLmJpbmQodGhpcyk7XHJcbiAgfSAgXHJcblxyXG4gIGNvbXBvbmVudERpZE1vdW50KCkge1xyXG5cclxuICAgIHRoaXMuZ2V0T3JkZXJzKCkudGhlbigob3JkZXJzKSA9PiB7XHJcblxyXG5cclxuICAgICAgdGhpcy5zZXRTdGF0ZSh7XHJcbiAgICAgICAgZGVmYXVsdERhdGE6IG9yZGVycyxcclxuICAgICAgICBvcmRlcnM6IG9yZGVycyxcclxuICAgICAgICBsb2FkaW5nOiBmYWxzZSxcclxuICAgICAgfSk7XHJcblxyXG4gICAgfSk7XHJcbiAgfVxyXG5cclxuICBnZXRPcmRlcnMoKSB7XHJcbiAgICByZXR1cm4gZmV0Y2goJy91bWJyYWNvL2JhY2tvZmZpY2UvZWtvbS9tYW5hZ2VyYXBpL2dldG9yZGVycycsIHtcclxuICAgICAgY3JlZGVudGlhbHM6ICdpbmNsdWRlJyxcclxuICAgIH0pLnRoZW4oZnVuY3Rpb24gKHJlc3BvbnNlKSB7XHJcbiAgICAgIHJldHVybiByZXNwb25zZS5qc29uKCk7XHJcbiAgICB9KS50aGVuKGZ1bmN0aW9uIChyZXN1bHQpIHtcclxuICAgICAgcmV0dXJuIHJlc3VsdDtcclxuICAgIH0pO1xyXG4gIH1cclxuICBkYXRhQ2hhbmdlKGZpbHRlcmVkLCBjb2x1bW4pIHtcclxuICAgIGNvbnNvbGUubG9nKGZpbHRlcmVkKVxyXG4gICAgdGhpcy5zZXRTdGF0ZSh7XHJcbiAgICAgIGZpbHRlcmVkOiBmaWx0ZXJlZFxyXG4gICAgfSlcclxuICAgIC8qXHJcbiAgICB0aGlzLnNldFN0YXRlKHsgbG9hZGluZzogdHJ1ZSB9KTtcclxuICAgIHRoaXMuZmlsdGVyRGF0YShcclxuICAgICAgZmlsdGVyZWRcclxuICAgICkudGhlbihyZXMgPT4ge1xyXG4gICAgICBjb25zb2xlLmxvZyhyZXMpXHJcbiAgICAgIHRoaXMuc2V0U3RhdGUoe1xyXG4gICAgICAgIG9yZGVyczogcmVzLFxyXG4gICAgICAgIGxvYWRpbmc6IGZhbHNlXHJcbiAgICAgIH0pXHJcbiAgICB9KS50aGVuKCgpID0+IHtcclxuICAgICAgY29uc29sZS5sb2codGhpcy5zdGF0ZSlcclxuICAgIH0pXHJcbiAgICAqL1xyXG4gIH1cclxuICBmaWx0ZXJEYXRhKGZpbHRlcmVkKSB7XHJcbiAgICAvLyBZb3UgY2FuIHJldHJpZXZlIHlvdXIgZGF0YSBob3dldmVyIHlvdSB3YW50LCBpbiB0aGlzIGNhc2UsIHdlIHdpbGwganVzdCB1c2Ugc29tZSBsb2NhbCBkYXRhLlxyXG4gICAgbGV0IGZpbHRlcmVkRGF0YSA9IHRoaXMuc3RhdGUuZGVmYXVsdERhdGE7XHJcblxyXG4gICAgLy8gWW91IGNhbiB1c2UgdGhlIGZpbHRlcnMgaW4geW91ciByZXF1ZXN0LCBidXQgeW91IGFyZSByZXNwb25zaWJsZSBmb3IgYXBwbHlpbmcgdGhlbS5cclxuICAgIGlmIChmaWx0ZXJlZC5sZW5ndGgpIHtcclxuICAgICAgZmlsdGVyZWREYXRhID0gZmlsdGVyZWQucmVkdWNlKChmaWx0ZXJlZFNvRmFyLCBuZXh0RmlsdGVyKSA9PiB7XHJcbiAgICAgICAgcmV0dXJuIGZpbHRlcmVkU29GYXIuZmlsdGVyKHJvdyA9PiB7XHJcbiAgICAgICAgICByZXR1cm4gKHJvd1tuZXh0RmlsdGVyLmlkXSArIFwiXCIpLmluY2x1ZGVzKG5leHRGaWx0ZXIudmFsdWUpO1xyXG4gICAgICAgIH0pO1xyXG4gICAgICB9LCBmaWx0ZXJlZERhdGEpO1xyXG4gICAgfVxyXG5cclxuICB9XHJcbiAgdXBkYXRlRGF0YShwYWdlU2l6ZSwgcGFnZSwgc29ydGVkLCBmaWx0ZXJlZCkge1xyXG4gICAgcmV0dXJuIG5ldyBQcm9taXNlKChyZXNvbHZlLCByZWplY3QpID0+IHtcclxuICAgICAgLy8gWW91IGNhbiByZXRyaWV2ZSB5b3VyIGRhdGEgaG93ZXZlciB5b3Ugd2FudCwgaW4gdGhpcyBjYXNlLCB3ZSB3aWxsIGp1c3QgdXNlIHNvbWUgbG9jYWwgZGF0YS5cclxuICAgICAgbGV0IGZpbHRlcmVkRGF0YSA9IHRoaXMuc3RhdGUuZGVmYXVsdERhdGE7XHJcbiAgXHJcbiAgICAgIC8vIFlvdSBjYW4gdXNlIHRoZSBmaWx0ZXJzIGluIHlvdXIgcmVxdWVzdCwgYnV0IHlvdSBhcmUgcmVzcG9uc2libGUgZm9yIGFwcGx5aW5nIHRoZW0uXHJcbiAgICAgIGlmIChmaWx0ZXJlZC5sZW5ndGgpIHtcclxuICAgICAgICBmaWx0ZXJlZERhdGEgPSBmaWx0ZXJlZC5yZWR1Y2UoKGZpbHRlcmVkU29GYXIsIG5leHRGaWx0ZXIpID0+IHtcclxuICAgICAgICAgIHJldHVybiBmaWx0ZXJlZFNvRmFyLmZpbHRlcihyb3cgPT4ge1xyXG4gICAgICAgICAgICByZXR1cm4gKHJvd1tuZXh0RmlsdGVyLmlkXSArIFwiXCIpLmluY2x1ZGVzKG5leHRGaWx0ZXIudmFsdWUpO1xyXG4gICAgICAgICAgfSk7XHJcbiAgICAgICAgfSwgZmlsdGVyZWREYXRhKTtcclxuICAgICAgfVxyXG4gICAgICAvLyBZb3UgY2FuIGFsc28gdXNlIHRoZSBzb3J0aW5nIGluIHlvdXIgcmVxdWVzdCwgYnV0IGFnYWluLCB5b3UgYXJlIHJlc3BvbnNpYmxlIGZvciBhcHBseWluZyBpdC5cclxuICAgICAgY29uc3Qgc29ydGVkRGF0YSA9IF8ub3JkZXJCeShcclxuICAgICAgICBmaWx0ZXJlZERhdGEsXHJcbiAgICAgICAgc29ydGVkLm1hcChzb3J0ID0+IHtcclxuICAgICAgICAgIHJldHVybiByb3cgPT4ge1xyXG4gICAgICAgICAgICBpZiAocm93W3NvcnQuaWRdID09PSBudWxsIHx8IHJvd1tzb3J0LmlkXSA9PT0gdW5kZWZpbmVkKSB7XHJcbiAgICAgICAgICAgICAgcmV0dXJuIC1JbmZpbml0eTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICByZXR1cm4gdHlwZW9mIHJvd1tzb3J0LmlkXSA9PT0gXCJzdHJpbmdcIlxyXG4gICAgICAgICAgICAgID8gcm93W3NvcnQuaWRdLnRvTG93ZXJDYXNlKClcclxuICAgICAgICAgICAgICA6IHJvd1tzb3J0LmlkXTtcclxuICAgICAgICAgIH07XHJcbiAgICAgICAgfSksXHJcbiAgICAgICAgc29ydGVkLm1hcChkID0+IChkLmRlc2MgPyBcImRlc2NcIiA6IFwiYXNjXCIpKVxyXG4gICAgICApO1xyXG4gIFxyXG4gICAgICAvLyBZb3UgbXVzdCByZXR1cm4gYW4gb2JqZWN0IGNvbnRhaW5pbmcgdGhlIHJvd3Mgb2YgdGhlIGN1cnJlbnQgcGFnZSwgYW5kIG9wdGlvbmFsbHkgdGhlIHRvdGFsIHBhZ2VzIG51bWJlci5cclxuICAgICAgY29uc3QgcmVzID0ge1xyXG4gICAgICAgIHJvd3M6IHNvcnRlZERhdGEuc2xpY2UocGFnZVNpemUgKiBwYWdlLCBwYWdlU2l6ZSAqIHBhZ2UgKyBwYWdlU2l6ZSksXHJcbiAgICAgICAgcGFnZXM6IE1hdGguY2VpbChmaWx0ZXJlZERhdGEubGVuZ3RoIC8gcGFnZVNpemUpXHJcbiAgICAgIH07XHJcbiAgXHJcbiAgICAgIC8vIEhlcmUgd2UnbGwgc2ltdWxhdGUgYSBzZXJ2ZXIgcmVzcG9uc2Ugd2l0aCA1MDBtcyBvZiBkZWxheS5cclxuICAgICAgc2V0VGltZW91dCgoKSA9PiByZXNvbHZlKHJlcyksIDUwMCk7XHJcbiAgICB9KTtcclxuICB9XHJcbiAgcmVuZGVyKCkge1xyXG5cclxuICAgIGNvbnN0IHtcclxuICAgICAgbG9hZGluZyxcclxuICAgICAgZGVmYXVsdERhdGEsXHJcbiAgICAgIG9yZGVycyxcclxuICAgICAgcGFnZXMsXHJcbiAgICAgIGZpbHRlcmVkXHJcbiAgICB9ID0gdGhpcy5zdGF0ZTtcclxuXHJcbiAgICB2YXIgY29sdW1ucyA9IFtcclxuICAgICAge1xyXG4gICAgICAgIEhlYWRlcjogJ09yZGVycycsXHJcbiAgICAgICAgY29sdW1uczogW1xyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdPcmRlciBOdW1iZXInLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ09yZGVyTnVtYmVyJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ1N0YXR1cycsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnT3JkZXJTdGF0dXMnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnRW1haWwnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ0N1c3RvbWVyRW1haWwnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnTmFtZScsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnQ3VzdG9tZXJOYW1lJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ0NvdW50cnknLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ0N1c3RvbWVyQ291bnRyeScsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdDcmVhdGVkJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdDcmVhdGVEYXRlJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ1BhaWQnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ1BhaWREYXRlJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ1RvdGFsJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdUb3RhbEFtb3VudCcsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgIF0sXHJcbiAgICAgIH0sXHJcbiAgICBdO1xyXG5cclxuICAgIHJldHVybiAoXHJcbiAgICAgIDxtYWluPlxyXG4gICAgICAgIDxSZWFjdFRhYmxlXHJcbiAgICAgICAgICAgIGRhdGE9e29yZGVyc31cclxuICAgICAgICAgICAgZmlsdGVyYWJsZVxyXG4gICAgICAgICAgICBwYWdlcz17cGFnZXN9XHJcbiAgICAgICAgICAgIGNvbHVtbnM9e2NvbHVtbnN9XHJcbiAgICAgICAgICAgIG9uRmlsdGVyZWRDaGFuZ2U9e3RoaXMuZGF0YUNoYW5nZX1cclxuICAgICAgICAgICAgZGVmYXVsdFBhZ2VTaXplPXsyfVxyXG4gICAgICAgICAgICBsb2FkaW5nPXtsb2FkaW5nfVxyXG4gICAgICAgICAgICBjbGFzc05hbWU9XCItc3RyaXBlZCAtaGlnaGxpZ2h0XCJcclxuICAgICAgICAgIC8+XHJcbiAgICAgIDwvbWFpbj5cclxuICAgICk7XHJcbiAgfVxyXG59XHJcbiJdLCJzb3VyY2VSb290IjoiIn0=\n//# sourceURL=webpack-internal:///./src/components/orders/orders.js\n");

/***/ })

})