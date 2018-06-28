webpackHotUpdate("site",{

/***/ "./src/components/orders/orders.js":
/*!*****************************************!*\
  !*** ./src/components/orders/orders.js ***!
  \*****************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Orders; });\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react */ \"./node_modules/react/index.js\");\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! lodash */ \"./node_modules/lodash/lodash.js\");\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(lodash__WEBPACK_IMPORTED_MODULE_1__);\n/* harmony import */ var stores_orderStore__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! stores/orderStore */ \"./src/stores/orderStore.js\");\n/* harmony import */ var react_table__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! react-table */ \"./node_modules/react-table/es/index.js\");\nfunction _typeof(obj) { if (typeof Symbol === \"function\" && typeof Symbol.iterator === \"symbol\") { _typeof = function _typeof(obj) { return typeof obj; }; } else { _typeof = function _typeof(obj) { return obj && typeof Symbol === \"function\" && obj.constructor === Symbol && obj !== Symbol.prototype ? \"symbol\" : typeof obj; }; } return _typeof(obj); }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function\"); } _setPrototypeOf(subClass.prototype, superClass && superClass.prototype); if (superClass) _setPrototypeOf(subClass, superClass); }\n\nfunction _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }\n\nfunction _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }\n\nfunction _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }\n\nfunction _possibleConstructorReturn(self, call) { if (call && (_typeof(call) === \"object\" || typeof call === \"function\")) { return call; } return _assertThisInitialized(self); }\n\nfunction _getPrototypeOf(o) { _getPrototypeOf = Object.getPrototypeOf || function _getPrototypeOf(o) { return o.__proto__; }; return _getPrototypeOf(o); }\n\nfunction _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return self; }\n\n\n\n\n\n\nvar Orders =\n/*#__PURE__*/\nfunction (_Component) {\n  function Orders(props) {\n    var _this;\n\n    _classCallCheck(this, Orders);\n\n    _this = _possibleConstructorReturn(this, _getPrototypeOf(Orders).call(this, props));\n    _this.state = {\n      orders: [],\n      pages: null,\n      loading: true\n    };\n    _this.dataChange = _this.dataChange.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    _this.updateData = _this.updateData.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    return _this;\n  }\n\n  _createClass(Orders, [{\n    key: \"componentDidMount\",\n    value: function componentDidMount() {\n      var _this2 = this;\n\n      this.getOrders().then(function (orders) {\n        console.log(orders);\n\n        _this2.setState({\n          orders: orders,\n          loading: false\n        });\n      });\n    }\n  }, {\n    key: \"getOrders\",\n    value: function getOrders() {\n      return fetch('/umbraco/backoffice/ekom/managerapi/getorders', {\n        credentials: 'include'\n      }).then(function (response) {\n        return response.json();\n      }).then(function (result) {\n        return result;\n      });\n    }\n  }, {\n    key: \"dataChange\",\n    value: function dataChange(state, instance) {\n      var _this3 = this;\n\n      this.setState({\n        loading: false\n      });\n      console.log(state);\n      this.updateData(state.pageSize, state.page, state.sorted, state.filtered).then(function (res) {\n        console.log(res);\n\n        _this3.setState({\n          orders: res.rows,\n          pages: res.pages\n        });\n      });\n    }\n  }, {\n    key: \"updateData\",\n    value: function updateData(pageSize, page, sorted, filtered) {\n      var _this4 = this;\n\n      return new Promise(function (resolve, reject) {\n        // You can retrieve your data however you want, in this case, we will just use some local data.\n        var filteredData = _this4.state.orders; // You can use the filters in your request, but you are responsible for applying them.\n\n        if (filtered.length) {\n          filteredData = filtered.reduce(function (filteredSoFar, nextFilter) {\n            return filteredSoFar.filter(function (row) {\n              return (row[nextFilter.id] + \"\").includes(nextFilter.value);\n            });\n          }, filteredData);\n        } // You can also use the sorting in your request, but again, you are responsible for applying it.\n\n\n        var sortedData = lodash__WEBPACK_IMPORTED_MODULE_1___default.a.orderBy(filteredData, sorted.map(function (sort) {\n          return function (row) {\n            if (row[sort.id] === null || row[sort.id] === undefined) {\n              return -Infinity;\n            }\n\n            return typeof row[sort.id] === \"string\" ? row[sort.id].toLowerCase() : row[sort.id];\n          };\n        }), sorted.map(function (d) {\n          return d.desc ? \"desc\" : \"asc\";\n        })); // You must return an object containing the rows of the current page, and optionally the total pages number.\n\n\n        var res = {\n          rows: sortedData.slice(pageSize * page, pageSize * page + pageSize),\n          pages: Math.ceil(filteredData.length / pageSize)\n        }; // Here we'll simulate a server response with 500ms of delay.\n\n        setTimeout(function () {\n          return resolve(res);\n        }, 500);\n      });\n    }\n  }, {\n    key: \"render\",\n    value: function render() {\n      var _this$state = this.state,\n          loading = _this$state.loading,\n          orders = _this$state.orders,\n          pages = _this$state.pages;\n      var columns = [{\n        Header: 'Orders',\n        columns: [{\n          Header: 'Order Number',\n          accessor: 'OrderNumber'\n        }, {\n          Header: 'Status',\n          accessor: 'OrderStatus'\n        }, {\n          Header: 'Email',\n          accessor: 'CustomerEmail'\n        }, {\n          Header: 'Name',\n          accessor: 'CustomerName'\n        }, {\n          Header: 'Country',\n          accessor: 'CustomerCountry'\n        }, {\n          Header: 'Created',\n          accessor: 'CreateDate'\n        }, {\n          Header: 'Paid',\n          accessor: 'PaidDate'\n        }, {\n          Header: 'Total',\n          accessor: 'TotalAmount'\n        }]\n      }];\n      return react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"main\", null, react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react_table__WEBPACK_IMPORTED_MODULE_3__[\"default\"], {\n        data: orders,\n        filterable: true,\n        pages: pages,\n        columns: columns,\n        onFetchData: this.dataChange,\n        defaultPageSize: 2,\n        loading: loading,\n        className: \"-striped -highlight\"\n      }));\n    }\n  }]);\n\n  _inherits(Orders, _Component);\n\n  return Orders;\n}(react__WEBPACK_IMPORTED_MODULE_0__[\"Component\"]);\n\n//# sourceURL=[module]\n//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vLi9zcmMvY29tcG9uZW50cy9vcmRlcnMvb3JkZXJzLmpzPzA5OGYiXSwibmFtZXMiOlsiT3JkZXJzIiwicHJvcHMiLCJzdGF0ZSIsIm9yZGVycyIsInBhZ2VzIiwibG9hZGluZyIsImRhdGFDaGFuZ2UiLCJiaW5kIiwidXBkYXRlRGF0YSIsImdldE9yZGVycyIsInRoZW4iLCJjb25zb2xlIiwibG9nIiwic2V0U3RhdGUiLCJmZXRjaCIsImNyZWRlbnRpYWxzIiwicmVzcG9uc2UiLCJqc29uIiwicmVzdWx0IiwiaW5zdGFuY2UiLCJwYWdlU2l6ZSIsInBhZ2UiLCJzb3J0ZWQiLCJmaWx0ZXJlZCIsInJlcyIsInJvd3MiLCJQcm9taXNlIiwicmVzb2x2ZSIsInJlamVjdCIsImZpbHRlcmVkRGF0YSIsImxlbmd0aCIsInJlZHVjZSIsImZpbHRlcmVkU29GYXIiLCJuZXh0RmlsdGVyIiwiZmlsdGVyIiwicm93IiwiaWQiLCJpbmNsdWRlcyIsInZhbHVlIiwic29ydGVkRGF0YSIsIl8iLCJvcmRlckJ5IiwibWFwIiwic29ydCIsInVuZGVmaW5lZCIsIkluZmluaXR5IiwidG9Mb3dlckNhc2UiLCJkIiwiZGVzYyIsInNsaWNlIiwiTWF0aCIsImNlaWwiLCJzZXRUaW1lb3V0IiwiY29sdW1ucyIsIkhlYWRlciIsImFjY2Vzc29yIl0sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7OztBQUFBO0FBQ0E7QUFDQTtBQUNBOztJQUVxQkEsTTs7O0FBRW5CLGtCQUFZQyxLQUFaLEVBQW1CO0FBQUE7O0FBQUE7O0FBQ2pCLGdGQUFNQSxLQUFOO0FBRUEsVUFBS0MsS0FBTCxHQUFhO0FBQ1hDLGNBQVEsRUFERztBQUVYQyxhQUFPLElBRkk7QUFHWEMsZUFBUztBQUhFLEtBQWI7QUFLQSxVQUFLQyxVQUFMLEdBQWtCLE1BQUtBLFVBQUwsQ0FBZ0JDLElBQWhCLHVEQUFsQjtBQUNBLFVBQUtDLFVBQUwsR0FBa0IsTUFBS0EsVUFBTCxDQUFn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cnQgUmVhY3QsIHsgQ29tcG9uZW50IH0gZnJvbSAncmVhY3QnO1xyXG5pbXBvcnQgXyBmcm9tIFwibG9kYXNoXCI7XHJcbmltcG9ydCBvcmRlclN0b3JlIGZyb20gJ3N0b3Jlcy9vcmRlclN0b3JlJztcclxuaW1wb3J0IFJlYWN0VGFibGUgZnJvbSAncmVhY3QtdGFibGUnO1xyXG5cclxuZXhwb3J0IGRlZmF1bHQgY2xhc3MgT3JkZXJzIGV4dGVuZHMgQ29tcG9uZW50IHtcclxuXHJcbiAgY29uc3RydWN0b3IocHJvcHMpIHtcclxuICAgIHN1cGVyKHByb3BzKTtcclxuXHJcbiAgICB0aGlzLnN0YXRlID0ge1xyXG4gICAgICBvcmRlcnM6IFtdLFxyXG4gICAgICBwYWdlczogbnVsbCxcclxuICAgICAgbG9hZGluZzogdHJ1ZSxcclxuICAgIH1cclxuICAgIHRoaXMuZGF0YUNoYW5nZSA9IHRoaXMuZGF0YUNoYW5nZS5iaW5kKHRoaXMpO1xyXG4gICAgdGhpcy51cGRhdGVEYXRhID0gdGhpcy51cGRhdGVEYXRhLmJpbmQodGhpcyk7XHJcbiAgfSAgXHJcblxyXG4gIGNvbXBvbmVudERpZE1vdW50KCkge1xyXG5cclxuICAgIHRoaXMuZ2V0T3JkZXJzKCkudGhlbigob3JkZXJzKSA9PiB7XHJcblxyXG4gICAgICBjb25zb2xlLmxvZyhvcmRlcnMpO1xyXG5cclxuICAgICAgdGhpcy5zZXRTdGF0ZSh7XHJcbiAgICAgICAgb3JkZXJzOiBvcmRlcnMsXHJcbiAgICAgICAgbG9hZGluZzogZmFsc2UsXHJcbiAgICAgIH0pO1xyXG5cclxuICAgIH0pO1xyXG4gIH1cclxuXHJcbiAgZ2V0T3JkZXJzKCkge1xyXG4gICAgcmV0dXJuIGZldGNoKCcvdW1icmFjby9iYWNrb2ZmaWNlL2Vrb20vbWFuYWdlcmFwaS9nZXRvcmRlcnMnLCB7XHJcbiAgICAgIGNyZWRlbnRpYWxzOiAnaW5jbHVkZScsXHJcbiAgICB9KS50aGVuKGZ1bmN0aW9uIChyZXNwb25zZSkge1xyXG4gICAgICByZXR1cm4gcmVzcG9uc2UuanNvbigpO1xyXG4gICAgfSkudGhlbihmdW5jdGlvbiAocmVzdWx0KSB7XHJcbiAgICAgIHJldHVybiByZXN1bHQ7XHJcbiAgICB9KTtcclxuICB9XHJcbiAgZGF0YUNoYW5nZShzdGF0ZSwgaW5zdGFuY2UpIHtcclxuICAgIHRoaXMuc2V0U3RhdGUoeyBsb2FkaW5nOiBmYWxzZSB9KTtcclxuICAgIGNvbnNvbGUubG9nKHN0YXRlKVxyXG4gICAgdGhpcy51cGRhdGVEYXRhKFxyXG4gICAgICBzdGF0ZS5wYWdlU2l6ZSxcclxuICAgICAgc3RhdGUucGFnZSxcclxuICAgICAgc3RhdGUuc29ydGVkLFxyXG4gICAgICBzdGF0ZS5maWx0ZXJlZFxyXG4gICAgKS50aGVuKHJlcyA9PiB7XHJcbiAgICAgIGNvbnNvbGUubG9nKHJlcylcclxuICAgICAgdGhpcy5zZXRTdGF0ZSh7XHJcbiAgICAgICAgb3JkZXJzOiByZXMucm93cyxcclxuICAgICAgICBwYWdlczogcmVzLnBhZ2VzLFxyXG4gICAgICB9KTtcclxuICAgIH0pO1xyXG4gIH1cclxuICB1cGRhdGVEYXRhKHBhZ2VTaXplLCBwYWdlLCBzb3J0ZWQsIGZpbHRlcmVkKSB7XHJcbiAgICByZXR1cm4gbmV3IFByb21pc2UoKHJlc29sdmUsIHJlamVjdCkgPT4ge1xyXG4gICAgICAvLyBZb3UgY2FuIHJldHJpZXZlIHlvdXIgZGF0YSBob3dldmVyIHlvdSB3YW50LCBpbiB0aGlzIGNhc2UsIHdlIHdpbGwganVzdCB1c2Ugc29tZSBsb2NhbCBkYXRhLlxyXG4gICAgICBsZXQgZmlsdGVyZWREYXRhID0gdGhpcy5zdGF0ZS5vcmRlcnM7XHJcbiAgXHJcbiAgICAgIC8vIFlvdSBjYW4gdXNlIHRoZSBmaWx0ZXJzIGluIHlvdXIgcmVxdWVzdCwgYnV0IHlvdSBhcmUgcmVzcG9uc2libGUgZm9yIGFwcGx5aW5nIHRoZW0uXHJcbiAgICAgIGlmIChmaWx0ZXJlZC5sZW5ndGgpIHtcclxuICAgICAgICBmaWx0ZXJlZERhdGEgPSBmaWx0ZXJlZC5yZWR1Y2UoKGZpbHRlcmVkU29GYXIsIG5leHRGaWx0ZXIpID0+IHtcclxuICAgICAgICAgIHJldHVybiBmaWx0ZXJlZFNvRmFyLmZpbHRlcihyb3cgPT4ge1xyXG4gICAgICAgICAgICByZXR1cm4gKHJvd1tuZXh0RmlsdGVyLmlkXSArIFwiXCIpLmluY2x1ZGVzKG5leHRGaWx0ZXIudmFsdWUpO1xyXG4gICAgICAgICAgfSk7XHJcbiAgICAgICAgfSwgZmlsdGVyZWREYXRhKTtcclxuICAgICAgfVxyXG4gICAgICAvLyBZb3UgY2FuIGFsc28gdXNlIHRoZSBzb3J0aW5nIGluIHlvdXIgcmVxdWVzdCwgYnV0IGFnYWluLCB5b3UgYXJlIHJlc3BvbnNpYmxlIGZvciBhcHBseWluZyBpdC5cclxuICAgICAgY29uc3Qgc29ydGVkRGF0YSA9IF8ub3JkZXJCeShcclxuICAgICAgICBmaWx0ZXJlZERhdGEsXHJcbiAgICAgICAgc29ydGVkLm1hcChzb3J0ID0+IHtcclxuICAgICAgICAgIHJldHVybiByb3cgPT4ge1xyXG4gICAgICAgICAgICBpZiAocm93W3NvcnQuaWRdID09PSBudWxsIHx8IHJvd1tzb3J0LmlkXSA9PT0gdW5kZWZpbmVkKSB7XHJcbiAgICAgICAgICAgICAgcmV0dXJuIC1JbmZpbml0eTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICByZXR1cm4gdHlwZW9mIHJvd1tzb3J0LmlkXSA9PT0gXCJzdHJpbmdcIlxyXG4gICAgICAgICAgICAgID8gcm93W3NvcnQuaWRdLnRvTG93ZXJDYXNlKClcclxuICAgICAgICAgICAgICA6IHJvd1tzb3J0LmlkXTtcclxuICAgICAgICAgIH07XHJcbiAgICAgICAgfSksXHJcbiAgICAgICAgc29ydGVkLm1hcChkID0+IChkLmRlc2MgPyBcImRlc2NcIiA6IFwiYXNjXCIpKVxyXG4gICAgICApO1xyXG4gIFxyXG4gICAgICAvLyBZb3UgbXVzdCByZXR1cm4gYW4gb2JqZWN0IGNvbnRhaW5pbmcgdGhlIHJvd3Mgb2YgdGhlIGN1cnJlbnQgcGFnZSwgYW5kIG9wdGlvbmFsbHkgdGhlIHRvdGFsIHBhZ2VzIG51bWJlci5cclxuICAgICAgY29uc3QgcmVzID0ge1xyXG4gICAgICAgIHJvd3M6IHNvcnRlZERhdGEuc2xpY2UocGFnZVNpemUgKiBwYWdlLCBwYWdlU2l6ZSAqIHBhZ2UgKyBwYWdlU2l6ZSksXHJcbiAgICAgICAgcGFnZXM6IE1hdGguY2VpbChmaWx0ZXJlZERhdGEubGVuZ3RoIC8gcGFnZVNpemUpXHJcbiAgICAgIH07XHJcbiAgXHJcbiAgICAgIC8vIEhlcmUgd2UnbGwgc2ltdWxhdGUgYSBzZXJ2ZXIgcmVzcG9uc2Ugd2l0aCA1MDBtcyBvZiBkZWxheS5cclxuICAgICAgc2V0VGltZW91dCgoKSA9PiByZXNvbHZlKHJlcyksIDUwMCk7XHJcbiAgICB9KTtcclxuICB9XHJcbiAgcmVuZGVyKCkge1xyXG5cclxuICAgIGNvbnN0IHtcclxuICAgICAgbG9hZGluZyxcclxuICAgICAgb3JkZXJzLFxyXG4gICAgICBwYWdlcyxcclxuICAgIH0gPSB0aGlzLnN0YXRlO1xyXG5cclxuICAgIHZhciBjb2x1bW5zID0gW1xyXG4gICAgICB7XHJcbiAgICAgICAgSGVhZGVyOiAnT3JkZXJzJyxcclxuICAgICAgICBjb2x1bW5zOiBbXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ09yZGVyIE51bWJlcicsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnT3JkZXJOdW1iZXInLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnU3RhdHVzJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdPcmRlclN0YXR1cycsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdFbWFpbCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnQ3VzdG9tZXJFbWFpbCcsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdOYW1lJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdDdXN0b21lck5hbWUnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnQ291bnRyeScsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnQ3VzdG9tZXJDb3VudHJ5JyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ0NyZWF0ZWQnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ0NyZWF0ZURhdGUnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnUGFpZCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnUGFpZERhdGUnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnVG90YWwnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ1RvdGFsQW1vdW50JyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgXSxcclxuICAgICAgfSxcclxuICAgIF07XHJcblxyXG4gICAgcmV0dXJuIChcclxuICAgICAgPG1haW4+XHJcbiAgICAgICAgPFJlYWN0VGFibGVcclxuICAgICAgICAgICAgZGF0YT17b3JkZXJzfVxyXG4gICAgICAgICAgICBmaWx0ZXJhYmxlXHJcbiAgICAgICAgICAgIHBhZ2VzPXtwYWdlc31cclxuICAgICAgICAgICAgY29sdW1ucz17Y29sdW1uc31cclxuICAgICAgICAgICAgb25GZXRjaERhdGE9e3RoaXMuZGF0YUNoYW5nZX1cclxuICAgICAgICAgICAgZGVmYXVsdFBhZ2VTaXplPXsyfVxyXG4gICAgICAgICAgICBsb2FkaW5nPXtsb2FkaW5nfVxyXG4gICAgICAgICAgICBjbGFzc05hbWU9XCItc3RyaXBlZCAtaGlnaGxpZ2h0XCJcclxuICAgICAgICAgIC8+XHJcbiAgICAgIDwvbWFpbj5cclxuICAgICk7XHJcbiAgfVxyXG59XHJcbiJdLCJzb3VyY2VSb290IjoiIn0=\n//# sourceURL=webpack-internal:///./src/components/orders/orders.js\n");

/***/ })

})