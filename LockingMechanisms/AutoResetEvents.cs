using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockingMechanisms
{
    public class AutoResetEvents
    {
        static AutoResetEvent are = new AutoResetEvent(true);

        public static void MainARE()
        {

            for (int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }
            Thread.Sleep(3000);
            //if i set this from main thread another thread will get signal to write and it will start behaving abnormally
            //so it should only set from the same thread that has made it wait
            //in such situations MUTEX comes to help
            are.Set();
            Console.ReadLine();
        }
        public static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} waiting");
            are.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing");
            Thread.Sleep(1000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has completed writing");
            are.Set();
        }
    }
}
