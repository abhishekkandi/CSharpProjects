using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate
{
    public class Client
    {
        private readonly IPublisher<int> IntPublisher;
        private readonly Subscriber<int> IntSublisher1;
        private readonly Subscriber<int> IntSublisher2;

        private readonly IPublisher<string> StringPublisher;
        private readonly Subscriber<string> StringSubscriber1;

        public Client()
        {
            IntPublisher = new Publisher<int>();
            StringPublisher = new Publisher<string>();

            IntSublisher1 = new Subscriber<int>(IntPublisher);
            IntSublisher1.Publisher.DataPublishHandler += publisher_DataPublisher1;

            IntSublisher2 = new Subscriber<int>(IntPublisher);
            IntSublisher2.Publisher.DataPublishHandler += publisher_DataPublisher2;

            StringSubscriber1 = new Subscriber<string>(StringPublisher);
            StringSubscriber1.Publisher.DataPublishHandler += publisher_DataPublisher3;

            //IntPublisher.PublishData(10);
            StringPublisher.PublishData("Abs you're awesome!");
        }

        void publisher_DataPublisher1(object sender, MessageArgument<int> e)
        {
            Console.WriteLine("Integer Subscriber 1 : " + e.Message);
        }


        void publisher_DataPublisher2(object sender, MessageArgument<int> e)
        {
            Console.WriteLine("Integer Subscriber 2 : " + e.Message);
        }

        void publisher_DataPublisher3(object sender, MessageArgument<string> e)
        {
            Console.WriteLine("String Subscriber 1 : " + e.Message);
        }
    }
}
