using System;
using Xamarin.Forms;
namespace FormStandard
{
	public class FlexGridLength
	{
		public FlexGridLength() { }
		public double Value { get; set; }

		public static implicit operator GridLength(FlexGridLength input)
		{
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				return new GridLength(2.0 * input.Value, GridUnitType.Absolute);
			}
			else
			{
				return new GridLength(input.Value, GridUnitType.Absolute);
			}
		}
	}
	public class FlexDouble
	{
		public FlexDouble() { }
		public double Value { get; set; }
		public static implicit operator double(FlexDouble input)
		{
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				return 2.0 * input.Value;
			}
			else
			{
				return input.Value;
			}
		}
	}
	public class FlexThickness
	{
		public FlexThickness() { }
		public Thickness Value { get; set; }
		public static implicit operator Thickness(FlexThickness input)
		{
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				return new Thickness(2 * input.Value.Left, 2 * input.Value.Top, 2 * input.Value.Right, 2 * input.Value.Bottom);
			}
			else
			{
				return input.Value;
			}

		}
	}
	public class Standard
	{
		
		public static int Flex(int input) 
		{
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				return 2 * input;
			}
			else
			{
				return input;
			}
		}
		public static double Flex(double input)
		{
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				return 2 * input;
			}
			else
			{
				return input;
			}
		}
		public static Thickness Flex(Thickness input)
		{
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				return new Thickness(2*input.Left, 2*input.Top, 2*input.Right, 2*input.Bottom);
			}
			else
			{
				return input;
			}
		}
		public static int Font(int input)
		{
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				return (int)(1.5 * input);
			}
			else
			{
				return input;
			}
		}
		public static double Font(double input)
		{
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				return 1.25 * input;
			}
			else
			{
				return input;
			}
		}
	}
}
