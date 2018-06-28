webpackHotUpdate("site",{

/***/ "./src/components/orders/orders.js":
/*!*****************************************!*\
  !*** ./src/components/orders/orders.js ***!
  \*****************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Orders; });\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react */ \"./node_modules/react/index.js\");\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! lodash */ \"./node_modules/lodash/lodash.js\");\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(lodash__WEBPACK_IMPORTED_MODULE_1__);\n/* harmony import */ var stores_orderStore__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! stores/orderStore */ \"./src/stores/orderStore.js\");\n/* harmony import */ var react_table__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! react-table */ \"./node_modules/react-table/es/index.js\");\nfunction _typeof(obj) { if (typeof Symbol === \"function\" && typeof Symbol.iterator === \"symbol\") { _typeof = function _typeof(obj) { return typeof obj; }; } else { _typeof = function _typeof(obj) { return obj && typeof Symbol === \"function\" && obj.constructor === Symbol && obj !== Symbol.prototype ? \"symbol\" : typeof obj; }; } return _typeof(obj); }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function\"); } _setPrototypeOf(subClass.prototype, superClass && superClass.prototype); if (superClass) _setPrototypeOf(subClass, superClass); }\n\nfunction _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }\n\nfunction _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }\n\nfunction _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }\n\nfunction _possibleConstructorReturn(self, call) { if (call && (_typeof(call) === \"object\" || typeof call === \"function\")) { return call; } return _assertThisInitialized(self); }\n\nfunction _getPrototypeOf(o) { _getPrototypeOf = Object.getPrototypeOf || function _getPrototypeOf(o) { return o.__proto__; }; return _getPrototypeOf(o); }\n\nfunction _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return self; }\n\n\n\n\n\n\nvar Orders =\n/*#__PURE__*/\nfunction (_Component) {\n  function Orders(props) {\n    var _this;\n\n    _classCallCheck(this, Orders);\n\n    _this = _possibleConstructorReturn(this, _getPrototypeOf(Orders).call(this, props));\n    _this.state = {\n      defaultData: [],\n      orders: [],\n      pages: null,\n      loading: true,\n      filtered: []\n    };\n    _this.dataChange = _this.dataChange.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    _this.updateData = _this.updateData.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    _this.filterData = _this.filterData.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    return _this;\n  }\n\n  _createClass(Orders, [{\n    key: \"componentDidMount\",\n    value: function componentDidMount() {\n      var _this2 = this;\n\n      this.getOrders().then(function (orders) {\n        _this2.setState({\n          defaultData: orders,\n          orders: orders,\n          loading: false\n        });\n      });\n    }\n  }, {\n    key: \"getOrders\",\n    value: function getOrders() {\n      return fetch('/umbraco/backoffice/ekom/managerapi/getorders', {\n        credentials: 'include'\n      }).then(function (response) {\n        return response.json();\n      }).then(function (result) {\n        return result;\n      });\n    }\n  }, {\n    key: \"dataChange\",\n    value: function dataChange(filtered, column) {\n      console.log(filtered);\n      this.setState({\n        filtered: filtered\n      });\n      /*\r\n      this.setState({ loading: true });\r\n      this.filterData(\r\n        filtered\r\n      ).then(res => {\r\n        console.log(res)\r\n        this.setState({\r\n          orders: res,\r\n          loading: false\r\n        })\r\n      }).then(() => {\r\n        console.log(this.state)\r\n      })\r\n      */\n    }\n  }, {\n    key: \"filterData\",\n    value: function filterData(filtered) {\n      var _this3 = this;\n\n      return new Promise(function (resolve, reject) {\n        // You can retrieve your data however you want, in this case, we will just use some local data.\n        var filteredData = _this3.state.defaultData; // You can use the filters in your request, but you are responsible for applying them.\n\n        if (filtered.length) {\n          filteredData = filtered.reduce(function (filteredSoFar, nextFilter) {\n            return filteredSoFar.filter(function (row) {\n              return (row[nextFilter.id] + \"\").includes(nextFilter.value);\n            });\n          }, filteredData);\n        }\n\n        setTimeout(function () {\n          return resolve(filteredData);\n        }, 500);\n      });\n    }\n  }, {\n    key: \"updateData\",\n    value: function updateData(pageSize, page, sorted, filtered) {\n      var _this4 = this;\n\n      return new Promise(function (resolve, reject) {\n        // You can retrieve your data however you want, in this case, we will just use some local data.\n        var filteredData = _this4.state.defaultData; // You can use the filters in your request, but you are responsible for applying them.\n\n        if (filtered.length) {\n          filteredData = filtered.reduce(function (filteredSoFar, nextFilter) {\n            return filteredSoFar.filter(function (row) {\n              return (row[nextFilter.id] + \"\").includes(nextFilter.value);\n            });\n          }, filteredData);\n        } // You can also use the sorting in your request, but again, you are responsible for applying it.\n\n\n        var sortedData = lodash__WEBPACK_IMPORTED_MODULE_1___default.a.orderBy(filteredData, sorted.map(function (sort) {\n          return function (row) {\n            if (row[sort.id] === null || row[sort.id] === undefined) {\n              return -Infinity;\n            }\n\n            return typeof row[sort.id] === \"string\" ? row[sort.id].toLowerCase() : row[sort.id];\n          };\n        }), sorted.map(function (d) {\n          return d.desc ? \"desc\" : \"asc\";\n        })); // You must return an object containing the rows of the current page, and optionally the total pages number.\n\n\n        var res = {\n          rows: sortedData.slice(pageSize * page, pageSize * page + pageSize),\n          pages: Math.ceil(filteredData.length / pageSize)\n        }; // Here we'll simulate a server response with 500ms of delay.\n\n        setTimeout(function () {\n          return resolve(res);\n        }, 500);\n      });\n    }\n  }, {\n    key: \"render\",\n    value: function render() {\n      var _this$state = this.state,\n          loading = _this$state.loading,\n          defaultData = _this$state.defaultData,\n          orders = _this$state.orders,\n          pages = _this$state.pages,\n          filtered = _this$state.filtered;\n      var columns = [{\n        Header: 'Orders',\n        columns: [{\n          Header: 'Order Number',\n          accessor: 'OrderNumber'\n        }, {\n          Header: 'Status',\n          accessor: 'OrderStatus'\n        }, {\n          Header: 'Email',\n          accessor: 'CustomerEmail'\n        }, {\n          Header: 'Name',\n          accessor: 'CustomerName'\n        }, {\n          Header: 'Country',\n          accessor: 'CustomerCountry'\n        }, {\n          Header: 'Created',\n          accessor: 'CreateDate'\n        }, {\n          Header: 'Paid',\n          accessor: 'PaidDate'\n        }, {\n          Header: 'Total',\n          accessor: 'TotalAmount'\n        }]\n      }];\n      return react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"main\", null, react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react_table__WEBPACK_IMPORTED_MODULE_3__[\"default\"], {\n        data: orders,\n        filterable: true,\n        pages: pages,\n        columns: columns,\n        onFilteredChange: this.dataChange,\n        defaultPageSize: 2,\n        loading: loading,\n        className: \"-striped -highlight\"\n      }));\n    }\n  }]);\n\n  _inherits(Orders, _Component);\n\n  return Orders;\n}(react__WEBPACK_IMPORTED_MODULE_0__[\"Component\"]);\n\n//# sourceURL=[module]\n//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vLi9zcmMvY29tcG9uZW50cy9vcmRlcnMvb3JkZXJzLmpzPzA5OGYiXSwibmFtZXMiOlsiT3JkZXJzIiwicHJvcHMiLCJzdGF0ZSIsImRlZmF1bHREYXRhIiwib3JkZXJzIiwicGFnZXMiLCJsb2FkaW5nIiwiZmlsdGVyZWQiLCJkYXRhQ2hhbmdlIiwiYmluZCIsInVwZGF0ZURhdGEiLCJmaWx0ZXJEYXRhIiwiZ2V0T3JkZXJzIiwidGhlbiIsInNldFN0YXRlIiwiZmV0Y2giLCJjcmVkZW50aWFscyIsInJlc3BvbnNlIiwianNvbiIsInJlc3VsdCIsImNvbHVtbiIsImNvbnNvbGUiLCJsb2ciLCJQcm9taXNlIiwicmVzb2x2ZSIsInJlamVjdCIsImZpbHRlcmVkRGF0YSIsImxlbmd0aCIsInJlZHVjZSIsImZpbHRlcmVkU29GYXIiLCJuZXh0RmlsdGVyIiwiZmlsdGVyIiwicm93IiwiaWQiLCJpbmNsdWRlcyIsInZhbHVlIiwic2V0VGltZW91dCIsInBhZ2VTaXplIiwicGFnZSIsInNvcnRlZCIsInNvcnRlZERhdGEiLCJfIiwib3JkZXJCeSIsIm1hcCIsInNvcnQiLCJ1bmRlZmluZWQiLCJJbmZpbml0eSIsInRvTG93ZXJDYXNlIiwiZCIsImRlc2MiLCJyZXMiLCJyb3dzIiwic2xpY2UiLCJNYXRoIiwiY2VpbCIsImNvbHVtbnMiLCJIZWFkZXIiLCJhY2Nlc3NvciJdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7QUFBQTtBQUNBO0FBQ0E7QUFDQTs7SUFFcUJBLE07OztBQUVuQixrQkFBWUMsS0FBWixFQUFtQjtBQUFBOztBQUFBOztBQUNqQixnRkFBTUEsS0FBTjtBQUVBLFVBQUtDLEtBQUwsR0FBYTtBQUNYQyxtQkFBYSxFQURGO0FBRVhDLGNBQVEsRUFGRztBQUdYQyxhQUFPLElBSEk7QUFJWEMsZUFBUyxJQUpFO0FBS1hDLGdCQUFVO0FBTEMsS0FBYjtBQU9BLFVBQUtDLFVBQUwsR0FBa0IsTUFBS0EsVUFB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QUNFRCxrQkFBUSxTQURWO0FBRUVDLG9CQUFVO0FBRlosU0FyQk8sRUF5QlA7QUFDRUQsa0JBQVEsTUFEVjtBQUVFQyxvQkFBVTtBQUZaLFNBekJPLEVBNkJQO0FBQ0VELGtCQUFRLE9BRFY7QUFFRUMsb0JBQVU7QUFGWixTQTdCTztBQUZYLE9BRFksQ0FBZDtBQXdDQSxhQUNFLHlFQUNFLDJEQUFDLG1EQUFEO0FBQ0ksY0FBTXJELE1BRFY7QUFFSSx3QkFGSjtBQUdJLGVBQU9DLEtBSFg7QUFJSSxpQkFBU2tELE9BSmI7QUFLSSwwQkFBa0IsS0FBSy9DLFVBTDNCO0FBTUkseUJBQWlCLENBTnJCO0FBT0ksaUJBQVNGLE9BUGI7QUFRSSxtQkFBVTtBQVJkLFFBREYsQ0FERjtBQWNEOzs7Ozs7RUFyTGlDLCtDIiwiZmlsZSI6Ii4vc3JjL2NvbXBvbmVudHMvb3JkZXJzL29yZGVycy5qcy5qcyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCBSZWFjdCwgeyBDb21wb25lbnQgfSBmcm9tICdyZWFjdCc7XHJcbmltcG9ydCBfIGZyb20gXCJsb2Rhc2hcIjtcclxuaW1wb3J0IG9yZGVyU3RvcmUgZnJvbSAnc3RvcmVzL29yZGVyU3RvcmUnO1xyXG5pbXBvcnQgUmVhY3RUYWJsZSBmcm9tICdyZWFjdC10YWJsZSc7XHJcblxyXG5leHBvcnQgZGVmYXVsdCBjbGFzcyBPcmRlcnMgZXh0ZW5kcyBDb21wb25lbnQge1xyXG5cclxuICBjb25zdHJ1Y3Rvcihwcm9wcykge1xyXG4gICAgc3VwZXIocHJvcHMpO1xyXG5cclxuICAgIHRoaXMuc3RhdGUgPSB7XHJcbiAgICAgIGRlZmF1bHREYXRhOiBbXSxcclxuICAgICAgb3JkZXJzOiBbXSxcclxuICAgICAgcGFnZXM6IG51bGwsXHJcbiAgICAgIGxvYWRpbmc6IHRydWUsXHJcbiAgICAgIGZpbHRlcmVkOiBbXSxcclxuICAgIH1cclxuICAgIHRoaXMuZGF0YUNoYW5nZSA9IHRoaXMuZGF0YUNoYW5nZS5iaW5kKHRoaXMpO1xyXG4gICAgdGhpcy51cGRhdGVEYXRhID0gdGhpcy51cGRhdGVEYXRhLmJpbmQodGhpcyk7XHJcbiAgICB0aGlzLmZpbHRlckRhdGEgPSB0aGlzLmZpbHRlckRhdGEuYmluZCh0aGlzKTtcclxuICB9ICBcclxuXHJcbiAgY29tcG9uZW50RGlkTW91bnQoKSB7XHJcblxyXG4gICAgdGhpcy5nZXRPcmRlcnMoKS50aGVuKChvcmRlcnMpID0+IHtcclxuXHJcblxyXG4gICAgICB0aGlzLnNldFN0YXRlKHtcclxuICAgICAgICBkZWZhdWx0RGF0YTogb3JkZXJzLFxyXG4gICAgICAgIG9yZGVyczogb3JkZXJzLFxyXG4gICAgICAgIGxvYWRpbmc6IGZhbHNlLFxyXG4gICAgICB9KTtcclxuXHJcbiAgICB9KTtcclxuICB9XHJcblxyXG4gIGdldE9yZGVycygpIHtcclxuICAgIHJldHVybiBmZXRjaCgnL3VtYnJhY28vYmFja29mZmljZS9la29tL21hbmFnZXJhcGkvZ2V0b3JkZXJzJywge1xyXG4gICAgICBjcmVkZW50aWFsczogJ2luY2x1ZGUnLFxyXG4gICAgfSkudGhlbihmdW5jdGlvbiAocmVzcG9uc2UpIHtcclxuICAgICAgcmV0dXJuIHJlc3BvbnNlLmpzb24oKTtcclxuICAgIH0pLnRoZW4oZnVuY3Rpb24gKHJlc3VsdCkge1xyXG4gICAgICByZXR1cm4gcmVzdWx0O1xyXG4gICAgfSk7XHJcbiAgfVxyXG4gIGRhdGFDaGFuZ2UoZmlsdGVyZWQsIGNvbHVtbikge1xyXG4gICAgY29uc29sZS5sb2coZmlsdGVyZWQpXHJcbiAgICB0aGlzLnNldFN0YXRlKHtcclxuICAgICAgZmlsdGVyZWQ6IGZpbHRlcmVkXHJcbiAgICB9KVxyXG4gICAgLypcclxuICAgIHRoaXMuc2V0U3RhdGUoeyBsb2FkaW5nOiB0cnVlIH0pO1xyXG4gICAgdGhpcy5maWx0ZXJEYXRhKFxyXG4gICAgICBmaWx0ZXJlZFxyXG4gICAgKS50aGVuKHJlcyA9PiB7XHJcbiAgICAgIGNvbnNvbGUubG9nKHJlcylcclxuICAgICAgdGhpcy5zZXRTdGF0ZSh7XHJcbiAgICAgICAgb3JkZXJzOiByZXMsXHJcbiAgICAgICAgbG9hZGluZzogZmFsc2VcclxuICAgICAgfSlcclxuICAgIH0pLnRoZW4oKCkgPT4ge1xyXG4gICAgICBjb25zb2xlLmxvZyh0aGlzLnN0YXRlKVxyXG4gICAgfSlcclxuICAgICovXHJcbiAgfVxyXG4gIGZpbHRlckRhdGEoZmlsdGVyZWQpIHtcclxuICAgIHJldHVybiBuZXcgUHJvbWlzZSgocmVzb2x2ZSwgcmVqZWN0KSA9PiB7XHJcbiAgICAgIC8vIFlvdSBjYW4gcmV0cmlldmUgeW91ciBkYXRhIGhvd2V2ZXIgeW91IHdhbnQsIGluIHRoaXMgY2FzZSwgd2Ugd2lsbCBqdXN0IHVzZSBzb21lIGxvY2FsIGRhdGEuXHJcbiAgICAgIGxldCBmaWx0ZXJlZERhdGEgPSB0aGlzLnN0YXRlLmRlZmF1bHREYXRhO1xyXG4gIFxyXG4gICAgICAvLyBZb3UgY2FuIHVzZSB0aGUgZmlsdGVycyBpbiB5b3VyIHJlcXVlc3QsIGJ1dCB5b3UgYXJlIHJlc3BvbnNpYmxlIGZvciBhcHBseWluZyB0aGVtLlxyXG4gICAgICBpZiAoZmlsdGVyZWQubGVuZ3RoKSB7XHJcbiAgICAgICAgZmlsdGVyZWREYXRhID0gZmlsdGVyZWQucmVkdWNlKChmaWx0ZXJlZFNvRmFyLCBuZXh0RmlsdGVyKSA9PiB7XHJcbiAgICAgICAgICByZXR1cm4gZmlsdGVyZWRTb0Zhci5maWx0ZXIocm93ID0+IHtcclxuICAgICAgICAgICAgcmV0dXJuIChyb3dbbmV4dEZpbHRlci5pZF0gKyBcIlwiKS5pbmNsdWRlcyhuZXh0RmlsdGVyLnZhbHVlKTtcclxuICAgICAgICAgIH0pO1xyXG4gICAgICAgIH0sIGZpbHRlcmVkRGF0YSk7XHJcbiAgICAgIH1cclxuICAgICAgXHJcbiAgICAgIHNldFRpbWVvdXQoKCkgPT4gcmVzb2x2ZShmaWx0ZXJlZERhdGEpLCA1MDApO1xyXG4gICAgfSlcclxuXHJcbiAgfVxyXG4gIHVwZGF0ZURhdGEocGFnZVNpemUsIHBhZ2UsIHNvcnRlZCwgZmlsdGVyZWQpIHtcclxuICAgIHJldHVybiBuZXcgUHJvbWlzZSgocmVzb2x2ZSwgcmVqZWN0KSA9PiB7XHJcbiAgICAgIC8vIFlvdSBjYW4gcmV0cmlldmUgeW91ciBkYXRhIGhvd2V2ZXIgeW91IHdhbnQsIGluIHRoaXMgY2FzZSwgd2Ugd2lsbCBqdXN0IHVzZSBzb21lIGxvY2FsIGRhdGEuXHJcbiAgICAgIGxldCBmaWx0ZXJlZERhdGEgPSB0aGlzLnN0YXRlLmRlZmF1bHREYXRhO1xyXG4gIFxyXG4gICAgICAvLyBZb3UgY2FuIHVzZSB0aGUgZmlsdGVycyBpbiB5b3VyIHJlcXVlc3QsIGJ1dCB5b3UgYXJlIHJlc3BvbnNpYmxlIGZvciBhcHBseWluZyB0aGVtLlxyXG4gICAgICBpZiAoZmlsdGVyZWQubGVuZ3RoKSB7XHJcbiAgICAgICAgZmlsdGVyZWREYXRhID0gZmlsdGVyZWQucmVkdWNlKChmaWx0ZXJlZFNvRmFyLCBuZXh0RmlsdGVyKSA9PiB7XHJcbiAgICAgICAgICByZXR1cm4gZmlsdGVyZWRTb0Zhci5maWx0ZXIocm93ID0+IHtcclxuICAgICAgICAgICAgcmV0dXJuIChyb3dbbmV4dEZpbHRlci5pZF0gKyBcIlwiKS5pbmNsdWRlcyhuZXh0RmlsdGVyLnZhbHVlKTtcclxuICAgICAgICAgIH0pO1xyXG4gICAgICAgIH0sIGZpbHRlcmVkRGF0YSk7XHJcbiAgICAgIH1cclxuICAgICAgLy8gWW91IGNhbiBhbHNvIHVzZSB0aGUgc29ydGluZyBpbiB5b3VyIHJlcXVlc3QsIGJ1dCBhZ2FpbiwgeW91IGFyZSByZXNwb25zaWJsZSBmb3IgYXBwbHlpbmcgaXQuXHJcbiAgICAgIGNvbnN0IHNvcnRlZERhdGEgPSBfLm9yZGVyQnkoXHJcbiAgICAgICAgZmlsdGVyZWREYXRhLFxyXG4gICAgICAgIHNvcnRlZC5tYXAoc29ydCA9PiB7XHJcbiAgICAgICAgICByZXR1cm4gcm93ID0+IHtcclxuICAgICAgICAgICAgaWYgKHJvd1tzb3J0LmlkXSA9PT0gbnVsbCB8fCByb3dbc29ydC5pZF0gPT09IHVuZGVmaW5lZCkge1xyXG4gICAgICAgICAgICAgIHJldHVybiAtSW5maW5pdHk7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgcmV0dXJuIHR5cGVvZiByb3dbc29ydC5pZF0gPT09IFwic3RyaW5nXCJcclxuICAgICAgICAgICAgICA/IHJvd1tzb3J0LmlkXS50b0xvd2VyQ2FzZSgpXHJcbiAgICAgICAgICAgICAgOiByb3dbc29ydC5pZF07XHJcbiAgICAgICAgICB9O1xyXG4gICAgICAgIH0pLFxyXG4gICAgICAgIHNvcnRlZC5tYXAoZCA9PiAoZC5kZXNjID8gXCJkZXNjXCIgOiBcImFzY1wiKSlcclxuICAgICAgKTtcclxuICBcclxuICAgICAgLy8gWW91IG11c3QgcmV0dXJuIGFuIG9iamVjdCBjb250YWluaW5nIHRoZSByb3dzIG9mIHRoZSBjdXJyZW50IHBhZ2UsIGFuZCBvcHRpb25hbGx5IHRoZSB0b3RhbCBwYWdlcyBudW1iZXIuXHJcbiAgICAgIGNvbnN0IHJlcyA9IHtcclxuICAgICAgICByb3dzOiBzb3J0ZWREYXRhLnNsaWNlKHBhZ2VTaXplICogcGFnZSwgcGFnZVNpemUgKiBwYWdlICsgcGFnZVNpemUpLFxyXG4gICAgICAgIHBhZ2VzOiBNYXRoLmNlaWwoZmlsdGVyZWREYXRhLmxlbmd0aCAvIHBhZ2VTaXplKVxyXG4gICAgICB9O1xyXG4gIFxyXG4gICAgICAvLyBIZXJlIHdlJ2xsIHNpbXVsYXRlIGEgc2VydmVyIHJlc3BvbnNlIHdpdGggNTAwbXMgb2YgZGVsYXkuXHJcbiAgICAgIHNldFRpbWVvdXQoKCkgPT4gcmVzb2x2ZShyZXMpLCA1MDApO1xyXG4gICAgfSk7XHJcbiAgfVxyXG4gIHJlbmRlcigpIHtcclxuXHJcbiAgICBjb25zdCB7XHJcbiAgICAgIGxvYWRpbmcsXHJcbiAgICAgIGRlZmF1bHREYXRhLFxyXG4gICAgICBvcmRlcnMsXHJcbiAgICAgIHBhZ2VzLFxyXG4gICAgICBmaWx0ZXJlZFxyXG4gICAgfSA9IHRoaXMuc3RhdGU7XHJcblxyXG4gICAgdmFyIGNvbHVtbnMgPSBbXHJcbiAgICAgIHtcclxuICAgICAgICBIZWFkZXI6ICdPcmRlcnMnLFxyXG4gICAgICAgIGNvbHVtbnM6IFtcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnT3JkZXIgTnVtYmVyJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdPcmRlck51bWJlcicsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdTdGF0dXMnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ09yZGVyU3RhdHVzJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ0VtYWlsJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdDdXN0b21lckVtYWlsJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ05hbWUnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ0N1c3RvbWVyTmFtZScsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdDb3VudHJ5JyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdDdXN0b21lckNvdW50cnknLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnQ3JlYXRlZCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnQ3JlYXRlRGF0ZScsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdQYWlkJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdQYWlkRGF0ZScsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdUb3RhbCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnVG90YWxBbW91bnQnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICBdLFxyXG4gICAgICB9LFxyXG4gICAgXTtcclxuXHJcbiAgICByZXR1cm4gKFxyXG4gICAgICA8bWFpbj5cclxuICAgICAgICA8UmVhY3RUYWJsZVxyXG4gICAgICAgICAgICBkYXRhPXtvcmRlcnN9XHJcbiAgICAgICAgICAgIGZpbHRlcmFibGVcclxuICAgICAgICAgICAgcGFnZXM9e3BhZ2VzfVxyXG4gICAgICAgICAgICBjb2x1bW5zPXtjb2x1bW5zfVxyXG4gICAgICAgICAgICBvbkZpbHRlcmVkQ2hhbmdlPXt0aGlzLmRhdGFDaGFuZ2V9XHJcbiAgICAgICAgICAgIGRlZmF1bHRQYWdlU2l6ZT17Mn1cclxuICAgICAgICAgICAgbG9hZGluZz17bG9hZGluZ31cclxuICAgICAgICAgICAgY2xhc3NOYW1lPVwiLXN0cmlwZWQgLWhpZ2hsaWdodFwiXHJcbiAgICAgICAgICAvPlxyXG4gICAgICA8L21haW4+XHJcbiAgICApO1xyXG4gIH1cclxufVxyXG4iXSwic291cmNlUm9vdCI6IiJ9\n//# sourceURL=webpack-internal:///./src/components/orders/orders.js\n");

/***/ })

})