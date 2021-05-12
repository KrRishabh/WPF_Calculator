using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber;
        double firstNumber;
        SelectedOperator selectedOperator;
        double result;
        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber)){
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber;
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            //if(resultLabel.Content.ToString()[0] == '-')
            // {
            //   resultLabel.Content = resultLabel.Content.ToString().Substring(1);
            //}
            //else
            // {
            //    resultLabel.Content = "-" + resultLabel.Content;
            //}
            lastNumber = double.Parse(resultLabel.Content.ToString());
            lastNumber = -lastNumber;
            resultLabel.Content = lastNumber.ToString();
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            
            string selectedValue = "0";
            /*
            if (sender == oneButton)
                selectedValue = "1";
            if (sender == twoButton)
                selectedValue = "2";
            if (sender == threeButton)
                selectedValue = "3";
            if (sender == fourButton)
                selectedValue = "4";
            if (sender == fiveButton)
                selectedValue = "5";
            if (sender == sixButton)
                selectedValue = "6";
            if (sender == sevenButton)
                selectedValue = "7";
            if (sender == eightButton)
                selectedValue = "8";
            if (sender == nineButton)
                selectedValue = "9";
            */

            selectedValue = (sender as Button).Content.ToString();

            if (resultLabel.Content.ToString() == "0")
                resultLabel.Content = selectedValue;
            else
                resultLabel.Content = resultLabel.Content.ToString() + selectedValue;
        }
        private void operationButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                
                resultLabel.Content = "0";
            }
            if (sender == multiplyButton)
                selectedOperator = SelectedOperator.Mulitplication;
            else if (sender == divideButton)
                selectedOperator = SelectedOperator.Division;
            else if (sender == plusButton)
                selectedOperator = SelectedOperator.Addition;
            else if (sender == minusButton)
                selectedOperator = SelectedOperator.Substraction;
        }

        private void equalsButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if(double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = lastNumber + newNumber;
                        break;
                    case SelectedOperator.Mulitplication:
                        result = lastNumber * newNumber;
                        break;
                    case SelectedOperator.Division:
                        result = lastNumber / newNumber;
                        break;
                    case SelectedOperator.Substraction:
                        result = lastNumber - newNumber;
                        break;

                        
                }
                resultLabel.Content = result.ToString();
            }
        }
    }
    public enum SelectedOperator
    {
        Addition,
        Substraction,
        Mulitplication,
        Division
    }
}
