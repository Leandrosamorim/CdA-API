using Domain.Models;
using Hangfire;

namespace Microservices.Models.Interfaces
{
    public interface IQueueServices
    {
        public CriminalCode Consume();

        public bool Dequeue();

    }
}
