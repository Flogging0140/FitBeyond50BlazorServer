namespace BlazorServer2.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public DateTime DateSubscribed { get; set; }
        public bool HasUnsubscribed { get; set; }
    }
}
