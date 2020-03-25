using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate
{
    public class Subscriber<T>
    {
        public IPublisher<T> Publisher { get; private set; }
        public Subscriber(IPublisher<T> publisher)
        {
            Publisher = publisher;
        }
    }

    //public class IntSubscriber : ISubscriber<int>
    //{
    //    public IntSubscriber(IPublisher<int> publisher) : base(publisher)
    //    {
    //        publisher.DataPublisher += publisher_DataPublisher;
    //    }

    //    void publisher_DataPublisher(object sender, MessageArgument<int> e)
    //    {
    //        Console.WriteLine(e.Message);
    //    }
    //}

    //public class StringSubscriber : ISubscriber<string>
    //{
    //    public StringSubscriber(IPublisher<string> publisher) : base(publisher)
    //    {
    //        publisher.DataPublisher += publisher_DataPublisher;
    //    }

    //    void publisher_DataPublisher(object sender, MessageArgument<string> e)
    //    {
    //        Console.WriteLine(e.Message);
    //    }
    //}
}
