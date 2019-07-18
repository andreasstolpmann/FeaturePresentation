using System;

namespace DefaultInterfaceImplementations
{
    public interface A
    {
        void M() => Console.WriteLine("Interface A");
    }


    public interface B : A
    {
        void A.M() => Console.WriteLine("Interface B");
    }


    public interface C : A
    {
        void A.M() => Console.WriteLine("Interface C");
    }



    public class D : B, C
    {
        void A.M() => Console.WriteLine("D!");

        //void M() => Console.WriteLine("D!");
        //void B.M() => Console.WriteLine("D!");
        //void C.M() => Console.WriteLine("D!");
    }
}