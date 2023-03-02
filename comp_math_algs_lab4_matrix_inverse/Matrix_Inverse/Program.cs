namespace Matrix_Inverse
{
	public static class Functions
	{
		// Function to print matrix.
		public static void PrintMatrix(double[,] ar, int n, int m)
		{
			for (var i = 0; i < n; i++) 
			{
				for (var j = 0; j < m; j++) 
				{
					Console.Write(ar[i,j] + " ");
				}
				Console.Write("\n");
			}
		}
	
		// Function to inverse matrix
		public static double[,] GaussJordan(double[,] defaultMatrix)
        {
            var n = defaultMatrix.GetLength(0);

            var inversedMatrix = new double[n, n];
            for (var i = 0; i < n; i++)
                inversedMatrix[i, i] = 1;
 
            var unifiedMatrix = new double[n, 2*n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                {
                    unifiedMatrix[i, j] = defaultMatrix[i, j];
                    unifiedMatrix[i, j + n] = inversedMatrix[i, j];
                }
            
            for (var k = 0; k < n; k++)
            {
                for (var i = 0; i < 2*n; i++)
                    unifiedMatrix[k, i] /= defaultMatrix[k, k];
                for (var i = k + 1; i < n; i++)
                {
                    var temp = unifiedMatrix[i, k] / unifiedMatrix[k, k];
                    for (var j = 0; j < 2*n; j++)
                        unifiedMatrix[i, j] -= unifiedMatrix[k, j] * temp;
                }
                for (var i = 0; i < n; i++)
                    for (var j = 0; j < n; j++)
                        defaultMatrix[i, j] = unifiedMatrix[i, j];
            }
            
            for (var k = n - 1; k > -1; k--)
            {
                for (var i = 2*n - 1; i > -1; i--)
                    unifiedMatrix[k, i] /= defaultMatrix[k, k];
                for (var i = k - 1; i > -1; i--)
                {
                    var temp = unifiedMatrix[i, k] / unifiedMatrix[k, k];
                    for (var j = 2*n - 1; j > -1; j--)
                        unifiedMatrix[i, j] -= unifiedMatrix[k, j] * temp;
                }
            }
            
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    inversedMatrix[i, j] = unifiedMatrix[i, j + n];
 
            return inversedMatrix;        
        }
		
		private static void GetCofactor(int[,] mat, int[,] temp, int p, int q, int n)
		{
			int i = 0, j = 0;
 
			// Looping for each element of the matrix
			for (int row = 0; row < n; row++) {
				for (int col = 0; col < n; col++) {
					// Copying into temporary matrix only those element
					// which are not in given row and column
					if (row != p && col != q) {
						temp[i,j++] = mat[row,col];
 
						// Row is filled, so increase row index and
						// reset col index
						if (j == n - 1) {
							j = 0;
							i++;
						}
					}
				}
			}
		}

		private static int DeterminantOfMatrix(int[,] mat, int n)
		{
			int d = 0; // Initialize result
 
			// Base case : if matrix contains single element
			if (n == 1)
				return mat[0,0];
 
			var temp = new int[n,n]; // To store cofactors
 
			int sign = 1; // To store sign multiplier
 
			// Iterate for each element of first row
			for (int f = 0; f < n; f++) {
				// Getting Cofactor of mat[0][f]
				GetCofactor(mat, temp, 0, f, n);
				d += sign * mat[0,f] * DeterminantOfMatrix(temp, n - 1);
 
				// terms are to be added with alternate sign
				sign = -sign;
			}
 
			Console.WriteLine("det = " + d);
			return d;
		}

		public static bool IsInvertible(int[,] mat, int n)
		{
			return DeterminantOfMatrix(mat, n) != 0;
		}
	}

	internal class Program
	{
		public static void Main()
		{
			const int order = 3;
			var matrix = new double[order,order];
			Random random = new Random();
			for (int i = 0; i < order; i++)
			{
				for (int j = 0; j < order; j++)
				{
					matrix[i,j] = random.Next(-50, 50);
				}
			}
			/*matrix[0,0] = 1;
			matrix[0,1] = 2;
			matrix[0,2] = 3;
			matrix[1,0] = 4;
			matrix[1,1] = 5;
			matrix[1,2] = 6;
			matrix[2,0] = 7;
			matrix[2,1] = 8;
			matrix[2,2] = 9;*/
			
			var testMatrix = new int[order,order];

			for (int i = 0; i < order; i++)
			{
				for (int j = 0; j < order; j++)
				{
					testMatrix[i,j] = (int) matrix[i,j];
				}
			}

			bool isInvertible = Functions.IsInvertible(testMatrix, order);
			if (isInvertible)
			{
				Console.WriteLine("Matrix is invertible");
				Functions.PrintMatrix(matrix, order, order);
				Console.WriteLine("---------------------------------------------------------");
				Functions.PrintMatrix(Functions.GaussJordan(matrix), order, order);
			}
			else
			{
				Console.WriteLine("Matrix is not invertible");
			}
		}
	}
}