using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurtleCommandWebApp.Models
{
    public enum Direction { North, South, East, West }

    public static class TurtleTable
    {
        public const int MaxXCoordinate = 5;
        public const int MaxYCoordinate = 5;
    }

    interface ITurtleCommand
    {
        void Place(int x, int y, Direction direction);
        void Move();
        void Left();
        void Right();
        string Report();
    }

    public class TurtleCommand : ITurtleCommand
    {
        private bool _hasPlaced = false; //Flag used to determine if the Turtle was already placed, ignore commands if not
        private enum TurningDirection { Left, Right };

        [Range(0, TurtleTable.MaxXCoordinate, ErrorMessage = "X coordinates should be between 0 and {2}")]
        public int X { get; set; }

        [Range(0, TurtleTable.MaxYCoordinate, ErrorMessage = "Y coordinates should be between 0 and {2}")]
        public int Y { get; set; }

        [Required(ErrorMessage = "Direction is required")]
        public Direction Facing { get; set; }

        public void Place(int x, int y, Direction direction)
        {
            this.X = x < 0 ? 0 : (x > TurtleTable.MaxXCoordinate ? TurtleTable.MaxXCoordinate : x);
            this.Y = y < 0 ? 0 : (y > TurtleTable.MaxYCoordinate ? TurtleTable.MaxYCoordinate : y);
            this.Facing = direction;

            _hasPlaced = true;
        }

        private void Turn(TurningDirection _turningDirection)
        {
            if (!_hasPlaced) { return; } //Command is ignored if the Turtle is not yet placed

            switch (this.Facing)
            {
                case Direction.North:
                    this.Facing = (_turningDirection == TurningDirection.Left) ? Direction.West : Direction.East;
                    break;

                case Direction.South:
                    this.Facing = (_turningDirection == TurningDirection.Left) ? Direction.East : Direction.West;
                    break;

                case Direction.East:
                    this.Facing = (_turningDirection == TurningDirection.Left) ? Direction.North : Direction.South;
                    break;

                case Direction.West:
                    this.Facing = (_turningDirection == TurningDirection.Left) ? Direction.South : Direction.North;
                    break;
            }
        }

        public void Left()
        {
            this.Turn(TurningDirection.Left);
        }

        public void Right()
        {
            this.Turn(TurningDirection.Right);
        }

        public void Move()
        {
            if (!_hasPlaced) { return; } //Command is ignored if the Turtle is not yet placed

            switch (this.Facing)
            {
                case Direction.North:
                    if (this.Y == TurtleTable.MaxYCoordinate) { return; } // Making sure turtle won't fall
                    this.Y += 1;
                    break;

                case Direction.South:
                    if (this.Y == 0) { return; }  // Making sure turtle won't fall
                    this.Y -= 1;
                    break;

                case Direction.East:
                    if (this.X == TurtleTable.MaxXCoordinate) { return; } // Making sure turtle won't fall
                    this.X += 1;
                    break;

                case Direction.West:
                    if (this.X == 0) { return; } // Making sure turtle won't fall
                    this.X -= 1;
                    break;
            }
        }

        public string Report()
        {
            if (!_hasPlaced) { return null; } //Command is ignored if the Turtle is not yet placed
            string result = string.Format("{0} {1} {2}", this.X, this.Y, this.Facing.ToString());

            Console.WriteLine("{0} {1} {2}", this.X, this.Y, this.Facing.ToString());
            return result;
        }

    }
}
