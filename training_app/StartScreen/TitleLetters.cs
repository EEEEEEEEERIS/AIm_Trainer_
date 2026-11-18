using System;
using System.Collections.Generic;
using System.Text;

namespace Aim_Trainer
{
    public class TitleLetters
    {
        public char Draw { get; set; }
        public float StartX { get; set; }      // wo er herkommt
        public float StartY { get; set; }
        public float DestinationX { get; set; }       // wo er landen soll
        public float DestinationY { get; set; }
        public float X { get; set; }           // aktuelle Position
        public float Y { get; set; }
    }
}
