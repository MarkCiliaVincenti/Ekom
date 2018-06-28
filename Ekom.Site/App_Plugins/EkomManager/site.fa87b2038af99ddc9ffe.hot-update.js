webpackHotUpdate("site",{

/***/ "./src/components/orders/orders.js":
/*!*****************************************!*\
  !*** ./src/components/orders/orders.js ***!
  \*****************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Orders; });\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react */ \"./node_modules/react/index.js\");\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! lodash */ \"./node_modules/lodash/lodash.js\");\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(lodash__WEBPACK_IMPORTED_MODULE_1__);\n/* harmony import */ var stores_orderStore__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! stores/orderStore */ \"./src/stores/orderStore.js\");\n/* harmony import */ var react_table__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! react-table */ \"./node_modules/react-table/es/index.js\");\nfunction _typeof(obj) { if (typeof Symbol === \"function\" && typeof Symbol.iterator === \"symbol\") { _typeof = function _typeof(obj) { return typeof obj; }; } else { _typeof = function _typeof(obj) { return obj && typeof Symbol === \"function\" && obj.constructor === Symbol && obj !== Symbol.prototype ? \"symbol\" : typeof obj; }; } return _typeof(obj); }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function\"); } _setPrototypeOf(subClass.prototype, superClass && superClass.prototype); if (superClass) _setPrototypeOf(subClass, superClass); }\n\nfunction _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }\n\nfunction _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }\n\nfunction _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }\n\nfunction _possibleConstructorReturn(self, call) { if (call && (_typeof(call) === \"object\" || typeof call === \"function\")) { return call; } return _assertThisInitialized(self); }\n\nfunction _getPrototypeOf(o) { _getPrototypeOf = Object.getPrototypeOf || function _getPrototypeOf(o) { return o.__proto__; }; return _getPrototypeOf(o); }\n\nfunction _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return self; }\n\n\n\n\n\n\nvar Orders =\n/*#__PURE__*/\nfunction (_Component) {\n  function Orders(props) {\n    var _this;\n\n    _classCallCheck(this, Orders);\n\n    _this = _possibleConstructorReturn(this, _getPrototypeOf(Orders).call(this, props));\n    _this.state = {\n      defaultData: [],\n      orders: [],\n      pages: null,\n      loading: true\n    };\n    _this.dataChange = _this.dataChange.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    _this.updateData = _this.updateData.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    return _this;\n  }\n\n  _createClass(Orders, [{\n    key: \"componentDidMount\",\n    value: function componentDidMount() {\n      var _this2 = this;\n\n      this.getOrders().then(function (orders) {\n        console.log(orders);\n\n        _this2.setState({\n          defaultData: orders,\n          orders: orders,\n          loading: false\n        });\n      });\n    }\n  }, {\n    key: \"getOrders\",\n    value: function getOrders() {\n      return fetch('/umbraco/backoffice/ekom/managerapi/getorders', {\n        credentials: 'include'\n      }).then(function (response) {\n        return response.json();\n      }).then(function (result) {\n        return result;\n      });\n    }\n  }, {\n    key: \"dataChange\",\n    value: function dataChange(filtered, column) {\n      console.log(filtered);\n      console.log(column);\n    }\n  }, {\n    key: \"filterData\",\n    value: function filterData(filtered) {\n      var _this3 = this;\n\n      return new Promise(function (resolve, reject) {\n        // You can retrieve your data however you want, in this case, we will just use some local data.\n        var filteredData = _this3.state.defaultData; // You can use the filters in your request, but you are responsible for applying them.\n\n        if (filtered.length) {\n          filteredData = filtered.reduce(function (filteredSoFar, nextFilter) {\n            return filteredSoFar.filter(function (row) {\n              return (row[nextFilter.id] + \"\").includes(nextFilter.value);\n            });\n          }, filteredData);\n        }\n\n        setTimeout(function () {\n          return resolve(res);\n        }, 500);\n      });\n    }\n  }, {\n    key: \"updateData\",\n    value: function updateData(pageSize, page, sorted, filtered) {\n      var _this4 = this;\n\n      return new Promise(function (resolve, reject) {\n        // You can retrieve your data however you want, in this case, we will just use some local data.\n        var filteredData = _this4.state.defaultData; // You can use the filters in your request, but you are responsible for applying them.\n\n        if (filtered.length) {\n          filteredData = filtered.reduce(function (filteredSoFar, nextFilter) {\n            return filteredSoFar.filter(function (row) {\n              return (row[nextFilter.id] + \"\").includes(nextFilter.value);\n            });\n          }, filteredData);\n        } // You can also use the sorting in your request, but again, you are responsible for applying it.\n\n\n        var sortedData = lodash__WEBPACK_IMPORTED_MODULE_1___default.a.orderBy(filteredData, sorted.map(function (sort) {\n          return function (row) {\n            if (row[sort.id] === null || row[sort.id] === undefined) {\n              return -Infinity;\n            }\n\n            return typeof row[sort.id] === \"string\" ? row[sort.id].toLowerCase() : row[sort.id];\n          };\n        }), sorted.map(function (d) {\n          return d.desc ? \"desc\" : \"asc\";\n        })); // You must return an object containing the rows of the current page, and optionally the total pages number.\n\n\n        var res = {\n          rows: sortedData.slice(pageSize * page, pageSize * page + pageSize),\n          pages: Math.ceil(filteredData.length / pageSize)\n        }; // Here we'll simulate a server response with 500ms of delay.\n\n        setTimeout(function () {\n          return resolve(res);\n        }, 500);\n      });\n    }\n  }, {\n    key: \"render\",\n    value: function render() {\n      var _this$state = this.state,\n          loading = _this$state.loading,\n          defaultData = _this$state.defaultData,\n          orders = _this$state.orders,\n          pages = _this$state.pages;\n      var columns = [{\n        Header: 'Orders',\n        columns: [{\n          Header: 'Order Number',\n          accessor: 'OrderNumber'\n        }, {\n          Header: 'Status',\n          accessor: 'OrderStatus'\n        }, {\n          Header: 'Email',\n          accessor: 'CustomerEmail'\n        }, {\n          Header: 'Name',\n          accessor: 'CustomerName'\n        }, {\n          Header: 'Country',\n          accessor: 'CustomerCountry'\n        }, {\n          Header: 'Created',\n          accessor: 'CreateDate'\n        }, {\n          Header: 'Paid',\n          accessor: 'PaidDate'\n        }, {\n          Header: 'Total',\n          accessor: 'TotalAmount'\n        }]\n      }];\n      return react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"main\", null, react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react_table__WEBPACK_IMPORTED_MODULE_3__[\"default\"], {\n        data: orders,\n        filterable: true,\n        pages: pages,\n        columns: columns,\n        onFilteredChange: this.dataChange,\n        defaultPageSize: 2,\n        loading: loading,\n        className: \"-striped -highlight\"\n      }));\n    }\n  }]);\n\n  _inherits(Orders, _Component);\n\n  return Orders;\n}(react__WEBPACK_IMPORTED_MODULE_0__[\"Component\"]);\n\n//# sourceURL=[module]\n//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vLi9zcmMvY29tcG9uZW50cy9vcmRlcnMvb3JkZXJzLmpzPzA5OGYiXSwibmFtZXMiOlsiT3JkZXJzIiwicHJvcHMiLCJzdGF0ZSIsImRlZmF1bHREYXRhIiwib3JkZXJzIiwicGFnZXMiLCJsb2FkaW5nIiwiZGF0YUNoYW5nZSIsImJpbmQiLCJ1cGRhdGVEYXRhIiwiZ2V0T3JkZXJzIiwidGhlbiIsImNvbnNvbGUiLCJsb2ciLCJzZXRTdGF0ZSIsImZldGNoIiwiY3JlZGVudGlhbHMiLCJyZXNwb25zZSIsImpzb24iLCJyZXN1bHQiLCJmaWx0ZXJlZCIsImNvbHVtbiIsIlByb21pc2UiLCJyZXNvbHZlIiwicmVqZWN0IiwiZmlsdGVyZWREYXRhIiwibGVuZ3RoIiwicmVkdWNlIiwiZmlsdGVyZWRTb0ZhciIsIm5leHRGaWx0ZXIiLCJmaWx0ZXIiLCJyb3ciLCJpZCIsImluY2x1ZGVzIiwidmFsdWUiLCJzZXRUaW1lb3V0IiwicmVzIiwicGFnZVNpemUiLCJwYWdlIiwic29ydGVkIiwic29ydGVkRGF0YSIsIl8iLCJvcmRlckJ5IiwibWFwIiwic29ydCIsInVuZGVmaW5lZCIsIkluZmluaXR5IiwidG9Mb3dlckNhc2UiLCJkIiwiZGVzYyIsInJvd3MiLCJzbGljZSIsIk1hdGgiLCJjZWlsIiwiY29sdW1ucyIsIkhlYWRlciIsImFjY2Vzc29yIl0sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7OztBQUFBO0FBQ0E7QUFDQTtBQUNBOztJQUVxQkEsTTs7O0FBRW5CLGtCQUFZQyxLQUFaLEVBQW1CO0FBQUE7O0FBQUE7O0FBQ2pCLGdGQUFNQSxLQUFOO0FBRUEsVUFBS0MsS0FBTCxHQUFhO0FBQ1hDLG1CQUFhLEVBREY7QUFFWEMsY0FBUSxFQUZHO0FBR1hDLGFBQU8sSUFISTtBQUlYQyxlQUFTO0FBSkUsS0FBYjtBQU1BLFVBQUtDLFVBQUwsR0FBa0IsTUFBS0EsVUFBTCxDQUFnQkMsSUFBaEIsdURBQWxCO0FBQ0EsVUFB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QUZaLFNBN0JPO0FBRlgsT0FEWSxDQUFkO0FBd0NBLGFBQ0UseUVBQ0UsMkRBQUMsbURBQUQ7QUFDSSxjQUFNcEQsTUFEVjtBQUVJLHdCQUZKO0FBR0ksZUFBT0MsS0FIWDtBQUlJLGlCQUFTaUQsT0FKYjtBQUtJLDBCQUFrQixLQUFLL0MsVUFMM0I7QUFNSSx5QkFBaUIsQ0FOckI7QUFPSSxpQkFBU0QsT0FQYjtBQVFJLG1CQUFVO0FBUmQsUUFERixDQURGO0FBY0Q7Ozs7OztFQWxLaUMsK0MiLCJmaWxlIjoiLi9zcmMvY29tcG9uZW50cy9vcmRlcnMvb3JkZXJzLmpzLmpzIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IFJlYWN0LCB7IENvbXBvbmVudCB9IGZyb20gJ3JlYWN0JztcclxuaW1wb3J0IF8gZnJvbSBcImxvZGFzaFwiO1xyXG5pbXBvcnQgb3JkZXJTdG9yZSBmcm9tICdzdG9yZXMvb3JkZXJTdG9yZSc7XHJcbmltcG9ydCBSZWFjdFRhYmxlIGZyb20gJ3JlYWN0LXRhYmxlJztcclxuXHJcbmV4cG9ydCBkZWZhdWx0IGNsYXNzIE9yZGVycyBleHRlbmRzIENvbXBvbmVudCB7XHJcblxyXG4gIGNvbnN0cnVjdG9yKHByb3BzKSB7XHJcbiAgICBzdXBlcihwcm9wcyk7XHJcblxyXG4gICAgdGhpcy5zdGF0ZSA9IHtcclxuICAgICAgZGVmYXVsdERhdGE6IFtdLFxyXG4gICAgICBvcmRlcnM6IFtdLFxyXG4gICAgICBwYWdlczogbnVsbCxcclxuICAgICAgbG9hZGluZzogdHJ1ZSxcclxuICAgIH1cclxuICAgIHRoaXMuZGF0YUNoYW5nZSA9IHRoaXMuZGF0YUNoYW5nZS5iaW5kKHRoaXMpO1xyXG4gICAgdGhpcy51cGRhdGVEYXRhID0gdGhpcy51cGRhdGVEYXRhLmJpbmQodGhpcyk7XHJcbiAgfSAgXHJcblxyXG4gIGNvbXBvbmVudERpZE1vdW50KCkge1xyXG5cclxuICAgIHRoaXMuZ2V0T3JkZXJzKCkudGhlbigob3JkZXJzKSA9PiB7XHJcblxyXG4gICAgICBjb25zb2xlLmxvZyhvcmRlcnMpO1xyXG5cclxuICAgICAgdGhpcy5zZXRTdGF0ZSh7XHJcbiAgICAgICAgZGVmYXVsdERhdGE6IG9yZGVycyxcclxuICAgICAgICBvcmRlcnM6IG9yZGVycyxcclxuICAgICAgICBsb2FkaW5nOiBmYWxzZSxcclxuICAgICAgfSk7XHJcblxyXG4gICAgfSk7XHJcbiAgfVxyXG5cclxuICBnZXRPcmRlcnMoKSB7XHJcbiAgICByZXR1cm4gZmV0Y2goJy91bWJyYWNvL2JhY2tvZmZpY2UvZWtvbS9tYW5hZ2VyYXBpL2dldG9yZGVycycsIHtcclxuICAgICAgY3JlZGVudGlhbHM6ICdpbmNsdWRlJyxcclxuICAgIH0pLnRoZW4oZnVuY3Rpb24gKHJlc3BvbnNlKSB7XHJcbiAgICAgIHJldHVybiByZXNwb25zZS5qc29uKCk7XHJcbiAgICB9KS50aGVuKGZ1bmN0aW9uIChyZXN1bHQpIHtcclxuICAgICAgcmV0dXJuIHJlc3VsdDtcclxuICAgIH0pO1xyXG4gIH1cclxuICBkYXRhQ2hhbmdlKGZpbHRlcmVkLCBjb2x1bW4pIHtcclxuICAgIGNvbnNvbGUubG9nKGZpbHRlcmVkKVxyXG4gICAgY29uc29sZS5sb2coY29sdW1uKVxyXG4gIH1cclxuICBmaWx0ZXJEYXRhKGZpbHRlcmVkKSB7XHJcbiAgICByZXR1cm4gbmV3IFByb21pc2UoKHJlc29sdmUsIHJlamVjdCkgPT4ge1xyXG4gICAgICAvLyBZb3UgY2FuIHJldHJpZXZlIHlvdXIgZGF0YSBob3dldmVyIHlvdSB3YW50LCBpbiB0aGlzIGNhc2UsIHdlIHdpbGwganVzdCB1c2Ugc29tZSBsb2NhbCBkYXRhLlxyXG4gICAgICBsZXQgZmlsdGVyZWREYXRhID0gdGhpcy5zdGF0ZS5kZWZhdWx0RGF0YTtcclxuICBcclxuICAgICAgLy8gWW91IGNhbiB1c2UgdGhlIGZpbHRlcnMgaW4geW91ciByZXF1ZXN0LCBidXQgeW91IGFyZSByZXNwb25zaWJsZSBmb3IgYXBwbHlpbmcgdGhlbS5cclxuICAgICAgaWYgKGZpbHRlcmVkLmxlbmd0aCkge1xyXG4gICAgICAgIGZpbHRlcmVkRGF0YSA9IGZpbHRlcmVkLnJlZHVjZSgoZmlsdGVyZWRTb0ZhciwgbmV4dEZpbHRlcikgPT4ge1xyXG4gICAgICAgICAgcmV0dXJuIGZpbHRlcmVkU29GYXIuZmlsdGVyKHJvdyA9PiB7XHJcbiAgICAgICAgICAgIHJldHVybiAocm93W25leHRGaWx0ZXIuaWRdICsgXCJcIikuaW5jbHVkZXMobmV4dEZpbHRlci52YWx1ZSk7XHJcbiAgICAgICAgICB9KTtcclxuICAgICAgICB9LCBmaWx0ZXJlZERhdGEpO1xyXG4gICAgICB9XHJcbiAgICAgIHNldFRpbWVvdXQoKCkgPT4gcmVzb2x2ZShyZXMpLCA1MDApO1xyXG4gICAgfSlcclxuXHJcbiAgfVxyXG4gIHVwZGF0ZURhdGEocGFnZVNpemUsIHBhZ2UsIHNvcnRlZCwgZmlsdGVyZWQpIHtcclxuICAgIHJldHVybiBuZXcgUHJvbWlzZSgocmVzb2x2ZSwgcmVqZWN0KSA9PiB7XHJcbiAgICAgIC8vIFlvdSBjYW4gcmV0cmlldmUgeW91ciBkYXRhIGhvd2V2ZXIgeW91IHdhbnQsIGluIHRoaXMgY2FzZSwgd2Ugd2lsbCBqdXN0IHVzZSBzb21lIGxvY2FsIGRhdGEuXHJcbiAgICAgIGxldCBmaWx0ZXJlZERhdGEgPSB0aGlzLnN0YXRlLmRlZmF1bHREYXRhO1xyXG4gIFxyXG4gICAgICAvLyBZb3UgY2FuIHVzZSB0aGUgZmlsdGVycyBpbiB5b3VyIHJlcXVlc3QsIGJ1dCB5b3UgYXJlIHJlc3BvbnNpYmxlIGZvciBhcHBseWluZyB0aGVtLlxyXG4gICAgICBpZiAoZmlsdGVyZWQubGVuZ3RoKSB7XHJcbiAgICAgICAgZmlsdGVyZWREYXRhID0gZmlsdGVyZWQucmVkdWNlKChmaWx0ZXJlZFNvRmFyLCBuZXh0RmlsdGVyKSA9PiB7XHJcbiAgICAgICAgICByZXR1cm4gZmlsdGVyZWRTb0Zhci5maWx0ZXIocm93ID0+IHtcclxuICAgICAgICAgICAgcmV0dXJuIChyb3dbbmV4dEZpbHRlci5pZF0gKyBcIlwiKS5pbmNsdWRlcyhuZXh0RmlsdGVyLnZhbHVlKTtcclxuICAgICAgICAgIH0pO1xyXG4gICAgICAgIH0sIGZpbHRlcmVkRGF0YSk7XHJcbiAgICAgIH1cclxuICAgICAgLy8gWW91IGNhbiBhbHNvIHVzZSB0aGUgc29ydGluZyBpbiB5b3VyIHJlcXVlc3QsIGJ1dCBhZ2FpbiwgeW91IGFyZSByZXNwb25zaWJsZSBmb3IgYXBwbHlpbmcgaXQuXHJcbiAgICAgIGNvbnN0IHNvcnRlZERhdGEgPSBfLm9yZGVyQnkoXHJcbiAgICAgICAgZmlsdGVyZWREYXRhLFxyXG4gICAgICAgIHNvcnRlZC5tYXAoc29ydCA9PiB7XHJcbiAgICAgICAgICByZXR1cm4gcm93ID0+IHtcclxuICAgICAgICAgICAgaWYgKHJvd1tzb3J0LmlkXSA9PT0gbnVsbCB8fCByb3dbc29ydC5pZF0gPT09IHVuZGVmaW5lZCkge1xyXG4gICAgICAgICAgICAgIHJldHVybiAtSW5maW5pdHk7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgcmV0dXJuIHR5cGVvZiByb3dbc29ydC5pZF0gPT09IFwic3RyaW5nXCJcclxuICAgICAgICAgICAgICA/IHJvd1tzb3J0LmlkXS50b0xvd2VyQ2FzZSgpXHJcbiAgICAgICAgICAgICAgOiByb3dbc29ydC5pZF07XHJcbiAgICAgICAgICB9O1xyXG4gICAgICAgIH0pLFxyXG4gICAgICAgIHNvcnRlZC5tYXAoZCA9PiAoZC5kZXNjID8gXCJkZXNjXCIgOiBcImFzY1wiKSlcclxuICAgICAgKTtcclxuICBcclxuICAgICAgLy8gWW91IG11c3QgcmV0dXJuIGFuIG9iamVjdCBjb250YWluaW5nIHRoZSByb3dzIG9mIHRoZSBjdXJyZW50IHBhZ2UsIGFuZCBvcHRpb25hbGx5IHRoZSB0b3RhbCBwYWdlcyBudW1iZXIuXHJcbiAgICAgIGNvbnN0IHJlcyA9IHtcclxuICAgICAgICByb3dzOiBzb3J0ZWREYXRhLnNsaWNlKHBhZ2VTaXplICogcGFnZSwgcGFnZVNpemUgKiBwYWdlICsgcGFnZVNpemUpLFxyXG4gICAgICAgIHBhZ2VzOiBNYXRoLmNlaWwoZmlsdGVyZWREYXRhLmxlbmd0aCAvIHBhZ2VTaXplKVxyXG4gICAgICB9O1xyXG4gIFxyXG4gICAgICAvLyBIZXJlIHdlJ2xsIHNpbXVsYXRlIGEgc2VydmVyIHJlc3BvbnNlIHdpdGggNTAwbXMgb2YgZGVsYXkuXHJcbiAgICAgIHNldFRpbWVvdXQoKCkgPT4gcmVzb2x2ZShyZXMpLCA1MDApO1xyXG4gICAgfSk7XHJcbiAgfVxyXG4gIHJlbmRlcigpIHtcclxuXHJcbiAgICBjb25zdCB7XHJcbiAgICAgIGxvYWRpbmcsXHJcbiAgICAgIGRlZmF1bHREYXRhLFxyXG4gICAgICBvcmRlcnMsXHJcbiAgICAgIHBhZ2VzLFxyXG4gICAgfSA9IHRoaXMuc3RhdGU7XHJcblxyXG4gICAgdmFyIGNvbHVtbnMgPSBbXHJcbiAgICAgIHtcclxuICAgICAgICBIZWFkZXI6ICdPcmRlcnMnLFxyXG4gICAgICAgIGNvbHVtbnM6IFtcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnT3JkZXIgTnVtYmVyJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdPcmRlck51bWJlcicsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdTdGF0dXMnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ09yZGVyU3RhdHVzJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ0VtYWlsJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdDdXN0b21lckVtYWlsJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ05hbWUnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ0N1c3RvbWVyTmFtZScsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdDb3VudHJ5JyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdDdXN0b21lckNvdW50cnknLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnQ3JlYXRlZCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnQ3JlYXRlRGF0ZScsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdQYWlkJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdQYWlkRGF0ZScsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdUb3RhbCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnVG90YWxBbW91bnQnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICBdLFxyXG4gICAgICB9LFxyXG4gICAgXTtcclxuXHJcbiAgICByZXR1cm4gKFxyXG4gICAgICA8bWFpbj5cclxuICAgICAgICA8UmVhY3RUYWJsZVxyXG4gICAgICAgICAgICBkYXRhPXtvcmRlcnN9XHJcbiAgICAgICAgICAgIGZpbHRlcmFibGVcclxuICAgICAgICAgICAgcGFnZXM9e3BhZ2VzfVxyXG4gICAgICAgICAgICBjb2x1bW5zPXtjb2x1bW5zfVxyXG4gICAgICAgICAgICBvbkZpbHRlcmVkQ2hhbmdlPXt0aGlzLmRhdGFDaGFuZ2V9XHJcbiAgICAgICAgICAgIGRlZmF1bHRQYWdlU2l6ZT17Mn1cclxuICAgICAgICAgICAgbG9hZGluZz17bG9hZGluZ31cclxuICAgICAgICAgICAgY2xhc3NOYW1lPVwiLXN0cmlwZWQgLWhpZ2hsaWdodFwiXHJcbiAgICAgICAgICAvPlxyXG4gICAgICA8L21haW4+XHJcbiAgICApO1xyXG4gIH1cclxufVxyXG4iXSwic291cmNlUm9vdCI6IiJ9\n//# sourceURL=webpack-internal:///./src/components/orders/orders.js\n");

/***/ })

})