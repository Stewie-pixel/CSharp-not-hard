using System;
class Snippet2 {
    static void Main() {
        int a = 31, b = 0, sum = 0;
        while (b <= a) {
            sum = sum + a;
            b = b + 2;
        }
        Console.WriteLine("sum = " + sum);
    }
}