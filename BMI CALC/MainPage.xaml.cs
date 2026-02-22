namespace BMI_CALC;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    
    private async void HideKeyboard()
    {
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            gettingHeight.Unfocus();
            gettingWeight.Unfocus();
        });
    }
    
    private async void BMICalc(object sender, EventArgs e)
    {
        // nag double try parse daw is better for input handling? 
        
        if (double.TryParse(gettingHeight.Text, out double heightInCM) &&
            double.TryParse(gettingWeight.Text, out double WeightInKg))
        {
            double BMI = (WeightInKg / (heightInCM * heightInCM)) * 10000;
            Result.Text = "Your BMI is " + Math.Round(BMI, 2);

            if (BMI < 18.5)
                Status.Text = "You are Underweight";
            else if (BMI < 25)
                Status.Text = "You have a Normal BMI";
            else if (BMI < 30)
                Status.Text = "You are Overweight";
            else
                Status.Text = "You are Obese";
        }
        else
        {
            Status.Text = "Please Input Proper Values";
        }
        
        HideKeyboard(); // yeah doesnt work lol
        
    }
}