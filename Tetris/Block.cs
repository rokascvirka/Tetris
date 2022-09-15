using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tetris
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        public abstract int Id { get; }

        private int rotationstate;
        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[rotationstate])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        public void RotateCW()
        {
            rotationstate = (rotationstate + 1) % Tiles.Length;
        }
        public void RotateCCW()
        {
            if (rotationstate == 0)
            {
                rotationstate = Tiles.Length - 1;
            }
            else
            {
                rotationstate--;
            }
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotationstate = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }

}
