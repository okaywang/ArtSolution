
var art = {};
art.ui = {};
art.ui.view = {};

(function () {
    art.ui.view.SystemNoticeList = SystemNoticeListClass;

    function SystemNoticeListClass() {
        var _self = this;
        var _criteria = { StartDate: "", EndDate: "", PagingRequest: { PageIndex: 0, PageSize: 10 } };

        function _init() {
            _self.setCriteria = setCriteria;

            _self.publish = publish;
            _self.refresh = refresh;
            _self.remove = remove;
        }

        function setCriteria(startDate,endDate) {
            _criteria.StartDate = startDate;
            _criteria.EndDate = endDate;
        }

        function publish(title, content, onSuccess) {
            var url = "/Message/Publish";
            webExpress.utility.ajax.request(url, { title: title, content: content },
                function () {
                    if (onSuccess) {
                        onSuccess();
                    }
                    setCriteria("", "");
                    refresh(0);
                },
                function () {
                }
            );
        }

        function refresh(pageIndex) {
            var url = "/Message/NoticeList";
            if (pageIndex !== undefined) {
                _criteria.PagingRequest.PageIndex = pageIndex;
            }
            webExpress.utility.ajax.request(url, _criteria,
                function () {

                },
                function (data) {
                    renderHtml(data.responseText);
                }
             );
        }

        function remove(noticeIds) {
            var url = "/Message/DeleteNotices";
            webExpress.utility.ajax.request(url, { noticeIds: noticeIds }, function (data) {
                refresh();
            }, function (data) {
                console.log("delete failture");
            });
        }

        function renderHtml(html) {
            $(".data").html(html);
            $(".data .grid-pager a[pageIndex]").click(function () {
                refresh($(this).attr("pageIndex"));
            });
        }

        _init();
    }
})();