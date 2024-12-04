using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockingMechanisms
{
    public class ManualResetEvents
    {
        static ManualResetEvent mre = new ManualResetEvent(false);
     
        public static void MainMRE()
        {
            new Thread(Write).Start();

            for (int i = 0; i < 5; i++)
            {
                new Thread(Read).Start();
            }
            Console.ReadLine();
        }
     
        public static void Write()
        {
            mre.Reset();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing");
            Thread.Sleep(5000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has completed writing");
            mre.Set();
        }  
        
        public static void Read()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is waiting");
            mre.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is reading");

        }
    }
}
