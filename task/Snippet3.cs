using System;
class Snippet3 {
    static void Main() {
        int x = 1;
        int total = 0;
        while (x <= 10) {
            total = total + x;
            x = x + 1;
        }
        Console.WriteLine("total = " + total);
    }
}