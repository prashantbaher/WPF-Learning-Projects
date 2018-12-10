using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Event_Binding_Test
{
    public class ViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private string mSampleText;

        public string SampleText
        {
            get
            {
                return this.mSampleText;
            }

            set
            {
                if (mSampleText == value)
                    return;

                mSampleText = value;

                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SampleText)));
            }
        }

        public ViewModel()
        {
            
        }

        public void IsAllowedInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
