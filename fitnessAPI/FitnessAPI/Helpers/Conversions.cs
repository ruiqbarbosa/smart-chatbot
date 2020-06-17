namespace FitnessAPI.Helpers
{
    public static class Conversions
    {
        public static double FtInchToInch(string number)
        {
            string[] tokens = number.Split('.');
            if (tokens.Length < 2 || tokens.Length > 2)
            {
                return 0;
            }

            int feet = int.Parse(tokens[0]);
            int inches = int.Parse(tokens[1]);
            if (inches >= 12)
            {
                return 0;
            }

            return (feet * 12) + inches;
        }
    }
}