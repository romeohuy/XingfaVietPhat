using System.Collections.Generic;

namespace WebXingFaUmbraco.Models
{
    public class Navigation
    {
        public class NavigationLinkInfo
        {
            public string Text { get; set; }
            public string Title { get; set; }
            public string Url { get; set; }
            public bool IsNewWindow { get; set; }

            public string Target => IsNewWindow ? "_blank" : string.Empty;

            public NavigationLinkInfo(string text = null, string url = null, bool isNewWindow = false, string title = null)
            {
                Text = text;
                Title = title;
                Url = url;
                IsNewWindow = isNewWindow;
            }
        }

        public class NavigationList
        {
            public string Text { get; set; }
            public NavigationLinkInfo LinkInfo { get; set; }
            public List<NavigationList> NavItems { get; set; }

            public bool HasSubNavigation => NavItems != null && NavItems.Count > 0;

            public NavigationList(NavigationLinkInfo linkInfo)
            {
                LinkInfo = linkInfo;
            }
        }
    }
}