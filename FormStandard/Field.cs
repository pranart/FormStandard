using System;
using PropertyChanged;

namespace FormStandard
{
    [AddINotifyPropertyChangedInterface]
    public class Field 
    {
        public string Name { get; set; } = string.Empty;
        public bool IsNotValid { get; set; }
        public string NotValidMessageError { get; set; } = string.Empty;
    }
}
