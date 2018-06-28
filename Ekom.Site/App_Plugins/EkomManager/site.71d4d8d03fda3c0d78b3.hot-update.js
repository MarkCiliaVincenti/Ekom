webpackHotUpdate("site",{

/***/ "./src/components/orders/orders.js":
/*!*****************************************!*\
  !*** ./src/components/orders/orders.js ***!
  \*****************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Orders; });\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react */ \"./node_modules/react/index.js\");\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var react_router_dom__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! react-router-dom */ \"./node_modules/react-router-dom/es/index.js\");\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! lodash */ \"./node_modules/lodash/lodash.js\");\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(lodash__WEBPACK_IMPORTED_MODULE_2__);\n/* harmony import */ var stores_orderStore__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! stores/orderStore */ \"./src/stores/orderStore.js\");\n/* harmony import */ var react_table__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! react-table */ \"./node_modules/react-table/es/index.js\");\n/* harmony import */ var _orders_scss__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./orders.scss */ \"./src/components/orders/orders.scss\");\n/* harmony import */ var _orders_scss__WEBPACK_IMPORTED_MODULE_5___default = /*#__PURE__*/__webpack_require__.n(_orders_scss__WEBPACK_IMPORTED_MODULE_5__);\nfunction _typeof(obj) { if (typeof Symbol === \"function\" && typeof Symbol.iterator === \"symbol\") { _typeof = function _typeof(obj) { return typeof obj; }; } else { _typeof = function _typeof(obj) { return obj && typeof Symbol === \"function\" && obj.constructor === Symbol && obj !== Symbol.prototype ? \"symbol\" : typeof obj; }; } return _typeof(obj); }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function\"); } _setPrototypeOf(subClass.prototype, superClass && superClass.prototype); if (superClass) _setPrototypeOf(subClass, superClass); }\n\nfunction _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }\n\nfunction _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }\n\nfunction _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }\n\nfunction _possibleConstructorReturn(self, call) { if (call && (_typeof(call) === \"object\" || typeof call === \"function\")) { return call; } return _assertThisInitialized(self); }\n\nfunction _getPrototypeOf(o) { _getPrototypeOf = Object.getPrototypeOf || function _getPrototypeOf(o) { return o.__proto__; }; return _getPrototypeOf(o); }\n\nfunction _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return self; }\n\n\n\n\n\n\n\n\nvar Orders =\n/*#__PURE__*/\nfunction (_Component) {\n  function Orders(props) {\n    var _this;\n\n    _classCallCheck(this, Orders);\n\n    _this = _possibleConstructorReturn(this, _getPrototypeOf(Orders).call(this, props));\n    _this.state = {\n      loading: true,\n      defaultData: [],\n      orders: [],\n      page: 0,\n      pageSize: 10,\n      expanded: {},\n      resized: [],\n      filtered: []\n    };\n    _this.defaultFilter = _this.defaultFilter.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    return _this;\n  }\n\n  _createClass(Orders, [{\n    key: \"componentDidMount\",\n    value: function componentDidMount() {\n      var _this2 = this;\n\n      this.getOrders().then(function (orders) {\n        console.log(orders);\n\n        _this2.setState({\n          defaultData: orders,\n          orders: orders,\n          loading: false\n        });\n      });\n    }\n  }, {\n    key: \"getOrders\",\n    value: function getOrders() {\n      return fetch('/umbraco/backoffice/ekom/managerapi/getorders', {\n        credentials: 'include'\n      }).then(function (response) {\n        return response.json();\n      }).then(function (result) {\n        return result;\n      });\n    }\n  }, {\n    key: \"defaultFilter\",\n    value: function defaultFilter(filter, row) {\n      return String(row[filter.id]).includes(filter.value);\n    }\n  }, {\n    key: \"render\",\n    value: function render() {\n      var _this$state = this.state,\n          loading = _this$state.loading,\n          defaultData = _this$state.defaultData,\n          orders = _this$state.orders,\n          pages = _this$state.pages,\n          filtered = _this$state.filtered;\n      var columns = [{\n        Header: 'Orders',\n        columns: [{\n          Header: 'Order Number',\n          accessor: 'OrderNumber',\n          Cell: function Cell(row) {\n            return react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react_router_dom__WEBPACK_IMPORTED_MODULE_1__[\"Link\"], {\n              to: \"/manager/order/\".concat(row.value)\n            }, row.value);\n          }\n        }, {\n          Header: 'Status',\n          accessor: 'OrderStatus'\n        }, {\n          Header: 'Email',\n          accessor: 'CustomerEmail'\n        }, {\n          Header: 'Name',\n          accessor: 'CustomerName'\n        }, {\n          Header: 'Country',\n          accessor: 'CustomerCountry'\n        }, {\n          Header: 'Created',\n          accessor: 'CreateDate'\n        }, {\n          Header: 'Paid',\n          accessor: 'PaidDate'\n        }, {\n          Header: 'Total',\n          accessor: 'TotalAmount'\n        }]\n      }];\n      return react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"main\", null, react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"nav\", {\n        className: _orders_scss__WEBPACK_IMPORTED_MODULE_5___default.a.navigation\n      }, react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react_router_dom__WEBPACK_IMPORTED_MODULE_1__[\"Link\"], {\n        to: \"#\",\n        className: _orders_scss__WEBPACK_IMPORTED_MODULE_5___default.a.link\n      }, \"Orders\"), react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"ul\", {\n        className: _orders_scss__WEBPACK_IMPORTED_MODULE_5___default.a.list\n      }, react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"li\", {\n        className: _orders_scss__WEBPACK_IMPORTED_MODULE_5___default.a.link\n      }, \"All\"), react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"li\", {\n        className: _orders_scss__WEBPACK_IMPORTED_MODULE_5___default.a.link\n      }, \"test\"))), react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"div\", {\n        className: \"section\"\n      }, react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react_table__WEBPACK_IMPORTED_MODULE_4__[\"default\"], {\n        data: orders,\n        filterable: true,\n        defaultFilterMethod: this.defaultFilter,\n        columns: columns,\n        defaultPageSize: 2,\n        loading: loading,\n        className: \"-striped -highlight\"\n      })));\n    }\n  }]);\n\n  _inherits(Orders, _Component);\n\n  return Orders;\n}(react__WEBPACK_IMPORTED_MODULE_0__[\"Component\"]);\n\n//# sourceURL=[module]\n//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vLi9zcmMvY29tcG9uZW50cy9vcmRlcnMvb3JkZXJzLmpzPzA5OGYiXSwibmFtZXMiOlsiT3JkZXJzIiwicHJvcHMiLCJzdGF0ZSIsImxvYWRpbmciLCJkZWZhdWx0RGF0YSIsIm9yZGVycyIsInBhZ2UiLCJwYWdlU2l6ZSIsImV4cGFuZGVkIiwicmVzaXplZCIsImZpbHRlcmVkIiwiZGVmYXVsdEZpbHRlciIsImJpbmQiLCJnZXRPcmRlcnMiLCJ0aGVuIiwiY29uc29sZSIsImxvZyIsInNldFN0YXRlIiwiZmV0Y2giLCJjcmVkZW50aWFscyIsInJlc3BvbnNlIiwianNvbiIsInJlc3VsdCIsImZpbHRlciIsInJvdyIsIlN0cmluZyIsImlkIiwiaW5jbHVkZXMiLCJ2YWx1ZSIsInBhZ2VzIiwiY29sdW1ucyIsIkhlYWRlciIsImFjY2Vzc29yIiwiQ2VsbCIsInMiLCJuYXZpZ2F0aW9uIiwibGluayIsImxpc3QiXSwibWFwcGluZ3MiOiI7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7O0FBQUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUVBOztJQUNxQkEsTTs7O0FBRW5CLGtCQUFZQyxLQUFaLEVBQW1CO0FBQUE7O0FBQUE7O0FBQ2pCLGdGQUFNQSxLQUFOO0FBRUEsVUFBS0MsS0FBTCxHQUFhO0FBQ1hDLGVBQVMsSUFERTtBQUVYQyxtQkFBYSxFQUZGO0FBR1hDLGNBQVEsRUFIRztBQUlYQyxZQUFNLENBSks7QUFLWEMsZ0JBQVUsRUFMQztBQU1YQyxnQkFBVSxFQU5DO0FBT1hDLGVBQVMsRUFQRTtBQVFYQyxnQkFBVTtBQVJDLEtBQWI7QUFVQSxVQUFLQyxhQUFMLEdBQXFCLE1BQUtBLGFBQUwsQ0FBbUJDLElBQW5CLHVEQUFyQjtBQWJpQjtBQWNsQjs7Ozt3Q0FFbUI7QUFBQTs7QUFFbEIsV0FBS0MsU0FBTCxHQUFpQkMsSUFBakIsQ0FBc0IsVUFBQ1QsTUFBRCxFQUFZO0FBRWhDVSxnQkFBUUMsR0FBUixDQUFZWCxNQUFaOztBQUNBLGVBQUtZLFFBQUwsQ0FBYztBQUNaYix1QkFBYUMsTUFERDtBQUVaQSxrQkFBUUEsTUFGSTtBQUdaRixtQkFBUztBQUhHLFNBQWQ7QUFNRCxPQVREO0FBVUQ7OztnQ0FFVztBQUNWLGFBQU9lLE1BQU0sK0NBQU4sRUFBdUQ7QUFDNURDLHFCQUFhO0FBRCtDLE9BQXZELEVBRUpMLElBRkksQ0FFQyxVQUFVTSxRQUFWLEVBQW9CO0FBQzFCLGVBQU9BLFNBQVNDLElBQVQsRUFBUDtBQUNELE9BSk0sRUFJSlAsSUFKSSxDQUlDLFVBQVVRLE1BQVYsRUFBa0I7QUFDeEIsZUFBT0EsTUFBUDtBQUNELE9BTk0sQ0FBUDtBQU9EOzs7a0NBR2FDLE0sRUFBUUMsRyxFQUFLO0FBQ3pCLGFBQU9DLE9BQU9ELElBQUlELE9BQU9HLEVBQVgsQ0FBUCxFQUF1QkMsUUFBdkIsQ0FBZ0NKLE9BQU9LLEtBQXZDLENBQVA7QUFDRDs7OzZCQUNRO0FBQUEsd0JBUUgsS0FBSzFCLEtBUkY7QUFBQSxVQUdMQyxPQUhLLGVBR0xBLE9BSEs7QUFBQSxVQUlMQyxXQUpLLGVBSUxBLFdBSks7QUFBQSxVQUtMQyxNQUxLLGVBS0xBLE1BTEs7QUFBQSxVQU1Md0IsS0FOSyxlQU1MQSxLQU5LO0FBQUEsVUFPTG5CLFFBUEssZUFPTEEsUUFQSztBQVVQLFVBQUlvQixVQUFVLENBQ1o7QUFDRUMsZ0JBQVEsUUFEVjtBQUVFRCxpQkFBUyxDQUNQO0FBQ0VDLGtCQUFRLGNBRFY7QUFFRUMsb0JBQVUsYUFGWjtBQUdFQyxnQkFBTTtBQUFBLG1CQUNKLDJEQUFDLHFEQUFEO0FBQU0sMkNBQXNCVCxJQUFJSSxLQUExQjtBQUFOLGVBQTBDSixJQUFJSSxLQUE5QyxDQURJO0FBQUE7QUFIUixTQURPLEVBUVA7QUFDRUcsa0JBQVEsUUFEVjtBQUVFQyxvQkFBVTtBQUZaLFNBUk8sRUFZUDtBQUNFRCxrQkFBUSxPQURWO0FBRUVDLG9CQUFVO0FBRlosU0FaTyxFQWdCUDtBQUNFRCxrQkFBUSxNQURWO0FBRUVDLG9CQUFVO0FBRlosU0FoQk8sRUFvQlA7QUFDRUQsa0JBQVEsU0FEVjtBQUVFQyxvQkFBVTtBQUZaLFNBcEJPLEVBd0JQO0FBQ0VELGtCQUFRLFNBRFY7QUFFRUMsb0JBQVU7QUFGWixTQXhCTyxFQTRCUDtBQUNFRCxrQkFBUSxNQURWO0FBRUVDLG9CQUFVO0FBRlosU0E1Qk8sRUFnQ1A7QUFDRUQsa0JBQVEsT0FEVjtBQUVFQyxvQkFBVTtBQUZaLFNBaENPO0FBRlgsT0FEWSxDQUFkO0FBMkNBLGFBQ0UseUVBQ0U7QUFBSyxtQkFBVyxtREFBQUUsQ0FBRUM7QUFBbEIsU0FDRSwyREFBQyxxREFBRDtBQUFNLFlBQUcsR0FBVDtBQUFhLG1CQUFXLG1EQUFBRCxDQUFFRTtBQUExQixrQkFERixFQUVFO0FBQUksbUJBQVcsbURBQUFGLENBQUVHO0FBQWpCLFNBQ0U7QUFBSSxtQkFBVyxtREFBQUgsQ0FBRUU7QUFBakIsZUFERixFQUVFO0FBQUksbUJBQVcsbURBQUFGLENBQUVFO0FBQWpCLGdCQUZGLENBRkYsQ0FERixFQVNFO0FBQUssbUJBQVU7QUFBZixTQUNFLDJEQUFDLG1EQUFEO0FBQ0ksY0FBTS9CLE1BRFY7QUFFSSx3QkFGSjtBQUdJLDZCQUFxQixLQUFLTSxhQUg5QjtBQUlJLGlCQUFTbUIsT0FKYjtBQUtJLHlCQUFpQixDQUxyQjtBQU1JLGlCQUFTM0IsT0FOYjtBQU9JLG1CQUFVO0FBUGQsUUFERixDQVRGLENBREY7QUF1QkQ7Ozs7OztFQTFIaUMsK0MiLCJmaWxlIjoiLi9zcmMvY29tcG9uZW50cy9vcmRlcnMvb3JkZXJzLmpzLmpzIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IFJlYWN0LCB7IENvbXBvbmVudCB9IGZyb20gJ3JlYWN0JztcclxuaW1wb3J0IHsgTGluayB9IGZyb20gJ3JlYWN0LXJvdXRlci1kb20nO1xyXG5pbXBvcnQgXyBmcm9tIFwibG9kYXNoXCI7XHJcbmltcG9ydCBvcmRlclN0b3JlIGZyb20gJ3N0b3Jlcy9vcmRlclN0b3JlJztcclxuaW1wb3J0IFJlYWN0VGFibGUgZnJvbSAncmVhY3QtdGFibGUnO1xyXG5cclxuaW1wb3J0IHMgZnJvbSAnLi9vcmRlcnMuc2Nzcyc7XHJcbmV4cG9ydCBkZWZhdWx0IGNsYXNzIE9yZGVycyBleHRlbmRzIENvbXBvbmVudCB7XHJcblxyXG4gIGNvbnN0cnVjdG9yKHByb3BzKSB7XHJcbiAgICBzdXBlcihwcm9wcyk7XHJcblxyXG4gICAgdGhpcy5zdGF0ZSA9IHtcclxuICAgICAgbG9hZGluZzogdHJ1ZSxcclxuICAgICAgZGVmYXVsdERhdGE6IFtdLFxyXG4gICAgICBvcmRlcnM6IFtdLFxyXG4gICAgICBwYWdlOiAwLFxyXG4gICAgICBwYWdlU2l6ZTogMTAsXHJcbiAgICAgIGV4cGFuZGVkOiB7fSxcclxuICAgICAgcmVzaXplZDogW10sXHJcbiAgICAgIGZpbHRlcmVkOiBbXVxyXG4gICAgfVxyXG4gICAgdGhpcy5kZWZhdWx0RmlsdGVyID0gdGhpcy5kZWZhdWx0RmlsdGVyLmJpbmQodGhpcyk7XHJcbiAgfSAgXHJcblxyXG4gIGNvbXBvbmVudERpZE1vdW50KCkge1xyXG5cclxuICAgIHRoaXMuZ2V0T3JkZXJzKCkudGhlbigob3JkZXJzKSA9PiB7XHJcblxyXG4gICAgICBjb25zb2xlLmxvZyhvcmRlcnMpXHJcbiAgICAgIHRoaXMuc2V0U3RhdGUoe1xyXG4gICAgICAgIGRlZmF1bHREYXRhOiBvcmRlcnMsXHJcbiAgICAgICAgb3JkZXJzOiBvcmRlcnMsXHJcbiAgICAgICAgbG9hZGluZzogZmFsc2UsXHJcbiAgICAgIH0pO1xyXG5cclxuICAgIH0pO1xyXG4gIH1cclxuXHJcbiAgZ2V0T3JkZXJzKCkge1xyXG4gICAgcmV0dXJuIGZldGNoKCcvdW1icmFjby9iYWNrb2ZmaWNlL2Vrb20vbWFuYWdlcmFwaS9nZXRvcmRlcnMnLCB7XHJcbiAgICAgIGNyZWRlbnRpYWxzOiAnaW5jbHVkZScsXHJcbiAgICB9KS50aGVuKGZ1bmN0aW9uIChyZXNwb25zZSkge1xyXG4gICAgICByZXR1cm4gcmVzcG9uc2UuanNvbigpO1xyXG4gICAgfSkudGhlbihmdW5jdGlvbiAocmVzdWx0KSB7XHJcbiAgICAgIHJldHVybiByZXN1bHQ7XHJcbiAgICB9KTtcclxuICB9XHJcblxyXG5cclxuICBkZWZhdWx0RmlsdGVyKGZpbHRlciwgcm93KSB7XHJcbiAgICByZXR1cm4gU3RyaW5nKHJvd1tmaWx0ZXIuaWRdKS5pbmNsdWRlcyhmaWx0ZXIudmFsdWUpXHJcbiAgfVxyXG4gIHJlbmRlcigpIHtcclxuXHJcbiAgICBjb25zdCB7XHJcbiAgICAgIGxvYWRpbmcsXHJcbiAgICAgIGRlZmF1bHREYXRhLFxyXG4gICAgICBvcmRlcnMsXHJcbiAgICAgIHBhZ2VzLFxyXG4gICAgICBmaWx0ZXJlZFxyXG4gICAgfSA9IHRoaXMuc3RhdGU7XHJcblxyXG4gICAgdmFyIGNvbHVtbnMgPSBbXHJcbiAgICAgIHtcclxuICAgICAgICBIZWFkZXI6ICdPcmRlcnMnLFxyXG4gICAgICAgIGNvbHVtbnM6IFtcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnT3JkZXIgTnVtYmVyJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdPcmRlck51bWJlcicsXHJcbiAgICAgICAgICAgIENlbGw6IHJvdyA9PiAoXHJcbiAgICAgICAgICAgICAgPExpbmsgdG89e2AvbWFuYWdlci9vcmRlci8ke3Jvdy52YWx1ZX1gfT57cm93LnZhbHVlfTwvTGluaz5cclxuICAgICAgICAgICAgKVxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnU3RhdHVzJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdPcmRlclN0YXR1cycsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdFbWFpbCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnQ3VzdG9tZXJFbWFpbCcsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdOYW1lJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdDdXN0b21lck5hbWUnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnQ291bnRyeScsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnQ3VzdG9tZXJDb3VudHJ5JyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ0NyZWF0ZWQnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ0NyZWF0ZURhdGUnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnUGFpZCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnUGFpZERhdGUnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnVG90YWwnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ1RvdGFsQW1vdW50JyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgXSxcclxuICAgICAgfSxcclxuICAgIF07XHJcblxyXG4gICAgcmV0dXJuIChcclxuICAgICAgPG1haW4+XHJcbiAgICAgICAgPG5hdiBjbGFzc05hbWU9e3MubmF2aWdhdGlvbn0+XHJcbiAgICAgICAgICA8TGluayB0bz1cIiNcIiBjbGFzc05hbWU9e3MubGlua30+T3JkZXJzPC9MaW5rPlxyXG4gICAgICAgICAgPHVsIGNsYXNzTmFtZT17cy5saXN0fT5cclxuICAgICAgICAgICAgPGxpIGNsYXNzTmFtZT17cy5saW5rfT5BbGw8L2xpPlxyXG4gICAgICAgICAgICA8bGkgY2xhc3NOYW1lPXtzLmxpbmt9PnRlc3Q8L2xpPlxyXG4gICAgICAgICAgPC91bD5cclxuICAgICAgICA8L25hdj5cclxuXHJcbiAgICAgICAgPGRpdiBjbGFzc05hbWU9XCJzZWN0aW9uXCI+XHJcbiAgICAgICAgICA8UmVhY3RUYWJsZVxyXG4gICAgICAgICAgICAgIGRhdGE9e29yZGVyc31cclxuICAgICAgICAgICAgICBmaWx0ZXJhYmxlXHJcbiAgICAgICAgICAgICAgZGVmYXVsdEZpbHRlck1ldGhvZD17dGhpcy5kZWZhdWx0RmlsdGVyfVxyXG4gICAgICAgICAgICAgIGNvbHVtbnM9e2NvbHVtbnN9XHJcbiAgICAgICAgICAgICAgZGVmYXVsdFBhZ2VTaXplPXsyfVxyXG4gICAgICAgICAgICAgIGxvYWRpbmc9e2xvYWRpbmd9XHJcbiAgICAgICAgICAgICAgY2xhc3NOYW1lPVwiLXN0cmlwZWQgLWhpZ2hsaWdodFwiXHJcbiAgICAgICAgICAgIC8+XHJcbiAgICAgICAgPC9kaXY+XHJcbiAgICAgIDwvbWFpbj5cclxuICAgICk7XHJcbiAgfVxyXG59XHJcbiJdLCJzb3VyY2VSb290IjoiIn0=\n//# sourceURL=webpack-internal:///./src/components/orders/orders.js\n");

/***/ })

})