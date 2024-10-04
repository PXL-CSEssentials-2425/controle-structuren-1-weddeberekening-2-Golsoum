using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace weddeberekening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string fullName;

        float paymentHour;
        float amountHour;
        double netoPayment;
        double grossPayment;
        double tax;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void countButton_Click(object sender, RoutedEventArgs e)
        {
            fullName = staffMemberTextBox.Text;
            amountHour = Convert.ToSingle(amountHourTextBox.Text);
            paymentHour = Convert.ToSingle(paymentPerHourTextBox.Text);
            grossPayment = amountHour * paymentHour;


            if (grossPayment > 50000)
            {
                tax += (grossPayment -50000) * 0.5 ;
                netoPayment = grossPayment - tax;

            }
            else if (grossPayment < 25000)
            {
                tax += (grossPayment - 25000)* 0.4; ;
                netoPayment = grossPayment - tax;
            }
            else if (grossPayment < 15000)
            {
                tax += (grossPayment - 15000) * 0.3; ;
                netoPayment = grossPayment - tax;
            }
            else if (grossPayment < 10000)
            {
                tax += (grossPayment - 10000) * 0.2; ;
                netoPayment = tax - grossPayment ;
            }
            else
            {
                tax = 0;
                netoPayment = grossPayment;
            }
            resultTextBlock.Text = $"LOONFICHE {fullName} \n Aantal gewerkte uren: {amountHour} \n Uurloon : {paymentHour} " +
                $"\n Brutojaarwedde: {grossPayment} \n belasting : {tax} \n Nettojaarwedde: {netoPayment}";
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            amountHourTextBox.Focus();
            amountHourTextBox.Clear();
            paymentPerHourTextBox.Clear();
        }
    }
}