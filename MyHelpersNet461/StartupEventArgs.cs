using System.Collections.Generic;
using System.ComponentModel;

namespace Mobilize.Helpers
{
    public class StartupEventArgs : CancelEventArgs
    {
        private IList<string> args;

        public StartupEventArgs(IList<string> args) { this.args = args; }


        public IList<string> CommandLine => this.args;
    }
}