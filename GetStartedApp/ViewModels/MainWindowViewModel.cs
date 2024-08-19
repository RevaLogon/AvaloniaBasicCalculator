using System;
using System.Windows.Input;

namespace GetStartedApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _firstNumber = string.Empty;
        private string _secondNumber = string.Empty;
        private string _result = string.Empty;

        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(CalculateAddition);
            SubtractCommand = new RelayCommand(CalculateSubtraction);
            MultiplyCommand = new RelayCommand(CalculateMultiplication);
            DivideCommand = new RelayCommand(CalculateDivision);
            ClearCommand = new RelayCommand(Clear);
        }

        public string FirstNumber
        {
            get => _firstNumber;
            set
            {
                if (_firstNumber != value)
                {
                    _firstNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SecondNumber
        {
            get => _secondNumber;
            set
            {
                if (_secondNumber != value)
                {
                    _secondNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }
        public ICommand ClearCommand { get; }

        private void CalculateAddition() => Calculate((a, b) => a + b, "addition");
        private void CalculateSubtraction() => Calculate((a, b) => a - b, "subtraction");
        private void CalculateMultiplication() => Calculate((a, b) => a * b, "multiplication");
        private void CalculateDivision()
        {
            if (double.TryParse(SecondNumber, out double secondNumber) && secondNumber == 0)
            {
                Result = "Cannot divide by zero.";
                return;
            }
            Calculate((a, b) => a / b, "division");
        }

        private void Calculate(Func<double, double, double> operation, string operationName)
        {
            if (double.TryParse(FirstNumber, out double firstNumber) &&
                double.TryParse(SecondNumber, out double secondNumber))
            {
                double calculationResult = operation(firstNumber, secondNumber);
                Result = $"The result of {operationName} is: {calculationResult}";
            }
            else
            {
                Result = "Please enter valid numbers.";
            }
        }

        private void Clear()
        {
            FirstNumber = string.Empty;
            SecondNumber = string.Empty;
            Result = string.Empty;
        }
    }
}

