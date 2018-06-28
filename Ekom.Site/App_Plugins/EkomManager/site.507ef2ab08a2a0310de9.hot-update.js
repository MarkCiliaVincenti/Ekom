webpackHotUpdate("site",{

/***/ "./src/components/orders/orders.js":
/*!*****************************************!*\
  !*** ./src/components/orders/orders.js ***!
  \*****************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Orders; });\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react */ \"./node_modules/react/index.js\");\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var react_router_dom__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! react-router-dom */ \"./node_modules/react-router-dom/es/index.js\");\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! lodash */ \"./node_modules/lodash/lodash.js\");\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(lodash__WEBPACK_IMPORTED_MODULE_2__);\n/* harmony import */ var stores_orderStore__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! stores/orderStore */ \"./src/stores/orderStore.js\");\n/* harmony import */ var react_table__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! react-table */ \"./node_modules/react-table/es/index.js\");\n!(function webpackMissingModule() { var e = new Error(\"Cannot find module \\\"./orders.scss\\\"\"); e.code = 'MODULE_NOT_FOUND'; throw e; }());\nfunction _typeof(obj) { if (typeof Symbol === \"function\" && typeof Symbol.iterator === \"symbol\") { _typeof = function _typeof(obj) { return typeof obj; }; } else { _typeof = function _typeof(obj) { return obj && typeof Symbol === \"function\" && obj.constructor === Symbol && obj !== Symbol.prototype ? \"symbol\" : typeof obj; }; } return _typeof(obj); }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function\"); } _setPrototypeOf(subClass.prototype, superClass && superClass.prototype); if (superClass) _setPrototypeOf(subClass, superClass); }\n\nfunction _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }\n\nfunction _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }\n\nfunction _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }\n\nfunction _possibleConstructorReturn(self, call) { if (call && (_typeof(call) === \"object\" || typeof call === \"function\")) { return call; } return _assertThisInitialized(self); }\n\nfunction _getPrototypeOf(o) { _getPrototypeOf = Object.getPrototypeOf || function _getPrototypeOf(o) { return o.__proto__; }; return _getPrototypeOf(o); }\n\nfunction _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return self; }\n\n\n\n\n\n\n\n\nvar Orders =\n/*#__PURE__*/\nfunction (_Component) {\n  function Orders(props) {\n    var _this;\n\n    _classCallCheck(this, Orders);\n\n    _this = _possibleConstructorReturn(this, _getPrototypeOf(Orders).call(this, props));\n    _this.state = {\n      loading: true,\n      defaultData: [],\n      orders: [],\n      page: 0,\n      pageSize: 10,\n      expanded: {},\n      resized: [],\n      filtered: []\n    };\n    _this.defaultFilter = _this.defaultFilter.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    return _this;\n  }\n\n  _createClass(Orders, [{\n    key: \"componentDidMount\",\n    value: function componentDidMount() {\n      var _this2 = this;\n\n      this.getOrders().then(function (orders) {\n        console.log(orders);\n\n        _this2.setState({\n          defaultData: orders,\n          orders: orders,\n          loading: false\n        });\n      });\n    }\n  }, {\n    key: \"getOrders\",\n    value: function getOrders() {\n      return fetch('/umbraco/backoffice/ekom/managerapi/getorders', {\n        credentials: 'include'\n      }).then(function (response) {\n        return response.json();\n      }).then(function (result) {\n        return result;\n      });\n    }\n  }, {\n    key: \"defaultFilter\",\n    value: function defaultFilter(filter, row) {\n      return String(row[filter.id]).includes(filter.value);\n    }\n  }, {\n    key: \"render\",\n    value: function render() {\n      var _this$state = this.state,\n          loading = _this$state.loading,\n          defaultData = _this$state.defaultData,\n          orders = _this$state.orders,\n          pages = _this$state.pages,\n          filtered = _this$state.filtered;\n      var columns = [{\n        Header: 'Orders',\n        columns: [{\n          Header: 'Order Number',\n          accessor: 'OrderNumber',\n          Cell: function Cell(row) {\n            return react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react_router_dom__WEBPACK_IMPORTED_MODULE_1__[\"Link\"], {\n              to: \"/manager/order/\".concat(row.value)\n            }, row.value);\n          }\n        }, {\n          Header: 'Status',\n          accessor: 'OrderStatus'\n        }, {\n          Header: 'Email',\n          accessor: 'CustomerEmail'\n        }, {\n          Header: 'Name',\n          accessor: 'CustomerName'\n        }, {\n          Header: 'Country',\n          accessor: 'CustomerCountry'\n        }, {\n          Header: 'Created',\n          accessor: 'CreateDate'\n        }, {\n          Header: 'Paid',\n          accessor: 'PaidDate'\n        }, {\n          Header: 'Total',\n          accessor: 'TotalAmount'\n        }]\n      }];\n      return react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"main\", null, react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"nav\", {\n        className: !(function webpackMissingModule() { var e = new Error(\"Cannot find module \\\"./orders.scss\\\"\"); e.code = 'MODULE_NOT_FOUND'; throw e; }()).navigation\n      }, react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"ul\", {\n        className: !(function webpackMissingModule() { var e = new Error(\"Cannot find module \\\"./orders.scss\\\"\"); e.code = 'MODULE_NOT_FOUND'; throw e; }()).list\n      }, react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"li\", null, \"All\"), react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"li\", null, \"test\"))), react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react_table__WEBPACK_IMPORTED_MODULE_4__[\"default\"], {\n        data: orders,\n        filterable: true,\n        defaultFilterMethod: this.defaultFilter,\n        columns: columns,\n        defaultPageSize: 2,\n        loading: loading,\n        className: \"-striped -highlight\"\n      }));\n    }\n  }]);\n\n  _inherits(Orders, _Component);\n\n  return Orders;\n}(react__WEBPACK_IMPORTED_MODULE_0__[\"Component\"]);\n\n//# sourceURL=[module]\n//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vLi9zcmMvY29tcG9uZW50cy9vcmRlcnMvb3JkZXJzLmpzPzA5OGYiXSwibmFtZXMiOlsiT3JkZXJzIiwicHJvcHMiLCJzdGF0ZSIsImxvYWRpbmciLCJkZWZhdWx0RGF0YSIsIm9yZGVycyIsInBhZ2UiLCJwYWdlU2l6ZSIsImV4cGFuZGVkIiwicmVzaXplZCIsImZpbHRlcmVkIiwiZGVmYXVsdEZpbHRlciIsImJpbmQiLCJnZXRPcmRlcnMiLCJ0aGVuIiwiY29uc29sZSIsImxvZyIsInNldFN0YXRlIiwiZmV0Y2giLCJjcmVkZW50aWFscyIsInJlc3BvbnNlIiwianNvbiIsInJlc3VsdCIsImZpbHRlciIsInJvdyIsIlN0cmluZyIsImlkIiwiaW5jbHVkZXMiLCJ2YWx1ZSIsInBhZ2VzIiwiY29sdW1ucyIsIkhlYWRlciIsImFjY2Vzc29yIiwiQ2VsbCIsInMiLCJuYXZpZ2F0aW9uIiwibGlzdCJdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7OztBQUFBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFFQTs7SUFDcUJBLE07OztBQUVuQixrQkFBWUMsS0FBWixFQUFtQjtBQUFBOztBQUFBOztBQUNqQixnRkFBTUEsS0FBTjtBQUVBLFVBQUtDLEtBQUwsR0FBYTtBQUNYQyxlQUFTLElBREU7QUFFWEMsbUJBQWEsRUFGRjtBQUdYQyxjQUFRLEVBSEc7QUFJWEMsWUFBTSxDQUpLO0FBS1hDLGdCQUFVLEVBTEM7QUFNWEMsZ0JBQVUsRUFOQztBQU9YQyxlQUFTLEVBUEU7QUFRWEMsZ0JBQVU7QUFSQyxLQUFiO0FBVUEsVUFBS0MsYUFBTCxHQUFxQixNQUFLQSxhQUFMLENBQW1CQyxJQUFuQix1REFBckI7QUFiaUI7QUFjbEI7Ozs7d0NBRW1CO0FBQUE7O0FBRWxCLFdBQUtDLFNBQUwsR0FBaUJDLElBQWpCLENBQXNCLFVBQUNULE1BQUQsRUFBWTtBQUVoQ1UsZ0JBQVFDLEdBQVIsQ0FBWVgsTUFBWjs7QUFDQSxlQUFLWSxRQUFMLENBQWM7QUFDWmIsdUJBQWFDLE1BREQ7QUFFWkEsa0JBQVFBLE1BRkk7QUFHWkYsbUJBQVM7QUFIRyxTQUFkO0FBTUQsT0FURDtBQVVEOzs7Z0NBRVc7QUFDVixhQUFPZSxNQUFNLCtDQUFOLEVBQXVEO0FBQzVEQyxxQkFBYTtBQUQrQyxPQUF2RCxFQUVKTCxJQUZJLENBRUMsVUFBVU0sUUFBVixFQUFvQjtBQUMxQixlQUFPQSxTQUFTQyxJQUFULEVBQVA7QUFDRCxPQUpNLEVBSUpQLElBSkksQ0FJQyxVQUFVUSxNQUFWLEVBQWtCO0FBQ3hCLGVBQU9BLE1BQVA7QUFDRCxPQU5NLENBQVA7QUFPRDs7O2tDQUdhQyxNLEVBQVFDLEcsRUFBSztBQUN6QixhQUFPQyxPQUFPRCxJQUFJRCxPQUFPRyxFQUFYLENBQVAsRUFBdUJDLFFBQXZCLENBQWdDSixPQUFPSyxLQUF2QyxDQUFQO0FBQ0Q7Ozs2QkFDUTtBQUFBLHdCQVFILEtBQUsxQixLQVJGO0FBQUEsVUFHTEMsT0FISyxlQUdMQSxPQUhLO0FBQUEsVUFJTEMsV0FKSyxlQUlMQSxXQUpLO0FBQUEsVUFLTEMsTUFMSyxlQUtMQSxNQUxLO0FBQUEsVUFNTHdCLEtBTkssZUFNTEEsS0FOSztBQUFBLFVBT0xuQixRQVBLLGVBT0xBLFFBUEs7QUFVUCxVQUFJb0IsVUFBVSxDQUNaO0FBQ0VDLGdCQUFRLFFBRFY7QUFFRUQsaUJBQVMsQ0FDUDtBQUNFQyxrQkFBUSxjQURWO0FBRUVDLG9CQUFVLGFBRlo7QUFHRUMsZ0JBQU07QUFBQSxtQkFDSiwyREFBQyxxREFBRDtBQUFNLDJDQUFzQlQsSUFBSUksS0FBMUI7QUFBTixlQUEwQ0osSUFBSUksS0FBOUMsQ0FESTtBQUFBO0FBSFIsU0FETyxFQVFQO0FBQ0VHLGtCQUFRLFFBRFY7QUFFRUMsb0JBQVU7QUFGWixTQVJPLEVBWVA7QUFDRUQsa0JBQVEsT0FEVjtBQUVFQyxvQkFBVTtBQUZaLFNBWk8sRUFnQlA7QUFDRUQsa0JBQVEsTUFEVjtBQUVFQyxvQkFBVTtBQUZaLFNBaEJPLEVBb0JQO0FBQ0VELGtCQUFRLFNBRFY7QUFFRUMsb0JBQVU7QUFGWixTQXBCTyxFQXdCUDtBQUNFRCxrQkFBUSxTQURWO0FBRUVDLG9CQUFVO0FBRlosU0F4Qk8sRUE0QlA7QUFDRUQsa0JBQVEsTUFEVjtBQUVFQyxvQkFBVTtBQUZaLFNBNUJPLEVBZ0NQO0FBQ0VELGtCQUFRLE9BRFY7QUFFRUMsb0JBQVU7QUFGWixTQWhDTztBQUZYLE9BRFksQ0FBZDtBQTJDQSxhQUNFLHlFQUVFO0FBQUssbUJBQVcseUlBQUFFLENBQUVDO0FBQWxCLFNBQ0U7QUFBSSxtQkFBVyx5SUFBQUQsQ0FBRUU7QUFBakIsU0FDRSw2RUFERixFQUVFLDhFQUZGLENBREYsQ0FGRixFQVNFLDJEQUFDLG1EQUFEO0FBQ0ksY0FBTS9CLE1BRFY7QUFFSSx3QkFGSjtBQUdJLDZCQUFxQixLQUFLTSxhQUg5QjtBQUlJLGlCQUFTbUIsT0FKYjtBQUtJLHlCQUFpQixDQUxyQjtBQU1JLGlCQUFTM0IsT0FOYjtBQU9JLG1CQUFVO0FBUGQsUUFURixDQURGO0FBcUJEOzs7Ozs7RUF4SGlDLCtDIiwiZmlsZSI6Ii4vc3JjL2NvbXBvbmVudHMvb3JkZXJzL29yZGVycy5qcy5qcyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCBSZWFjdCwgeyBDb21wb25lbnQgfSBmcm9tICdyZWFjdCc7XHJcbmltcG9ydCB7IExpbmsgfSBmcm9tICdyZWFjdC1yb3V0ZXItZG9tJztcclxuaW1wb3J0IF8gZnJvbSBcImxvZGFzaFwiO1xyXG5pbXBvcnQgb3JkZXJTdG9yZSBmcm9tICdzdG9yZXMvb3JkZXJTdG9yZSc7XHJcbmltcG9ydCBSZWFjdFRhYmxlIGZyb20gJ3JlYWN0LXRhYmxlJztcclxuXHJcbmltcG9ydCBzIGZyb20gJy4vb3JkZXJzLnNjc3MnO1xyXG5leHBvcnQgZGVmYXVsdCBjbGFzcyBPcmRlcnMgZXh0ZW5kcyBDb21wb25lbnQge1xyXG5cclxuICBjb25zdHJ1Y3Rvcihwcm9wcykge1xyXG4gICAgc3VwZXIocHJvcHMpO1xyXG5cclxuICAgIHRoaXMuc3RhdGUgPSB7XHJcbiAgICAgIGxvYWRpbmc6IHRydWUsXHJcbiAgICAgIGRlZmF1bHREYXRhOiBbXSxcclxuICAgICAgb3JkZXJzOiBbXSxcclxuICAgICAgcGFnZTogMCxcclxuICAgICAgcGFnZVNpemU6IDEwLFxyXG4gICAgICBleHBhbmRlZDoge30sXHJcbiAgICAgIHJlc2l6ZWQ6IFtdLFxyXG4gICAgICBmaWx0ZXJlZDogW11cclxuICAgIH1cclxuICAgIHRoaXMuZGVmYXVsdEZpbHRlciA9IHRoaXMuZGVmYXVsdEZpbHRlci5iaW5kKHRoaXMpO1xyXG4gIH0gIFxyXG5cclxuICBjb21wb25lbnREaWRNb3VudCgpIHtcclxuXHJcbiAgICB0aGlzLmdldE9yZGVycygpLnRoZW4oKG9yZGVycykgPT4ge1xyXG5cclxuICAgICAgY29uc29sZS5sb2cob3JkZXJzKVxyXG4gICAgICB0aGlzLnNldFN0YXRlKHtcclxuICAgICAgICBkZWZhdWx0RGF0YTogb3JkZXJzLFxyXG4gICAgICAgIG9yZGVyczogb3JkZXJzLFxyXG4gICAgICAgIGxvYWRpbmc6IGZhbHNlLFxyXG4gICAgICB9KTtcclxuXHJcbiAgICB9KTtcclxuICB9XHJcblxyXG4gIGdldE9yZGVycygpIHtcclxuICAgIHJldHVybiBmZXRjaCgnL3VtYnJhY28vYmFja29mZmljZS9la29tL21hbmFnZXJhcGkvZ2V0b3JkZXJzJywge1xyXG4gICAgICBjcmVkZW50aWFsczogJ2luY2x1ZGUnLFxyXG4gICAgfSkudGhlbihmdW5jdGlvbiAocmVzcG9uc2UpIHtcclxuICAgICAgcmV0dXJuIHJlc3BvbnNlLmpzb24oKTtcclxuICAgIH0pLnRoZW4oZnVuY3Rpb24gKHJlc3VsdCkge1xyXG4gICAgICByZXR1cm4gcmVzdWx0O1xyXG4gICAgfSk7XHJcbiAgfVxyXG5cclxuXHJcbiAgZGVmYXVsdEZpbHRlcihmaWx0ZXIsIHJvdykge1xyXG4gICAgcmV0dXJuIFN0cmluZyhyb3dbZmlsdGVyLmlkXSkuaW5jbHVkZXMoZmlsdGVyLnZhbHVlKVxyXG4gIH1cclxuICByZW5kZXIoKSB7XHJcblxyXG4gICAgY29uc3Qge1xyXG4gICAgICBsb2FkaW5nLFxyXG4gICAgICBkZWZhdWx0RGF0YSxcclxuICAgICAgb3JkZXJzLFxyXG4gICAgICBwYWdlcyxcclxuICAgICAgZmlsdGVyZWRcclxuICAgIH0gPSB0aGlzLnN0YXRlO1xyXG5cclxuICAgIHZhciBjb2x1bW5zID0gW1xyXG4gICAgICB7XHJcbiAgICAgICAgSGVhZGVyOiAnT3JkZXJzJyxcclxuICAgICAgICBjb2x1bW5zOiBbXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ09yZGVyIE51bWJlcicsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnT3JkZXJOdW1iZXInLFxyXG4gICAgICAgICAgICBDZWxsOiByb3cgPT4gKFxyXG4gICAgICAgICAgICAgIDxMaW5rIHRvPXtgL21hbmFnZXIvb3JkZXIvJHtyb3cudmFsdWV9YH0+e3Jvdy52YWx1ZX08L0xpbms+XHJcbiAgICAgICAgICAgIClcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ1N0YXR1cycsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnT3JkZXJTdGF0dXMnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnRW1haWwnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ0N1c3RvbWVyRW1haWwnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnTmFtZScsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnQ3VzdG9tZXJOYW1lJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ0NvdW50cnknLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ0N1c3RvbWVyQ291bnRyeScsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdDcmVhdGVkJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdDcmVhdGVEYXRlJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ1BhaWQnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ1BhaWREYXRlJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ1RvdGFsJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdUb3RhbEFtb3VudCcsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgIF0sXHJcbiAgICAgIH0sXHJcbiAgICBdO1xyXG5cclxuICAgIHJldHVybiAoXHJcbiAgICAgIDxtYWluPlxyXG5cclxuICAgICAgICA8bmF2IGNsYXNzTmFtZT17cy5uYXZpZ2F0aW9ufT5cclxuICAgICAgICAgIDx1bCBjbGFzc05hbWU9e3MubGlzdH0+XHJcbiAgICAgICAgICAgIDxsaT5BbGw8L2xpPlxyXG4gICAgICAgICAgICA8bGk+dGVzdDwvbGk+XHJcbiAgICAgICAgICA8L3VsPlxyXG4gICAgICAgIDwvbmF2PlxyXG5cclxuICAgICAgICA8UmVhY3RUYWJsZVxyXG4gICAgICAgICAgICBkYXRhPXtvcmRlcnN9XHJcbiAgICAgICAgICAgIGZpbHRlcmFibGVcclxuICAgICAgICAgICAgZGVmYXVsdEZpbHRlck1ldGhvZD17dGhpcy5kZWZhdWx0RmlsdGVyfVxyXG4gICAgICAgICAgICBjb2x1bW5zPXtjb2x1bW5zfVxyXG4gICAgICAgICAgICBkZWZhdWx0UGFnZVNpemU9ezJ9XHJcbiAgICAgICAgICAgIGxvYWRpbmc9e2xvYWRpbmd9XHJcbiAgICAgICAgICAgIGNsYXNzTmFtZT1cIi1zdHJpcGVkIC1oaWdobGlnaHRcIlxyXG4gICAgICAgICAgLz5cclxuICAgICAgPC9tYWluPlxyXG4gICAgKTtcclxuICB9XHJcbn1cclxuIl0sInNvdXJjZVJvb3QiOiIifQ==\n//# sourceURL=webpack-internal:///./src/components/orders/orders.js\n");

/***/ })

})