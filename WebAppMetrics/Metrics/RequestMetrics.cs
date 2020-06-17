using App.Metrics;
using App.Metrics.Counter;

namespace WebAppMetrics.Metrics
{
    public static class RequestMetrics
    {

        public static CounterOptions GetCustomersCounter => new CounterOptions
        {
            Name = "Get Customers Request",
            Context = "CustomersAPI",
            MeasurementUnit = Unit.Calls
        };


        public static CounterOptions CreateCustomersCounter => new CounterOptions
        {
            Name = "Create Customers Request",
            Context = "CustomersAPI",
            MeasurementUnit = Unit.Calls
        };
    }
}
