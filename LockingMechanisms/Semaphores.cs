using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockingMechanisms
{
    public class Semaphores
    {
        static Semaphore semaphore = new Semaphore(3,4);

        public static void MainSemaphore()
        {
             
            for (int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }
            Thread.Sleep(3000);

        }
        public static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} waiting");
            semaphore.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has completed writing");
            semaphore.Release();
        }
    }
}
