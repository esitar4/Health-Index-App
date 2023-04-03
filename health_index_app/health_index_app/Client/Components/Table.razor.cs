using health_index_app.Client.Services;
using health_index_app.Shared.DTObjects;
using Microsoft.AspNetCore.Components;
using System.Drawing.Printing;

namespace health_index_app.Client.Components
{
    partial class Table<T>
    {
        [Parameter]
        public string Title { get; set; }
        [Parameter] 
        public List<T> Data { get; set; }
        [Parameter]
        public IEnumerable<T> Values { get; set; }
        [Parameter]
        public List<string> Names { get; set; }
        [Parameter]
        public List<string> ColumnNames { get; set; }
        [Parameter]
        public List<StringDTO> Search { get; set; }

        [Parameter]
        public int PageSize { get; set; }
        [Parameter]
        public string ActiveSortColumn { get; set; }

        [Parameter]
        public EventCallback<TableEventCallBackArgs<T>> eventCallback { get; set; }

        private int _pageNumber = 1;
        private Dictionary<string, bool> _isHidden = new Dictionary<string, bool>();

        protected override void OnInitialized()
        {
            Title = "Title";
            Data = new List<T>();
            Names = new List<string>();
            ColumnNames = new List<string>();
            Search = new List<StringDTO>();
            PageSize = 10;
            ActiveSortColumn = string.Empty;
        }

        List<T> FilteredData => Values
                                .ToList();
        List<T> PagedData => FilteredData
            .Page(_pageNumber, PageSize)
            .ToList();

        private void UpdateData(TableEventCallBackArgs<T> args)
        {
            Data = args.Data;
            ActiveSortColumn = args.ActiveSortColumn;
            Search = args.Search;
            eventCallback.InvokeAsync(args);
        }

        public void GetUpdatedPageNumber(int num)
        {
            _pageNumber = num;
        }

        //private void Show(int mealId)
        //{
        //    _isHidden[mealId] = !isHidden[mealId];
        //}

    }
}
