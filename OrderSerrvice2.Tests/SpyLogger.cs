using OrderService_for_Spy;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSerrvice2.Tests
{
    public class SpyLogger : ILogger
    {
        public int CallCount { get; private set; } // автовластивість лічмльник викликів

        public string LastMessage { get; private set; } // автовластивість -останнє повідомлення

        public void Log(string message)
        {
            CallCount++; // лічить кожен виклик Log() 
            LastMessage = message;
        }
    }
}
/* SpyLogger
       - Фіксує кожен виклик Log()
       - Збільшує лічильник CallCount
       - Запам'ятовує останнє повідомлення
 * */
