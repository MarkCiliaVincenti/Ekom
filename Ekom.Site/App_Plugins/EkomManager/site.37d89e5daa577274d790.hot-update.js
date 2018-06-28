webpackHotUpdate("site",{

/***/ "./src/components/orders/orders.js":
/*!*****************************************!*\
  !*** ./src/components/orders/orders.js ***!
  \*****************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Orders; });\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react */ \"./node_modules/react/index.js\");\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! lodash */ \"./node_modules/lodash/lodash.js\");\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(lodash__WEBPACK_IMPORTED_MODULE_1__);\n/* harmony import */ var stores_orderStore__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! stores/orderStore */ \"./src/stores/orderStore.js\");\n/* harmony import */ var react_table__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! react-table */ \"./node_modules/react-table/es/index.js\");\nfunction _typeof(obj) { if (typeof Symbol === \"function\" && typeof Symbol.iterator === \"symbol\") { _typeof = function _typeof(obj) { return typeof obj; }; } else { _typeof = function _typeof(obj) { return obj && typeof Symbol === \"function\" && obj.constructor === Symbol && obj !== Symbol.prototype ? \"symbol\" : typeof obj; }; } return _typeof(obj); }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function\"); } _setPrototypeOf(subClass.prototype, superClass && superClass.prototype); if (superClass) _setPrototypeOf(subClass, superClass); }\n\nfunction _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }\n\nfunction _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }\n\nfunction _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }\n\nfunction _possibleConstructorReturn(self, call) { if (call && (_typeof(call) === \"object\" || typeof call === \"function\")) { return call; } return _assertThisInitialized(self); }\n\nfunction _getPrototypeOf(o) { _getPrototypeOf = Object.getPrototypeOf || function _getPrototypeOf(o) { return o.__proto__; }; return _getPrototypeOf(o); }\n\nfunction _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return self; }\n\n\n\n\n\n\nvar Orders =\n/*#__PURE__*/\nfunction (_Component) {\n  function Orders(props) {\n    var _this;\n\n    _classCallCheck(this, Orders);\n\n    _this = _possibleConstructorReturn(this, _getPrototypeOf(Orders).call(this, props));\n    _this.state = {\n      defaultData: [],\n      orders: [],\n      pages: null,\n      loading: true,\n      filtered: []\n    };\n    _this.dataChange = _this.dataChange.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    _this.updateData = _this.updateData.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    _this.filterData = _this.filterData.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    return _this;\n  }\n\n  _createClass(Orders, [{\n    key: \"componentDidMount\",\n    value: function componentDidMount() {\n      var _this2 = this;\n\n      this.getOrders().then(function (orders) {\n        console.log(orders);\n\n        _this2.setState({\n          defaultData: orders,\n          orders: orders,\n          loading: false\n        });\n      });\n    }\n  }, {\n    key: \"getOrders\",\n    value: function getOrders() {\n      return fetch('/umbraco/backoffice/ekom/managerapi/getorders', {\n        credentials: 'include'\n      }).then(function (response) {\n        return response.json();\n      }).then(function (result) {\n        return result;\n      });\n    }\n  }, {\n    key: \"dataChange\",\n    value: function dataChange(filtered, column) {\n      console.log(filtered);\n      console.log(column);\n      /*\r\n      this.setState({ loading: true });\r\n      this.filterData(\r\n        filtered\r\n      ).then(res => {\r\n        console.log(res)\r\n        this.setState({\r\n          orders: res,\r\n          loading: false\r\n        })\r\n      }).then(() => {\r\n        console.log(this.state)\r\n      })\r\n      */\n    }\n  }, {\n    key: \"filterData\",\n    value: function filterData(filtered) {\n      var _this3 = this;\n\n      return new Promise(function (resolve, reject) {\n        // You can retrieve your data however you want, in this case, we will just use some local data.\n        var filteredData = _this3.state.defaultData; // You can use the filters in your request, but you are responsible for applying them.\n\n        if (filtered.length) {\n          filteredData = filtered.reduce(function (filteredSoFar, nextFilter) {\n            return filteredSoFar.filter(function (row) {\n              return (row[nextFilter.id] + \"\").includes(nextFilter.value);\n            });\n          }, filteredData);\n        }\n\n        setTimeout(function () {\n          return resolve(filteredData);\n        }, 500);\n      });\n    }\n  }, {\n    key: \"updateData\",\n    value: function updateData(pageSize, page, sorted, filtered) {\n      var _this4 = this;\n\n      return new Promise(function (resolve, reject) {\n        // You can retrieve your data however you want, in this case, we will just use some local data.\n        var filteredData = _this4.state.defaultData; // You can use the filters in your request, but you are responsible for applying them.\n\n        if (filtered.length) {\n          filteredData = filtered.reduce(function (filteredSoFar, nextFilter) {\n            return filteredSoFar.filter(function (row) {\n              return (row[nextFilter.id] + \"\").includes(nextFilter.value);\n            });\n          }, filteredData);\n        } // You can also use the sorting in your request, but again, you are responsible for applying it.\n\n\n        var sortedData = lodash__WEBPACK_IMPORTED_MODULE_1___default.a.orderBy(filteredData, sorted.map(function (sort) {\n          return function (row) {\n            if (row[sort.id] === null || row[sort.id] === undefined) {\n              return -Infinity;\n            }\n\n            return typeof row[sort.id] === \"string\" ? row[sort.id].toLowerCase() : row[sort.id];\n          };\n        }), sorted.map(function (d) {\n          return d.desc ? \"desc\" : \"asc\";\n        })); // You must return an object containing the rows of the current page, and optionally the total pages number.\n\n\n        var res = {\n          rows: sortedData.slice(pageSize * page, pageSize * page + pageSize),\n          pages: Math.ceil(filteredData.length / pageSize)\n        }; // Here we'll simulate a server response with 500ms of delay.\n\n        setTimeout(function () {\n          return resolve(res);\n        }, 500);\n      });\n    }\n  }, {\n    key: \"render\",\n    value: function render() {\n      var _this$state = this.state,\n          loading = _this$state.loading,\n          defaultData = _this$state.defaultData,\n          orders = _this$state.orders,\n          pages = _this$state.pages,\n          filtered = _this$state.filtered;\n      var columns = [{\n        Header: 'Orders',\n        columns: [{\n          Header: 'Order Number',\n          accessor: 'OrderNumber'\n        }, {\n          Header: 'Status',\n          accessor: 'OrderStatus'\n        }, {\n          Header: 'Email',\n          accessor: 'CustomerEmail'\n        }, {\n          Header: 'Name',\n          accessor: 'CustomerName'\n        }, {\n          Header: 'Country',\n          accessor: 'CustomerCountry'\n        }, {\n          Header: 'Created',\n          accessor: 'CreateDate'\n        }, {\n          Header: 'Paid',\n          accessor: 'PaidDate'\n        }, {\n          Header: 'Total',\n          accessor: 'TotalAmount'\n        }]\n      }];\n      return react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"main\", null, react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react_table__WEBPACK_IMPORTED_MODULE_3__[\"default\"], {\n        data: orders,\n        filterable: true,\n        pages: pages,\n        columns: columns,\n        filtered: filtered,\n        onFilteredChange: this.dataChange,\n        defaultPageSize: 2,\n        loading: loading,\n        className: \"-striped -highlight\"\n      }));\n    }\n  }]);\n\n  _inherits(Orders, _Component);\n\n  return Orders;\n}(react__WEBPACK_IMPORTED_MODULE_0__[\"Component\"]);\n\n//# sourceURL=[module]\n//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vLi9zcmMvY29tcG9uZW50cy9vcmRlcnMvb3JkZXJzLmpzPzA5OGYiXSwibmFtZXMiOlsiT3JkZXJzIiwicHJvcHMiLCJzdGF0ZSIsImRlZmF1bHREYXRhIiwib3JkZXJzIiwicGFnZXMiLCJsb2FkaW5nIiwiZmlsdGVyZWQiLCJkYXRhQ2hhbmdlIiwiYmluZCIsInVwZGF0ZURhdGEiLCJmaWx0ZXJEYXRhIiwiZ2V0T3JkZXJzIiwidGhlbiIsImNvbnNvbGUiLCJsb2ciLCJzZXRTdGF0ZSIsImZldGNoIiwiY3JlZGVudGlhbHMiLCJyZXNwb25zZSIsImpzb24iLCJyZXN1bHQiLCJjb2x1bW4iLCJQcm9taXNlIiwicmVzb2x2ZSIsInJlamVjdCIsImZpbHRlcmVkRGF0YSIsImxlbmd0aCIsInJlZHVjZSIsImZpbHRlcmVkU29GYXIiLCJuZXh0RmlsdGVyIiwiZmlsdGVyIiwicm93IiwiaWQiLCJpbmNsdWRlcyIsInZhbHVlIiwic2V0VGltZW91dCIsInBhZ2VTaXplIiwicGFnZSIsInNvcnRlZCIsInNvcnRlZERhdGEiLCJfIiwib3JkZXJCeSIsIm1hcCIsInNvcnQiLCJ1bmRlZmluZWQiLCJJbmZpbml0eSIsInRvTG93ZXJDYXNlIiwiZCIsImRlc2MiLCJyZXMiLCJyb3dzIiwic2xpY2UiLCJNYXRoIiwiY2VpbCIsImNvbHVtbnMiLCJIZWFkZXIiLCJhY2Nlc3NvciJdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7QUFBQTtBQUNBO0FBQ0E7QUFDQTs7SUFFcUJBLE07OztBQUVuQixrQkFBWUMsS0FBWixFQUFtQjtBQUFBOztBQUFBOztBQUNqQixnRkFBTUEsS0FBTjtBQUVBLFVBQUtDLEtBQUwsR0FBYTtBQUNYQyxtQkFBYSxFQURGO0FBRVhDLGNBQVEsRUFGRztBQUdYQyxhQUFPLElBSEk7QUFJWEMsZUFBUyxJQUpFO0FBS1hDLGdCQUFVO0FBTEMsS0FBYjtBQU9BLFVBQUtDLFVBQUwsR0FBa0IsTUFBS0EsVUFB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LFNBakJPLEVBcUJQO0FBQ0VELGtCQUFRLFNBRFY7QUFFRUMsb0JBQVU7QUFGWixTQXJCTyxFQXlCUDtBQUNFRCxrQkFBUSxNQURWO0FBRUVDLG9CQUFVO0FBRlosU0F6Qk8sRUE2QlA7QUFDRUQsa0JBQVEsT0FEVjtBQUVFQyxvQkFBVTtBQUZaLFNBN0JPO0FBRlgsT0FEWSxDQUFkO0FBd0NBLGFBQ0UseUVBQ0UsMkRBQUMsbURBQUQ7QUFDSSxjQUFNckQsTUFEVjtBQUVJLHdCQUZKO0FBR0ksZUFBT0MsS0FIWDtBQUlJLGlCQUFTa0QsT0FKYjtBQUtJLGtCQUFVaEQsUUFMZDtBQU1JLDBCQUFrQixLQUFLQyxVQU4zQjtBQU9JLHlCQUFpQixDQVByQjtBQVFJLGlCQUFTRixPQVJiO0FBU0ksbUJBQVU7QUFUZCxRQURGLENBREY7QUFlRDs7Ozs7O0VBckxpQywrQyIsImZpbGUiOiIuL3NyYy9jb21wb25lbnRzL29yZGVycy9vcmRlcnMuanMuanMiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgUmVhY3QsIHsgQ29tcG9uZW50IH0gZnJvbSAncmVhY3QnO1xyXG5pbXBvcnQgXyBmcm9tIFwibG9kYXNoXCI7XHJcbmltcG9ydCBvcmRlclN0b3JlIGZyb20gJ3N0b3Jlcy9vcmRlclN0b3JlJztcclxuaW1wb3J0IFJlYWN0VGFibGUgZnJvbSAncmVhY3QtdGFibGUnO1xyXG5cclxuZXhwb3J0IGRlZmF1bHQgY2xhc3MgT3JkZXJzIGV4dGVuZHMgQ29tcG9uZW50IHtcclxuXHJcbiAgY29uc3RydWN0b3IocHJvcHMpIHtcclxuICAgIHN1cGVyKHByb3BzKTtcclxuXHJcbiAgICB0aGlzLnN0YXRlID0ge1xyXG4gICAgICBkZWZhdWx0RGF0YTogW10sXHJcbiAgICAgIG9yZGVyczogW10sXHJcbiAgICAgIHBhZ2VzOiBudWxsLFxyXG4gICAgICBsb2FkaW5nOiB0cnVlLFxyXG4gICAgICBmaWx0ZXJlZDogW10sXHJcbiAgICB9XHJcbiAgICB0aGlzLmRhdGFDaGFuZ2UgPSB0aGlzLmRhdGFDaGFuZ2UuYmluZCh0aGlzKTtcclxuICAgIHRoaXMudXBkYXRlRGF0YSA9IHRoaXMudXBkYXRlRGF0YS5iaW5kKHRoaXMpO1xyXG4gICAgdGhpcy5maWx0ZXJEYXRhID0gdGhpcy5maWx0ZXJEYXRhLmJpbmQodGhpcyk7XHJcbiAgfSAgXHJcblxyXG4gIGNvbXBvbmVudERpZE1vdW50KCkge1xyXG5cclxuICAgIHRoaXMuZ2V0T3JkZXJzKCkudGhlbigob3JkZXJzKSA9PiB7XHJcblxyXG4gICAgICBjb25zb2xlLmxvZyhvcmRlcnMpO1xyXG5cclxuICAgICAgdGhpcy5zZXRTdGF0ZSh7XHJcbiAgICAgICAgZGVmYXVsdERhdGE6IG9yZGVycyxcclxuICAgICAgICBvcmRlcnM6IG9yZGVycyxcclxuICAgICAgICBsb2FkaW5nOiBmYWxzZSxcclxuICAgICAgfSk7XHJcblxyXG4gICAgfSk7XHJcbiAgfVxyXG5cclxuICBnZXRPcmRlcnMoKSB7XHJcbiAgICByZXR1cm4gZmV0Y2goJy91bWJyYWNvL2JhY2tvZmZpY2UvZWtvbS9tYW5hZ2VyYXBpL2dldG9yZGVycycsIHtcclxuICAgICAgY3JlZGVudGlhbHM6ICdpbmNsdWRlJyxcclxuICAgIH0pLnRoZW4oZnVuY3Rpb24gKHJlc3BvbnNlKSB7XHJcbiAgICAgIHJldHVybiByZXNwb25zZS5qc29uKCk7XHJcbiAgICB9KS50aGVuKGZ1bmN0aW9uIChyZXN1bHQpIHtcclxuICAgICAgcmV0dXJuIHJlc3VsdDtcclxuICAgIH0pO1xyXG4gIH1cclxuICBkYXRhQ2hhbmdlKGZpbHRlcmVkLCBjb2x1bW4pIHtcclxuICAgIGNvbnNvbGUubG9nKGZpbHRlcmVkKVxyXG4gICAgY29uc29sZS5sb2coY29sdW1uKVxyXG4gICAgLypcclxuICAgIHRoaXMuc2V0U3RhdGUoeyBsb2FkaW5nOiB0cnVlIH0pO1xyXG4gICAgdGhpcy5maWx0ZXJEYXRhKFxyXG4gICAgICBmaWx0ZXJlZFxyXG4gICAgKS50aGVuKHJlcyA9PiB7XHJcbiAgICAgIGNvbnNvbGUubG9nKHJlcylcclxuICAgICAgdGhpcy5zZXRTdGF0ZSh7XHJcbiAgICAgICAgb3JkZXJzOiByZXMsXHJcbiAgICAgICAgbG9hZGluZzogZmFsc2VcclxuICAgICAgfSlcclxuICAgIH0pLnRoZW4oKCkgPT4ge1xyXG4gICAgICBjb25zb2xlLmxvZyh0aGlzLnN0YXRlKVxyXG4gICAgfSlcclxuICAgICovXHJcbiAgfVxyXG4gIGZpbHRlckRhdGEoZmlsdGVyZWQpIHtcclxuICAgIHJldHVybiBuZXcgUHJvbWlzZSgocmVzb2x2ZSwgcmVqZWN0KSA9PiB7XHJcbiAgICAgIC8vIFlvdSBjYW4gcmV0cmlldmUgeW91ciBkYXRhIGhvd2V2ZXIgeW91IHdhbnQsIGluIHRoaXMgY2FzZSwgd2Ugd2lsbCBqdXN0IHVzZSBzb21lIGxvY2FsIGRhdGEuXHJcbiAgICAgIGxldCBmaWx0ZXJlZERhdGEgPSB0aGlzLnN0YXRlLmRlZmF1bHREYXRhO1xyXG4gIFxyXG4gICAgICAvLyBZb3UgY2FuIHVzZSB0aGUgZmlsdGVycyBpbiB5b3VyIHJlcXVlc3QsIGJ1dCB5b3UgYXJlIHJlc3BvbnNpYmxlIGZvciBhcHBseWluZyB0aGVtLlxyXG4gICAgICBpZiAoZmlsdGVyZWQubGVuZ3RoKSB7XHJcbiAgICAgICAgZmlsdGVyZWREYXRhID0gZmlsdGVyZWQucmVkdWNlKChmaWx0ZXJlZFNvRmFyLCBuZXh0RmlsdGVyKSA9PiB7XHJcbiAgICAgICAgICByZXR1cm4gZmlsdGVyZWRTb0Zhci5maWx0ZXIocm93ID0+IHtcclxuICAgICAgICAgICAgcmV0dXJuIChyb3dbbmV4dEZpbHRlci5pZF0gKyBcIlwiKS5pbmNsdWRlcyhuZXh0RmlsdGVyLnZhbHVlKTtcclxuICAgICAgICAgIH0pO1xyXG4gICAgICAgIH0sIGZpbHRlcmVkRGF0YSk7XHJcbiAgICAgIH1cclxuICAgICAgXHJcbiAgICAgIHNldFRpbWVvdXQoKCkgPT4gcmVzb2x2ZShmaWx0ZXJlZERhdGEpLCA1MDApO1xyXG4gICAgfSlcclxuXHJcbiAgfVxyXG4gIHVwZGF0ZURhdGEocGFnZVNpemUsIHBhZ2UsIHNvcnRlZCwgZmlsdGVyZWQpIHtcclxuICAgIHJldHVybiBuZXcgUHJvbWlzZSgocmVzb2x2ZSwgcmVqZWN0KSA9PiB7XHJcbiAgICAgIC8vIFlvdSBjYW4gcmV0cmlldmUgeW91ciBkYXRhIGhvd2V2ZXIgeW91IHdhbnQsIGluIHRoaXMgY2FzZSwgd2Ugd2lsbCBqdXN0IHVzZSBzb21lIGxvY2FsIGRhdGEuXHJcbiAgICAgIGxldCBmaWx0ZXJlZERhdGEgPSB0aGlzLnN0YXRlLmRlZmF1bHREYXRhO1xyXG4gIFxyXG4gICAgICAvLyBZb3UgY2FuIHVzZSB0aGUgZmlsdGVycyBpbiB5b3VyIHJlcXVlc3QsIGJ1dCB5b3UgYXJlIHJlc3BvbnNpYmxlIGZvciBhcHBseWluZyB0aGVtLlxyXG4gICAgICBpZiAoZmlsdGVyZWQubGVuZ3RoKSB7XHJcbiAgICAgICAgZmlsdGVyZWREYXRhID0gZmlsdGVyZWQucmVkdWNlKChmaWx0ZXJlZFNvRmFyLCBuZXh0RmlsdGVyKSA9PiB7XHJcbiAgICAgICAgICByZXR1cm4gZmlsdGVyZWRTb0Zhci5maWx0ZXIocm93ID0+IHtcclxuICAgICAgICAgICAgcmV0dXJuIChyb3dbbmV4dEZpbHRlci5pZF0gKyBcIlwiKS5pbmNsdWRlcyhuZXh0RmlsdGVyLnZhbHVlKTtcclxuICAgICAgICAgIH0pO1xyXG4gICAgICAgIH0sIGZpbHRlcmVkRGF0YSk7XHJcbiAgICAgIH1cclxuICAgICAgLy8gWW91IGNhbiBhbHNvIHVzZSB0aGUgc29ydGluZyBpbiB5b3VyIHJlcXVlc3QsIGJ1dCBhZ2FpbiwgeW91IGFyZSByZXNwb25zaWJsZSBmb3IgYXBwbHlpbmcgaXQuXHJcbiAgICAgIGNvbnN0IHNvcnRlZERhdGEgPSBfLm9yZGVyQnkoXHJcbiAgICAgICAgZmlsdGVyZWREYXRhLFxyXG4gICAgICAgIHNvcnRlZC5tYXAoc29ydCA9PiB7XHJcbiAgICAgICAgICByZXR1cm4gcm93ID0+IHtcclxuICAgICAgICAgICAgaWYgKHJvd1tzb3J0LmlkXSA9PT0gbnVsbCB8fCByb3dbc29ydC5pZF0gPT09IHVuZGVmaW5lZCkge1xyXG4gICAgICAgICAgICAgIHJldHVybiAtSW5maW5pdHk7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgcmV0dXJuIHR5cGVvZiByb3dbc29ydC5pZF0gPT09IFwic3RyaW5nXCJcclxuICAgICAgICAgICAgICA/IHJvd1tzb3J0LmlkXS50b0xvd2VyQ2FzZSgpXHJcbiAgICAgICAgICAgICAgOiByb3dbc29ydC5pZF07XHJcbiAgICAgICAgICB9O1xyXG4gICAgICAgIH0pLFxyXG4gICAgICAgIHNvcnRlZC5tYXAoZCA9PiAoZC5kZXNjID8gXCJkZXNjXCIgOiBcImFzY1wiKSlcclxuICAgICAgKTtcclxuICBcclxuICAgICAgLy8gWW91IG11c3QgcmV0dXJuIGFuIG9iamVjdCBjb250YWluaW5nIHRoZSByb3dzIG9mIHRoZSBjdXJyZW50IHBhZ2UsIGFuZCBvcHRpb25hbGx5IHRoZSB0b3RhbCBwYWdlcyBudW1iZXIuXHJcbiAgICAgIGNvbnN0IHJlcyA9IHtcclxuICAgICAgICByb3dzOiBzb3J0ZWREYXRhLnNsaWNlKHBhZ2VTaXplICogcGFnZSwgcGFnZVNpemUgKiBwYWdlICsgcGFnZVNpemUpLFxyXG4gICAgICAgIHBhZ2VzOiBNYXRoLmNlaWwoZmlsdGVyZWREYXRhLmxlbmd0aCAvIHBhZ2VTaXplKVxyXG4gICAgICB9O1xyXG4gIFxyXG4gICAgICAvLyBIZXJlIHdlJ2xsIHNpbXVsYXRlIGEgc2VydmVyIHJlc3BvbnNlIHdpdGggNTAwbXMgb2YgZGVsYXkuXHJcbiAgICAgIHNldFRpbWVvdXQoKCkgPT4gcmVzb2x2ZShyZXMpLCA1MDApO1xyXG4gICAgfSk7XHJcbiAgfVxyXG4gIHJlbmRlcigpIHtcclxuXHJcbiAgICBjb25zdCB7XHJcbiAgICAgIGxvYWRpbmcsXHJcbiAgICAgIGRlZmF1bHREYXRhLFxyXG4gICAgICBvcmRlcnMsXHJcbiAgICAgIHBhZ2VzLFxyXG4gICAgICBmaWx0ZXJlZFxyXG4gICAgfSA9IHRoaXMuc3RhdGU7XHJcblxyXG4gICAgdmFyIGNvbHVtbnMgPSBbXHJcbiAgICAgIHtcclxuICAgICAgICBIZWFkZXI6ICdPcmRlcnMnLFxyXG4gICAgICAgIGNvbHVtbnM6IFtcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnT3JkZXIgTnVtYmVyJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdPcmRlck51bWJlcicsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdTdGF0dXMnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ09yZGVyU3RhdHVzJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ0VtYWlsJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdDdXN0b21lckVtYWlsJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ05hbWUnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ0N1c3RvbWVyTmFtZScsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdDb3VudHJ5JyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdDdXN0b21lckNvdW50cnknLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnQ3JlYXRlZCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnQ3JlYXRlRGF0ZScsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdQYWlkJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdQYWlkRGF0ZScsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdUb3RhbCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnVG90YWxBbW91bnQnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICBdLFxyXG4gICAgICB9LFxyXG4gICAgXTtcclxuXHJcbiAgICByZXR1cm4gKFxyXG4gICAgICA8bWFpbj5cclxuICAgICAgICA8UmVhY3RUYWJsZVxyXG4gICAgICAgICAgICBkYXRhPXtvcmRlcnN9XHJcbiAgICAgICAgICAgIGZpbHRlcmFibGVcclxuICAgICAgICAgICAgcGFnZXM9e3BhZ2VzfVxyXG4gICAgICAgICAgICBjb2x1bW5zPXtjb2x1bW5zfVxyXG4gICAgICAgICAgICBmaWx0ZXJlZD17ZmlsdGVyZWR9XHJcbiAgICAgICAgICAgIG9uRmlsdGVyZWRDaGFuZ2U9e3RoaXMuZGF0YUNoYW5nZX1cclxuICAgICAgICAgICAgZGVmYXVsdFBhZ2VTaXplPXsyfVxyXG4gICAgICAgICAgICBsb2FkaW5nPXtsb2FkaW5nfVxyXG4gICAgICAgICAgICBjbGFzc05hbWU9XCItc3RyaXBlZCAtaGlnaGxpZ2h0XCJcclxuICAgICAgICAgIC8+XHJcbiAgICAgIDwvbWFpbj5cclxuICAgICk7XHJcbiAgfVxyXG59XHJcbiJdLCJzb3VyY2VSb290IjoiIn0=\n//# sourceURL=webpack-internal:///./src/components/orders/orders.js\n");

/***/ })

})