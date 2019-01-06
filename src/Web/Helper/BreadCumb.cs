using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSWeb.Web.Helper
{
    public class BreadCumb
    {
        private StringBuilder sb = new StringBuilder();
        public BreadCumb()
        {
            this.sb.Append("<ol class=\"breadcrumb float-sm-right\">");
        }
        public void AddBreadCumb(BreadCumbModel model)
        {
            string active = "";
            if(string.IsNullOrEmpty(model.Url.Trim()))
            {
                model.Url = "#";
            }
            if(model.isActive)
            {
                active = "active";
            }
            sb.Append($"<li class=\"breadcrumb-item {active}\"><a href=\"{model.Url}\">{model.DiplayText}</a></li>");
        }

        public string GetBreadCumb()
        {
            sb.Append("</ol>");
            return this.sb.ToString();
        }

    }
    public class BreadCumbModel
    {
        public string DiplayText { get; set; }
        public string Url { get; set; }
        public bool isActive { get; set; }
    }
}
