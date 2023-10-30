using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples;

public class ParallelTasks
{
    public static void RunSample(string[] args)
    {
        Thread.CurrentThread.Name = "Sample-Main";
        outputThreadInfo("Parallel tasks start");
        //RunInvoke();
        //RunTasks();
        TaskSample2(args);
        outputThreadInfo($"Parallel tasks end");

    }

    static void RunInvoke()
    {
        Parallel.Invoke(() => DoSomeWork(), () => DoSomeOtherWork());
    }

    static void RunTasks()
    {
        Task task1 = new Task(() => DoSomeWork());
        task1.Start();
        var task2 = Task.Run(() => DoSomeOtherWork());
        task1.Wait();
        task2.Wait();
    }

    static void DoSomeWork()
    {
        outputThreadInfo("DoSomeWork start");
        Thread.Sleep(1000);
        outputThreadInfo("DoSomeWork end");

    }
    static void DoSomeOtherWork()
    {
        outputThreadInfo("DoSomeOtherWork start");
        Thread.Sleep(1000);
        outputThreadInfo("DoSomeOtherWork end");

    }


    static void TaskSample2(string[] args)
    {
        Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Statred");

        #region Stat Method
        //Creating Task using Method
        Task task1 = new Task(PrintCounter);
        task1.Start();

        //Creating Task using Anonymous Method
        Task task2 = new Task(delegate ()
        {
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            Task.Delay(200);
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        });
        task2.Start();

        //Creating Task using Lambda Expression
        Task task3 = new Task(() =>
        {
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            Task.Delay(200);
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        });
        task3.Start();
        #endregion

        #region StartNew
        //Creating Task using Method
        Task task4 = Task.Factory.StartNew(PrintCounter);

        //Creating Task using Anonymous Method
        Task task5 = Task.Factory.StartNew(delegate ()
        {
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            Task.Delay(200);
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        });

        //Creating Task using Lambda Expression
        Task task6 = Task.Factory.StartNew(() =>
        {
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            Task.Delay(200);
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        });

        #endregion

        #region Run
        //Creating Task using Method
        Task task7 = Task.Run(PrintCounter);

        //Creating Task using Anonymous Method
        Task task8 = Task.Run(delegate ()
        {
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            Task.Delay(200);
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        });

        //Creating Task using Lambda Expression
        Task task9 = Task.Run(() =>
        {
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            Task.Delay(200);
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        });

        #endregion

        Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        Console.ReadKey();
    }

    static void PrintCounter()
    {
        Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
        Thread.Sleep(200);
        Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
    }

    static void outputThreadInfo(string msg)
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}, {Thread.CurrentThread.Name}, {msg}");
    }
}
