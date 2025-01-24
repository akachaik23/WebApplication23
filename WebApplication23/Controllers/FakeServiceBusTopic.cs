namespace WebApplication23.Controllers
{
    public class FakeServiceBusTopic : IServiceBusTopic
    {
        private readonly ILogger<FakeServiceBusTopic> _logger;
        private readonly IMyService _myService;

        public FakeServiceBusTopic(ILogger<FakeServiceBusTopic> logger, IMyService myService)
        {
            _logger = logger;
            _myService = myService;
        }

        public string GetData()
        {
            _logger.LogInformation("Hello from FakeServiceBusTopic");
            return "Hello from FakeServiceBusTopic";
        }
    }
}
