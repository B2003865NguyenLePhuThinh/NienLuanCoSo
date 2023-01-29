using System;
namespace NienLuanCoSo
{
    public class SovleKenKen
    {
        #region field
        private bool _isfounded = false;
        private int size;
        private int[,] resultMap;
        private int[,] blockMap;
        private int[] results;
        private int[] operators;
        private LastPointBlock lastPointBlock;
        private Block[] pointsBlock;
        #endregion
        #region property
        /// <summary>
        /// Kích thức bài toán
        /// </summary>
        public int Size { get => size; set => size = value; }
        /// <summary>
        /// Mảng lưu kết quả của mỗi block
        /// </summary>
        public int[] Results { get => results; set => results = value; }
        /// <summary>
        /// Mảng lưu toán tử của mỗi block
        /// </summary>
        public int[] Operators { get => operators; set => operators = value; }
        /// <summary>
        /// Mảng lưu kết quả
        /// </summary>
        public int[,] ResultMap { get => resultMap; set => resultMap = value; }
        /// <summary>
        /// Mảng lưu thứ tự block của các ô
        /// </summary>
        public int[,] BlockMap { get => blockMap; set => blockMap = value; }
        /// <summary>
        /// Điểm cuối của mỗi block và số điểm mỗi block
        /// </summary>
        public LastPointBlock LastPointBlock { get => lastPointBlock; set => lastPointBlock = value; }
        /// <summary>
        /// Tọa đổ của tất cả các điểm trong mỗi block
        /// </summary>
        public Block[] PointsBlock { get => pointsBlock; set => pointsBlock = value; }
        #endregion

        public SovleKenKen(int size, int[] results, int[] operators, int[,] blockMap)
        {
            this.Size = size;
            this.Results = results;
            this.Operators = operators;
            this.BlockMap = blockMap;
            this.ResultMap = new int[this.Size, this.Size];
            this.LastPointBlock = new LastPointBlock(this.Operators.Length);
            this.PointsBlock = new Block[this.Operators.Length];
            
            for(int i = 0; i < this.Operators.Length; i ++)
                this.PointsBlock[i] = new Block(this.Size * this.Size);

            int[] cnt   = new int[this.Operators.Length];
            ///find last Point of all Blocks and Point 
            for(int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    int blockIndex = this.BlockMap[i, j];
                    if (blockIndex == this.LastPointBlock.Index[blockIndex])
                    {
                        this.LastPointBlock.Points[blockIndex] = new Point(j, i);
                        this.LastPointBlock.BlockSize[blockIndex]++;
                        this.PointsBlock[blockIndex].Points[cnt[blockIndex] ++]  = new Point(j, i);
                    }
                }
            }




            Sovle(0, size * size);
        }
        public int ConvertRow(int k)
        {
            return k / this.Size;
        }
        public int ConvertCol(int k)
        {
            return k % this.Size == 0 ? 0 : k % this.Size;
        }
        public bool IsTrueRow(int r, int c, int x)
        {
            for (int i = 0; i < c; i++)
                if (this.ResultMap[r, i] == x )
                    return false;
            return true;
        }
        public bool IsTrueCol(int r, int c, int x)
        {
            for (int i = 0; i < r; i++)
                if (this.ResultMap[i, c] == x )
                    return false;
            return true;
        }
        public bool IsTrueAddBlock(Block block, int n, int blockIndex)
        {
            int sum = 0;
            for(int i = 0; i < n; i++)
            {
                Point p = block.Points[i];
                sum += this.ResultMap[p.Y, p.X];
            }
            return sum == this.Results[blockIndex];
        }
        public bool IsTrueSubBlock(Block block, int n, int blockIndex)
        {
            Point p1 = block.Points[0];
            Point p2 = block.Points[1];
            int results = Math.Abs(this.ResultMap[p1.Y, p1.X] - this.ResultMap[p2.Y, p2.X]);
            return results == this.Results[blockIndex];
        }
        public bool IsTrueMulBlock(Block block, int n, int blockIndex)
        {
            int mul = 1;
            for (int i = 0; i < n; i++)
            {
                Point p = block.Points[i];
                mul *= this.ResultMap[p.Y, p.X];
            }
            return mul == this.Results[blockIndex];
        }
        public bool IsTrueDivBlock(Block block, int n, int blockIndex)
        {
            Point p1 = block.Points[0];
            Point p2 = block.Points[1];
            float result1 = this.ResultMap[p1.Y, p1.X] / this.ResultMap[p2.Y,p2.X];
            float result2 = this.ResultMap[p2.Y, p2.X] / this.ResultMap[p1.Y, p1.X];
            return (this.Results[blockIndex] == (int)result1 || this.Results[blockIndex] == (int)result2);
        }
        public bool IsTrueNoneBlock(Block block, int n, int blockIndex)
        {
            Point p = block.Points[0];
            return this.Results[blockIndex] == this.ResultMap[p.Y, p.X];
        }
        public bool IsTrueBlock(int r, int c)
        {
            int index = this.LastPointBlock.Index[this.BlockMap[r, c]];
            Point p = this.LastPointBlock.Points[index];
            if (this.ResultMap[p.Y, p.X] == 0)
                return true;
            switch (this.Operators[index])
            {
                case 0: //Cộng
                    return IsTrueAddBlock(this.PointsBlock[index], this.LastPointBlock.BlockSize[index], index);
                    break;
                case 1://Trừ
                    return IsTrueSubBlock(this.PointsBlock[index], this.LastPointBlock.BlockSize[index], index);
                    break;
                case 2://Nhân 
                    return IsTrueMulBlock(this.PointsBlock[index], this.LastPointBlock.BlockSize[index], index);
                    break;
                case 3: //Chia
                    return IsTrueDivBlock(this.PointsBlock[index], this.LastPointBlock.BlockSize[index], index);
                    break;
                case 4: //Không
                    return IsTrueNoneBlock(this.PointsBlock[index], this.LastPointBlock.BlockSize[index], index);
                    break;
            }
            return true;
        }
        public void Sovle(int k, int M)
        {
            if(k == M)
            {
                _isfounded = true;
                return;
            }
            int r = ConvertRow(k);
            int c = ConvertCol(k);
            for(int i = 1; i <= this.Size; i++)
            {
                this.ResultMap[r,c] = i;
                if (IsTrueRow(r, c, this.ResultMap[r,c]) && IsTrueCol(r,c, this.ResultMap[r, c]) && IsTrueBlock(r,c)){
                    Sovle(k + 1, M);
                    if (_isfounded)
                        return;
                }
                this.ResultMap[r,c] = 0;
                //IsLastPointBlock(r, c) ? 0 : -1
            }
        }

        public bool IsLastPointBlock(int r, int c)
        {
            int blockIndex = this.BlockMap[r,c];
            return this.LastPointBlock.Points[blockIndex].Equal(new Point(c, r));
        }
        


    }
    public class Block {
        private Point[] points;
        public Block(int n)
        {
            this.Points = new Point[n];
        }
        public Point[] Points { get => points; set => points = value; }
    }

    public class LastPointBlock {
        private int [] index;
        private Point[] points;
        private int[] blockSize;
        public LastPointBlock(int size)
        {
            this.Points = new Point[size];
            this.Index = new int[size];
            this.BlockSize = new int[size];
            for(int i = 0; i < size; i++)
            {
                index[i] = i;
            }
        }

        public int[] Index { get => index; set => index = value; }
        public Point[] Points { get => points; set => points = value; }
        public int[] BlockSize { get => blockSize; set => blockSize = value; }
    }
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public bool Equal(Point point)
        {
            return X == point.X && Y == point.Y;
        }
    }
}
