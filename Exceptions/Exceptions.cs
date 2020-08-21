using System;

namespace Exceptions
{
    //TODO: Create custom exception "MatrixException"
    public class MatrixException : Exception
    {
        public MatrixException ()
        {}

        public MatrixException (string message) 
            : base(message)
        {}

        public MatrixException (string message, Exception innerException)
            : base (message, innerException)
        {}    
    }
    public class Matrix
    {
        /// <summary>
        /// Number of rows.
        /// </summary>
        private int rows;
        public int Rows
        {
            get;
            
        }





        /// <summary>
        /// Number of columns.
        /// </summary>
        private int columns;
        public int Columns
        {
            get;
            
        }

        /// <summary>
        /// An array of floating-point values that represents the elements of this Matrix.
        /// </summary>
        private double[,] array;
        public double[,] Array
        {
            get;
            
        } 
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when row or column is zero or negative.</exception>
        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            array = new double[rows,columns];
            this.rows = rows;
            this.columns = columns;
                
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class with the specified elements.
        /// </summary>
        /// <param name="array">An array of floating-point values that represents the elements of this Matrix.</param>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        public Matrix(double[,] array)
        {
            if (array==null)
            {
                throw new ArgumentNullException();
            }
            
            this.array = array;
            
            
        }

        /// <summary>
        /// Allows instances of a <see cref="Matrix"/> to be indexed just like arrays.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <exception cref="ArgumentException">Thrown when index is out of range.</exception>
        public double this[int row, int column]
        {
            get
            {
                if (row > Rows|| column>Columns || row<=0||column<=0) throw new ArgumentException();
                return array[row, column];
            }
            set
            {
                if(row > Rows|| column>Columns || row<=0||column<=0) throw new ArgumentException();
                array[row, column] = value;
            }
        }

        /// <summary>
        /// Adds <see cref="Matrix"/> to the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for adding.</param>
        /// <exception cref="ArgumentNullException">Thrown when parameter is null.</exception>
        /// <exception cref="MatrixException">Thrown when the matrix has the wrong dimensions for the operation.</exception>
        /// <returns><see cref="Matrix"/></returns>
        public Matrix Add(Matrix matrix)
        {
            
            if (matrix == null) throw new ArgumentNullException(); 
            if(matrix.Columns!=columns|| matrix.Rows!=rows)
            {
                throw new MatrixException();
            }
            
            
                var res = new double[Rows,Columns];
                for(int x = 0;x<Rows;x++)
                {
                    for(int y = 0;y<Columns;y++)
                    {
                        res[x,y] = this[x,y]+matrix[x,y];
                    }
                }
            
            return new Matrix(res);
        }

        /// <summary>
        /// Subtracts <see cref="Matrix"/> from the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for subtracting.</param>
        /// <exception cref="ArgumentNullException">Thrown when parameter is null.</exception>
        /// <exception cref="MatrixException">Thrown when the matrix has the wrong dimensions for the operation.</exception>
        /// <returns><see cref="Matrix"/></returns>
        public Matrix Subtract(Matrix matrix)
        {
            double[,] result = new double[Rows,Columns];
            if (matrix == null) throw new ArgumentNullException(); 
            if(matrix.Columns!=Columns|| matrix.Rows!=Rows)
            {
                throw new MatrixException();
            }
            
            
                
                for(int x = 0;x<Rows;x++)
                {
                    for(int y = 0;y<Columns;y++)
                    {
                        result[x,y] = Array[x,y] - matrix.Array[x,y];
                    }
                }
            
            return new Matrix(result);
        }

        /// <summary>
        /// Multiplies <see cref="Matrix"/> on the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for multiplying.</param>
        /// <exception cref="ArgumentNullException">Thrown when parameter is null.</exception>
        /// <exception cref="MatrixException">Thrown when the matrix has the wrong dimensions for the operation.</exception>
        /// <returns><see cref="Matrix"/></returns>
        public Matrix Multiply(Matrix matrix)
        {
            
            if (matrix == null) throw new ArgumentNullException();
            if(Columns!=matrix.Rows)
            {
                throw new MatrixException();
            }
            
            
                double[,] result = new double[Rows, matrix.Rows];
                for (int i=0; i<Rows; i++)
                for (int j=0; j<matrix.Columns; j++)
                for (int k = 0; k < Columns; k++)
                    result[i,j] += Array[i,k] * matrix.Array[k,j];
            
            return new Matrix(result);
        }
    }
}