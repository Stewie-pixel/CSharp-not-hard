using System;

public class TestMyPolynomial
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Testing MyPolynomial Class...");

        // Test Constructor and GetDegree
        TestGetDegree();

        // Test Evaluate
        TestEvaluate();

        // Test Add
        TestAdd();

        // Test Multiply
        TestMultiply();

        // Test ToString
        TestToString();

        Console.WriteLine("\n--- All Tests Completed ---");
    }

    private static void TestGetDegree()
    {
        Console.WriteLine("\n--- Test GetDegree ---");
        MyPolynomial p1 = new MyPolynomial(new double[] { 1.0, 2.0, 3.0 }); // 3x^2 + 2x + 1
        Console.WriteLine($"Polynomial: {p1}");
        Console.WriteLine($"Expected Degree: 2, Actual Degree: {p1.GetDegree()}");

        MyPolynomial p2 = new MyPolynomial(new double[] { 5.0 }); // 5
        Console.WriteLine($"Polynomial: {p2}");
        Console.WriteLine($"Expected Degree: 0, Actual Degree: {p2.GetDegree()}");

        MyPolynomial p3 = new MyPolynomial(new double[] { 0.0, 0.0, 0.0 }); // 0
        Console.WriteLine($"Polynomial: {p3}");
        Console.WriteLine($"Expected Degree: 0, Actual Degree: {p3.GetDegree()}");

        MyPolynomial p4 = new MyPolynomial(new double[] { 1.0, 2.0, 0.0 }); // 2x + 1 (constructor should trim 0.0)
        Console.WriteLine($"Polynomial: {p4}");
        Console.WriteLine($"Expected Degree: 1, Actual Degree: {p4.GetDegree()}");
    }

    private static void TestEvaluate()
    {
        Console.WriteLine("\n--- Test Evaluate ---");
        MyPolynomial p = new MyPolynomial(new double[] { 1.0, 2.0, 3.0 }); // 3x^2 + 2x + 1
        Console.WriteLine($"Polynomial: {p}");
        Console.WriteLine($"Evaluate at x=0: Expected 1, Actual: {p.Evaluate(0)}"); // 1
        Console.WriteLine($"Evaluate at x=1: Expected 6, Actual: {p.Evaluate(1)}"); // 3+2+1 = 6
        Console.WriteLine($"Evaluate at x=2: Expected 17, Actual: {p.Evaluate(2)}"); // 3*4 + 2*2 + 1 = 12+4+1 = 17

        MyPolynomial p2 = new MyPolynomial(new double[] { 5.0 }); // 5
        Console.WriteLine($"Polynomial: {p2}");
        Console.WriteLine($"Evaluate at x=10: Expected 5, Actual: {p2.Evaluate(10)}");
    }

    private static void TestAdd()
    {
        Console.WriteLine("\n--- Test Add ---");
        MyPolynomial p1 = new MyPolynomial(new double[] { 1.0, 2.0 }); // 2x + 1
        MyPolynomial p2 = new MyPolynomial(new double[] { 3.0, 4.0, 5.0 }); // 5x^2 + 4x + 3
        Console.WriteLine($"P1: {p1}");
        Console.WriteLine($"P2: {p2}");
        MyPolynomial sum1 = p1.Add(p2); // Should be 5x^2 + 6x + 4
        Console.WriteLine($"P1 + P2: Expected 5x^2 + 6x + 4, Actual: {sum1}");

        MyPolynomial p3 = new MyPolynomial(new double[] { 1.0, 2.0, 3.0 }); // 3x^2 + 2x + 1
        MyPolynomial p4 = new MyPolynomial(new double[] { -1.0, -2.0, -3.0 }); // -3x^2 - 2x - 1
        Console.WriteLine($"P3: {p3}");
        Console.WriteLine($"P4: {p4}");
        MyPolynomial sum2 = p3.Add(p4); // Should be 0
        Console.WriteLine($"P3 + P4: Expected 0, Actual: {sum2}");

        MyPolynomial p5 = new MyPolynomial(new double[] { 0.0 }); // 0
        MyPolynomial p6 = new MyPolynomial(new double[] { 1.0, 1.0 }); // x + 1
        Console.WriteLine($"P5: {p5}");
        Console.WriteLine($"P6: {p6}");
        MyPolynomial sum3 = p5.Add(p6); // Should be x + 1
        Console.WriteLine($"P5 + P6: Expected x + 1, Actual: {sum3}");
    }

    private static void TestMultiply()
    {
        Console.WriteLine("\n--- Test Multiply ---");
        MyPolynomial p1 = new MyPolynomial(new double[] { 1.0, 1.0 }); // x + 1
        MyPolynomial p2 = new MyPolynomial(new double[] { 1.0, -1.0 }); // -x + 1
        Console.WriteLine($"P1: {p1}");
        Console.WriteLine($"P2: {p2}");
        MyPolynomial product1 = p1.Multiply(p2); // (x+1)(-x+1) = -x^2 + 1
        Console.WriteLine($"P1 * P2: Expected -x^2 + 1, Actual: {product1}");

        MyPolynomial p3 = new MyPolynomial(new double[] { 1.0, 2.0 }); // 2x + 1
        MyPolynomial p4 = new MyPolynomial(new double[] { 3.0, 4.0 }); // 4x + 3
        Console.WriteLine($"P3: {p3}");
        Console.WriteLine($"P4: {p4}");
        MyPolynomial product2 = p3.Multiply(p4); // (2x+1)(4x+3) = 8x^2 + 6x + 4x + 3 = 8x^2 + 10x + 3
        Console.WriteLine($"P3 * P4: Expected 8x^2 + 10x + 3, Actual: {product2}");

        MyPolynomial p5 = new MyPolynomial(new double[] { 0.0 }); // 0
        MyPolynomial p6 = new MyPolynomial(new double[] { 1.0, 2.0, 3.0 }); // 3x^2 + 2x + 1
        Console.WriteLine($"P5: {p5}");
        Console.WriteLine($"P6: {p6}");
        MyPolynomial product3 = p5.Multiply(p6); // 0 * (3x^2 + 2x + 1) = 0
        Console.WriteLine($"P5 * P6: Expected 0, Actual: {product3}");
    }

    private static void TestToString()
    {
        Console.WriteLine("\n--- Test ToString ---");
        MyPolynomial p1 = new MyPolynomial(new double[] { 1.0, 2.0, 3.0 }); // 3x^2 + 2x + 1
        Console.WriteLine($"Coeffs: {{1, 2, 3}}, Expected: 3x^2 + 2x + 1, Actual: {p1.ToString()}");

        MyPolynomial p2 = new MyPolynomial(new double[] { 5.0 }); // 5
        Console.WriteLine($"Coeffs: {{5}}, Expected: 5, Actual: {p2.ToString()}");

        MyPolynomial p3 = new MyPolynomial(new double[] { 0.0 }); // 0
        Console.WriteLine($"Coeffs: {{0}}, Expected: 0, Actual: {p3.ToString()}");

        MyPolynomial p4 = new MyPolynomial(new double[] { 1.0, 0.0, 3.0 }); // 3x^2 + 1
        Console.WriteLine($"Coeffs: {{1, 0, 3}}, Expected: 3x^2 + 1, Actual: {p4.ToString()}");

        MyPolynomial p5 = new MyPolynomial(new double[] { -1.0, 2.0, -3.0 }); // -3x^2 + 2x - 1
        Console.WriteLine($"Coeffs: {{-1, 2, -3}}, Expected: -3x^2 + 2x - 1, Actual: {p5.ToString()}");

        MyPolynomial p6 = new MyPolynomial(new double[] { 1.0, -1.0 }); // -x + 1
        Console.WriteLine($"Coeffs: {{1, -1}}, Expected: -x + 1, Actual: {p6.ToString()}");

        MyPolynomial p7 = new MyPolynomial(new double[] { -1.0, -1.0 }); // -x - 1
        Console.WriteLine($"Coeffs: {{-1, -1}}, Expected: -x - 1, Actual: {p7.ToString()}");

        MyPolynomial p8 = new MyPolynomial(new double[] { 0, 1, 0, 0 }); // x
        Console.WriteLine($"Coeffs: {{0, 1, 0, 0}}, Expected: x, Actual: {p8.ToString()}");

        MyPolynomial p9 = new MyPolynomial(new double[] { 1, 1, 0, 0 }); // x + 1
        Console.WriteLine($"Coeffs: {{1, 1, 0, 0}}, Expected: x + 1, Actual: {p9.ToString()}");
    }
}
