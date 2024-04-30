namespace Assignment2
{
    internal class Die
    {
        /*
         * The Die class should contain one property to hold the current die value,
         * and one method that rolls the die, returns and integer and takes no parameters.
         */

        private Random random;

        //Property to hold die value
        public int DieValue { get; private set; }


        // Constructor with random object as parameter to avoid all dices rolling the same number
        public Die(Random random)
        {
            this.random = random;
            // Initialize the die value, for example, with a default value of 1
            DieValue = 1;
        }

        //Method to roll the die and return result
        public int Roll()
        {
            DieValue = random.Next(1, 7); // Genrates a random number between 1 and 6
            return DieValue;
        }
    }
}