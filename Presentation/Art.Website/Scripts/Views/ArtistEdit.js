/// <reference path="_references.views.js" />
/// <reference path="../webExpress/webExpress.controls.adpaters.js" />

(function () {
    art.ui.view.ArtistEdit = ArtistEditClass;

    function ArtistEditClass() {
        var _self = this;
        art.ui.view.ViewBase.call(_self);

        function _init() {
            _self.init = init;

            _self.bindModel = bindModel;

            _self.save = save;
        }

        function init() {
            initDomEvent();
            initDomElement();
            initValidation();
        }
        function initDomEvent() {
            $("#J_addbtn").click(function () {
                var isValid = $("form").valid();
                if (isValid) {
                    save(viewModel);
                }
            });

            $(":file").change(function () {
                $("form").validate().cancelSubmit = true;
                $("form").submit();
            });
        }
        function initDomElement() { 
            _self.attachBindingAttribute();
        }
        function initValidation() {
            var options = {
                rules: {}
            };
            var properties = $("[property-name]");
            for (var i = 0; i < properties.length; i++) {
                var $property = $(properties[i]);
                if ($property.hasClass("mandatory")) {
                    var propName = $property.attr("property-name");
                    options.rules[propName] = { required: true };
                }
            }
            $("form").validate(options);
        }

        function bindModel(model) {
            parseModel(model);

            viewModel = kendo.observable(model);

            kendo.bind($("form"), viewModel);
        }

        function parseModel(model) {
            for (var i = 0; i < model.Artist.ProfessionIds.length; i++) {
                model.Artist.ProfessionIds[i] += "";
            }

            for (var i = 0; i < model.Artist.SkilledGenreIds.length; i++) {
                model.Artist.SkilledGenreIds[i] += "";
            }

            if (model.Artist.Birthday) {
                model.Artist.Birthday = model.Artist.Birthday.substr(0, 10);
            }

            if (model.Artist.Deathday) {
                model.Artist.Deathday = model.Artist.Deathday.substr(0, 10);
            }

            if (model.Artist.AvatarFileName) {
                model.Artist.AvatarFileName = webExpress.utility.url.getFullUrl(model.Artist.AvatarFileName);
            }
        }

        function save(model) {
            var url = model.Artist.Id > 0 ? "/Artist/Update" : "/Artist/Add";
            webExpress.utility.ajax.request(url, model.Artist,
            function () {
                alert("success");
            },
            function () {
                alert("error");
            });
        }

        _init();
    }
})();