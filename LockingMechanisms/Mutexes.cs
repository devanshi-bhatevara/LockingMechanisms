using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockingMechanisms
{
    public class Mutexes
    {
        static Mutex mutex = new Mutex();

        public static void MainMutex()
        {

            for (int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }
            Thread.Sleep(3000);
           

            //here in case of mutex it will throw an exception as only the thread that locked the mutex can release it
            //thus overcomes the problem of ARE

            mutex.ReleaseMutex();
            Console.ReadLine();
        }
        public static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} waiting");
            mutex.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing");
            Thread.Sleep(1000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has completed writing");
            mutex.ReleaseMutex();
        }
    }
}
