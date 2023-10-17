using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class GreetingMorning : IGreeting{
        public string GetMessage() =>"おはよう";
    }

    class GreetingAfternoon : IGreeting {
        public string GetMessage() => "こんにちは";
    }

    class GreetingEvening : IGreeting {
        public string GetMessage() =>"こんばんは";
    }
}
