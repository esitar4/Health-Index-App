namespace health_index_app.Client.Components
{
    public class AlertMessagesDTO
    {
        public int Status { get; set; } = 0;
        public string None { get; set; } = string.Empty;
        public string Successful { get; set; } = "Success";
        public string Unsucessful { get; set; } = "Unsuccessful";
    }
}
