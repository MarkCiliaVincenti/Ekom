var bind = function (data, eventsService) {

  let nameInput = document.getElementsByClassName('umb-editor-header__name-input')[0];

  if (nameInput) {

    nameInput.addEventListener("keyup", function () {

      var model = {
        title: "",
        slug: "",
        alias: data.alias,
        all: true
      };

      data.tabs.forEach((tab) => {

        let titleInput = document.getElementById('title.' + tab.value);

        if (titleInput) {
          model.title = nameInput.value;
        }

        var slugInput = document.getElementById('slug.' + tab.value);

        if (slugInput) {

          const slugify =
            nameInput.value
              .toString()                           // Cast to string (optional)
              .replace('ð', 'd')
              .replace('Ð', 'd')
              .replace('þ', 'th')
              .replace('Þ', 'th')
              .replace('ó', 'o')
              .replace('Ó', 'o')
              .replace('í', 'i')
              .replace('Í', 'i')
              .replace('æ', 'ae')
              .replace('Æ', 'ae')
              .replace('ú', 'u')
              .replace('Ú', 'u')
              .replace('ö', 'oe')
              .replace('Ö', 'oe')
              .normalize('NFKD')            // The normalize() using NFKD method returns the Unicode Normalization Form of a given string.
              .toLowerCase()                  // Convert the string to lowercase letters
              .trim()                                  // Remove whitespace from both sides of a string (optional)
              .replace(/\s+/g, '-')            // Replace spaces with -
              .replace(/[^\w\-]+/g, '')     // Remove all non-word chars
              .replace(/\-\-+/g, '-');        // Replace multiple - with single -

          model.slug = slugify;
        }

      });

      eventsService.emit("ekmInputChange", { value: model });

    });

  }

};

(function () {
  'use strict';

  function loader(eventsService) {

    // fired when ekom property has finished loading
    eventsService.on('ekmPropertyLoaded', function (event, data) {

      const params = new Proxy(new URLSearchParams(window.location.href), {
        get: (searchParams, prop) => searchParams.get(prop),
      });

      if (params != null && params.create && params.create == 'true') {
        if (data.value.model.alias == 'title') {
          bind(data.value, eventsService);
        }
      }


    });

  }

  angular.module('umbraco').run(loader);

})();
