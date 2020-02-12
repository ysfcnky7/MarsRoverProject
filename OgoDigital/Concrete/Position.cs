using OgoDigital.Abstract;
using OgoDigital.Enums;
using System;
using System.Collections.Generic;
namespace OgoDigital.Concrete
{
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions _Direction { get; set; }
        public Position()
        {
            X = Y = 0;
            _Direction = Directions.N;
        }
        private void LeftRotate()
        {
            switch (this._Direction)
            {
                case Directions.N:
                    this._Direction = Directions.W;
                    break;
                case Directions.S:
                    this._Direction = Directions.E;
                    break;
                case Directions.E:
                    this._Direction = Directions.N;
                    break;
                case Directions.W:
                    this._Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }
        private void RightRotate()
        {
            switch (this._Direction)
            {
                case Directions.N:
                    this._Direction = Directions.E;
                    break;
                case Directions.S:
                    this._Direction = Directions.W;
                    break;
                case Directions.E:
                    this._Direction = Directions.S;
                    break;
                case Directions.W:
                    this._Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }
        private void ForwardRotate()
        {
            switch (this._Direction)
            {
                case Directions.N:
                    this.Y += 1;
                    break;
                case Directions.S:
                    this.Y -= 1;
                    break;
                case Directions.E:
                    this.X += 1;
                    break;
                case Directions.W:
                    this.X -= 1;
                    break;
                default:
                    break;
            }
        }
        public void StartMove(List<int> maxPoints, string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        this.ForwardRotate();
                        break;
                    case 'L':
                        this.LeftRotate();
                        break;
                    case 'R':
                        this.RightRotate();
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {move}");
                        break;
                }
                if (this.X < 0 || this.X > maxPoints[0] || this.Y < 0 || this.Y > maxPoints[1])
                {
                    throw new Exception($"Oops! Position can not be beyond bounderies (0 , 0) and ({maxPoints[0]} , {maxPoints[1]})");
                }
            }
        }
    }
}
