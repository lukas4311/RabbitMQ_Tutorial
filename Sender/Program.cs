using System;
using System.Runtime.InteropServices;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            SenderService senderService = new SenderService();
            senderService.SendMessage();
        }
    }
}
