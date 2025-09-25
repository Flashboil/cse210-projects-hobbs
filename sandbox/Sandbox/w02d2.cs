using System;

class Program
{
    static void Main(string[] args)
    {
        int x = 2;
        int y = 3;
        int sum = Adder(x, y);

        Console.WriteLine(sum);

        GreetUser("Bob");


        string someonesName = "Jill";
        GreetUser(someonesName);
    }

    static int Adder(int a, int b)
    {
        return a + b;
    }

    static void GreetUser(string firstName)
    {
        Console.WriteLine($"Hello {firstName}!");
    }
}