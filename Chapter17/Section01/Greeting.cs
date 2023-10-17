using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class GreetingMorning : GreetingBase{
        public override string GetMessage() =>"おはよう";
    }

    class GreetingAfternoon : GreetingBase {
        public override string GetMessage() => "こんにちは";
    }

    class GreetingEvening : GreetingBase {
        public override string GetMessage() =>"こんばんは";
    }
}
