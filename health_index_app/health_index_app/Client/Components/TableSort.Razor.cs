using health_index_app.Shared.DTObjects;
using Microsoft.AspNetCore.Components;

namespace health_index_app.Client.Components
{
    partial class TableSort<T>
    {
        [Parameter]
        public List<T> Data { get; set; }
        [Parameter]
        public List<string> NameList { get; set; }
        [Parameter]
        public List<string> ColumnNameList { get; set; }

        [Parameter]
        public string ActiveSortColumn { get; set; }
        [Parameter]
        public List<StringDTO> Search { get; set; }

        [Parameter]
        public EventCallback<TableEventCallBackArgs<T>> eventCallback { get; set; }

        public void GetUpdatedData(TableEventCallBackArgs<T> args)
        {
            ActiveSortColumn = args.ActiveSortColumn;
            eventCallback.InvokeAsync(args);
        }
    }
}
