using Art.BussinessLogic;
using Art.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art.Website.Controllers
{
    public class MessageController : Controller
    {
        [HttpGet]
        public ActionResult NoticeList()
        {
            var defaultCriteria = new SystemNoticeSearchCriteria(10);
            var model = GetPageSystemNoticeModel(defaultCriteria);
            return View(model);
        }

        public ActionResult NoticeList(SystemNoticeSearchCriteria criteria)
        {
            var model = GetPageSystemNoticeModel(criteria);
            return PartialView("_NoticeList", model);
        }

        public JsonResult DeleteNotices(int[] noticeIds)
        {
            var notices = MessageBussinessLogic.Instance.GetSystemNotices(noticeIds);
            MessageBussinessLogic.Instance.DeleteSystemNotices(notices.ToArray());
            var model = new ResultModel(true, string.Empty);
            return Json(model);
        }

        private PagedSystemNoticeModel GetPageSystemNoticeModel(SystemNoticeSearchCriteria criteria)
        {
            var pagedSystemNotice = MessageBussinessLogic.Instance.SearchSystemNotice(criteria.StartDate, criteria.EndDate, criteria.PagingRequest);
            var notices = SystemNoticeModelTranslator.Instance.Translate(pagedSystemNotice.ToList());
            var model = new PagedSystemNoticeModel(notices, pagedSystemNotice.PagingResult);
            return model;
        }

        public JsonResult Publish(string title, string content)
        {
            MessageBussinessLogic.Instance.PublishSystemNotice(title, content);
            var result = new ResultModel(true, string.Empty);
            return Json(result);
        }



    }
}
