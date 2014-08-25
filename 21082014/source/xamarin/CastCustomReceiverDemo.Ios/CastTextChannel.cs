using System;
using GoogleCast;

namespace CastCustomReceiverDemo.Ios
{
    public class CastTextChannel : GCKCastChannel
    {
        public CastTextChannel(string channelNameSpace)
            : base(channelNameSpace)
        {
            
        }

        public override void DidReceiveTextMessage(string message)
        {
            base.DidReceiveTextMessage(message);
            Console.WriteLine("Message received back from ChromeCast: " + message);
        }
    }
}