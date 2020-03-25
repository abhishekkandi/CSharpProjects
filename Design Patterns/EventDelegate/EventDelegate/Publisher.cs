using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate
{
    public class MessageArgument<T> : EventArgs 
    {
        public T Message { get;  private set; }
        public MessageArgument(T message)
        {
            Message = message;
        }
    }
    
    public class Publisher<T> : IPublisher<T>
    {
        //Defined datapublisher event
        public event EventHandler<MessageArgument<T>> DataPublishHandler;

        private void OnDataPublisher(MessageArgument<T> args)
        {
            var handler = DataPublishHandler;
            if (handler != null)
                handler(this, args);
        }


        public void PublishData(T data)
        {
            MessageArgument<T> message = (MessageArgument<T>)Activator.CreateInstance(typeof(MessageArgument<T>), new object[] { data });
            OnDataPublisher(message);
        }
    }
}
