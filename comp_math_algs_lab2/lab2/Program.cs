namespace lab2;

internal static class Program
{
    public static int Length = 7;
    public static int Main()
    {
        Console.WriteLine("INIT AB");
        LabMatrix.PrintMatrix(LabMatrix.JordanMatrix());
        Console.WriteLine("");
        Console.WriteLine("SEIDEL A");
        LabMatrix.PrintMatrix(LabMatrix.SeidelA());
        Console.WriteLine("");
        Console.WriteLine("SEIDEL B");
        LabMatrix.PrintVector(LabMatrix.SeidelB());
        Console.WriteLine("");
        Console.WriteLine("GUESS");
        LabMatrix.PrintVector(LabMatrix.SeidelGuess());
        Console.WriteLine("");
        Console.WriteLine("CD");
        LabMatrix.PrintMatrix(Calc.SeidelCd());
        Console.WriteLine("");
        Console.WriteLine("LAMBDA");
        LabMatrix.PrintVector(Calc.Lambda());
        Console.WriteLine("");
        Console.WriteLine("EUCLID");
        Console.WriteLine(Calc.EuclidNorm(Calc.SeidelC()));
        Console.WriteLine("");

        var gaussJordan = Calc.GaussJordan(LabMatrix.JordanMatrix());

        for (int i = 0; i < Calc.MaxErrorValueCounter; i++)
        {
            var gaussSeidel = Calc.GaussSeidel(i);
        }
        

        return 0;
    }
}

public static class Calc
{
    private static int _length = Program.Length;
    public static int MaxErrorValueCounter
    {
        get => _maxErrorValueCounter;
        private set => _maxErrorValueCounter = value;
    }

    public static double[] MaxError = { 0.1, 0.02, 0.005, 0.001 };
    private static double _velocity = 1.0;
    private static int _maxErrorValueCounter = MaxError.Length;

    public static double[] GaussJordan(double[][] a) 
    {
        for (int k = 0; k < _length; k++) {
            for (int i = k+1; i < _length+1; i++) {
                a[k][i] = a[k][i] / a[k][k];
            }

            a[k][k] = 1;

            for (int i = 0; i < _length; i++) {
                if (i != k) {
                    for (int j = k+1; j < _length+1; j++) {
                        a[i][j] = a[i][j] - (a[k][j] * a[i][k]);
                    }
                }
            }
        }

        double[] x = new double[_length];
        
        for (int m = 0; m < _length; m++) {
            x[m] = a[m][_length];
        }
        
        Console.WriteLine("Жордана-Гаусса:");
        LabMatrix.PrintVector(x);
        Console.WriteLine();
        return x;
    }
    
    public static double[] GaussSeidel(int errorIndex)
    {
        // Required
        double[][] c = SeidelC();
        double[] d = SeidelD();
        double[] g = LabMatrix.SeidelGuess();
        int iter = 0;
        double error = 1;

        // First init
        double[] tempX = new double[_length];
        double[] newX = new double[_length];
        double[] oldX = new double[_length];
        double[] errorX = new double[_length];
            
        for (int i = 0; i < _length; i++)
        {
            tempX[i] = g[i];
            oldX[i] = g[i];
        }

        while (iter != 1000)
        {
            // Main
            for (int i = 0; i < _length; i++)
            {
                newX[i] = 0;
                for (int j = 0; j < _length; j++)
                {
                    newX[i] += c[i][j] * tempX[j];
                }
                newX[i] += d[i];
                tempX[i] = newX[i];
                errorX[i] = Math.Abs(newX[i] - oldX[i]);
            }

            error = errorX.Max();
            if (error <= MaxError[errorIndex])
            {
                Console.WriteLine($"Гаусса-Зейделя с точностью [Epsilon = {MaxError[errorIndex]} (достигнуто {error})], скоростью [V = {_velocity}] и количеством итераций [Iteration = {iter}]");
                LabMatrix.PrintVector(newX);
                Console.WriteLine();
                return newX;
            }

            for (int i = 0; i < _length; i++)
            {
                oldX[i] = newX[i];
            }
            
            iter++;
        }
        
        Console.WriteLine($"Гаусса-Зейделя с точностью [Epsilon = {MaxError[errorIndex]} (достигнуто {error})], скоростью [V = {_velocity}] и количеством итераций [Iteration = {iter}]");
        LabMatrix.PrintVector(newX);
        return newX;
    }

    public static double[][] SeidelCd()
    {
        double[][] a = LabMatrix.SeidelA();
        double[] b = LabMatrix.SeidelB();

        var lambda = Lambda();

        for (int i = 0; i < _length; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                if (i == j)
                {
                    a[i][j] = EqC(a[i][j], lambda[i]);
                }
                else
                {
                    a[i][j] = NotEqC(a[i][j], lambda[i]);
                }
                
            }

            b[i] = D(b[i], lambda[i]);
        }
        
