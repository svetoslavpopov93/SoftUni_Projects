using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

namespace Problem2_AsyncTimer
{
    class AsyncTimer
    {
        private int t;
        private int ticks;
        private Action exec;

        public AsyncTimer(int t, int ticks, Action exec)
        {
            this.t = t;
            this.ticks = ticks;
            this.exec = exec;
        }

        public async void Repeat()
        {
            for (int i = 0; i < this.ticks; i++)
            {
                Thread newThread = new Thread(() =>
                {
                    int passedTicks = 0;
                    while (passedTicks < this.ticks)
                    {
                        this.exec();
                        passedTicks++;
                        Thread.Sleep(this.t);
                    }
                });


                newThread.Start();
            }
        }


        

    }
}
