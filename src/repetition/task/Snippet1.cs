using System;
class Snippet1 {
    static void Main() {
       int c = 1, product = 1; 
        while (c <= 5) {
            product = product * 5;
            c = c + 1;
        }
        Console.WriteLine("product = " + product);
    }
}