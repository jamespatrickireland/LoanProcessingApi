using System.Text.Json.Serialization;

namespace LoanProcessingApi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApplicationStatus
    {
        Approved,
        Rejected
    }
}
