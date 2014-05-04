﻿/// <reference path="_references.views.js" />
/// <reference path="../webExpress/webExpress.controls.adpaters.js" />

var art = {};
art.ui = {};
art.ui.view = {};

(function () {
    art.ui.view.ArtworkList = ArtworkListClass;
    art.ui.view.DomResolver = DomResolverClass;

    function ArtworkListClass() {
        var DEFAULT_PAGESIZE = 10;

        var _self = this;
        var _searchCriterial = { PagingRequest: { PageIndex: 0, PageSize: DEFAULT_PAGESIZE } };
        var _currentPageIndex = 0;

        function _init() {
            _self.remove = remove;

            _self.publish = publish;

            _self.cancelPublish = cancelPublish;

            _self.search = search;

            _self.refresh = refresh;
        }

        function remove(artworkId) {
            var url = "Artwork/Delete/" + artworkId;
            webExpress.utility.ajax.request(url, null,
            function (data) {
                if (data.IsSuccess) {
                    refresh(_currentPageIndex);
                }
                else {
                    alert(data.Message);
                }
            },
            function () {
                alert(0);
            });
        }

        function publish(artworkId) {
            var url = "Artwork/Publish/" + artworkId;
            webExpress.utility.ajax.request(url, null,
            function (data) {
                if (data.IsSuccess) {
                    alert("ss");
                    //refresh(_currentPageIndex);
                }
                else {
                    alert(data.Message);
                }
            },
            function () {
                alert(0);
            });
        }

        function cancelPublish(artworkId) {
            var url = "Artwork/CancelPublish/" + artworkId;
            webExpress.utility.ajax.request(url, null,
            function (data) {
                if (data.IsSuccess) {
                    alert("ss");
                    //refresh(_currentPageIndex);
                }
                else {
                    alert(data.Message);
                }
            },
            function () {
                alert(0);
            });
        }

        function cancelPublish(artworkId) {
            var url = "Artwork/CancelPublish/" + artworkId;
            webExpress.utility.ajax.request(url, null,
            function (data) {
                if (data.IsSuccess) {
                    alert("ss");
                    //refresh(_currentPageIndex);
                }
                else {
                    alert(data.Message);
                }
            },
            function () {
                alert(0);
            });
        }

        function search() {
            _searchCriterial = {
                NamePart: $("#txtName").val(),
                ArtworkTypeId: $("#ddlArtworkType option:selected").val(),
                ArtistId: $("#ddlArtMaterial option:selected").val(),
                ArtMaterialId: $("#ddlArtist option:selected").val(),
                PagingRequest: {
                    PageSize: DEFAULT_PAGESIZE
                }
            };
            refresh(0);
        }

        function refresh(pageIndex) {
            var url = "Artwork/List";
            if (pageIndex !== undefined) {
                _searchCriterial.PagingRequest.PageIndex = pageIndex;
            }
            webExpress.utility.ajax.request(url, _searchCriterial,
                function (data) {
                    $(".data").html(data);

                }
                , function (data) {
                    $(".data").html(data.responseText);
                    _currentPageIndex = pageIndex;
                });
        }

        _init();
    }

    function DomResolverClass() {
        var _self = this;

        var _currentRecordElement = null;
        function _init() {
            _self.setCurrentRecordElement = setCurrentRecordElement;
            _self.getRecordId = getRecordId;
            _self.setPublishState = setPublishState;
        }

        function setCurrentRecordElement(element) {
            _currentRecordElement = element;
        }

        function getRecordId() {
            return _currentRecordElement.attr("RecordId");
        }

        function setPublishState(isPublish) {
            if (isPublish) {
                _currentRecordElement.find("td.zt").text("已发布");
            }
            else {
                _currentRecordElement.find("td.zt").text("未发布");
            }
        }
        _init();
    }
})();