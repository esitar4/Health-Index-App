using System.Collections;

namespace health_index_app.Client.Components
{
    public class TableSortHeaderEventCallBackArgs<T>
    {
        public string ActiveSortColumn { get; set; }
        public List<T> Data { get; set; }

    }
}
