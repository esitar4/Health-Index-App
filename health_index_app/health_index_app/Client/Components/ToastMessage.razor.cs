using Microsoft.AspNetCore.Components;
using System.Drawing.Printing;

namespace health_index_app.Client.Components
{
    partial class ToastMessage
    {
        [Parameter]
        public AlertMessagesDTO Message { get; set; }
        [Parameter]
        public EventCallback<AlertMessagesDTO> eventCallback { get; set; }

        private AlertMessagesDTO _curMessage;
        protected override void OnInitialized()
        {
            Message = new();
            _curMessage = new();
        }


        protected override async void OnParametersSet()
        {
            if (!_curMessage.Equals(Message))
            {
                _curMessage = Message;

                StateHasChanged();

                await Task.Delay(TimeSpan.FromSeconds(3));

                _curMessage.Status = 0;

                StateHasChanged();

                await eventCallback.InvokeAsync(_curMessage);
            }

        }


    }
}
