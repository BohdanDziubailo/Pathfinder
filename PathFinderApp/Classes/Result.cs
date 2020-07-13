using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinderApp.Classes
{
    public class Result
    {
        public readonly bool State;
        public readonly string Description;

        public Result(bool state, string descr)
        {
            State = state;
            Description = descr;
        }
    }
}
