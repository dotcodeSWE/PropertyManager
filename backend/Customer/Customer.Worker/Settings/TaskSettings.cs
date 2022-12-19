namespace Customer.Worker.Settings
{
    public class TaskSettings
    {
        public const string Setting = "TaskSettings";
        public int OlderThanDays { get; set; }
        public string ExecuteEvery { get; set; }
    }
}
