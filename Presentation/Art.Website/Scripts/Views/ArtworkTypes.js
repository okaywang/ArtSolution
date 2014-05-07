var art = {};
art.ui = {};
art.ui.view = {};
(function () {
    art.ui.view.ArtworkTypes = ArtworkTypesClass

    function ArtworkTypesClass() {
        var _self = this;

        function _init() {
            _self.addType = addType;
            _self.removeType = removeType;
            _self.editType = editType;
            _self.refresh = refresh;
        }

        function addType(typeName, materials, shapes, techniques) {
            var url = "/Artwork/AddArtworkType";
            var artworkType = {
                Name: typeName,
                ArtMaterials: materials,
                ArtShapes: shapes,
                ArtTechniques: techniques
            };
            webExpress.utility.ajax.request(url, artworkType, function (data) {
                if (data.IsSuccess) {
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

        function editType() {

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