webpackHotUpdate("site",{

/***/ "./src/components/orders/orders.js":
/*!*****************************************!*\
  !*** ./src/components/orders/orders.js ***!
  \*****************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Orders; });\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react */ \"./node_modules/react/index.js\");\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var stores_orderStore__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! stores/orderStore */ \"./src/stores/orderStore.js\");\n/* harmony import */ var react_table__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! react-table */ \"./node_modules/react-table/es/index.js\");\nfunction _typeof(obj) { if (typeof Symbol === \"function\" && typeof Symbol.iterator === \"symbol\") { _typeof = function _typeof(obj) { return typeof obj; }; } else { _typeof = function _typeof(obj) { return obj && typeof Symbol === \"function\" && obj.constructor === Symbol && obj !== Symbol.prototype ? \"symbol\" : typeof obj; }; } return _typeof(obj); }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function\"); } _setPrototypeOf(subClass.prototype, superClass && superClass.prototype); if (superClass) _setPrototypeOf(subClass, superClass); }\n\nfunction _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }\n\nfunction _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }\n\nfunction _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }\n\nfunction _possibleConstructorReturn(self, call) { if (call && (_typeof(call) === \"object\" || typeof call === \"function\")) { return call; } return _assertThisInitialized(self); }\n\nfunction _getPrototypeOf(o) { _getPrototypeOf = Object.getPrototypeOf || function _getPrototypeOf(o) { return o.__proto__; }; return _getPrototypeOf(o); }\n\nfunction _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return self; }\n\n\n\n\n\nvar Orders =\n/*#__PURE__*/\nfunction (_Component) {\n  function Orders(props) {\n    var _this;\n\n    _classCallCheck(this, Orders);\n\n    _this = _possibleConstructorReturn(this, _getPrototypeOf(Orders).call(this, props));\n    _this.state = {\n      orders: [],\n      loading: true\n    };\n    _this.filterData = _this.filterData.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    return _this;\n  }\n\n  _createClass(Orders, [{\n    key: \"componentDidMount\",\n    value: function componentDidMount() {\n      var _this2 = this;\n\n      this.getOrders().then(function (orders) {\n        console.log(orders);\n\n        _this2.setState({\n          orders: orders,\n          loading: false\n        });\n      });\n    }\n  }, {\n    key: \"getOrders\",\n    value: function getOrders() {\n      return fetch('/umbraco/backoffice/ekom/managerapi/getorders', {\n        credentials: 'include'\n      }).then(function (response) {\n        return response.json();\n      }).then(function (result) {\n        return result;\n      });\n    }\n  }, {\n    key: \"filterData\",\n    value: function filterData(state, instance) {\n      console.log(state);\n      console.log(\"test\");\n    }\n  }, {\n    key: \"render\",\n    value: function render() {\n      var _this$state = this.state,\n          loading = _this$state.loading,\n          orders = _this$state.orders;\n      var columns = [{\n        Header: 'Orders',\n        columns: [{\n          Header: 'Order Number',\n          accessor: 'OrderNumber'\n        }, {\n          Header: 'Status',\n          accessor: 'OrderStatus'\n        }, {\n          Header: 'Email',\n          accessor: 'CustomerEmail'\n        }, {\n          Header: 'Name',\n          accessor: 'CustomerName'\n        }, {\n          Header: 'Country',\n          accessor: 'CustomerCountry'\n        }, {\n          Header: 'Created',\n          accessor: 'CreateDate'\n        }, {\n          Header: 'Paid',\n          accessor: 'PaidDate'\n        }, {\n          Header: 'Total',\n          accessor: 'TotalAmount'\n        }]\n      }];\n      return react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"main\", null, orders.length ? react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react_table__WEBPACK_IMPORTED_MODULE_2__[\"default\"], {\n        data: orders,\n        filterable: true,\n        columns: columns,\n        onFetchData: this.filterData,\n        defaultPageSize: 2,\n        loading: loading,\n        className: \"-striped -highlight\"\n      }) : null);\n    }\n  }]);\n\n  _inherits(Orders, _Component);\n\n  return Orders;\n}(react__WEBPACK_IMPORTED_MODULE_0__[\"Component\"]);\n\n//# sourceURL=[module]\n//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vLi9zcmMvY29tcG9uZW50cy9vcmRlcnMvb3JkZXJzLmpzPzA5OGYiXSwibmFtZXMiOlsiT3JkZXJzIiwicHJvcHMiLCJzdGF0ZSIsIm9yZGVycyIsImxvYWRpbmciLCJmaWx0ZXJEYXRhIiwiYmluZCIsImdldE9yZGVycyIsInRoZW4iLCJjb25zb2xlIiwibG9nIiwic2V0U3RhdGUiLCJmZXRjaCIsImNyZWRlbnRpYWxzIiwicmVzcG9uc2UiLCJqc29uIiwicmVzdWx0IiwiaW5zdGFuY2UiLCJjb2x1bW5zIiwiSGVhZGVyIiwiYWNjZXNzb3IiLCJsZW5ndGgiXSwibWFwcGluZ3MiOiI7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7OztBQUFBO0FBQ0E7QUFDQTs7SUFFcUJBLE07OztBQUVuQixrQkFBWUMsS0FBWixFQUFtQjtBQUFBOztBQUFBOztBQUNqQixnRkFBTUEsS0FBTjtBQUVBLFVBQUtDLEtBQUwsR0FBYTtBQUNYQyxjQUFRLEVBREc7QUFFWEMsZUFBUztBQUZFLEtBQWI7QUFJQSxVQUFLQyxVQUFMLEdBQWtCLE1BQUtBLFVBQUwsQ0FBZ0JDLElBQWhCLHVEQUFsQjtBQVBpQjtBQVFsQjs7Ozt3Q0FFbUI7QUFBQTs7QUFFbEIsV0FBS0MsU0FBTCxHQUFpQkMsSUFBakIsQ0FBc0IsVUFBQ0wsTUFBRCxFQUFZO0FBRWhDTSxnQkFBUUMsR0FBUixDQUFZUCxNQUFaOztBQUVBLGVBQUtRLFFBQUwsQ0FBYztBQUNaUixrQkFBUUEsTUFESTtBQUVaQyxtQkFBUztBQUZHLFNBQWQ7QUFLRCxPQVREO0FBVUQ7OztnQ0FFVztBQUNWLGFBQU9RLE1BQU0sK0NBQU4sRUFBdUQ7QUFDNURDLHFCQUFhO0FBRCtDLE9BQXZELEVBRUpMLElBRkksQ0FFQyxVQUFVTSxRQUFWLEVBQW9CO0FBQzFCLGVBQU9BLFNBQVNDLElBQVQsRUFBUDtBQUNELE9BSk0sRUFJSlAsSUFKSSxDQUlDLFVBQVVRLE1BQVYsRUFBa0I7QUFDeEIsZUFBT0EsTUFBUDtBQUNELE9BTk0sQ0FBUDtBQU9EOzs7K0JBQ1VkLEssRUFBT2UsUSxFQUFVO0FBRTFCUixjQUFRQyxHQUFSLENBQVlSLEtBQVo7QUFDQU8sY0FBUUMsR0FBUixDQUFZLE1BQVo7QUFDRDs7OzZCQUNRO0FBQUEsd0JBS0gsS0FBS1IsS0FMRjtBQUFBLFVBR0xFLE9BSEssZUFHTEEsT0FISztBQUFBLFVBSUxELE1BSkssZUFJTEEsTUFKSztBQU9QLFVBQUllLFVBQVUsQ0FDWjtBQUNFQyxnQkFBUSxRQURWO0FBRUVELGlCQUFTLENBQ1A7QUFDRUMsa0JBQVEsY0FEVjtBQUVFQyxvQkFBVTtBQUZaLFNBRE8sRUFLUDtBQUNFRCxrQkFBUSxRQURWO0FBRUVDLG9CQUFVO0FBRlosU0FMTyxFQVNQO0FBQ0VELGtCQUFRLE9BRFY7QUFFRUMsb0JBQVU7QUFGWixTQVRPLEVBYVA7QUFDRUQsa0JBQVEsTUFEVjtBQUVFQyxvQkFBVTtBQUZaLFNBYk8sRUFpQlA7QUFDRUQsa0JBQVEsU0FEVjtBQUVFQyxvQkFBVTtBQUZaLFNBakJPLEVBcUJQO0FBQ0VELGtCQUFRLFNBRFY7QUFFRUMsb0JBQVU7QUFGWixTQXJCTyxFQXlCUDtBQUNFRCxrQkFBUSxNQURWO0FBRUVDLG9CQUFVO0FBRlosU0F6Qk8sRUE2QlA7QUFDRUQsa0JBQVEsT0FEVjtBQUVFQyxvQkFBVTtBQUZaLFNBN0JPO0FBRlgsT0FEWSxDQUFkO0FBd0NBLGFBQ0UseUVBQ0dqQixPQUFPa0IsTUFBUCxHQUNDLDJEQUFDLG1EQUFEO0FBQ0UsY0FBTWxCLE1BRFI7QUFFRSx3QkFGRjtBQUdFLGlCQUFTZSxPQUhYO0FBSUUscUJBQWEsS0FBS2IsVUFKcEI7QUFLRSx5QkFBaUIsQ0FMbkI7QUFNRSxpQkFBU0QsT0FOWDtBQU9FLG1CQUFVO0FBUFosUUFERCxHQVVDLElBWEosQ0FERjtBQWVEOzs7Ozs7RUF0R2lDLCtDIiwiZmlsZSI6Ii4vc3JjL2NvbXBvbmVudHMvb3JkZXJzL29yZGVycy5qcy5qcyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCBSZWFjdCwgeyBDb21wb25lbnQgfSBmcm9tICdyZWFjdCc7XHJcbmltcG9ydCBvcmRlclN0b3JlIGZyb20gJ3N0b3Jlcy9vcmRlclN0b3JlJztcclxuaW1wb3J0IFJlYWN0VGFibGUgZnJvbSAncmVhY3QtdGFibGUnO1xyXG5cclxuZXhwb3J0IGRlZmF1bHQgY2xhc3MgT3JkZXJzIGV4dGVuZHMgQ29tcG9uZW50IHtcclxuXHJcbiAgY29uc3RydWN0b3IocHJvcHMpIHtcclxuICAgIHN1cGVyKHByb3BzKTtcclxuXHJcbiAgICB0aGlzLnN0YXRlID0ge1xyXG4gICAgICBvcmRlcnM6IFtdLFxyXG4gICAgICBsb2FkaW5nOiB0cnVlLFxyXG4gICAgfVxyXG4gICAgdGhpcy5maWx0ZXJEYXRhID0gdGhpcy5maWx0ZXJEYXRhLmJpbmQodGhpcyk7XHJcbiAgfSAgXHJcblxyXG4gIGNvbXBvbmVudERpZE1vdW50KCkge1xyXG5cclxuICAgIHRoaXMuZ2V0T3JkZXJzKCkudGhlbigob3JkZXJzKSA9PiB7XHJcblxyXG4gICAgICBjb25zb2xlLmxvZyhvcmRlcnMpO1xyXG5cclxuICAgICAgdGhpcy5zZXRTdGF0ZSh7XHJcbiAgICAgICAgb3JkZXJzOiBvcmRlcnMsXHJcbiAgICAgICAgbG9hZGluZzogZmFsc2UsXHJcbiAgICAgIH0pO1xyXG5cclxuICAgIH0pO1xyXG4gIH1cclxuXHJcbiAgZ2V0T3JkZXJzKCkge1xyXG4gICAgcmV0dXJuIGZldGNoKCcvdW1icmFjby9iYWNrb2ZmaWNlL2Vrb20vbWFuYWdlcmFwaS9nZXRvcmRlcnMnLCB7XHJcbiAgICAgIGNyZWRlbnRpYWxzOiAnaW5jbHVkZScsXHJcbiAgICB9KS50aGVuKGZ1bmN0aW9uIChyZXNwb25zZSkge1xyXG4gICAgICByZXR1cm4gcmVzcG9uc2UuanNvbigpO1xyXG4gICAgfSkudGhlbihmdW5jdGlvbiAocmVzdWx0KSB7XHJcbiAgICAgIHJldHVybiByZXN1bHQ7XHJcbiAgICB9KTtcclxuICB9XHJcbiAgZmlsdGVyRGF0YShzdGF0ZSwgaW5zdGFuY2UpIHtcclxuXHJcbiAgICBjb25zb2xlLmxvZyhzdGF0ZSk7XHJcbiAgICBjb25zb2xlLmxvZyhcInRlc3RcIilcclxuICB9XHJcbiAgcmVuZGVyKCkge1xyXG5cclxuICAgIGNvbnN0IHtcclxuICAgICAgbG9hZGluZyxcclxuICAgICAgb3JkZXJzLFxyXG4gICAgfSA9IHRoaXMuc3RhdGU7XHJcblxyXG4gICAgdmFyIGNvbHVtbnMgPSBbXHJcbiAgICAgIHtcclxuICAgICAgICBIZWFkZXI6ICdPcmRlcnMnLFxyXG4gICAgICAgIGNvbHVtbnM6IFtcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnT3JkZXIgTnVtYmVyJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdPcmRlck51bWJlcicsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdTdGF0dXMnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ09yZGVyU3RhdHVzJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ0VtYWlsJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdDdXN0b21lckVtYWlsJyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ05hbWUnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ0N1c3RvbWVyTmFtZScsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdDb3VudHJ5JyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdDdXN0b21lckNvdW50cnknLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnQ3JlYXRlZCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnQ3JlYXRlRGF0ZScsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdQYWlkJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdQYWlkRGF0ZScsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdUb3RhbCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnVG90YWxBbW91bnQnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICBdLFxyXG4gICAgICB9LFxyXG4gICAgXTtcclxuXHJcbiAgICByZXR1cm4gKFxyXG4gICAgICA8bWFpbj5cclxuICAgICAgICB7b3JkZXJzLmxlbmd0aFxyXG4gICAgICAgID8gPFJlYWN0VGFibGVcclxuICAgICAgICAgICAgZGF0YT17b3JkZXJzfVxyXG4gICAgICAgICAgICBmaWx0ZXJhYmxlXHJcbiAgICAgICAgICAgIGNvbHVtbnM9e2NvbHVtbnN9XHJcbiAgICAgICAgICAgIG9uRmV0Y2hEYXRhPXt0aGlzLmZpbHRlckRhdGF9XHJcbiAgICAgICAgICAgIGRlZmF1bHRQYWdlU2l6ZT17Mn1cclxuICAgICAgICAgICAgbG9hZGluZz17bG9hZGluZ31cclxuICAgICAgICAgICAgY2xhc3NOYW1lPVwiLXN0cmlwZWQgLWhpZ2hsaWdodFwiXHJcbiAgICAgICAgICAvPlxyXG4gICAgICAgIDogbnVsbH1cclxuICAgICAgPC9tYWluPlxyXG4gICAgKTtcclxuICB9XHJcbn1cclxuIl0sInNvdXJjZVJvb3QiOiIifQ==\n//# sourceURL=webpack-internal:///./src/components/orders/orders.js\n");

/***/ })

})