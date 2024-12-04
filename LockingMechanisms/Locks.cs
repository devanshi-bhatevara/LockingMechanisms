using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockingMechanisms
{
    public class Locks
    {
        private static object _lock = new object();
        public static void MainLock()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(DoWork).Start();
            }
            Console.ReadLine();
        }
        public static void DoWork()
        {
            lock (_lock)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting");
                Thread.Sleep(2000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed");
            }
        }
    }
}
