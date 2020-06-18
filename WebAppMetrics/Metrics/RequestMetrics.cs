using App.Metrics;
using App.Metrics.Counter;

namespace WebAppMetrics.Metrics
{
    public static class RequestMetrics
    {

        public static CounterOptions GetCustomersCounter => new CounterOptions
        {
            Name = "customers_get_request",
            Context = "CustomersAPI",
            MeasurementUnit = Unit.Calls
        };


        public static CounterOptions CreateCustomersCounter => new CounterOptions
        {
            Name = "customers_create_request",
            Context = "CustomersAPI",
            MeasurementUnit = Unit.Calls
        };
    }
}
