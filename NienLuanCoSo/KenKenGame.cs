using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NienLuanCoSo
{
    public class KenKenGame
    {
        private bool isfounded;
        int size;
        private int[,] map;
        private int[,] mapBlock;
        private ArrayList blocksList;
        private char[] operators;
        private int[] results;
       
        #region property
        public int[,] Map { get => map; set => map = value; }
        public int Size { get => size; set => size = value; }
        public int[,] MapBlock { get => mapBlock; set => mapBlock = value; }
        public ArrayList BlocksList { get => blocksList; set => blocksList = value; }
        public int[] Results { get => results; set => results = value; }
        public char[] Operators { get => operators; set => operators = value; }
        
        #endregion
        public KenKenGame(int size)
        {
            this.Size = size;
            Map = new int[size, size];
            MapBlock = new int[size, size];
            this.BlocksList = new ArrayList();
            this.CreateMapBlock();
            this.CreateMap();
            this.Operators = new char[this.BlocksList.Count];
            this.Results = new int[this.BlocksList.Count];
            this.CreateOperators();
         
        }
        #region ArrayList Block and ArrayList AdjacentBlock

        public void SetListPoint(int blockIndex)
        {
            for (int i = 0; i < blockIndex; i++)
            {
                List<Point> list = new List<Point>();
                this.blocksList.Add(list);
            }
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    Point point = new Point(j, i);
                    List<Point> list = blocksList[this.MapBlock[i, j] - 1] as List<Point>;
                    list.Add(point);
                }
            }
        }
        public bool IsNotRepeat(int k, int blockIndex)
        {
            List<int> ints = this.BlocksList[blockIndex] as List <int>;
            if (ints is null)
                return true;
            foreach(int i in ints)
            {
                if (i == k)
                    return false;
            }
            return true;
        }
       
       

        #endregion
        #region Map

        #region Check value
        public bool trueCol(int value, int r, int c)
        {
            for (int i = 0; i < c; i++)
                if (this.Map[r, i] == value) return false;
            return true;
        }
        public bool trueRow(int value, int r, int c)
        {
            for (int i = 0; i < r; i++)
                if (this.Map[i, c] == value) return false;
            return true;
        }
        public int ConvertRow(int k)
        {
            return k / this.Size;
        }
        public int ConvertCol(int k)
        {
            return k % this.Size == 0 ? 0 : k % this.Size;
        }
        public bool TrueBlockValue(int row, int col, int value)
        {
            int blockIndex = this.MapBlock[row, col] - 1;
            List<Point> points = this.BlocksList[blockIndex] as List<Point>;
            foreach (Point p in points)
            {
                if (value == this.Map[p.Y, p.X] && p.X != col && p.Y != row) return false;
            }
            return true;
        }
        #endregion
        public void CreateBackTracking(ArrayList arrayList, int k)
        {
            if (k == this.Size * this.Size)
            {
                isfounded = true;
                return;
            }
            int row = this.ConvertRow(k);
            int col = this.ConvertCol(k);

            List<int> list = arrayList[row] as List<int>;
            for (int i = 0; i < list.Count; i++)
            {
                this.Map[row, col] = list[i];
                if (this.trueRow(list[i], row, col) && this.trueCol(list[i], row, col) && this.TrueBlockValue(row, col, list[i]))
                {
                    CreateBackTracking(arrayList, k + 1);
                    if (isfounded)
                        return;
                }
                this.Map[row, col] = 0;
            }

        }
        public void CreateMap()
        {
            ArrayList list = new ArrayList();

            Random rand = new Random();

            for (int i = 0; i < this.Size; i++)
            {
                List<int> randList = new List<int>();
                List<int> temp = new List<int>();
                for (int j = 1; j <= Size; j++)
                    temp.Add(j);
                for (int j = 0; j < Size; j++)
                {
                    int k = rand.Next(0, temp.Count);
                    randList.Add(temp[k]);
                    temp.RemoveAt(k);
                }
                list.Add(randList);
            }
            CreateBackTracking(list, 0);
        }
        #endregion
        #region MapBlock
        public void CreateMapBlock()
        {
            Random rand = new Random();
            int blockIndex = 1;
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    if (MapBlock[i, j] != 0) continue;
                    int numbersBlock = SetNumbersBlock(rand.Next() % 101);
                    SetMapBlockValue(i, j, 0, numbersBlock, blockIndex, rand);
                    blockIndex++;
                }
            }

            SetListPoint(blockIndex - 1);
        }
        int SetNumbersBlock(int n)
        {
            return n <= 10 ? 1 : (n <= 40 ? 2 : (n <= 90 ? 3 : 4));
        }
        public void SetMapBlockValue(int r, int c, int numbersBlockCount, int numbersBlock, int blockIndex, Random rand)
        {
            if (numbersBlockCount == numbersBlock || r == Size || c == Size || MapBlock[r, c] != 0)
            {
                return;
            }
            this.MapBlock[r, c] = blockIndex;
            numbersBlockCount++;
            int[] deltaX = { 0, 1 }, deltaY = { 1, 0 };
            int randNumber = rand.Next() % 2;
            SetMapBlockValue(r + deltaY[randNumber], c + deltaX[randNumber], numbersBlockCount, numbersBlock, blockIndex, rand);
        }
        #endregion
        #region Operator and Result
        public void CreateOperators()
        {
            for (int i = 0; i < this.BlocksList.Count; i++)
            {
                List<Point> list = this.BlocksList[i] as List<Point>;
                this.Results[i] = list.Count == 2 ? this.SetResult1(list, i) : this.SetResult2(list, i);
            }
        }
        /// <summary>
        /// Inluce 4 calculations
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int SetResult1(List<Point> list, int blockIndex)
        {
            int result = 0;
            Random rand = new Random();
            int randOperator = rand.Next() % 4;
            switch (randOperator)
            {
                case 0:
                    result = SetAddValue(list, blockIndex);
                    break;
                case 1:
                    result = SetSubValue(list, blockIndex);
                    break;
                case 2:
                    result = SetMulValue(list, blockIndex);
                    break;
                case 3:
                    result = SetDivValue(list, blockIndex);
                    break;
            }
            return result;
        }
        /// <summary>
        /// Calculations only include addition, multiplication and NonCalculations
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int SetResult2(List<Point> list, int blockIndex)
        {
            if (list.Count == 1)
            {
                this.Operators[blockIndex] = '!';
                return this.Map[list[0].Y, list[0].X];
            }
            Random rand = new Random();
            return rand.Next() % 2 == 0 ? SetAddValue(list, blockIndex) : SetMulValue(list, blockIndex);
        }
        public int SetAddValue(List<Point> list, int blockIndex)
        {
            this.Operators[blockIndex] = '+';
            int sum = 0;
            foreach (Point p in list)
            {
                sum += this.Map[p.Y, p.X];
            }
            return sum;
        }
        public int SetMulValue(List<Point> list, int blockIndex)
        {
            this.Operators[blockIndex] = '*';
            int mul = 1;
            foreach (Point p in list)
            {
                mul *= this.Map[p.Y, p.X];
            }
            return mul;
        }
        public int SetSubValue(List<Point> list, int blockIndex)
        {
            int max = this.max(this.Map[list[0].Y, list[0].X], this.Map[list[1].Y, list[1].X]);
            int min = this.min(this.Map[list[0].Y, list[0].X], this.Map[list[1].Y, list[1].X]);
            this.Operators[blockIndex] = '-';
            return max - min;
        }
        public int SetDivValue(List<Point> list, int blockIndex)
        {
            int max = this.max(this.Map[list[0].Y, list[0].X], this.Map[list[1].Y, list[1].X]);
            int min = this.min(this.Map[list[0].Y, list[0].X], this.Map[list[1].Y, list[1].X]);
            if (max % min == 0)
            {
                this.Operators[blockIndex] = '/';
                return max / min;
            }
            return SetSubValue(list, blockIndex);
        }
        public int max(int a, int b)
        {
            return a > b ? a : b;
        }
        public int min(int a, int b)
        {
            return a > b ? b : a;
        }

        #endregion
    }
}
