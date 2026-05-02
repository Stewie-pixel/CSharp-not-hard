using System;
using System.Linq;
using System.Text;

public class MyPolynomial
{
    private double[] _coeffs;

    // Constructor
    public MyPolynomial(double[] coeffs)
    {
        // Remove trailing zeros to get the actual degree
        int actualLength = coeffs.Length;
        while (actualLength > 1 && coeffs[actualLength - 1] == 0)
        {
            actualLength--;
        }
        _coeffs = new double[actualLength];
        Array.Copy(coeffs, _coeffs, actualLength);
    }

    // Returns the degree of the polynomial.
    public int GetDegree()
    {
        return _coeffs.Length - 1;
    }

    // Evaluates the polynomial for the given x.
    public double Evaluate(double x)
    {
        double result = 0;
        for (int i = 0; i < _coeffs.Length; i++)
        {
            result += _coeffs[i] * Math.Pow(x, i);
        }
        return result;
    }

    // Adds the other polynomial to this polynomial.
    public MyPolynomial Add(MyPolynomial another)
    {
        int maxDegree = Math.Max(this.GetDegree(), another.GetDegree());
        double[] newCoeffs = new double[maxDegree + 1];

        for (int i = 0; i <= maxDegree; i++)
        {
            double coeff1 = (i <= this.GetDegree()) ? this._coeffs[i] : 0;
            double coeff2 = (i <= another.GetDegree()) ? another._coeffs[i] : 0;
            newCoeffs[i] = coeff1 + coeff2;
        }
        this._coeffs = new MyPolynomial(newCoeffs)._coeffs; // Use constructor to trim leading zeros
        return this;
    }

    // Multiplies the another polynomial by this polynomial.
    public MyPolynomial Multiply(MyPolynomial another)
    {
        int degree1 = this.GetDegree();
        int degree2 = another.GetDegree();
        double[] newCoeffs = new double[degree1 + degree2 + 1];

        for (int i = 0; i <= degree1; i++)
        {
            for (int j = 0; j <= degree2; j++)
            {
                newCoeffs[i + j] += this._coeffs[i] * another._coeffs[j];
            }
        }
        this._coeffs = new MyPolynomial(newCoeffs)._coeffs; // Use constructor to trim leading zeros
        return this;
    }

    // Returns a string representation of the polynomial.
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = GetDegree(); i >= 0; i--)
        {
            double coeff = _coeffs[i];
            if (coeff == 0) continue;

            // Handle the sign and separator
            if (sb.Length > 0)
            {
                if (coeff > 0)
                {
                    sb.Append(" + ");
                }
                else // coeff < 0
                {
                    sb.Append(" - ");
                    coeff = Math.Abs(coeff); // Make coeff positive for printing its value
                }
            }
            else // First term
            {
                if (coeff < 0)
                {
                    sb.Append("-");
                    coeff = Math.Abs(coeff); // Make coeff positive for printing its value
                }
            }

            // Handle the coefficient value
            if (i == 0 || coeff != 1) // If its a constant term, always print the coeff.
                                      // If its not a constant term and coeff is not 1, print the coeff.
            {
                sb.Append(coeff);
            }

            // Handle the x and its power
            if (i > 0) // Not a constant term
            {
                sb.Append("x");
                if (i > 1)
                {
                    sb.Append($"^{i}");
                }
            }
        }

        if (sb.Length == 0)
        {
            return "0";
        }
        return sb.ToString();
    }
}