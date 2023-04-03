using health_index_app.Shared.DTObjects;
using Microsoft.AspNetCore.Components;
using System.Drawing.Printing;

namespace health_index_app.Client.Components
{
    partial class TableSortHeader<T>
    {
        [Parameter]
        public List<T> Data { get; set; }
        [Parameter]
        public string Name { get; set; }
        [Parameter]
        public string ColumnName { get; set; }
        [Parameter]
        public string ActiveSortColumn { get; set; }
        [Parameter]
        public List<StringDTO> Search { get; set; }
        [Parameter]
        public EventCallback<TableEventCallBackArgs<T>> eventCallback { get; set; }

        private bool isSortedAscending;
        private string _activeSortColumn = null!;
        private List<T> _data = null!;

        protected override void OnInitialized()
        {
            _activeSortColumn = ActiveSortColumn;
            _data = Data;
        }

        protected override void OnParametersSet()
        {
            if (_activeSortColumn != ActiveSortColumn)
            {
                _activeSortColumn = ActiveSortColumn;
            }
            if (_data != Data) { 
                _data = Data;
            }
        }

        private void SortTable(string columnName)
        {
            if (columnName != _activeSortColumn)
            {
                _data = _data.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                isSortedAscending = true;
                _activeSortColumn = columnName;
            }
            else
            {
                if (isSortedAscending)
                {
                    _data = _data.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                else
                {
                    _data = _data.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                isSortedAscending = !isSortedAscending;
            }

            eventCallback.InvokeAsync(
                new TableEventCallBackArgs<T>
                {
                    ActiveSortColumn = _activeSortColumn,
                    Data = _data,
                    Search = Search
                }
            );
        }

        private string SetSortIcon(string columnName)
        {
            if (_activeSortColumn != columnName)
            {
                return "fa-sort";
            }
            if (isSortedAscending)
            {
                return "fa-sort-up";
            }
            else
            {
                return "fa-sort-down";
            }
        }
    }
}
