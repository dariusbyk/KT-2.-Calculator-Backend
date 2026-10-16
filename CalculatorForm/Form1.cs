namespace CalculatorForm
{
    public partial class Form1 : Form
    {
        private double firstNumber = 0;
        private string operation = "";
        private bool startNewNumber = true;
        private bool hasError = false;
        private CalculatorService calculator = new CalculatorService();

        public Form1()
        {
            InitializeComponent();

            textBox1.Text = "0";
            textBox1.ReadOnly = true;
            textBox1.TextAlign = HorizontalAlignment.Right;
        }

        // Один обработчик для всех кнопок с цифрами.
        private void Number_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (hasError == true)
            {
                ClearCalculator();
            }

            if (startNewNumber == true || textBox1.Text == "0")
            {
                textBox1.Text = button.Text;
                startNewNumber = false;
            }
            else
            {
                // Ограничиваем длину вводимого числа.
                if (textBox1.Text.Length < 15)
                {
                    textBox1.Text = textBox1.Text + button.Text;
                }
            }
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            if (hasError == true)
            {
                return;
            }

            Button button = (Button)sender;

            // Например, при вводе 2 + 3 * сначала получаем 5.
            if (operation != "" && startNewNumber == false)
            {
                if (CalculateResult() == false)
                {
                    return;
                }
            }

            firstNumber = Convert.ToDouble(textBox1.Text);
            operation = button.Text;
            startNewNumber = true;
        }

        private void Equals_Click(object sender, EventArgs e)
        {
            if (hasError == true || operation == "" || startNewNumber == true)
            {
                return;
            }

            if (CalculateResult() == true)
            {
                operation = "";
                startNewNumber = true;
            }
        }

        private bool CalculateResult()
        {
            double secondNumber = Convert.ToDouble(textBox1.Text);

            if (operation == "/" && secondNumber == 0)
            {
                ShowError("Нельзя делить на 0");
                return false;
            }

            double result = calculator.Calculate(firstNumber, secondNumber, operation);

            if (double.IsInfinity(result) == true || double.IsNaN(result) == true)
            {
                ShowError("Слишком большое число");
                return false;
            }

            textBox1.Text = result.ToString();
            firstNumber = result;
            return true;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            ClearCalculator();
        }

        private void ClearCalculator()
        {
            firstNumber = 0;
            operation = "";
            startNewNumber = true;
            hasError = false;
            textBox1.Text = "0";
        }

        private void ShowError(string message)
        {
            textBox1.Text = message;
            firstNumber = 0;
            operation = "";
            startNewNumber = true;
            hasError = true;
        }
    }
}
