using System;
using bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace bookstore.Infrastructure
{
	[HtmlTargetElement("div", Attributes = "page-info")] //@todo: read up on this
	public class PaginationTagHelper : TagHelper
	{
		private IUrlHelperFactory urlHelperFactory;

		public PaginationTagHelper(IUrlHelperFactory factory)
		{
			urlHelperFactory = factory;
		}

		//@todo: learn about ViewContext
		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext viewContext { get; set; }

		public PageInfo PageInfo { get; set; }
		public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
			//base.Process(context, output);
			IUrlHelper helper = urlHelperFactory.GetUrlHelper(viewContext); //@todo: Figure out what this does and why we shouldn't call the base method
            TagBuilder _output = new TagBuilder("div");

			for (int i = 1; i <= PageInfo.PageCount; i++)
            {
				TagBuilder builder = new TagBuilder("a");
				builder.InnerHtml.Append(i.ToString());
				builder.Attributes["href"] = helper.Action(PageAction, new { _page = i });
				builder.AddCssClass("mx-4");
				_output.InnerHtml.AppendHtml(builder);
            }
			output.Content.AppendHtml(_output.InnerHtml);
        }

        //@todo: add bootstrap pagination styling
    }
}

