using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace Event_Binding_Test
{
    /// <summary>
    /// A view model for our UI
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        #region Public Events

        /// <summary>
        /// Property change event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion

        #region Private Members

        /// <summary>
        /// Sample text property for text in <see cref="TextBox"/>
        /// </summary>
        private string mSampleText;

        #endregion

        #region Public Properties

        /// <summary>
        /// Sample text property for text in <see cref="TextBox"/>
        /// </summary>
        public string SampleText
        {
            get
            {
                // return this private property
                return mSampleText;
            }

            set
            {
                // Check if provided is already exist then do nothing
                if (mSampleText == value)
                    return;

                // Assigning the value of input value to private member
                mSampleText = value;

                // This event fire up whenever this property's value is changed
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SampleText)));
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ViewModel()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method which to define input characters we want for our application
        /// e.g. Integers, Decimals
        /// </summary>
        /// <param name="sender">Sender of this method is <see cref="TextBox"/></param>
        /// <param name="e">Events of text composition</param>
        public void IsAllowedInput(object sender, TextCompositionEventArgs e)
        {
            
            // Initiating "Regex" and limiting what characters we want to enter.
            Regex regex = new Regex("[^0-9.-]+");
            
            // Fires the event to add text when input character is match with defined characters.
            e.Handled = regex.IsMatch(e.Text);

        }

        #endregion
    }
}
