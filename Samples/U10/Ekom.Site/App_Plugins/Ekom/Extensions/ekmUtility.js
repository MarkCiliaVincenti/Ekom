var bind = function (data) {

  var nameInput = document.getElementsByClassName('umb-editor-header__name-input')[0];

  if (nameInput) {


    var isEmpty = true;

    data.tabs.forEach((tab) => {

      var titleInput = document.getElementById('title.' + tab.value);
      var slugInput = document.getElementById('slug.' + tab.value);

      if (titleInput && slugInput) {

        if (titleInput.value !== '' || slugInput.value !== '') {
          isEmpty = false;
        }
      }

    });

    console.log(isEmpty);

    if (isEmpty) {

      nameInput.addEventListener("keyup", function () {

        data.tabs.forEach((tab) => {

          var titleInput = document.getElementById('title.' + tab.value);

          if (titleInput) {
            titleInput.value = nameInput.value;
          }

          var slugInput = document.getElementById('slug.' + tab.value);

          if (slugInput) {

            const slugify =
              nameInput.value
                .toString()                           // Cast to string (optional)
                .normalize('NFKD')            // The normalize() using NFKD method returns the Unicode Normalization Form of a given string.
                .toLowerCase()                  // Convert the string to lowercase letters
                .trim()                                  // Remove whitespace from both sides of a string (optional)
                .replace(/\s+/g, '-')            // Replace spaces with -
                .replace(/[^\w\-]+/g, '')     // Remove all non-word chars
                .replace(/\-\-+/g, '-');        // Replace multiple - with single -


            slugInput.value = slugify;
          }

        });

      });
    }


  }

};

(function () {
  'use strict';

  function loader(eventsService) {

    // fired when ekom property has finished loading
    eventsService.on('ekmPropertyLoaded', function (event, data) {

      if (data.value.model.alias == 'title') {
        bind(data.value);
      }

    });

  }

  angular.module('umbraco').run(loader);

})();
