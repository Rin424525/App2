using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App2
{
	public partial class MainPage : ContentPage
	{
		int currentState = 1;
		string mathOperator;
		double firstNumber, secondNumber;
		private bool cliker;


		public MainPage()
		{
			InitializeComponent(); 
			OnClear(this, null);
		}

		void OnSelectNumber(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string pressed = button.Text;

			if (this.resultText.Text == "0" || currentState < 0)
			{
				this.resultText.Text = "";
				if (currentState < 0)
					currentState *= -1;
			}

			this.resultText.Text += pressed;

			double number;
			if (double.TryParse(this.resultText.Text, out number))
			{
				this.resultText.Text = number.ToString();
				if (currentState == 1)
				{
					firstNumber = number;
				}
				else
				{
					secondNumber = number;
				}
			}
		}


		void OnSelectOperator(object sender, EventArgs e)
		{
			currentState = -2;
			Button button = (Button)sender;
			string pressed = button.Text;
			mathOperator = pressed;
		}


		void OnClear(object sender, EventArgs e)
		{
			firstNumber = 0;
			secondNumber = 0;
			currentState = 1;
			this.resultText.Text = "0";
		}
		private void OnSelectOperator2(object sender, EventArgs e)
        {
			string number = resultText.Text;
			if(number!= "0")
            {
				number = number.Remove(number.Length - 1, 1);
				if(string.IsNullOrEmpty(number))
                {
					resultText.Text = "0";

                }
                else
                {
					resultText.Text= number;
                }

            }


		}


		public static class SimpleCalculator
		{
			public static double Calculate(double value1, double value2, string mathOperator)
			{
				double result = 0;

				switch (mathOperator)
				{
					case "/":
						result = value1 / value2;
						break;
					case "*":
						result = value1 * value2;
						break;
					case "+":
						result = value1 + value2;
						break;
					case "-":
						result = value1 - value2;
						break;
					case "%":
						result =value1 / 100;
						break;
					

				}

				return result;
			}
		}

        private void ZP(object sender, EventArgs e)
        {
			var button = sender as Button;
			if(resultText.Text=="0" || cliker)
            {
				cliker = false;
				resultText.Text = button.Text;
            }
			else
            {
				resultText.Text += button.Text;

            }

        }

        void OnCalculate(object sender, EventArgs e)
		{
			if (currentState == 2)
			{
				var result = SimpleCalculator.Calculate(firstNumber, secondNumber, mathOperator);

				this.resultText.Text = result.ToString();
				firstNumber = result;
				currentState = -1;
			}
		}
	}
}
