webpackHotUpdate("site",{

/***/ "./src/components/orders/orders.js":
/*!*****************************************!*\
  !*** ./src/components/orders/orders.js ***!
  \*****************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return Orders; });\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react */ \"./node_modules/react/index.js\");\n/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! lodash */ \"./node_modules/lodash/lodash.js\");\n/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(lodash__WEBPACK_IMPORTED_MODULE_1__);\n/* harmony import */ var stores_orderStore__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! stores/orderStore */ \"./src/stores/orderStore.js\");\n/* harmony import */ var react_table__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! react-table */ \"./node_modules/react-table/es/index.js\");\nfunction _typeof(obj) { if (typeof Symbol === \"function\" && typeof Symbol.iterator === \"symbol\") { _typeof = function _typeof(obj) { return typeof obj; }; } else { _typeof = function _typeof(obj) { return obj && typeof Symbol === \"function\" && obj.constructor === Symbol && obj !== Symbol.prototype ? \"symbol\" : typeof obj; }; } return _typeof(obj); }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function\"); } _setPrototypeOf(subClass.prototype, superClass && superClass.prototype); if (superClass) _setPrototypeOf(subClass, superClass); }\n\nfunction _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }\n\nfunction _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }\n\nfunction _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }\n\nfunction _possibleConstructorReturn(self, call) { if (call && (_typeof(call) === \"object\" || typeof call === \"function\")) { return call; } return _assertThisInitialized(self); }\n\nfunction _getPrototypeOf(o) { _getPrototypeOf = Object.getPrototypeOf || function _getPrototypeOf(o) { return o.__proto__; }; return _getPrototypeOf(o); }\n\nfunction _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return self; }\n\n\n\n\n\n\nvar Orders =\n/*#__PURE__*/\nfunction (_Component) {\n  function Orders(props) {\n    var _this;\n\n    _classCallCheck(this, Orders);\n\n    _this = _possibleConstructorReturn(this, _getPrototypeOf(Orders).call(this, props));\n    _this.state = {\n      defaultData: [],\n      orders: [],\n      pages: null,\n      loading: true\n    };\n    _this.dataChange = _this.dataChange.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    _this.updateData = _this.updateData.bind(_assertThisInitialized(_assertThisInitialized(_this)));\n    return _this;\n  }\n\n  _createClass(Orders, [{\n    key: \"componentDidMount\",\n    value: function componentDidMount() {\n      var _this2 = this;\n\n      this.getOrders().then(function (orders) {\n        console.log(orders);\n\n        _this2.setState({\n          defaultData: orders,\n          orders: orders,\n          loading: false\n        });\n      });\n    }\n  }, {\n    key: \"getOrders\",\n    value: function getOrders() {\n      return fetch('/umbraco/backoffice/ekom/managerapi/getorders', {\n        credentials: 'include'\n      }).then(function (response) {\n        return response.json();\n      }).then(function (result) {\n        return result;\n      });\n    }\n  }, {\n    key: \"dataChange\",\n    value: function dataChange(state, instance) {\n      console.log(state);\n    }\n  }, {\n    key: \"updateData\",\n    value: function updateData(pageSize, page, sorted, filtered) {\n      var _this3 = this;\n\n      return new Promise(function (resolve, reject) {\n        // You can retrieve your data however you want, in this case, we will just use some local data.\n        var filteredData = _this3.state.defaultData; // You can use the filters in your request, but you are responsible for applying them.\n\n        if (filtered.length) {\n          filteredData = filtered.reduce(function (filteredSoFar, nextFilter) {\n            return filteredSoFar.filter(function (row) {\n              return (row[nextFilter.id] + \"\").includes(nextFilter.value);\n            });\n          }, filteredData);\n        } // You can also use the sorting in your request, but again, you are responsible for applying it.\n\n\n        var sortedData = lodash__WEBPACK_IMPORTED_MODULE_1___default.a.orderBy(filteredData, sorted.map(function (sort) {\n          return function (row) {\n            if (row[sort.id] === null || row[sort.id] === undefined) {\n              return -Infinity;\n            }\n\n            return typeof row[sort.id] === \"string\" ? row[sort.id].toLowerCase() : row[sort.id];\n          };\n        }), sorted.map(function (d) {\n          return d.desc ? \"desc\" : \"asc\";\n        })); // You must return an object containing the rows of the current page, and optionally the total pages number.\n\n\n        var res = {\n          rows: sortedData.slice(pageSize * page, pageSize * page + pageSize),\n          pages: Math.ceil(filteredData.length / pageSize)\n        }; // Here we'll simulate a server response with 500ms of delay.\n\n        setTimeout(function () {\n          return resolve(res);\n        }, 500);\n      });\n    }\n  }, {\n    key: \"render\",\n    value: function render() {\n      var _this$state = this.state,\n          loading = _this$state.loading,\n          defaultData = _this$state.defaultData,\n          orders = _this$state.orders,\n          pages = _this$state.pages;\n      var columns = [{\n        Header: 'Orders',\n        columns: [{\n          Header: 'Order Number',\n          accessor: 'OrderNumber'\n        }, {\n          Header: 'Status',\n          accessor: 'OrderStatus'\n        }, {\n          Header: 'Email',\n          accessor: 'CustomerEmail'\n        }, {\n          Header: 'Name',\n          accessor: 'CustomerName'\n        }, {\n          Header: 'Country',\n          accessor: 'CustomerCountry'\n        }, {\n          Header: 'Created',\n          accessor: 'CreateDate'\n        }, {\n          Header: 'Paid',\n          accessor: 'PaidDate'\n        }, {\n          Header: 'Total',\n          accessor: 'TotalAmount'\n        }]\n      }];\n      return react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(\"main\", null, react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react_table__WEBPACK_IMPORTED_MODULE_3__[\"default\"], {\n        data: orders,\n        filterable: true,\n        pages: pages,\n        columns: columns,\n        onFilteredChange: this.dataChange,\n        defaultPageSize: 2,\n        loading: loading,\n        className: \"-striped -highlight\"\n      }));\n    }\n  }]);\n\n  _inherits(Orders, _Component);\n\n  return Orders;\n}(react__WEBPACK_IMPORTED_MODULE_0__[\"Component\"]);\n\n//# sourceURL=[module]\n//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vLi9zcmMvY29tcG9uZW50cy9vcmRlcnMvb3JkZXJzLmpzPzA5OGYiXSwibmFtZXMiOlsiT3JkZXJzIiwicHJvcHMiLCJzdGF0ZSIsImRlZmF1bHREYXRhIiwib3JkZXJzIiwicGFnZXMiLCJsb2FkaW5nIiwiZGF0YUNoYW5nZSIsImJpbmQiLCJ1cGRhdGVEYXRhIiwiZ2V0T3JkZXJzIiwidGhlbiIsImNvbnNvbGUiLCJsb2ciLCJzZXRTdGF0ZSIsImZldGNoIiwiY3JlZGVudGlhbHMiLCJyZXNwb25zZSIsImpzb24iLCJyZXN1bHQiLCJpbnN0YW5jZSIsInBhZ2VTaXplIiwicGFnZSIsInNvcnRlZCIsImZpbHRlcmVkIiwiUHJvbWlzZSIsInJlc29sdmUiLCJyZWplY3QiLCJmaWx0ZXJlZERhdGEiLCJsZW5ndGgiLCJyZWR1Y2UiLCJmaWx0ZXJlZFNvRmFyIiwibmV4dEZpbHRlciIsImZpbHRlciIsInJvdyIsImlkIiwiaW5jbHVkZXMiLCJ2YWx1ZSIsInNvcnRlZERhdGEiLCJfIiwib3JkZXJCeSIsIm1hcCIsInNvcnQiLCJ1bmRlZmluZWQiLCJJbmZpbml0eSIsInRvTG93ZXJDYXNlIiwiZCIsImRlc2MiLCJyZXMiLCJyb3dzIiwic2xpY2UiLCJNYXRoIiwiY2VpbCIsInNldFRpbWVvdXQiLCJjb2x1bW5zIiwiSGVhZGVyIiwiYWNjZXNzb3IiXSwibWFwcGluZ3MiOiI7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7O0FBQUE7QUFDQTtBQUNBO0FBQ0E7O0lBRXFCQSxNOzs7QUFFbkIsa0JBQVlDLEtBQVosRUFBbUI7QUFBQTs7QUFBQTs7QUFDakIsZ0ZBQU1BLEtBQU47QUFFQSxVQUFLQyxLQUFMLEdBQWE7QUFDWEMsbUJBQWEsRUFERjtBQUVYQyxjQUFRLEVBRkc7QUFHWEMsYUFBTyxJQUhJO0FBSVhDLGVBQVM7QUFKRSxLQUFiO0FBTUEsVUFBS0MsVUFBTCxHQUFrQixNQUFLQSxVQUFMLENBQWdCQyxJQUFoQix1REFBbEI7QUFDQSxVQUFLQyxVQUFMLEdBQWtCLE1BQUtBLFVBQUwsQ0FBZ0JELElBQWhCLHVEQUFsQjtBQVZpQjtBQVdsQjs7Ozt3Q0FFbUI7QUFBQTs7QUFFbEIsV0FBS0UsU0FBTCxHQUFpQkMsSUFBakIsQ0FBc0IsVUFBQ1AsTUFBRCxFQUFZO0FBRWhDUSxnQkFBUUMsR0FBUixDQUFZVCxNQUFaOztBQUVBLGVBQUtVLFFBQUwsQ0FBYztBQUNaWCx1QkFBYUMsTUFERDtBQUVaQSxrQkFBUUEsTUFGSTtBQUdaRSxtQkFBUztBQUhHLFNBQWQ7QUFNRCxPQVZEO0FBV0Q7OztnQ0FFVztBQUNWLGFBQU9TLE1BQU0sK0NBQU4sRUFBdUQ7QUFDNURDLHFCQUFhO0FBRCtDLE9BQXZELEVBRUpMLElBRkksQ0FFQyxVQUFVTSxRQUFWLEVBQW9CO0FBQzFCLGVBQU9BLFNBQVNDLElBQVQsRUFBUDtBQUNELE9BSk0sRUFJSlAsSUFKSSxDQUlDLFVBQVVRLE1BQVYsRUFBa0I7QUFDeEIsZUFBT0EsTUFBUDtBQUNELE9BTk0sQ0FBUDtBQU9EOzs7K0JBQ1VqQixLLEVBQU9rQixRLEVBQVU7QUFDMUJSLGNBQVFDLEdBQVIsQ0FBWVgsS0FBWjtBQUNEOzs7K0JBQ1VtQixRLEVBQVVDLEksRUFBTUMsTSxFQUFRQyxRLEVBQVU7QUFBQTs7QUFDM0MsYUFBTyxJQUFJQyxPQUFKLENBQVksVUFBQ0MsT0FBRCxFQUFVQyxNQUFWLEVBQXFCO0FBQ3RDO0FBQ0EsWUFBSUMsZUFBZSxPQUFLMUIsS0FBTCxDQUFXQyxXQUE5QixDQUZzQyxDQUl0Qzs7QUFDQSxZQUFJcUIsU0FBU0ssTUFBYixFQUFxQjtBQUNuQkQseUJBQWVKLFNBQVNNLE1BQVQsQ0FBZ0IsVUFBQ0MsYUFBRCxFQUFnQkMsVUFBaEIsRUFBK0I7QUFDNUQsbUJBQU9ELGNBQWNFLE1BQWQsQ0FBcUIsZUFBTztBQUNqQyxxQkFBTyxDQUFDQyxJQUFJRixXQUFXRyxFQUFmLElBQXFCLEVBQXRCLEVBQTBCQyxRQUExQixDQUFtQ0osV0FBV0ssS0FBOUMsQ0FBUDtBQUNELGFBRk0sQ0FBUDtBQUdELFdBSmMsRUFJWlQsWUFKWSxDQUFmO0FBS0QsU0FYcUMsQ0FZdEM7OztBQUNBLFlBQU1VLGFBQWEsNkNBQUFDLENBQUVDLE9BQUYsQ0FDakJaLFlBRGlCLEVBRWpCTCxPQUFPa0IsR0FBUCxDQUFXLGdCQUFRO0FBQ2pCLGlCQUFPLGVBQU87QUFDWixnQkFBSVAsSUFBSVEsS0FBS1AsRUFBVCxNQUFpQixJQUFqQixJQUF5QkQsSUFBSVEsS0FBS1AsRUFBVCxNQUFpQlEsU0FBOUMsRUFBeUQ7QUFDdkQscUJBQU8sQ0FBQ0MsUUFBUjtBQUNEOztBQUNELG1CQUFPLE9BQU9WLElBQUlRLEtBQUtQLEVBQVQsQ0FBUCxLQUF3QixRQUF4QixHQUNIRCxJQUFJUSxLQUFLUCxFQUFULEVBQWFVLFdBQWIsRUFERyxHQUVIWCxJQUFJUSxLQUFLUCxFQUFULENBRko7QUFHRCxXQVBEO0FBUUQsU0FURCxDQUZpQixFQVlqQlosT0FBT2tCLEdBQVAsQ0FBVztBQUFBLGlCQUFNSyxFQUFFQyxJQUFGLEdBQVMsTUFBVCxHQUFrQixLQUF4QjtBQUFBLFNBQVgsQ0FaaUIsQ0FBbkIsQ0Fic0MsQ0E0QnRDOzs7QUFDQSxZQUFNQyxNQUFNO0FBQ1ZDLGdCQUFNWCxXQUFXWSxLQUFYLENBQWlCN0IsV0FBV0MsSUFBNUIsRUFBa0NELFdBQVdDLElBQVgsR0FBa0JELFFBQXBELENBREk7QUFFVmhCLGlCQUFPOEMsS0FBS0MsSUFBTCxDQUFVeEIsYUFBYUMsTUFBYixHQUFzQlIsUUFBaEM7QUFGRyxTQUFaLENBN0JzQyxDQWtDdEM7O0FBQ0FnQyxtQkFBVztBQUFBLGlCQUFNM0IsUUFBUXNCLEdBQVIsQ0FBTjtBQUFBLFNBQVgsRUFBK0IsR0FBL0I7QUFDRCxPQXBDTSxDQUFQO0FBcUNEOzs7NkJBQ1E7QUFBQSx3QkFPSCxLQUFLOUMsS0FQRjtBQUFBLFVBR0xJLE9BSEssZUFHTEEsT0FISztBQUFBLFVBSUxILFdBSkssZUFJTEEsV0FKSztBQUFBLFVBS0xDLE1BTEssZUFLTEEsTUFMSztBQUFBLFVBTUxDLEtBTkssZUFNTEEsS0FOSztBQVNQLFVBQUlpRCxVQUFVLENBQ1o7QUFDRUMsZ0JBQVEsUUFEVjtBQUVFRCxpQkFBUyxDQUNQO0FBQ0VDLGtCQUFRLGNBRFY7QUFFRUMsb0JBQVU7QUFGWixTQURPLEVBS1A7QUFDRUQsa0JBQVEsUUFEVjtBQUVFQyxvQkFBVTtBQUZaLFNBTE8sRUFTUDtBQUNFRCxrQkFBUSxPQURWO0FBRUVDLG9CQUFVO0FBRlosU0FUTyxFQWFQO0FBQ0VELGtCQUFRLE1BRFY7QUFFRUMsb0JBQVU7QUFGWixTQWJPLEVBaUJQO0FBQ0VELGtCQUFRLFNBRFY7QUFFRUMsb0JBQVU7QUFGWixTQWpCTyxFQXFCUDtBQUNFRCxrQkFBUSxTQURWO0FBRUVDLG9CQUFVO0FBRlosU0FyQk8sRUF5QlA7QUFDRUQsa0JBQVEsTUFEVjtBQUVFQyxvQkFBVTtBQUZaLFNBekJPLEVBNkJQO0FBQ0VELGtCQUFRLE9BRFY7QUFFRUMsb0JBQVU7QUFGWixTQTdCTztBQUZYLE9BRFksQ0FBZDtBQXdDQSxhQUNFLHlFQUNFLDJEQUFDLG1EQUFEO0FBQ0ksY0FBTXBELE1BRFY7QUFFSSx3QkFGSjtBQUdJLGVBQU9DLEtBSFg7QUFJSSxpQkFBU2lELE9BSmI7QUFLSSwwQkFBa0IsS0FBSy9DLFVBTDNCO0FBTUkseUJBQWlCLENBTnJCO0FBT0ksaUJBQVNELE9BUGI7QUFRSSxtQkFBVTtBQVJkLFFBREYsQ0FERjtBQWNEOzs7Ozs7RUFoSmlDLCtDIiwiZmlsZSI6Ii4vc3JjL2NvbXBvbmVudHMvb3JkZXJzL29yZGVycy5qcy5qcyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCBSZWFjdCwgeyBDb21wb25lbnQgfSBmcm9tICdyZWFjdCc7XHJcbmltcG9ydCBfIGZyb20gXCJsb2Rhc2hcIjtcclxuaW1wb3J0IG9yZGVyU3RvcmUgZnJvbSAnc3RvcmVzL29yZGVyU3RvcmUnO1xyXG5pbXBvcnQgUmVhY3RUYWJsZSBmcm9tICdyZWFjdC10YWJsZSc7XHJcblxyXG5leHBvcnQgZGVmYXVsdCBjbGFzcyBPcmRlcnMgZXh0ZW5kcyBDb21wb25lbnQge1xyXG5cclxuICBjb25zdHJ1Y3Rvcihwcm9wcykge1xyXG4gICAgc3VwZXIocHJvcHMpO1xyXG5cclxuICAgIHRoaXMuc3RhdGUgPSB7XHJcbiAgICAgIGRlZmF1bHREYXRhOiBbXSxcclxuICAgICAgb3JkZXJzOiBbXSxcclxuICAgICAgcGFnZXM6IG51bGwsXHJcbiAgICAgIGxvYWRpbmc6IHRydWUsXHJcbiAgICB9XHJcbiAgICB0aGlzLmRhdGFDaGFuZ2UgPSB0aGlzLmRhdGFDaGFuZ2UuYmluZCh0aGlzKTtcclxuICAgIHRoaXMudXBkYXRlRGF0YSA9IHRoaXMudXBkYXRlRGF0YS5iaW5kKHRoaXMpO1xyXG4gIH0gIFxyXG5cclxuICBjb21wb25lbnREaWRNb3VudCgpIHtcclxuXHJcbiAgICB0aGlzLmdldE9yZGVycygpLnRoZW4oKG9yZGVycykgPT4ge1xyXG5cclxuICAgICAgY29uc29sZS5sb2cob3JkZXJzKTtcclxuXHJcbiAgICAgIHRoaXMuc2V0U3RhdGUoe1xyXG4gICAgICAgIGRlZmF1bHREYXRhOiBvcmRlcnMsXHJcbiAgICAgICAgb3JkZXJzOiBvcmRlcnMsXHJcbiAgICAgICAgbG9hZGluZzogZmFsc2UsXHJcbiAgICAgIH0pO1xyXG5cclxuICAgIH0pO1xyXG4gIH1cclxuXHJcbiAgZ2V0T3JkZXJzKCkge1xyXG4gICAgcmV0dXJuIGZldGNoKCcvdW1icmFjby9iYWNrb2ZmaWNlL2Vrb20vbWFuYWdlcmFwaS9nZXRvcmRlcnMnLCB7XHJcbiAgICAgIGNyZWRlbnRpYWxzOiAnaW5jbHVkZScsXHJcbiAgICB9KS50aGVuKGZ1bmN0aW9uIChyZXNwb25zZSkge1xyXG4gICAgICByZXR1cm4gcmVzcG9uc2UuanNvbigpO1xyXG4gICAgfSkudGhlbihmdW5jdGlvbiAocmVzdWx0KSB7XHJcbiAgICAgIHJldHVybiByZXN1bHQ7XHJcbiAgICB9KTtcclxuICB9XHJcbiAgZGF0YUNoYW5nZShzdGF0ZSwgaW5zdGFuY2UpIHtcclxuICAgIGNvbnNvbGUubG9nKHN0YXRlKVxyXG4gIH1cclxuICB1cGRhdGVEYXRhKHBhZ2VTaXplLCBwYWdlLCBzb3J0ZWQsIGZpbHRlcmVkKSB7XHJcbiAgICByZXR1cm4gbmV3IFByb21pc2UoKHJlc29sdmUsIHJlamVjdCkgPT4ge1xyXG4gICAgICAvLyBZb3UgY2FuIHJldHJpZXZlIHlvdXIgZGF0YSBob3dldmVyIHlvdSB3YW50LCBpbiB0aGlzIGNhc2UsIHdlIHdpbGwganVzdCB1c2Ugc29tZSBsb2NhbCBkYXRhLlxyXG4gICAgICBsZXQgZmlsdGVyZWREYXRhID0gdGhpcy5zdGF0ZS5kZWZhdWx0RGF0YTtcclxuICBcclxuICAgICAgLy8gWW91IGNhbiB1c2UgdGhlIGZpbHRlcnMgaW4geW91ciByZXF1ZXN0LCBidXQgeW91IGFyZSByZXNwb25zaWJsZSBmb3IgYXBwbHlpbmcgdGhlbS5cclxuICAgICAgaWYgKGZpbHRlcmVkLmxlbmd0aCkge1xyXG4gICAgICAgIGZpbHRlcmVkRGF0YSA9IGZpbHRlcmVkLnJlZHVjZSgoZmlsdGVyZWRTb0ZhciwgbmV4dEZpbHRlcikgPT4ge1xyXG4gICAgICAgICAgcmV0dXJuIGZpbHRlcmVkU29GYXIuZmlsdGVyKHJvdyA9PiB7XHJcbiAgICAgICAgICAgIHJldHVybiAocm93W25leHRGaWx0ZXIuaWRdICsgXCJcIikuaW5jbHVkZXMobmV4dEZpbHRlci52YWx1ZSk7XHJcbiAgICAgICAgICB9KTtcclxuICAgICAgICB9LCBmaWx0ZXJlZERhdGEpO1xyXG4gICAgICB9XHJcbiAgICAgIC8vIFlvdSBjYW4gYWxzbyB1c2UgdGhlIHNvcnRpbmcgaW4geW91ciByZXF1ZXN0LCBidXQgYWdhaW4sIHlvdSBhcmUgcmVzcG9uc2libGUgZm9yIGFwcGx5aW5nIGl0LlxyXG4gICAgICBjb25zdCBzb3J0ZWREYXRhID0gXy5vcmRlckJ5KFxyXG4gICAgICAgIGZpbHRlcmVkRGF0YSxcclxuICAgICAgICBzb3J0ZWQubWFwKHNvcnQgPT4ge1xyXG4gICAgICAgICAgcmV0dXJuIHJvdyA9PiB7XHJcbiAgICAgICAgICAgIGlmIChyb3dbc29ydC5pZF0gPT09IG51bGwgfHwgcm93W3NvcnQuaWRdID09PSB1bmRlZmluZWQpIHtcclxuICAgICAgICAgICAgICByZXR1cm4gLUluZmluaXR5O1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIHJldHVybiB0eXBlb2Ygcm93W3NvcnQuaWRdID09PSBcInN0cmluZ1wiXHJcbiAgICAgICAgICAgICAgPyByb3dbc29ydC5pZF0udG9Mb3dlckNhc2UoKVxyXG4gICAgICAgICAgICAgIDogcm93W3NvcnQuaWRdO1xyXG4gICAgICAgICAgfTtcclxuICAgICAgICB9KSxcclxuICAgICAgICBzb3J0ZWQubWFwKGQgPT4gKGQuZGVzYyA/IFwiZGVzY1wiIDogXCJhc2NcIikpXHJcbiAgICAgICk7XHJcbiAgXHJcbiAgICAgIC8vIFlvdSBtdXN0IHJldHVybiBhbiBvYmplY3QgY29udGFpbmluZyB0aGUgcm93cyBvZiB0aGUgY3VycmVudCBwYWdlLCBhbmQgb3B0aW9uYWxseSB0aGUgdG90YWwgcGFnZXMgbnVtYmVyLlxyXG4gICAgICBjb25zdCByZXMgPSB7XHJcbiAgICAgICAgcm93czogc29ydGVkRGF0YS5zbGljZShwYWdlU2l6ZSAqIHBhZ2UsIHBhZ2VTaXplICogcGFnZSArIHBhZ2VTaXplKSxcclxuICAgICAgICBwYWdlczogTWF0aC5jZWlsKGZpbHRlcmVkRGF0YS5sZW5ndGggLyBwYWdlU2l6ZSlcclxuICAgICAgfTtcclxuICBcclxuICAgICAgLy8gSGVyZSB3ZSdsbCBzaW11bGF0ZSBhIHNlcnZlciByZXNwb25zZSB3aXRoIDUwMG1zIG9mIGRlbGF5LlxyXG4gICAgICBzZXRUaW1lb3V0KCgpID0+IHJlc29sdmUocmVzKSwgNTAwKTtcclxuICAgIH0pO1xyXG4gIH1cclxuICByZW5kZXIoKSB7XHJcblxyXG4gICAgY29uc3Qge1xyXG4gICAgICBsb2FkaW5nLFxyXG4gICAgICBkZWZhdWx0RGF0YSxcclxuICAgICAgb3JkZXJzLFxyXG4gICAgICBwYWdlcyxcclxuICAgIH0gPSB0aGlzLnN0YXRlO1xyXG5cclxuICAgIHZhciBjb2x1bW5zID0gW1xyXG4gICAgICB7XHJcbiAgICAgICAgSGVhZGVyOiAnT3JkZXJzJyxcclxuICAgICAgICBjb2x1bW5zOiBbXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ09yZGVyIE51bWJlcicsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnT3JkZXJOdW1iZXInLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnU3RhdHVzJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdPcmRlclN0YXR1cycsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdFbWFpbCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnQ3VzdG9tZXJFbWFpbCcsXHJcbiAgICAgICAgICB9LFxyXG4gICAgICAgICAge1xyXG4gICAgICAgICAgICBIZWFkZXI6ICdOYW1lJyxcclxuICAgICAgICAgICAgYWNjZXNzb3I6ICdDdXN0b21lck5hbWUnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnQ291bnRyeScsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnQ3VzdG9tZXJDb3VudHJ5JyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgICB7XHJcbiAgICAgICAgICAgIEhlYWRlcjogJ0NyZWF0ZWQnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ0NyZWF0ZURhdGUnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnUGFpZCcsXHJcbiAgICAgICAgICAgIGFjY2Vzc29yOiAnUGFpZERhdGUnLFxyXG4gICAgICAgICAgfSxcclxuICAgICAgICAgIHtcclxuICAgICAgICAgICAgSGVhZGVyOiAnVG90YWwnLFxyXG4gICAgICAgICAgICBhY2Nlc3NvcjogJ1RvdGFsQW1vdW50JyxcclxuICAgICAgICAgIH0sXHJcbiAgICAgICAgXSxcclxuICAgICAgfSxcclxuICAgIF07XHJcblxyXG4gICAgcmV0dXJuIChcclxuICAgICAgPG1haW4+XHJcbiAgICAgICAgPFJlYWN0VGFibGVcclxuICAgICAgICAgICAgZGF0YT17b3JkZXJzfVxyXG4gICAgICAgICAgICBmaWx0ZXJhYmxlXHJcbiAgICAgICAgICAgIHBhZ2VzPXtwYWdlc31cclxuICAgICAgICAgICAgY29sdW1ucz17Y29sdW1uc31cclxuICAgICAgICAgICAgb25GaWx0ZXJlZENoYW5nZT17dGhpcy5kYXRhQ2hhbmdlfVxyXG4gICAgICAgICAgICBkZWZhdWx0UGFnZVNpemU9ezJ9XHJcbiAgICAgICAgICAgIGxvYWRpbmc9e2xvYWRpbmd9XHJcbiAgICAgICAgICAgIGNsYXNzTmFtZT1cIi1zdHJpcGVkIC1oaWdobGlnaHRcIlxyXG4gICAgICAgICAgLz5cclxuICAgICAgPC9tYWluPlxyXG4gICAgKTtcclxuICB9XHJcbn1cclxuIl0sInNvdXJjZVJvb3QiOiIifQ==\n//# sourceURL=webpack-internal:///./src/components/orders/orders.js\n");

/***/ })

})