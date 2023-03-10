/*! github.com/serbanghita/formToObject.js 1.0.1  (c) 2013 Serban Ghita <serbanghita@gmail.com> @licence MIT */

export default {
  formToObject(formRef) {

    if (!formRef) { return false; }

    this.formRef = formRef;
    this.keyRegex = /[^\[\]]+/g;
    this.$form = null;
    this.$formElements = [];
    this.formObj = {};

    if (!this.setForm()) { return false; }
    if (!this.setFormElements()) { return false; }

    var obj = this.setFormObj();

    var str = [];
    for (var p in obj)
      if (obj.hasOwnProperty(p)) {
        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
      }

    return str.join("&");

  },

  // Set the main form object we are working on.
  setForm() {

    switch (typeof this.formRef) {

      case 'string':
        this.$form = document.getElementById(this.formRef);
        break;

      case 'object':
        if (this.isDomNode(this.formRef)) {
          this.$form = this.formRef;
        }
        break;

    }

    return this.$form;

  },

  // Set the elements we need to parse.
  setFormElements() {
    this.$formElements = this.$form.querySelectorAll('input, textarea, select');
    return this.$formElements.length;
  },

  // Check to see if the object is a HTML node.
  isDomNode(node) {
    return typeof node === "object" && "nodeType" in node && node.nodeType === 1;
  },

  // Iteration through arrays and objects. Compatible with IE.
  forEach(arr, callback) {

    if ([].forEach) {
      return [].forEach.call(arr, callback);
    }

    var i;
    for (i in arr) {
      // Object.prototype.hasOwnProperty instead of arr.hasOwnProperty for IE8 compatibility.
      if (Object.prototype.hasOwnProperty.call(arr, i)) {
        callback.call(arr, arr[i]);
      }
    }

    return;

  },

  // Recursive method that adds keys and values of the corresponding fields.
  addChild(result, domNode, keys, value) {

    // #1 - Single dimensional array.
    if (keys.length === 1) {

      // We're only interested in the radio that is checked.
      if (domNode.nodeName === 'INPUT' && domNode.type === 'radio') {
        if (domNode.checked) {
          return result[keys] = value;
        } else {
          return;
        }
      }

      // Checkboxes are a special case. We have to grab each checked values
      // and put them into an array.
      if (domNode.nodeName === 'INPUT' && domNode.type === 'checkbox') {

        if (domNode.checked) {

          if (!result[keys]) {
            result[keys] = [];
          }
          return result[keys].push(value);

        } else {
          return;
        }

      }

      // Multiple select is a special case.
      // We have to grab each selected option and put them into an array.
      if (domNode.nodeName === 'SELECT' && domNode.type === 'select-multiple') {

        result[keys] = [];
        var DOMchilds = domNode.querySelectorAll('option[selected]');
        if (DOMchilds) {
          this.forEach(DOMchilds, function(child) {
            result[keys].push(child.value);
          });
        }
        return;

      }

      // Fallback. The default one to one assign.
      result[keys] = value;

    }

    // #2 - Multi dimensional array.
    if (keys.length > 1) {

      if (!result[keys[0]]) {
        result[keys[0]] = {};
      }

      return this.addChild(result[keys[0]], domNode, keys.splice(1, keys.length), value);

    }

    return result;

  },

  setFormObj() {

    var test, i = 0;

    for (i = 0; i < this.$formElements.length; i++) {
      // Ignore the element if the 'name' attribute is empty.
      // Ignore the 'disabled' elements.
      if (this.$formElements[i].name && !this.$formElements[i].disabled) {
        test = this.$formElements[i].name.match(this.keyRegex);
        this.addChild(this.formObj, this.$formElements[i], test, this.$formElements[i].value);
      }
    }

    return this.formObj;

  },
};