        double[][] cd = new double[_length][];
        for (int i = 0; i < _length; i++)
        {
            var arr = new List<double>();
            foreach (var element in a[i])
            {
                arr.Add(element);
            }
            arr.Add(b[i]);
            cd[i] = arr.ToArray();
        }
        return cd;
    }

    public static double[][] SeidelC()
    {
        double[][] cd = SeidelCd();
        var c = new double[_length][];
        int counter = 0;

        foreach (var element in cd)
        {
            var temp = new List<double>();
            
            for (int i = 0; i < _length + 1 - 1; i++)
            {
                temp.Add(element[i]);
            }
            c[counter] = temp.ToArray();
            counter++;
        }
        return c;
    }

    private static double[] SeidelD()
    {
        double[][] cd = SeidelCd();
        var temp = new List<double>();
        
        foreach (var element in cd)
        {
            temp.Add(element[_length + 1 -1]);
        }

        var d = temp.ToArray();
        return d;
    }

    public static double[] Lambda()
    {
        double[][] a = LabMatrix.SeidelA();
        double[] lambda = new double[_length];
        for (int i = 0; i < _length; i++)
        {
            lambda[i] = -((Math.Sign(a[i][i]) * _velocity) / (1 + Math.Abs(a[i][i])));
        }
        
        return lambda;
    }

    private static double EqC(double element, double lambda)
    {
        double c = 1 + (lambda * element);
        return c;
    }

    private static double NotEqC(double element, double lambda)
    {
        double c = lambda * element;
        return c;
    }

    private static double D(double element, double lambda)
    {
        double d = -lambda * element;
        return d;
    }
    
    public static double EuclidNorm(double[][] c)
    {
        double ex = 0;

        foreach (var n in c)
        {
            foreach (var m in n)
            {
                ex += Math.Pow(m, 2);
            }
        }

        var res = Math.Sqrt(ex);
        
        return res;
    }
}

public static class LabMatrix
{
    private static int _length = Program.Length;
    private static double[][] InitMatrix()
    {
        var defaultMatrix = new double[_length][];
        defaultMatrix[0] = new[] { -3.6, 9.8, -0.6, 10.0, 3.6, 18.7, 0.3, };
        defaultMatrix[1] = new[] { -17.6, 3.8, 7.6, 12.9, -14.4, 3.7, -10.3, };
        defaultMatrix[2] = new[] { 9.7, 5.6, 6.8, -3.3, -6.8, 4.0, -3.1, };
        defaultMatrix[3] = new[] { 4.8, 10.0, -14.2, -10.9, 5.3, 13.0, 19.7, };
        defaultMatrix[4] = new[] { 6.2, 8.1, 2.3, 6.4, 11.5, -4.8, -6.9, };
        defaultMatrix[5] = new[] { 2.5, 15.7, -3.8, -1.6, -6.1, -8.3, 6.4, };
        defaultMatrix[6] = new[] { -8.6, 1.2, 18.5, -4.0, -10.4, 12.9, -12.3, };
        
        return defaultMatrix;
    }

    private static double[] InitVector()
    {
        var defaultVector = new[]
        {
            -156.74,
            -30.25,
            1.73,
            -19.13,
            -68.39,
            58.07,
            -21.77,
        };

        return defaultVector;
    }

    private static double[] InitGuess()
    {
        var defaultGuess = new[]
        {
            1.1,
            -1.4,
            -1.4,
            -2.5,
            -1.0,
            -0.1,
            0.6,
        };

        return defaultGuess;
    }
    
    public static double[][] JordanMatrix()
    {
        var matrix = InitMatrix();
        var vector = InitVector();
        
        var fullDefaultMatrix = new double[_length][];
        
        for (int i = 0; i < _length; i++)
        {
            var temp = matrix[i].ToList();
            temp.Add(vector[i]);
            fullDefaultMatrix[i] = temp.ToArray();
        }
        
        return fullDefaultMatrix;
    }

    public static double[][] SeidelA()
    {
        var testMatrix = new double[_length][];
        
        testMatrix[0] = InitMatrix()[1];
        
        testMatrix[1] = InitMatrix()[5];
        
        testMatrix[2] = InitMatrix()[6];
        
        var list3 = new List<double>();
        for (int i = 0; i < InitMatrix()[0].Length; i++)
        {
            list3.Add(InitMatrix()[2][i] + InitMatrix()[3][i] - InitMatrix()[0][i]);
        }
        testMatrix[3] = list3.ToArray();
        
        testMatrix[4] = InitMatrix()[4];
        
        testMatrix[5] = InitMatrix()[0];
        
        testMatrix[6] = InitMatrix()[3];
        
        return testMatrix;
    }

    public static double[] SeidelB()
    {
        var testVector = new double[_length];
        testVector[0] = InitVector()[1];
        testVector[1] = InitVector()[5];
        testVector[2] = InitVector()[6];
        testVector[3] = InitVector()[2] + InitVector()[3] - InitVector()[0];
        testVector[4] = InitVector()[4];
        testVector[5] = InitVector()[0];
        testVector[6] = InitVector()[3];
        return testVector;
    }
    
    public static double[] SeidelGuess()
    {
        var testGuess = new double[_length];
        testGuess[0] = InitGuess()[1];
        testGuess[1] = InitGuess()[5];
        testGuess[2] = InitGuess()[6];
        testGuess[3] = InitGuess()[2] + InitGuess()[3] - InitGuess()[0];
        testGuess[4] = InitGuess()[4];
        testGuess[5] = InitGuess()[0];
        testGuess[6] = InitGuess()[3];
        return testGuess;
    }

    public static void PrintMatrix(double[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                Console.Write(String.Format("{0:0.00}", matrix[i][j]) + "\t");
            }
            Console.WriteLine();
        }
    }

    public static void PrintVector(double[] vector)
    {
        for (int i = 0; i < vector.Length; i++)
        {
            Console.Write(String.Format("{0:0.0000}",vector[i]) + "\t");
        }
        Console.WriteLine();
    }
}

