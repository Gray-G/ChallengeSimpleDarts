using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Dart
    {
        public int Score { get; set; }

        public bool IsDoubleBand { get; set; }
        public bool IsTripleBand { get; set; }
        public bool IsBullseye { get; set; }

        public Dart(Random random)
        {
            Random randomNumber = random;
        }

        public void Throw(Random randomNumber)
        {
            IsDoubleBand = false;
            IsTripleBand = false;
            IsBullseye = false;
            int greaterDartPosition = randomNumber.Next(0, 20);
            int doubleRingOrTripleRing = randomNumber.Next(0, 100);

            if (greaterDartPosition >= 1)
            { 

                if (doubleRingOrTripleRing <= 5) // 5% chance of landing in outer band (double score)
                {
                    IsDoubleBand = true;
                }
                else if (doubleRingOrTripleRing > 5 && doubleRingOrTripleRing <= 10) // 5% chance of landing in inner band (triple score)
                {
                    IsTripleBand = true;
                }
            }
            else if (greaterDartPosition == 0)
            {
                IsBullseye = true;

                if (doubleRingOrTripleRing <= 5) // 5% chance of landing in inner band (triple score)
                {
                    IsTripleBand = true;
                }
            }

            readThrow(greaterDartPosition);
        }

        public void readThrow(int greaterDartPosition)
        {
            if (IsBullseye && IsTripleBand)
                Score += 50;
            else if (IsBullseye)
                Score += 25;
            else
            {
                if (IsDoubleBand)
                    Score += (greaterDartPosition * 2);
                else if (IsTripleBand)
                    Score += (greaterDartPosition * 3);
            }
        }
    }
}