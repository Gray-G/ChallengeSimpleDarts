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
        public Random RandomNumber { get; set; }

        public Dart(Random random)
        {
            RandomNumber = random;
        }

        public void Throw()
        {
            IsDoubleBand = false;
            IsTripleBand = false;
            IsBullseye = false;
            int dartPosition = RandomNumber.Next(0, 20);
            int doubleRingOrTripleRing = RandomNumber.Next(0, 100);

            // Generate dart's position on board, including whether in double or triple ring
            generateDartPosition(dartPosition, doubleRingOrTripleRing);
        }

        private void generateDartPosition(int dartPosition, int doubleRingOrTripleRing)
        {
            if (dartPosition >= 1) // It's not a bullseye
                handleNonBullseye(doubleRingOrTripleRing);
            else if (dartPosition == 0) // It's a bullseye
                handleBullseye(IsBullseye, doubleRingOrTripleRing);

            // Add points to score by reading dartPosition
            addPoints(dartPosition);
        }

        private void handleNonBullseye(int doubleRingOrTripleRing)
        {
            if (doubleRingOrTripleRing <= 5) // 5% chance of landing in outer band (double score)
                IsDoubleBand = true;
            else if (doubleRingOrTripleRing > 5 && doubleRingOrTripleRing <= 10) // 5% chance of landing in inner band (triple score)
                IsTripleBand = true;
        }

        private void handleBullseye(bool isBullseye, int doubleRingOrTripleRing)
        {
            IsBullseye = true;

            if (doubleRingOrTripleRing <= 5) // 5% chance of landing in inner band (triple score)
                IsTripleBand = true;
        }

        public void addPoints(int dartPosition)
        {
            if (IsBullseye && IsTripleBand)
                Score += 50;
            else if (IsBullseye)
                Score += 25;
            else
            {
                if (IsDoubleBand)
                    Score += (dartPosition * 2);
                else if (IsTripleBand)
                    Score += (dartPosition * 3);
            }
        }
    }
}