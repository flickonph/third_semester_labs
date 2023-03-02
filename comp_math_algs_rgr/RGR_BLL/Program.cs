/* 48 вар. | Qрасч = a0 + a1xБ + a2xУ + a3xБxЖ + a4xЖxУ | МНК | V выборки = 6 */

namespace RGR_BLL;
    
public static class Calc
{
    private static readonly int ASize = 5;
    public static double Function(double[] a, double x1, double x2, double x3)
    {
        double q = a[0] + a[1]*x1 + a[2]*x3 + a[3]*x1*x2 + a[4]*x2*x3;
        return q;
    }

    public static Product ResProduct(List<Product> products, Product todo)
    {
        var a = VectorA(products, ASize);
        
        todo.Q = Function(a, todo.X1, todo.X2, todo.X3);

        return todo;
    }

    public static void Test()
    {
        double[][] a = { new[] { 3.0, 4.0 }, new[] { 7.0, 2.0 } };

        var t = Transpose(a);

        a[0] = new[] { 3.0, 4.0 }; 
        a[1] = new[] { 7.0, 2.0 };
        var i = Inverse(a);
        
        a[0] = new[] { 3.0, 4.0 }; 
        a[1] = new[] { 7.0, 2.0 };
        var m = Multiply(a, i);
    }

    public static double[] VectorA(List<Product> products, int size)
    {
        var matrixA = MatrixA(products, size);
        var vectorQ = VectorQ(products, size);
        
        var a = MultiplyToVector(Multiply(Inverse(Multiply(Transpose(matrixA), matrixA)), Transpose(matrixA)), vectorQ);

        return a;
    }

    public static double[][] MatrixA(List<Product> products, int size)
    {
        double[][] result = new double[size][];
        for (int i = 0; i < size; i++)
        {
            result[i] = new[] {1, products[i].X1, products[i].X3, products[i].X1 * products[i].X2, products[i].X2 * products[i].X3};
        }
        
        return result;
    }
    
    public static double[] VectorQ(List<Product> products, int size)
    {
        double[] result = new double[size];
        for (int i = 0; i < size; i++)
        {
            result[i] = products[i].Q;
        }
        
        return result;
    }
    public static double[][] Transpose(double[][] matrix)
    {
        double[][] result = new double[matrix[0].Length][];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = new double[matrix.Length];
            for (int j = 0; j < result[i].Length; j++)
            {
                result[i][j] = matrix[j][i];
            }
        }
        return result;
    }

    public static double[][] Multiply(double[][] a, double[][] b)
    {
        double[][] result = new double[a.Length][];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = new double[b[0].Length];
            for (int j = 0; j < b[0].Length; j++)
            {
                result[i][j] = 0;
                for (int k = 0; k < a[0].Length; k++)
                {
                    result[i][j] += a[i][k] * b[k][j];
                }
            }
        }
        return result;
    }

    public static double[] MultiplyToVector(double[][] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = 0;
            for (int j = 0; j < a[0].Length; j++)
            {
                result[i] += a[i][j] * b[j];
            }
        }
        return result;
    }

    public static double[][] Inverse(double[][] matrix)
    {
        double[][] result = new double[matrix.Length][];
        for (int i = 0; i < matrix.Length; i++)
        {
            result[i] = new double[matrix[0].Length];
            for (int j = 0; j < matrix[0].Length; j++)
            {
                result[i][j] = 0;
            }
            result[i][i] = 1;
        }
        for (int i = 0; i < matrix.Length; i++)
        {
            double main = matrix[i][i];
            for (int j = 0; j < matrix.Length; j++)
            {
                matrix[i][j] /= main;
                result[i][j] /= main;
            }
            for (int j = 0; j < matrix.Length; j++)
            {
                if (i != j)
                {
                    double coef = matrix[j][i];
                    for (int k = 0; k < matrix.Length; k++)
                    {
                        matrix[j][k] -= matrix[i][k] * coef;
                        result[j][k] -= result[i][k] * coef;
                    }
                }
            }
        }
        return result;
    }
}

public class Product
{
    public Product(double x1, double x2, double x3, double q)
    {
        X1 = x1;
        X2 = x2;
        X3 = x3;
        Q = q;
    }

    public double X1 { get; }
    public double X2 { get; }
    public double X3 { get; }
    public double Q { get; set; }

    public override string ToString()
    {
        string result = $"Белки: {X1} г., Жиры: {X2} г., Углеводы: {X3} г. | Калорийность: {Q} <ед. изм.>.";
        return result;
    }
}