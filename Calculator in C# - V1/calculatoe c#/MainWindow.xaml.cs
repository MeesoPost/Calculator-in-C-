using System;
using System.Windows;
using System.Windows.Controls;

namespace Reken_Machine
{
    public partial class MainWindow : Window
    {
        private string currentNumber;
        private string operation;
        private double result;
        private TextBox txtDisplay;

        public MainWindow()
        {
            InitializeComponent();

            currentNumber = "";
            operation = "";
            result = 0;

            // Assign the txtDisplay TextBox control from the XAML to the txtDisplay variable
            txtDisplay = TxtDisplay;
        }

        private void AppendNumber(string number)
        {
            currentNumber += number;
            txtDisplay.Text = currentNumber;
        }

        private void SetOperation(string operation)
        {
            this.operation = operation;
            result = double.Parse(currentNumber);
            currentNumber = "";
        }

        private void CalculateResult()
        {
            double secondNumber = double.Parse(currentNumber);

            switch (operation)
            {
                case "+":
                    result += secondNumber;
                    break;
                case "-":
                    result -= secondNumber;
                    break;
                case "x":
                    result *= secondNumber;
                    break;
                case "÷":
                    result /= secondNumber;
                    break;
            }

            txtDisplay.Text = result.ToString();
            currentNumber = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string content = button.Content.ToString();

            switch (content)
            {
                case "C":
                    currentNumber = "";
                    txtDisplay.Text = "0";
                    break;
                case "=":
                    CalculateResult();
                    break;
                case "+":
                case "-":
                case "x":
                case "÷":
                    SetOperation(content);
                    break;
                default:
                    AppendNumber(content);
                    break;
            }
        }

        private void TxtDisplay_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Get the updated text from the TextBox
            string newText = txtDisplay.Text;

            // Add your custom logic here
            // For example, you can perform validation or update other UI elements based on the new text

            // Let's display a message box with the updated text
            MessageBox.Show($"New text: {newText}");
        }
    }
}
