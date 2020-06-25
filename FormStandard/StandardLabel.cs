using System;
using Xamarin.Forms;

namespace FormStandard
{
    public class StandardLabel : Label
	{
		public StandardLabel ()
		{
            //FontFamily = "THSarabunNew";
            //FontSize = Device.GetNamedSize(NamedSize.Large, this);
            FontSize = Device.GetNamedSize(NamedSize.Medium, this);

        }


        public static readonly BindableProperty IsBoldProperty =
            //BindableProperty.Create<StandardLabel,bool>(X=>X.IsBold,false);
            BindableProperty.Create(nameof(IsBold), typeof(bool), typeof(StandardLabel),false);

		public bool IsBold
		{
            get { return (bool)base.GetValue (IsBoldProperty); }
            set { base.SetValue (IsBoldProperty, value); }

		}

        public static readonly BindableProperty LineLimitProperty =
            //BindableProperty.Create<StandardLabel,int>(X=>X.LineLimit,10000);
            BindableProperty.Create(nameof(LineLimit), typeof(int), typeof(StandardLabel),10000);

		public int LineLimit
		{
			get { return (int)base.GetValue (LineLimitProperty); }
			set { base.SetValue (LineLimitProperty, value); }

		}
	}
}

