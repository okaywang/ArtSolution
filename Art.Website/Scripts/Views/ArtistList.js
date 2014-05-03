/// <reference path="_references.views.js" />
/// <reference path="../webExpress/webExpress.controls.adpaters.js" />

var art = {};
art.ui = {};
art.ui.view = {};

(function () {
    art.ui.view.ArtistList = ArtistListClass;

    function ArtistListClass() {
        var _self = this;
        function _init() {
            _self.remove = remove;

        }

        function remove(artistId) {

        }

        _init();
    }
})();