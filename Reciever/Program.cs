﻿using System;

namespace Reciever
{
    class Program
    {
        static void Main(string[] args)
        {
            RecieverService recieverService = new RecieverService();
            recieverService.RecieverMessage();
        }
    }
}
