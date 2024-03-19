using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Study.Processor;
using System.Threading;
using Study.Helpers;
using System.Globalization;
using Study.DemoSingleton;
using CS021_ASYNCHRONOUS;
using System.Runtime.CompilerServices;
using Study.Models;
using Study.PrototypePattern;

public class Program
{
    static async Task Task2()
    {
        Task t2 = new Task(
            (object ob) =>
            {
                string tentacvu = (string)ob;
                DoSomeThing(10, tentacvu, ConsoleColor.Yellow);
            }
            , "T2");
        t2.Start();

        await t2;
        Console.WriteLine($"End T2");
    }
    static async Task Task3() 
    {
        Task t3 = new Task(
            (object ob) =>
            {
                string tentacvu = (string)ob;
                DoSomeThing(4, tentacvu, ConsoleColor.Yellow);
            }
            , "T3");
        t3.Start();

        await t3;
        Console.WriteLine($"End T3");
    }
    public static void Main(string[] args)
    {
        var chicN = new { Age = 2, Name = "c"};
        Chicken chic1 = new Chicken();
        chic1.Name = "chic1";
        chic1.Age = 10;
        Chicken chic2 = chic1;
        chic2.Name = "chic2";
        Chicken chic3 = chic1.GetClone();
        chic3.Name = "chic3";
        Console.WriteLine($"chic 1 {chic1.Name}");
        Console.WriteLine($"chic 2 {chic2.Name}");
        Console.WriteLine($"chic 3 {chic3.Name}");
        ColorManager colormanager = new ColorManager();
        // Initialize with standard colors
        colormanager["red"] = new Color(255, 0, 0);
        colormanager["green"] = new Color(0, 255, 0);
        colormanager["blue"] = new Color(0, 0, 255);
        // User adds personalized colors
        colormanager["angry"] = new Color(255, 54, 0);
        colormanager["peace"] = new Color(128, 211, 128);
        colormanager["flame"] = new Color(211, 34, 20);
        // User clones selected colors
        Color color1 = colormanager["red"].Clone() as Color;
        Color color11 = colormanager["red"] as Color;
        Color color2 = colormanager["peace"].Clone() as Color;
        Color color22 = colormanager["peace"] as Color;
        Color color3 = colormanager["flame"].Clone() as Color;
        // Wait for user
        Console.ReadKey();

        var list = new List<int>() { 5, 2, 13, 9};
        var list1 = list.Where1((x) =>
        {
            return x > 8;
        });
        var item2 = list.Where((x, y) => x > 4 && y < 2).ToList();//x: value, y: key
        var item3 = list.Where(delegate (int x)
        {
            return x > 10;
        }).ToList();
        var item4 = list.Select(x => x.ToString());
        foreach (var item in list1)
        {
            Console.WriteLine(item);
        }

        var lstChicken = new List<Chicken>() 
        {
            new Chicken()
            {
                Name = "Ling",
                DOB = "24/8/1999",
                Age = 25,
            },
            new Chicken()
            {
                Name = "Nam",
                DOB = "14/8/2000",
                Age = 24,
            },
        };
        var lstChic = lstChicken.Select1(x => x.Age);
        foreach (var item in lstChic)
        {
            Console.WriteLine(item * 4);
        }
        #region delegate,lambda expression
        //yield
        //var students = ReadStudentsFromFile1("students.txt");
        //var student2s = ReadStudentsFromFile2("students.txt");
        //foreach (var student in students)
        //{
        //    Console.WriteLine(student);
        //}
        //foreach (var student2 in student2s)
        //{
        //    Console.WriteLine(student2);
        //}

        //foreach (var number in GenerateFibonacci(10))
        //{
        //    Console.Write(number + " ");
        //}

        //        //1. Có thể bỏ qua kiểu dữ liệu của parameter truyền vào
        //        (string qua) => { Console.WriteLine("Tặng quà: " + qua); }
        //        (qua) => { Console.WriteLine("Tặng quà: " + qua); }

        //        //2. Nếu không có parameter, bỏ dấu () trống
        //        () => { Console.WriteLine("Hello"); }

        //        //3. Nếu chỉ có 1 parameter, có thể bỏ luôn dấu ()
        //        (x) => { Console.WriteLine("Hello " + x); }
        //        x => { Console.WriteLine("Hello " + x); }

        //        //4. Nếu có nhiều parameter, ngăn cách bằng dấu phẩy
        //        (x, y) => { Console.WriteLine("Hello " + x + y); }

        //        //5. Nếu anonymous function chỉ có 1 câu lệnh, có thể bỏ dấu {}
        //        x => { Console.WriteLine("Hello " + x); }
        //x => Console.WriteLine("Hello " + x)

        ////6. Nếu chỉ return 1 giá trị, có thể bỏ chữ return.
        ////4 lambda expression sau tương đương nhau
        //(x) => { return x > 4; }
        //        x => { return x > 4; }
        //x => return x > 4
        //x => x > 4
        NewDelegate newDelegate = TestFunction;//default
        NewDelegate newDelegate1 = delegate (string message)
        {
            return int.Parse(message);
        };//anonymous function
        NewDelegate newDelegate2 = (message) =>
        {
            return int.Parse(message);
        };//lambda expression
        GiveGift2(StayHome, newDelegate, "2024");
        Task t2 = Task2();
        Task t3 = Task3();
        DoSomeThing(6, "T1", ConsoleColor.Green);

        Console.WriteLine("End all");
        Console.ReadLine();
        //return;
        //GiveGift(stayHome);
        Func<string, int> testFunc2 = (str) =>
        {
            return int.Parse(str);
        };
        testFunc2("22");

        GiveGift(StayHome, TestFunction, "2024");
        GiveGift(StayHome, testFunc2, "2024");
        Console.WriteLine("stop");
        #endregion

        #region comment

        Student std = new Student();
        string str1 = std.GetName();
        string str = "hello2";
        Console.WriteLine(str.LastOrDefault());
        if ("sd2ld".Contains(str.LastOrDefault()))
            Console.WriteLine("true");
        List<int> ints = new List<int>();
        int _1 = ints.Where(x => x > 0).Count();
        int sum = ints.Sum();

        DemoThread("sd");
        //Thread t = new Thread(() =>
        //{
        //    DemoThread("thread1");
        //});
        //Thread t2 = new Thread(() =>
        //{
        //    DemoThread("thread2");
        //});
        //Thread t3 = new Thread(() =>
        //{
        //    DemoThread("thread3");
        //});
        //t.Start();
        //t2.Start();
        //t3.Start();
        Console.ReadLine();
        //test git fetch
        #region stack issue
        int[] arr = new int[7] { 2, 1, 3, 2, 8, 5, 7 };
        int[] res = new int[7];
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        res[0] = -1;
        int flag = -1;
        Console.Write(res[0] + ", ");
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i - 1] > arr[i])
            {
                stack.Push(i);
                res[i] = i - 1;
            }
            else
            {
                while (stack.Count > 0 && arr[stack.Peek()] < arr[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    res[i] = stack.Peek();
                }
                else
                {
                    stack.Push(i);
                    res[i] = -1;
                }
            }
            Console.Write(res[i] + ", ");
        }
        #endregion

        //int i = 3;
        //int j = 3;
        Student stu = new Student();
        string per1 = stu.GetName();
        string per2 = stu.GetName();
        if (per1 == per2)
        {
            Console.WriteLine("pass");
        }
        else
        {
            Console.WriteLine("failed");
        }

        foreach (int item in res)
        {
            Console.Write(item + ", ");
        }
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.WriteLine(arr[i]);
        //}
        //AmericanEngine ae = new AmericanEngine();
        //Car car = new Car("Mercedes", ae);
        //ArrayList arrList = new ArrayList(arr);
        //Hashtable hashtable = new Hashtable();
        //SortedList sortedList = new SortedList();
        //sortedList.Add("h", "hash");
        //sortedList["b"] = "bb";

        //sortedList.Add("t", "table");

        //sortedList["a"] = "aaaa";
        //Stack stack = new Stack(arrList);
        //stack.Push("education");
        //stack.Push("kteam");
        //int length = stack.Count;
        //for (int i = 0; i < stack.Count; i++)
        //{
        //    //Console.WriteLine(sortedList.GetByIndex(i).ToString());
        //    Console.WriteLine(@"Count : {0} - {1}",stack.Count, stack.Pop());
        //}
        //Console.WriteLine(@"Count after : {0}", stack.Count);

        //foreach (DictionaryEntry key in sortedList)
        //{
        //    Console.WriteLine(key.Key + " - " +key.Value);
        //}
        int first = 2;
        int second = 4;
        //first = Swap(first, second);
        //Console.WriteLine("first : " + first);
        #endregion
    }
    static bool MyPredicate(int obj)
    {
        return obj > 2;
    }
    static IEnumerable<int> ReadStudentsFromFile2(string fileName)
    {
        string[] lines = new string[] { "4", "5", "6" };
        foreach (var line in lines)
        {
            var student = int.Parse(line);//line gán student
            yield return student; //vòng lặp đầu tiên sẽ tạm dừng ở đây và trả về kết quả student(nhưng chưa kết thúc vòng lặp như là return đơn thuần)
            Console.WriteLine("Continue here...");//vòng lặp thứ 2, 3,..sẽ bắt đầu từ đây và chạy ngược lên line gán student rồi trả về student tiếp và cứ tiếp tục như vậy
        }
    }
    static List<int> ReadStudentsFromFile1(string fileName)
    {
        string[] lines = new string[] { "1", "2", "3"};
        //Tạo một list trống
        List<int> result = new List<int>();

        foreach (var line in lines)
        {
            result.Add(int.Parse(line)); //Thêm student vào list
        }
        return result; // Trả list ra
    }
    static IEnumerable<int> GenerateFibonacci(int count)
    {
        int a = 0, b = 1;

        for (int i = 0; i < count; i++)
        {
            yield return a; // Trả về giá trị và tạm dừng tại đây

            int temp = a;
            a = b;
            b = temp + b;
        }
    }
    public delegate int NewDelegate(string message);
    public static void DoSomeThing(int seconds, string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"{message,10} ... Start");
        Console.ResetColor();

        for (var i = 0; i < seconds; i++)
        {
            Console.ForegroundColor= color;
            Console.WriteLine($"{message,10} {i,2}");
            Console.ResetColor();

            Thread.Sleep(1000);
        }

    }
    public static void GiveGift2(Action<string> stayHome, NewDelegate test, string no)
    {
        StayHome("Done 1");
        stayHome("Done 2");
        int te = test(no);
        Console.WriteLine(te);
    }
    public static void GiveGift(Action<string> stayHome, Func<string, int> test, string no)
    {
        StayHome("Done 1");
        stayHome("Done 2");
        int te = test(no);
        Console.WriteLine(te);
    }
    public static void StayHome(string wish)
    {
        Console.WriteLine("Give the gift with the wish: " + wish);
    }
    public static int TestFunction(string input)
    {
        return int.Parse(input);
    }
    public delegate void StayHomeDelegate(string str);
    public static int Swap(int a, int b)
    {
        int i = a;
        a = b;
        b = i;
        return a;
    }

    public static void DemoThread(string str)
    {
        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine(str + " - " + i);
        }
    }
    
}




