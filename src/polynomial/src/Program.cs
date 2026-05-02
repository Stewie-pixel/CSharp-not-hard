using System;
using System.Text;

namespace PolynomialApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestMyPolynomial.RunTests();
        }
    }

    public class TestMyPolynomial
    {
        public static void RunTests()
        {
            Console.WriteLine("Running MyPolynomial Tests...");

            TestPolynomialCreationAndDegree();
            TestToStringFormatting();
            TestEvaluateFunctionality();
            TestAdditionOperations();
            TestMultiplicationOperations();

            // New Edge Case Tests
            TestZeroPolynomialEdgeCases();
            TestConstantPolynomialEdgeCases();
            TestMixedDegreeOperations();
            TestOperationsResultingInZero();
            TestEvaluateSpecialValues();
            TestConstructorTrimming();

            Console.WriteLine("\nAll MyPolynomial Tests Completed.");
        }

        private static void TestPolynomialCreationAndDegree()
        {
            Console.WriteLine("\n--- Test: Polynomial Creation and GetDegree ---");
            // Test Case 1: Standard polynomial (3x^2 - 4x + 11)
            double[] coeffs1 = { 11, -4, 3 }; // a0=11, a1=-4, a2=3
            MyPolynomial p1 = new MyPolynomial(coeffs1);
            Console.WriteLine($"P1: {p1}. Degree: {p1.GetDegree()} (Expected: 2)");
            System.Diagnostics.Debug.Assert(p1.GetDegree() == 2, "Failed: P1 degree incorrect.");

            // Test Case 2: Polynomial with internal zero coefficient (5x^3 + 0x^2 + 2x + 1)
            double[] coeffs2 = { 1, 2, 0, 5 }; // a0=1, a1=2, a2=0, a3=5
            MyPolynomial p2 = new MyPolynomial(coeffs2);
            Console.WriteLine($"P2: {p2}. Degree: {p2.GetDegree()} (Expected: 3)");
            System.Diagnostics.Debug.Assert(p2.GetDegree() == 3, "Failed: P2 degree incorrect.");

            // Test Case 3: Zero polynomial (should have degree 0 and be "0")
            double[] coeffs3 = { 0 };
            MyPolynomial p3 = new MyPolynomial(coeffs3);
            Console.WriteLine($"P3: {p3}. Degree: {p3.GetDegree()} (Expected: 0)");
            System.Diagnostics.Debug.Assert(p3.GetDegree() == 0, "Failed: P3 degree incorrect for zero polynomial.");
            System.Diagnostics.Debug.Assert(p3.ToString() == "0", "Failed: P3 ToString incorrect for zero polynomial.");

            // Test Case 4: Constant polynomial (7)
            double[] coeffs4 = { 7 };
            MyPolynomial p4 = new MyPolynomial(coeffs4);
            Console.WriteLine($"P4: {p4}. Degree: {p4.GetDegree()} (Expected: 0)");
            System.Diagnostics.Debug.Assert(p4.GetDegree() == 0, "Failed: P4 degree incorrect.");
        }

        private static void TestToStringFormatting()
        {
            Console.WriteLine();
            Console.WriteLine("--- Test: ToString() Formatting ---");
            // Test Case 1: Example from PDF ("6x^4 + 8x^3 + 6x + 1")
            double[] coeffs1 = { 1, 6, 0, 8, 6 };
            MyPolynomial p1 = new MyPolynomial(coeffs1);
            string expected1 = "6x^4 + 8x^3 + 6x + 1";
            Console.WriteLine($"P1: {p1} (Expected: {expected1})");
            System.Diagnostics.Debug.Assert(p1.ToString() == expected1, $"Failed: P1 ToString. Got '{p1}', Expected '{expected1}'");

            // Test Case 2: Standard polynomial ("3x^2 - 4x + 11")
            double[] coeffs2 = { 11, -4, 3 };
            MyPolynomial p2 = new MyPolynomial(coeffs2);
            string expected2 = "3x^2 - 4x + 11";
            Console.WriteLine($"P2: {p2} (Expected: {expected2})");
            System.Diagnostics.Debug.Assert(p2.ToString() == expected2, $"Failed: P2 ToString. Got '{p2}', Expected '{expected2}'");

            // Test Case 3: Polynomial with coefficient of 1 ("x + 1")
            double[] coeffs3 = { 1, 1 };
            MyPolynomial p3 = new MyPolynomial(coeffs3);
            string expected3 = "x + 1";
            Console.WriteLine($"P3: {p3} (Expected: {expected3})");
            System.Diagnostics.Debug.Assert(p3.ToString() == expected3, $"Failed: P3 ToString. Got '{p3}', Expected '{expected3}'");

            // Test Case 4: Polynomial with coefficient of -1 ("-x^2")
            double[] coeffs4 = { 0, 0, -1 };
            MyPolynomial p4 = new MyPolynomial(coeffs4);
            string expected4 = "-x^2";
            Console.WriteLine($"P4: {p4} (Expected: {expected4})");
            System.Diagnostics.Debug.Assert(p4.ToString() == expected4, $"Failed: P4 ToString. Got '{p4}', Expected '{expected4}'");

            // Test Case 5: Constant polynomial ("5")
            double[] coeffs5 = { 5 };
            MyPolynomial p5 = new MyPolynomial(coeffs5);
            string expected5 = "5";
            Console.WriteLine($"P5: {p5} (Expected: {expected5})");
            System.Diagnostics.Debug.Assert(p5.ToString() == expected5, $"Failed: P5 ToString. Got '{p5}', Expected '{expected5}'");

            // Test Case 6: Zero polynomial ("0")
            double[] coeffs6 = { 0 };
            MyPolynomial p6 = new MyPolynomial(coeffs6);
            string expected6 = "0";
            Console.WriteLine($"P6: {p6} (Expected: {expected6})");
            System.Diagnostics.Debug.Assert(p6.ToString() == expected6, $"Failed: P6 ToString. Got '{p6}', Expected '{expected6}'");
        }

        private static void TestEvaluateFunctionality()
        {
            Console.WriteLine();
            Console.WriteLine("--- Test: Evaluate() Functionality ---");
            // Test Case 1: Evaluate 3x^2 - 4x + 11 at x=2
            double[] coeffs1 = { 11, -4, 3 };
            MyPolynomial p1 = new MyPolynomial(coeffs1);
            double x1 = 2;
            double expected1 = 3 * Math.Pow(2, 2) - 4 * 2 + 11; // 12 - 8 + 11 = 15
            double result1 = p1.Evaluate(x1);
            Console.WriteLine($"P1({x1}): {result1} (Expected: {expected1})");
            System.Diagnostics.Debug.Assert(result1 == expected1, $"Failed: P1 Evaluate({x1}) result incorrect.");

            // Test Case 2: Evaluate 6x^4 + 8x^3 + 6x + 1 at x=1
            double[] coeffs2 = { 1, 6, 0, 8, 6 };
            MyPolynomial p2 = new MyPolynomial(coeffs2);
            double x2 = 1;
            double expected2 = 6 + 8 + 6 + 1; // 21
            double result2 = p2.Evaluate(x2);
            Console.WriteLine($"P2({x2}): {result2} (Expected: {expected2})");
            System.Diagnostics.Debug.Assert(result2 == expected2, $"Failed: P2 Evaluate({x2}) result incorrect.");

            // Test Case 3: Evaluate zero polynomial at x=5
            double[] coeffs3 = { 0 };
            MyPolynomial p3 = new MyPolynomial(coeffs3);
            double x3 = 5;
            double expected3 = 0;
            double result3 = p3.Evaluate(x3);
            Console.WriteLine($"P3({x3}): {result3} (Expected: {expected3})");
            System.Diagnostics.Debug.Assert(result3 == expected3, $"Failed: P3 Evaluate({x3}) result incorrect.");
        }

        private static void TestAdditionOperations()
        {
            Console.WriteLine();
            Console.WriteLine("--- Test: Add() Operations ---");
            // Test Case 1: (3x^2 - 4x + 11) + (x^3 + 2x - 5) = x^3 + 3x^2 - 2x + 6
            double[] coeffs1_p1 = { 11, -4, 3 };
            MyPolynomial p1_add = new MyPolynomial(coeffs1_p1);
            double[] coeffs2_p2 = { -5, 2, 0, 1 };
            MyPolynomial p2_add = new MyPolynomial(coeffs2_p2);
            MyPolynomial sum = p1_add.Add(p2_add);
            string expectedSum = "x^3 + 3x^2 - 2x + 6";
            Console.WriteLine($"({new MyPolynomial(coeffs1_p1)}) + ({new MyPolynomial(coeffs2_p2)}) = {sum} (Expected: {expectedSum})");
            System.Diagnostics.Debug.Assert(sum.ToString() == expectedSum, $"Failed: Add Test 1. Got '{sum}', Expected '{expectedSum}'");

            // Test Case 2: Zero polynomial + (x + 1) = x + 1
            double[] coeffs3_p3 = { 0 };
            MyPolynomial p3_add = new MyPolynomial(coeffs3_p3);
            double[] coeffs4_p4 = { 1, 1 };
            MyPolynomial p4_add = new MyPolynomial(coeffs4_p4);
            MyPolynomial sum2 = p3_add.Add(p4_add);
            string expectedSum2 = "x + 1";
            Console.WriteLine($"({new MyPolynomial(coeffs3_p3)}) + ({new MyPolynomial(coeffs4_p4)}) = {sum2} (Expected: {expectedSum2})");
            System.Diagnostics.Debug.Assert(sum2.ToString() == expectedSum2, $"Failed: Add Test 2. Got '{sum2}', Expected '{expectedSum2}'");

            // Test Case 3: (x + 1) + (-x - 1) = 0
            double[] coeffs5_p5 = { 1, 1 };
            MyPolynomial p5_add = new MyPolynomial(coeffs5_p5);
            double[] coeffs6_p6 = { -1, -1 };
            MyPolynomial p6_add = new MyPolynomial(coeffs6_p6);
            MyPolynomial sum3 = p5_add.Add(p6_add);
            string expectedSum3 = "0";
            Console.WriteLine($"({new MyPolynomial(coeffs5_p5)}) + ({new MyPolynomial(coeffs6_p6)}) = {sum3} (Expected: {expectedSum3})");
            System.Diagnostics.Debug.Assert(sum3.ToString() == expectedSum3, $"Failed: Add Test 3. Got '{sum3}', Expected '{expectedSum3}'");
        }

        private static void TestMultiplicationOperations()
        {
            Console.WriteLine();
            Console.WriteLine("--- Test: Multiply() Operations ---");
            // Test Case 1: (x + 1) * (x - 1) = x^2 - 1
            double[] coeffs1_p1 = { 1, 1 };
            MyPolynomial p1_mult = new MyPolynomial(coeffs1_p1);
            double[] coeffs2_p2 = { -1, 1 };
            MyPolynomial p2_mult = new MyPolynomial(coeffs2_p2);
            MyPolynomial product1 = p1_mult.Multiply(p2_mult);
            string expectedProduct1 = "x^2 - 1";
            Console.WriteLine($"({new MyPolynomial(coeffs1_p1)}) * ({new MyPolynomial(coeffs2_p2)}) = {product1} (Expected: {expectedProduct1})");
            System.Diagnostics.Debug.Assert(product1.ToString() == expectedProduct1, $"Failed: Multiply Test 1. Got '{product1}', Expected '{expectedProduct1}'");

            // Test Case 2: (2x) * (x^2 + 3) = 2x^3 + 6x
            double[] coeffs3_p3 = { 0, 2 };
            MyPolynomial p3_mult = new MyPolynomial(coeffs3_p3);
            double[] coeffs4_p4 = { 3, 0, 1 };
            MyPolynomial p4_mult = new MyPolynomial(coeffs4_p4);
            MyPolynomial product2 = p3_mult.Multiply(p4_mult);
            string expectedProduct2 = "2x^3 + 6x";
            Console.WriteLine($"({new MyPolynomial(coeffs3_p3)}) * ({new MyPolynomial(coeffs4_p4)}) = {product2} (Expected: {expectedProduct2})");
            System.Diagnostics.Debug.Assert(product2.ToString() == expectedProduct2, $"Failed: Multiply Test 2. Got '{product2}', Expected '{expectedProduct2}'");

            // Test Case 3: Zero polynomial * (3x^2 + 2x + 1) = 0
            double[] coeffs5_p5 = { 0 };
            MyPolynomial p5_mult = new MyPolynomial(coeffs5_p5);
            double[] coeffs6_p6 = { 1, 2, 3 };
            MyPolynomial p6_mult = new MyPolynomial(coeffs6_p6);
            MyPolynomial product3 = p5_mult.Multiply(p6_mult);
            string expectedProduct3 = "0";
            Console.WriteLine($"({new MyPolynomial(coeffs5_p5)}) * ({new MyPolynomial(coeffs6_p6)}) = {product3} (Expected: {expectedProduct3})");
            System.Diagnostics.Debug.Assert(product3.ToString() == expectedProduct3, $"Failed: Multiply Test 3. Got '{product3}', Expected '{expectedProduct3}'");
        }

        // --- New Edge Case Tests ---

        private static void TestZeroPolynomialEdgeCases()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("--- Test: Zero Polynomial Edge Cases ---");
            // Test Case 1: Creation of a zero polynomial
            double[] zeroCoeffs = { 0 };
            MyPolynomial zeroP = new MyPolynomial(zeroCoeffs);
            System.Diagnostics.Debug.Assert(zeroP.GetDegree() == 0, "Failed: Zero polynomial degree should be 0.");
            System.Diagnostics.Debug.Assert(zeroP.ToString() == "0", "Failed: Zero polynomial ToString should be '0'.");
            Console.WriteLine($"Zero Polynomial: {zeroP} (Degree: {zeroP.GetDegree()}) - Expected: 0 (Degree: 0)");

            // Test Case 2: Adding two zero polynomials
            double[] zeroCoeffsA = { 0 };
            MyPolynomial zeroPA = new MyPolynomial(zeroCoeffsA);
            double[] zeroCoeffsB = { 0 };
            MyPolynomial zeroPB = new MyPolynomial(zeroCoeffsB);
            MyPolynomial sum = zeroPA.Add(zeroPB);
            System.Diagnostics.Debug.Assert(sum.ToString() == "0", "Failed: Sum of two zero polynomials should be 0.");
            Console.WriteLine($"({new MyPolynomial(zeroCoeffsA)}) + ({new MyPolynomial(zeroCoeffsB)}) = {sum} - Expected: 0");

            // Test Case 3: Multiplying two zero polynomials
            double[] zeroCoeffsC = { 0 };
            MyPolynomial zeroPC = new MyPolynomial(zeroCoeffsC);
            double[] zeroCoeffsD = { 0 };
            MyPolynomial zeroPD = new MyPolynomial(zeroCoeffsD);
            MyPolynomial product = zeroPC.Multiply(zeroPD);
            System.Diagnostics.Debug.Assert(product.ToString() == "0", "Failed: Product of two zero polynomials should be 0.");
            Console.WriteLine($"({new MyPolynomial(zeroCoeffsC)}) * ({new MyPolynomial(zeroCoeffsD)}) = {product} - Expected: 0");

            // Test Case 4: Evaluate zero polynomial at any x
            System.Diagnostics.Debug.Assert(zeroP.Evaluate(10) == 0, "Failed: Evaluate zero polynomial at x=10 should be 0.");
            Console.WriteLine($"Evaluate zero polynomial at x=10: {zeroP.Evaluate(10)} - Expected: 0");
        }

        private static void TestConstantPolynomialEdgeCases()
        {
            Console.WriteLine();
            Console.WriteLine("--- Test: Constant Polynomial Edge Cases ---");
            // Test Case 1: Creation of a constant polynomial (e.g., 5)
            double[] constCoeffs = { 5 };
            MyPolynomial constP = new MyPolynomial(constCoeffs);
            System.Diagnostics.Debug.Assert(constP.GetDegree() == 0, "Failed: Constant polynomial degree should be 0.");
            System.Diagnostics.Debug.Assert(constP.ToString() == "5", "Failed: Constant polynomial ToString should be '5'.");
            Console.WriteLine($"Constant Polynomial: {constP} (Degree: {constP.GetDegree()}) - Expected: 5 (Degree: 0)");

            // Test Case 2: Adding a constant polynomial to another (5 + 3 = 8)
            double[] constCoeffsA = { 5 };
            MyPolynomial constPA = new MyPolynomial(constCoeffsA);
            double[] constCoeffsB = { 3 };
            MyPolynomial constPB = new MyPolynomial(constCoeffsB);
            MyPolynomial sum = constPA.Add(constPB);
            System.Diagnostics.Debug.Assert(sum.ToString() == "8", "Failed: Sum of two constant polynomials should be 8.");
            Console.WriteLine($"({new MyPolynomial(constCoeffsA)}) + ({new MyPolynomial(constCoeffsB)}) = {sum} - Expected: 8");

            // Test Case 3: Multiplying a constant polynomial by another (5 * 3 = 15)
            double[] constCoeffsC = { 5 };
            MyPolynomial constPC = new MyPolynomial(constCoeffsC);
            double[] constCoeffsD = { 3 };
            MyPolynomial constPD = new MyPolynomial(constCoeffsD);
            MyPolynomial product = constPC.Multiply(constPD);
            System.Diagnostics.Debug.Assert(product.ToString() == "15", "Failed: Product of two constant polynomials should be 15.");
            Console.WriteLine($"({new MyPolynomial(constCoeffsC)}) * ({new MyPolynomial(constCoeffsD)}) = {product} - Expected: 15");

            // Test Case 4: Evaluate constant polynomial at any x
            System.Diagnostics.Debug.Assert(constP.Evaluate(100) == 5, "Failed: Evaluate constant polynomial at x=100 should be 5.");
            Console.WriteLine($"Evaluate constant polynomial at x=100: {constP.Evaluate(100)} - Expected: 5");
        }

        private static void TestMixedDegreeOperations()
        {
            Console.WriteLine();
            Console.WriteLine("--- Test: Mixed Degree Operations ---");
            // Test Case 1: Add (2x + 1) + (x^2) = x^2 + 2x + 1
            double[] coeffsP1 = { 1, 2 }; // 2x + 1
            MyPolynomial p1 = new MyPolynomial(coeffsP1);
            double[] coeffsP2 = { 0, 0, 1 }; // x^2
            MyPolynomial p2 = new MyPolynomial(coeffsP2);
            MyPolynomial sum = p1.Add(p2);
            string expectedSum = "x^2 + 2x + 1";
            System.Diagnostics.Debug.Assert(sum.ToString() == expectedSum, $"Failed: Mixed Degree Add 1. Got '{sum}', Expected '{expectedSum}'");
            Console.WriteLine($"({new MyPolynomial(coeffsP1)}) + ({new MyPolynomial(coeffsP2)}) = {sum} - Expected: {expectedSum}");

            // Test Case 2: Multiply (2x + 1) * (x^2) = 2x^3 + x^2
            double[] coeffsP3 = { 1, 2 }; // 2x + 1
            MyPolynomial p3 = new MyPolynomial(coeffsP3);
            double[] coeffsP4 = { 0, 0, 1 }; // x^2
            MyPolynomial p4 = new MyPolynomial(coeffsP4);
            MyPolynomial product = p3.Multiply(p4);
            string expectedProduct = "2x^3 + x^2";
            System.Diagnostics.Debug.Assert(product.ToString() == expectedProduct, $"Failed: Mixed Degree Multiply 1. Got '{product}', Expected '{expectedProduct}'");
            Console.WriteLine($"({new MyPolynomial(coeffsP3)}) * ({new MyPolynomial(coeffsP4)}) = {product} - Expected: {expectedProduct}");
        }

        private static void TestOperationsResultingInZero()
        {
            Console.WriteLine();
            Console.WriteLine("--- Test: Operations Resulting in Zero ---");
            // Test Case 1: Add (x - 1) + (-x + 1) = 0
            double[] coeffsP1 = { -1, 1 }; // x - 1
            MyPolynomial p1 = new MyPolynomial(coeffsP1);
            double[] coeffsP2 = { 1, -1 }; // -x + 1
            MyPolynomial p2 = new MyPolynomial(coeffsP2);
            MyPolynomial sum = p1.Add(p2);
            System.Diagnostics.Debug.Assert(sum.ToString() == "0", "Failed: Add resulting in zero polynomial should be '0'.");
            Console.WriteLine($"({new MyPolynomial(coeffsP1)}) + ({new MyPolynomial(coeffsP2)}) = {sum} - Expected: 0");

            // Test Case 2: Multiply (x + 1) * (0) = 0
            double[] coeffsP3 = { 1, 1 }; // x + 1
            MyPolynomial p3 = new MyPolynomial(coeffsP3);
            double[] coeffsP4 = { 0 }; // 0
            MyPolynomial p4 = new MyPolynomial(coeffsP4);
            MyPolynomial product = p3.Multiply(p4);
            System.Diagnostics.Debug.Assert(product.ToString() == "0", "Failed: Multiply by zero polynomial should be '0'.");
            Console.WriteLine($"({new MyPolynomial(coeffsP3)}) * ({new MyPolynomial(coeffsP4)}) = {product} - Expected: 0");
        }

        private static void TestEvaluateSpecialValues()
        {
            Console.WriteLine();
            Console.WriteLine("--- Test: Evaluate Special Values ---");
            // Test Case 1: Evaluate 3x^2 - 4x + 11 at x=0 (should be a0)
            double[] coeffs1 = { 11, -4, 3 };
            MyPolynomial p1 = new MyPolynomial(coeffs1);
            double x1 = 0;
            double expected1 = 11;
            double result1 = p1.Evaluate(x1);
            System.Diagnostics.Debug.Assert(result1 == expected1, $"Failed: Evaluate at x=0. Got {result1}, Expected {expected1}");
            Console.WriteLine($"Evaluate {p1} at x={x1}: {result1} - Expected: {expected1}");

            // Test Case 2: Evaluate 3x^2 - 4x + 11 at x=1 (sum of coefficients)
            double[] coeffs2 = { 11, -4, 3 };
            MyPolynomial p2 = new MyPolynomial(coeffs2);
            double x2 = 1;
            double expected2 = 11 - 4 + 3; // 10
            double result2 = p2.Evaluate(x2);
            System.Diagnostics.Debug.Assert(result2 == expected2, $"Failed: Evaluate at x=1. Got {result2}, Expected {expected2}");
            Console.WriteLine($"Evaluate {p2} at x={x2}: {result2} - Expected: {expected2}");
        }

        private static void TestConstructorTrimming()
        {
            Console.WriteLine("\n--- Test: Constructor Trimming of Trailing Zeros ---");
            // Test Case 1: Polynomial with actual trailing zeros (3x^2 + 0x + 0)
            double[] coeffs1 = { 0, 0, 3, 0, 0 }; // Should become 3x^2
            MyPolynomial p1 = new MyPolynomial(coeffs1);
            System.Diagnostics.Debug.Assert(p1.ToString() == "3x^2", "Failed: Trimming leading zeros failed for '3x^2 + 0x + 0'.");
            System.Diagnostics.Debug.Assert(p1.GetDegree() == 2, "Failed: Degree after trimming failed for '3x^2 + 0x + 0'.");
            Console.WriteLine($"Input: [0, 0, 3, 0, 0] -> Output: {p1} (Degree: {p1.GetDegree()}) - Expected: 3x^2 (Degree: 2)");

            // Test Case 2: Polynomial that is effectively zero [0, 0, 0]
            double[] coeffs2 = { 0, 0, 0 }; // Should become 0
            MyPolynomial p2 = new MyPolynomial(coeffs2);
            System.Diagnostics.Debug.Assert(p2.ToString() == "0", "Failed: Trimming leading zeros failed for '[0, 0, 0]'.");
            System.Diagnostics.Debug.Assert(p2.GetDegree() == 0, "Failed: Degree after trimming failed for '[0, 0, 0]'.");
            Console.WriteLine($"Input: [0, 0, 0] -> Output: {p2} (Degree: {p2.GetDegree()}) - Expected: 0 (Degree: 0)");

            // Test Case 3: Polynomial with no trailing zeros (x^2 + x + 1)
            double[] coeffs3 = { 1, 1, 1 };
            MyPolynomial p3 = new MyPolynomial(coeffs3);
            System.Diagnostics.Debug.Assert(p3.ToString() == "x^2 + x + 1", "Failed: Trimming altered valid polynomial.");
            System.Diagnostics.Debug.Assert(p3.GetDegree() == 2, "Failed: Degree altered for valid polynomial.");
            Console.WriteLine($"Input: [1, 1, 1] -> Output: {p3} (Degree: {p3.GetDegree()}) - Expected: x^2 + x + 1 (Degree: 2)");

            // Test Case 4: Single non-zero coefficient (constant) [5]
            double[] coeffs4 = { 5 };
            MyPolynomial p4 = new MyPolynomial(coeffs4);
            System.Diagnostics.Debug.Assert(p4.ToString() == "5", "Failed: Trimming altered constant polynomial.");
            System.Diagnostics.Debug.Assert(p4.GetDegree() == 0, "Failed: Degree altered for constant polynomial.");
            Console.WriteLine($"Input: [5] -> Output: {p4} (Degree: {p4.GetDegree()}) - Expected: 5 (Degree: 0)");
        }
    }
}