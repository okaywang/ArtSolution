﻿/// <reference path="_references.views.js" />
/// <reference path="../webExpress/webExpress.controls.adpaters.js" />

var art = {};
art.ui = {};
art.ui.views = {};

(function () {
    art.ui.views.ArtworkEdit = ArtworkEditClass;

    function ArtworkEditClass() {
        var _self = this;
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
            var adminjs = new adminglass();
            adminjs.datepickerbox('.datepicker');

            $("#J_addbtn").click(function () {
                var isValid = $("form").valid();
                if (isValid) {
                    save(viewModel);
                }
            });

            $(":file").change(function () {
                $("form").submit();
            });
        }

        function initDomElement() {
            var properties = $("[property-name]");
            var controlAdapters = webExpress.controls.adpaters;
            for (var i = 0; i < properties.length; i++) {
                var $property = $(properties[i]);
                $property.addClass("control-group");
                var controlType = $property.attr("control-type");
                var adapter = controlAdapters[controlType];
                var controls = $property.find("*").andSelf().filter(adapter.controlSelector);
                for (var j = 0; j < controls.length; j++) {
                    var control = controls[j];
                    var propName = $property.attr("property-name");
                    control.name = propName;

                    var bindStr = "";
                    if (typeof (adapter.valueField) == "function") {
                        bindStr = adapter.valueField(propName);
                    }
                    else {
                        bindStr = adapter.valueField + ":" + propName;
                    }

                    if ($property.attr("data-source")) {
                        bindStr += "," + "source:" + $property.attr("data-source");
                    }

                    $(control).attr("data-bind", bindStr);
                }
            }
        }

        function initValidation() {
            var options = {
                onkeyup: false,
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

            jQuery.validator.addMethod("DateValidate", function (value, element) {
                if (viewModel.Artwork.EndDateTime <= viewModel.Artwork.StartDateTime) { 
                    return false;
                }
                return true;
            },"end datetime should be greater than start datetime");

            options.rules["Artwork.StartDateTime"] = { DateValidate: true };
            options.rules["Artwork.EndDateTime"] = { DateValidate: true };

            $("form").validate(options);
        }

        function bindModel(model) {
            parseModel(model);

            viewModel = kendo.observable(model);

            kendo.bind($("form"), viewModel);
        }

        function parseModel(model) {
            for (var i = 0; i < model.Artwork.SuitablePlaceIds.length; i++) {
                model.Artwork.SuitablePlaceIds[i] += "";
            }

            //if (model.Artist.Birthday) {
            //    model.Artist.Birthday = model.Artist.Birthday.substr(0, 10);
            //}

            //if (model.Artist.Deathday) {
            //    model.Artist.Deathday = model.Artist.Deathday.substr(0, 10);
            //}

            //if (model.Artist.AvatarFileName) {
            //    model.Artist.AvatarFileName = webExpress.utility.url.getFullUrl(model.Artist.AvatarFileName);
            //}
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