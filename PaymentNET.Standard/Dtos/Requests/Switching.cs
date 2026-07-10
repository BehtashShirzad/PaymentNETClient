using System.Collections.Generic;

namespace PaymentNET.Standard.Dtos.Requests
{
    public class Switching
    {
        public List<string> TerminalIds{get;set;}= new List<string>();
        public bool AutoSwitching{get;set;}= false;
    }
}