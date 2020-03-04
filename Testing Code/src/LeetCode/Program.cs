using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int retVal = Reverse(120); 
            Console.WriteLine(retVal);
            Console.WriteLine(divideby10(1234));
            int valueMax = Int32.MaxValue; 
            Console.WriteLine(valueMax); 
        }


        static public int Reverse(int x) {
        int ret = 0;
        while (x !=0 ) {
            int digit = x % 10;
            int tmp = ret * 10;
            Console.WriteLine($"digit: {digit} tmp: {tmp}");
            if (tmp / 10 != ret)
                return 0;
            
            tmp += digit;
            ret = tmp;
            x = divideby10(x);
            Console.WriteLine($"ret: {ret} tmp: {tmp} x: {x}");
        }
        return ret;
        }

        static public int divideby10(int n){

            
            int q, r;
            q = (n >> 1) + (n >> 2);
            q = q + (q >> 4);
            q = q + (q >> 8);
            q = q + (q >> 16);
            q = q >> 3;
            r = n - (((q << 2) + q) << 1);
            
            return q + (r >> 9);

        }
    }
}
