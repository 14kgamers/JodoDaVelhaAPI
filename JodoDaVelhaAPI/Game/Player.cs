using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JodoDaVelhaAPI.Game
{
    public class Player
    {
        public string Name { get;}
        public char Mark { get;}

        public Player (string name, char mark)
        {
            Name = name; 
            Mark = mark;
        }
    }
}
