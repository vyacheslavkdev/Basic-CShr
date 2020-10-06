using System;
using System.IO;
using System.Linq;

namespace MyMatrixNamespace
{
    public class MyMatrix
    {
        private int[][] _matrix = null;

        public MyMatrix(int rows, int cols, int initValue, int valueStep, bool random = true)
        {
            if (random)
            {
                InitRandomMatrix(rows, cols, initValue, valueStep);
            }
            else
            {
                InitMatrix(rows, cols, initValue, valueStep);
            }
        }

        public MyMatrix(string fileName)
        {
            InitFromFile(fileName);
        }

        private void InitRandomMatrix(int rows, int cols, int initValue, int valueStep)
        {
            _matrix = new int[rows][];
            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                int[] elements = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    elements[j] = initValue + rnd.Next(-valueStep, valueStep + 1);
                }

                _matrix[i] = elements;
            }
        }

        private void InitMatrix(int rows, int cols, int initValue, int valueStep)
        {
            _matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] elements = new int[cols];
                for (int j = 0; j < cols; i++)
                {
                    elements[j] = initValue + valueStep * valueStep;
                }

                _matrix[i] = elements;
            }
        }

        private void InitFromFile(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string[] lines = ReadLinesFromFile(reader);
                    _matrix = new int[lines.Length][];
                    
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] lineSplit = SplitLine(lines[i]);
                        int[] elements = new int[lineSplit.Length];
                        
                        for (int j = 0; j < lineSplit.Length; j++)
                        {
                            if (int.TryParse(lineSplit[j], out var parseInt))
                            {
                                elements[j] = parseInt;
                            }
                        }

                        _matrix[i] = elements;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new FileNotFoundException("Чтение из файла не возможно!");
            }
        }

        public int ElementSum()
        {
            int sum = 0;

            for (int i = 0; i < _matrix.Length; i++)
            {
                for (int j = 0; j < _matrix[i].Length; j++)
                {
                    sum += _matrix[i][j];
                }
            }

            return sum;
        }

        public int ElementSum(int threshold)
        {
            int sum = 0;

            for (int i = 0; i < _matrix.Length; i++)
            {
                for (int j = 0; j < _matrix[i].Length; j++)
                {
                    if (threshold < _matrix[i][j])
                    {
                        sum += _matrix[i][j];
                    }
                }
            }

            return sum;
        }

        public void SetMaxElementId(ref int rowId, ref int colId)
        {
            int maxElement = 0;
            for (int i = 0; i < _matrix.Length; i++)
            {
                for (int j = 0; j < _matrix[i].Length; j++)
                {
                    if (maxElement < _matrix[i][j])
                    {
                        maxElement = _matrix[i][j];
                        rowId = i;
                        colId = j;
                    }
                }
            }
        }

        public int MaxElement
        {
            get
            {
                int max = _matrix[0][0];
                for (int i = 0; i < _matrix.Length; i++)
                {
                    int maxInRow = _matrix[i].Max();
                    max = max < maxInRow ? maxInRow : max;
                }

                return max;
            }
        }

        public int MinElement
        {
            get
            {
                int min = _matrix[0][0];
                for (int i = 0; i < _matrix.Length; i++)
                {
                    int minInRow = _matrix[i].Min();
                    min = min > minInRow ? minInRow : min;
                }

                return min;
            }
        }

        public void Show()
        {
            for (int i = 0; i < _matrix.Length; i++)
            {
                for (int j = 0; j < _matrix[i].Length; j++)
                {
                    Console.Write($"{_matrix[i][j],4}");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private string[] ReadLinesFromFile(StreamReader reader)
        {
            string fileText = "";
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line != null)
                {
                    line = line.Trim();
                            
                    if (line.Equals(""))
                    {
                        continue;
                    }

                    if (!fileText.Equals(""))
                    {
                        fileText += ";";
                    }
                }
                        
                fileText += $"{line}";
            }

            return fileText.Split(";");
        }
        
        private string[] SplitLine(string text)
        {
            string lineForSplit = "";
            bool hasWhiteSpace = false;
            foreach (char c in text)
            {
                if (Char.IsWhiteSpace(c) && hasWhiteSpace)
                {
                    continue;
                }

                lineForSplit += c;
                hasWhiteSpace = Char.IsWhiteSpace(c);
            }

            return lineForSplit.Split(" ");
        }

        static void Main(string[] args)
        {
        }
    }
}