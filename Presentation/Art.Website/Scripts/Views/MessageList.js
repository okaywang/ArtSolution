
var art = {};
art.ui = {};
art.ui.view = {};

(function () {
    art.ui.view.MessageList = MessageListClass;

    function MessageListClass() {
        var _self = this;

        function _init() {
            _self.publishSystemNotice = publishSystemNotice;
            _self.refreshSystemNotices = refreshSystemNotices;
        }

        function publishSystemNotice(title,content,onSuccess) {
            var url = "/Message/Publish";
            webExpress.utility.ajax.request(url, { title: title, content: content },
                function () {
                    if (onSuccess) {
                        onSuccess();
                    }
                },
                function () {
                    alert(2);
                }
            );
        }

        function refreshSystemNotices() {

        }

        _init();
    }
})();