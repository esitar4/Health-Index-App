using health_index_app.Shared.DTObjects;
using System.Collections;

namespace health_index_app.Client.Components
{
    public class TableEventCallBackArgs<T>
    {
        public string ActiveSortColumn { get; set; }
        public List<T> Data { get; set; }
        public List<StringDTO> Search { get; set;}

    }
}
