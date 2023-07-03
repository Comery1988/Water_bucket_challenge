namespace Water_bucket_challenge.Models
{
    public class ValidateGallons
    {
        /*
         * Function to validate that the obtained values allow a possible solution to the problem. 
         * This function receives the gallons inserted by the user (X, Y and Z) to carry out the 3 
         * necessary validations to know if the combination has a solution
         */
        public bool Validate(Gallons gallons)
        {
            // Check if the values of X and Y are less than Z, if so it has no solution and returns false
            if (gallons.X_Gallon < gallons.Z_Gallon && gallons.Y_Gallon < gallons.Z_Gallon)
            {
                return false;
            }
            // Verify that if the values of X and Y are equal and in turn are different from X, if so, it has no solution and returns false
            else if (gallons.X_Gallon == gallons.Y_Gallon && gallons.X_Gallon != gallons.Z_Gallon)
            {
                return false;
            }
            // Check if the Greatest Common Divisor of X and Y is not divisible by Z, if so it has no solution and returns false
            else if ((gallons.Z_Gallon % GetGCD(gallons.X_Gallon, gallons.Y_Gallon)) != 0)
            {
                return false;
            }
            // If none of the above conditions were true, the combination has a solution and returns true
            else
            {
                return true;
            }
        }

        /*
         * Function performed by Euclid's algorithm to determine the Greatest Common Divisor of two numbers
         */
        private static int GetGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
    }
}
