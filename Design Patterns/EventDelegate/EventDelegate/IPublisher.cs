using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate
{
    public interface IPublisher<T>
    {
        event EventHandler<MessageArgument<T>> DataPublishHandler;
        void PublishData(T data);
    }
}
