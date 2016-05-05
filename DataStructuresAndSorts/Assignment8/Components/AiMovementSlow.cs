using System;

namespace Assignment8
{
    class AiMovementSlow : Component
    {
        public override void Update()
        {
            switch (Direction())
            {
                case "00":
                    Container.Position.X--;
                    break;
                case "01":
                    Container.Position.Y--;
                    break;
                case "10":
                    Container.Position.X++;
                    break;
                case "11":
                    Container.Position.Y++;
                    break;
            }
        }

        private string Direction()
        {
            string result = null;

            for (int i = 0; i < 2; i++)
            {
                if (RandomBool() == true)
                    result += "1";
                else
                    result += "0";
            }
            return result;
        }

        private bool RandomBool()
        {
            return new Random().Next() % 2 == 0;
        }
    }
}