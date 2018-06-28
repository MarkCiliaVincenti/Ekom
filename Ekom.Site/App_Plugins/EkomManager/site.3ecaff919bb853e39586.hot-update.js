webpackHotUpdate("site",{

/***/ "./src/components/orders/orders.js":
/*!*****************************************!*\
  !*** ./src/components/orders/orders.js ***!
  \*****************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Orders; });\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react */ \"./node_modules/react/index.js\");\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var stores_orderStore__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! stores/orderStore */ \"./src/stores/orderStore.js\");\n/* harmony import */ var react_table__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! react-table */ \"./node_modules/react-table/es/index.js\");\nfunction _typeof(obj) { if (typeof Symbol === \"function\" && typeof Symbol.iterator === \"symbol\") { _typeof = function _typeof(obj) { return typeof obj; }; } else { _typeof = function _typeof(obj) { return obj && typeof Symbol === \"function\" && obj.constructor === Symbol && obj !== Symbol.prototype ? \"symbol\" : typeof obj; }; } return _typeof(obj); }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function\"); } _setPrototypeOf(subClass.prototype, superClass && superClass.prototype); if (superClass) _setPrototypeOf(subClass, superClass); }\n\nfunction _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }\n\nfunction _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }\n\nfunction _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }\n\nfunction _possibleConstructorReturn(self, call) { if (call && (_typeof(call) === \"object\" || typeof call === \"function\")) { return call; } return _assertThisInitialized(self); }\n\nfunction _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return self; }\n\nfunction _getPrototypeOf(o) { _getPrototypeOf = Object.getPrototypeOf || function _getPrototypeOf(o) { return o.__proto__; }; return _getPrototypeOf(o); }\n\n\n\n\n\nvar Orders =\n/*#__PURE__*/\nfunction (_Component) {\n  function Orders(props) {\n    var _this;\n\n    _classCallCheck(this, Orders);\n\n    _this = _possibleConstructorReturn(this, _getPrototypeOf(Orders).call(this, props));\n    _this.state = {\n      orders: [],\n      loading: true\n    };\n    return _this;\n  }\n\n  _createClass(Orders, [{\n    key: \"componentDidMount\",\n    value: function componentDidMount() {\n      var _this2 = this;\n\n      this.getOrders().then(function (orders) {\n        console.log(orders);\n\n        _this2.setState({\n          orders: orders,\n          loading: false\n        });\n      });\n    }\n  }, {\n    key: \"getOrders\",\n    value: function getOrders() {\n      return fetch('/umbraco/backoffice/ekom/managerapi/getorders', {\n        credentials: 'include'\n      }).then(function (response) {\n        return response.json();\n      }).then(function (result) {\n        return result;\n      });\n    }\n  }, {\n    key: \"render\",\n    value: function render() {\n      var _this$state = this.state,\n          loading = _this$state.loading,\n          orders = _this$state.orders;\n      var columns = [{\n        Header: 'Orders',\n        columns: [{\n          Header: 'OrderNumber',\n          accessor: 'OrderNumber'\n        }, {\n          Header: 'Status',\n          accessor: 'OrderStatus'\n        }, {\n          Header: 'Email',\n          accessor: 'CustomerEmail'\n        }, {\n          Header: 'Name',\n          accessor: 'CustomerName'\n        }, {\n          Header: 'Country',\n          accessor: 'CustomerCountry'\n        }, {\n          Header: 'Created',\n          accessor: 'CreateDate'\n        }, {\n          Header: 'Paid',\n          accessor: 'PaidDate'\n        }, {\n          Header: 'Total',\n          accessor: 'TotalAmount'\n        }]\n      }];\n      return react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"main\", null, orders.length ? react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react_table__WEBPACK_IMPORTED_MODULE_2__[\"default\"], {\n        data: orders,\n        filterable: true,\n        columns: columns,\n        defaultPageSize: 2,\n        loading: loading,\n        className: \"-striped -highlight\"\n      }) : null);\n    }\n  }]);\n\n  _inherits(Orders, _Component);\n\n  return Orders;\n}(react__WEBPACK_IMPORTED_MODULE_0__[\"Component\"]);\n\n//# sourceURL=[module]\n//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vLi9zcmMvY29tcG9uZW50cy9vcmRlcnMvb3JkZXJzLmpzPzA5OGYiXSwibmFtZXMiOlsiT3JkZXJzIiwicHJvcHMiLCJzdGF0ZSIsIm9yZGVycyIsImxvYWRpbmciLCJnZXRPcmRlcnMiLCJ0aGVuIiwiY29uc29sZSIsImxvZyIsInNldFN0YXRlIiwiZmV0Y2giLCJjcmVkZW50aWFscyIsInJlc3BvbnNlIiwianNvbiIsInJlc3VsdCIsImNvbHVtbnMiLCJIZWFkZXIiLCJhY2Nlc3NvciIsImxlbmd0aCJdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7O0FBQUE7QUFDQTtBQUNBOztJQUVxQkEsTTs7O0FBRW5CLGtCQUFZQyxLQUFaLEVBQW1CO0FBQUE7O0FBQUE7O0FBQ2pCLGdGQUFNQSxLQUFOO0FBRUEsVUFBS0MsS0FBTCxHQUFhO0FBQ1hDLGNBQVEsRUFERztBQUVYQyxlQUFTO0FBRkUsS0FBYjtBQUhpQjtBQU9sQjs7Ozt3Q0FFbUI7QUFBQTs7QUFFbEIsV0FBS0MsU0FBTCxHQUFpQkMsSUFBakIsQ0FBc0IsVUFBQ0gsTUFBRCxFQUFZO0FBRWhDSSxnQkFBUUMsR0FBUixDQUFZTCxNQUFaOztBQUVBLGVBQUtNLFFBQUwsQ0FBYztBQUNaTixrQkFBUUEsTUFESTtBQUVaQyxtQkFBUztBQUZHLFNBQWQ7QUFLRCxPQVREO0FBVUQ7OztnQ0FFVztBQUNWLGFBQU9NLE1BQU0sK0NBQU4sRUFBdUQ7QUFDNURDLHFCQUFhO0FBRCtDLE9BQXZELEVBRUpMLElBRkksQ0FFQyxVQUFVTSxRQUFWLEVBQW9CO0FBQzFCLGVBQU9BLFNBQVNDLElBQVQsRUFBUDtBQUNELE9BSk0sRUFJSlAsSUFKSSxDQUlDLFVBQVVRLE1BQVYsRUFBa0I7QUFDeEIsZUFBT0EsTUFBUDtBQUNELE9BTk0sQ0FBUDtBQU9EOzs7NkJBRVE7QUFBQSx3QkFLSCxLQUFLWixLQUxGO0FBQUEsVUFHTEUsT0FISyxlQUdMQSxPQUhLO0FBQUEsVUFJTEQsTUFKSyxlQUlMQSxNQUpLO0FBT1AsVUFBSVksVUFBVSxDQUNaO0FBQ0VDLGdCQUFRLFFBRFY7QUFFRUQsaUJBQVMsQ0FDUDtBQUNFQyxrQkFBUSxhQURWO0FBRUVDLG9CQUFVO0FBRlosU0FETyxFQUtQO0FBQ0VELGtCQUFRLFFBRFY7QUFFRUMsb0JBQVU7QUFGWixTQUxPLEVBU1A7QUFDRUQsa0JBQVEsT0FEVjtBQUVFQyxvQkFBVTtBQUZaLFNBVE8sRUFhUDtBQUNFRCxrQkFBUSxNQURWO0FBRUVDLG9CQUFVO0FBRlosU0FiTyxFQWlCUDtBQUNFRCxrQkFBUSxTQURWO0FBRUVDLG9CQUFVO0FBRlosU0FqQk8sRUFxQlA7QUFDRUQsa0JBQVEsU0FEVjtBQUVFQyxvQkFBVTtBQUZaLFNBckJPLEVBeUJQO0FBQ0VELGtCQUFRLE1BRFY7QUFFRUMsb0JBQVU7QUFGWixTQXpCTyxFQTZCUDtBQUNFRCxrQkFBUSxPQURWO0FBRUVDLG9CQUFVO0FBRlosU0E3Qk87QUFGWCxPQURZLENBQWQ7QUF3Q0EsYUFDRSx5RUFDR2QsT0FBT2UsTUFBUCxHQUNDLDJEQUFDLG1EQUFEO0FBQ0UsY0FBTWYsTUFEUjtBQUVFLHdCQUZGO0FBR0UsaUJBQVNZLE9BSFg7QUFJRSx5QkFBaUIsQ0FKbkI7QUFLRSxpQkFBU1gsT0FMWDtBQU1FLG1CQUFVO0FBTlosUUFERCxHQVNDLElBVkosQ0FERjtBQWNEOzs7Ozs7RUFoR2lDLCtDIiwiZmlsZSI6Ii4vc3JjL2NvbXBvbmVudHMvb3JkZXJzL29yZGVycy5qcy5qcyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCBSZWFjdCwgeyBDb21wb25lbnQgfSBmcm9tICdyZWFjdCc7XHJcbmltcG9ydCBvcmRlclN0b3JlIGZyb20gJ3N0b3Jlcy9vcmRlclN0b3JlJztcclxuaW1wb3J0IFJlYWN0VGFibGUgZnJvbSAncmVhY3QtdGFibGUnO1xyXG5cclxuZXhwb3J0IGRlZmF1bHQgY2xhc3MgT3JkZXJzIGV4dGVuZHMgQ29tcG9uZW50IHtcclxuXHJcbiAgY29uc3RydWN0b3IocHJvcHMpIHtcclxuICAgIHN1cGVyKHByb3BzKTtcclxuXHJcbiAgICB0aGlzLnN0YXRlID0ge1xyXG4gICAgICBvcmRlcnM6IFtdLFxyXG4gICAgICBsb2FkaW5nOiB0cnVlLFxyXG4gICAgfVxyXG4gIH0gIFxyXG5cclxuICBjb21wb25lbnREaWRNb3VudCgpIHtcclxuXHJcbiAgICB0aGlzLmdldE9yZGVycygpLnRoZW4oKG9yZGVycykgPT4ge1xyXG5cclxuICAgICAgY29uc29sZS5sb2cob3JkZXJzKTtcclxuXHJcbiAgICAgIHRoaXMuc2V0U3RhdGUoe1xyXG4gICAgICAgIG9yZGVyczogb3JkZXJzLFxyXG4gICAgICAgIGxvYWRpbmc6IGZhbHNlLFxyXG4gICAgICB9KTtcclxuXHJcbiAgICB9KTtcclxuICB9XHJcblxyXG4gIGdldE9yZGVycygpIHtcclxuICAgIHJldHVybiBmZXRjaCgnL3VtYnJhY28vYmFja29mZmljZS9la29tL21hbmFnZXJhcGkvZ2V0b3JkZXJzJywge1xyXG4gICAgICBjcmVkZW50aWFsczogJ2luY2x1ZGUnLFxyXG4gICAgfSkudGhlbihmdW5jdGlvbiAocmVzcG9uc2UpIHtcclxuICAgICAgcmV0dXJuIHJlc3BvbnNlLmpzb24oKTtcclxuICAgIH0pLnRoZW4oZnVuY3Rpb24gKHJlc3VsdCkge1xyXG4gICAgICByZXR1cm4gcmVzdWx0O1xyXG4gICAgfSk7XHJcbiAgfVxyXG5cclxuICByZW5kZXIoKSB7XHJcblxyXG4gICAgY29uc3Qge1xyXG4gICAgICBsb2FkaW5nLFxyXG4gICAgICBvcmRlcnMsXHJcbiAgICB9ID0gdGhpcy5zdGF0ZTtcclxuXHJcbiAgICB2YXIgY29sdW1ucyA9IFtcclxuICAgICAge1xyXG4gICAgICAgIEhlYWRlcjogJ09yZGVycycsXHJcbiAgICAgICAgY29sdW1uczogW1xyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdPcmRlck51bWJlcicsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnT3JkZXJOdW1iZXInLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnU3RhdHVzJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdPcmRlclN0YXR1cycsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdFbWFpbCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnQ3VzdG9tZXJFbWFpbCcsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdOYW1lJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdDdXN0b21lck5hbWUnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnQ291bnRyeScsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnQ3VzdG9tZXJDb3VudHJ5JyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ0NyZWF0ZWQnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ0NyZWF0ZURhdGUnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnUGFpZCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnUGFpZERhdGUnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnVG90YWwnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ1RvdGFsQW1vdW50JyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgXSxcclxuICAgICAgfSxcclxuICAgIF07XHJcblxyXG4gICAgcmV0dXJuIChcclxuICAgICAgPG1haW4+XHJcbiAgICAgICAge29yZGVycy5sZW5ndGhcclxuICAgICAgICA/IDxSZWFjdFRhYmxlXHJcbiAgICAgICAgICAgIGRhdGE9e29yZGVyc31cclxuICAgICAgICAgICAgZmlsdGVyYWJsZVxyXG4gICAgICAgICAgICBjb2x1bW5zPXtjb2x1bW5zfVxyXG4gICAgICAgICAgICBkZWZhdWx0UGFnZVNpemU9ezJ9XHJcbiAgICAgICAgICAgIGxvYWRpbmc9e2xvYWRpbmd9XHJcbiAgICAgICAgICAgIGNsYXNzTmFtZT1cIi1zdHJpcGVkIC1oaWdobGlnaHRcIlxyXG4gICAgICAgICAgLz5cclxuICAgICAgICA6IG51bGx9XHJcbiAgICAgIDwvbWFpbj5cclxuICAgICk7XHJcbiAgfVxyXG59XHJcbiJdLCJzb3VyY2VSb290IjoiIn0=\n//# sourceURL=webpack-internal:///./src/components/orders/orders.js\n");

/***/ })

})