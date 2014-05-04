/// <reference path="_references.views.js" />
/// <reference path="../webExpress/webExpress.controls.adpaters.js" />
/// <reference path="base/ViewBase.js" />


(function () {
    art.ui.view.ArtworkEdit = ArtworkEditClass;

    function ArtworkEditClass() {
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
            _self.attachBindingAttribute();
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
            }, "end datetime should be greater than start datetime");

            options.rules["Artwork.StartDateTime"] = { DateValidate: true };
            options.rules["Artwork.EndDateTime"] = { DateValidate: true };

            $("form").validate(options);
        }

        function bindModel(model) {
            parseModel(model);

            viewModel = kendo.observable(model);
            viewModel.Artwork.bind("change", function (item) {
                if (item.field == "Artwork.ArtworkTypeId") {
                    var artworkTypeId = item.sender.get();
                    var artworkType = $.grep(viewModel.SourceArtworkTypes, function (element,index) {
                        return element.Id == artworkTypeId;
                    })[0];

                    //var sourceArtMaterials = [{ Id: "", Name: "未选" }];
                    //if (artworkType) {
                    //    for (var i = 0; i < artworkType.ArtMaterials.length; i++) {
                    //        sourceArtMaterials.push(artworkType.ArtMaterials[i]);
                    //    }
                    //}
                    //viewModel.set("SourceArtMaterials", sourceArtMaterials);
                    //viewModel.Artwork.set("ArtMaterialId", "");

                    bindArtworkTypeSubItems(artworkType, "SourceArtMaterials", "ArtMaterials", "ArtMaterialId");
                    bindArtworkTypeSubItems(artworkType, "SourceArtShapes", "ArtShapes", "ArtShapeId");
                    bindArtworkTypeSubItems(artworkType, "SourceArtTechniques", "ArtTechniques", "ArtTechniqueId");
                }
            });

            kendo.bind($("form"), viewModel);
        }

        function bindArtworkTypeSubItems(artworkType,sourceItemsName,itemsName, itemName){
            var sourceItems = [{ Id: "", Name: "未选" }];
            if (artworkType) {
                for (var i = 0; i < artworkType[itemsName].length; i++) {
                    sourceItems.push(artworkType[itemsName][i]);
                }
            }
            viewModel.set(sourceItemsName, sourceItems);
            viewModel.Artwork.set(itemName, "");
        }

        function parseModel(model) {
            for (var i = 0; i < model.Artwork.SuitablePlaceIds.length; i++) {
                model.Artwork.SuitablePlaceIds[i] += "";
            }

            model.SourceArtMaterials = [{ Id: "", Name: "未选" }];
            model.SourceArtShapes = [{ Id: "", Name: "未选" }];
            model.SourceArtTechniques = [{ Id: "", Name: "未选" }];
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