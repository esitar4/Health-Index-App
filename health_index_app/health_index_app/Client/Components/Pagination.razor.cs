using Microsoft.AspNetCore.Components;

namespace health_index_app.Client.Components
{
    partial class Pagination
    {
        [Parameter]
        public int PageNumber { get; set; }
        [Parameter]
        public int PageSize { get; set; }
        [Parameter]
        public int ListSize { get; set; }
        [Parameter]
        public EventCallback<int> eventCallback { get; set; }
        private int MaxPage { get; set; }

        protected override void OnInitialized()
        {
            MaxPage = ListSize / PageSize;
        }

        protected override void OnParametersSet()
        {
            if (MaxPage != ListSize/PageSize)
            {
                MaxPage = ListSize / PageSize;
                PageNumber = 1;
                eventCallback.InvokeAsync(PageNumber);
            }
        }

        private void changePage(int num)
        {
            MaxPage = ListSize / PageSize;

            if (PageNumber + num < 1)
            {
                PageNumber = 1;
            }
            else if (PageNumber + num >= MaxPage)
            {
                PageNumber = Math.Max(MaxPage, 1);
            }
            else
            {
                PageNumber += num;
            }

            eventCallback.InvokeAsync(PageNumber);
        }
    }
}
