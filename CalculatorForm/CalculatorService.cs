namespace CalculatorForm
{
    internal class CalculatorService
    {
        public double Calculate(double firstNumber, double secondNumber, string operation)
        {
            double result = 0;

            if (operation == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (operation == "-")
            {
                result = firstNumber - secondNumber;
            }
            else if (operation == "*")
            {
                result = firstNumber * secondNumber;
            }
            else if (operation == "/")
            {
                result = firstNumber / secondNumber;
            }

            return result;
        }
    }
}
