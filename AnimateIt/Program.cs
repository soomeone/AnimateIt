using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimateIt
{
    class Program
    {
        static void Main(string[] args)
        {
            int fps = 15;

            if (args.Length >= 2)
                fps = int.Parse(args[1]);
            BackgroundManager bm = new BackgroundManager(args[0], fps);
            bm.Start();
        }
    }
}
