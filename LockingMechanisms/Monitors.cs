using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockingMechanisms
{
    public class Monitors
    {
        private static object _lock = new object();
        public static void MainMonitor()
        {
            for (int i = 0; i < 5; i++)
            {
                //new Thread(DoWork).Start();
                new Thread(DoWorkWithException).Start();
            }
            Console.ReadLine();
        }
        //same as lock lock is just a cimpler way to write monitor
        //monitors provide more flexibility like allows to handle exception
        public static void DoWork()
        {
            Monitor.Enter(_lock);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting");
                Thread.Sleep(2000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed");
            Monitor.Exit(_lock);
        } 
        public static void DoWorkWithException()
        {
            try
            {
                Monitor.Enter(_lock);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting");
                Thread.Sleep(2000);
                if (Thread.CurrentThread.ManagedThreadId == 7)
                {
                    throw new IndexOutOfRangeException();
                }
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed");
            }
            catch(Exception e) 
            {
                Console.WriteLine("Message: " + e.Message);
            
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
    }
}
