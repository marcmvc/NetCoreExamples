using System;

namespace Packt.Shared
{
    public class BossInfoEventArgs:EventArgs
    {
        public DateTime CallDateTime;
        public string Message;
    }    
}