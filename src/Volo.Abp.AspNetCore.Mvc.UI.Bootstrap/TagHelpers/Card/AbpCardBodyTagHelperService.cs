﻿using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.Microsoft.AspNetCore.Razor.TagHelpers;

namespace Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Card
{
    public class AbpCardBodyTagHelperService : AbpTagHelperService<AbpCardBodyTagHelper>
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.AddClass("card-body");

            ProcessTitle(output);
            ProcessSubtitle(output);
        }

        private void ProcessTitle(TagHelperOutput output)
        {
            if (!TagHelper.Title.IsNullOrWhiteSpace())
            {
                var cardTitle = new TagBuilder(AbpCardTitleTagHelper.DefaultHeading.ToHtmlTag());
                cardTitle.AddCssClass("card-title");
                cardTitle.InnerHtml.Append(TagHelper.Title);
                output.PreContent.AppendHtml(cardTitle);
            }
        }

        private void ProcessSubtitle(TagHelperOutput output)
        {
            if (!TagHelper.Subtitle.IsNullOrWhiteSpace())
            {
                var cardSubtitle = new TagBuilder(AbpCardSubtitleTagHelper.DefaultHeading.ToHtmlTag());
                cardSubtitle.AddCssClass("card-subtitle text-muted mb-2");
                cardSubtitle.InnerHtml.Append(TagHelper.Subtitle);
                output.PreContent.AppendHtml(cardSubtitle);
            }
        }
    }
}