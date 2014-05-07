﻿var art = {};
art.ui = {};
art.ui.view = {};
(function () {
    art.ui.view.ArtworkTypes = ArtworkTypesClass

    function ArtworkTypesClass() {
        var _self = this;

        function _init() {
            _self.addType = addType;
            _self.removeType = removeType;
            _self.updateType = updateType;
            _self.refresh = refresh;
        }

        function addType(artworkType,onSuccess) {
            var url = "/Artwork/AddArtworkType";
            webExpress.utility.ajax.request(url, artworkType, function (data) {
                if (data.IsSuccess) {
                    if (onSuccess) {
                        onSuccess();
                    }
                    refresh();
                }
            });
        }

        function removeType(typeId) {
            var url = "/Artwork/DeleteArtworkType/" + typeId;
            webExpress.utility.ajax.request(url, null, function (data) {
                if (data.IsSuccess) {
                    refresh();
                } else {
                    alert(data.Message);
                }
            });
        }

        function updateType(artworkType,onSuccess) {
            var url = "/Artwork/UpdateArtworkType";
            webExpress.utility.ajax.request(url, artworkType, function (data) {
                if (data.IsSuccess) {
                    if (onSuccess) {
                        onSuccess();
                    }
                    refresh();
                }
            });
        }

        function refresh() {
            var url = "/Artwork/ArtworkTypes";
            webExpress.utility.ajax.request(url, null, function (data) {
                $(".data").html(data);
            });
        }

        _init();
    }
})();