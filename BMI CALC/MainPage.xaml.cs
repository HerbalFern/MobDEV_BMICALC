namespace BMI_CALC;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void BMICalc(object sender, EventArgs e)
    {
        double heightInCM = Convert.ToDouble(gettingHeight.Text);
        double WeightInKg = Convert.ToDouble(gettingWeight.Text);

        if (!double.IsNaN(heightInCM) && !double.IsNaN(WeightInKg))
        {
            double BMI = (WeightInKg / (heightInCM * heightInCM)) * 10000;

            Result.Text = "Your BMI is " + Math.Round(BMI, 2);
            
            if (BMI < 18.5)
            {
                Status.Text = "You are Underweight";
            } 
            else if (BMI < 25)
            {
                Status.Text = "You have a Normal BMI";
            } 
            else if (BMI < 30)
                Status.Text = "You are Overweight";
            else
            {
                Status.Text = "You are Obese";
            }
        }
        else
        {
            Status.Text = "Please Input Proper Values";
        }      
    }
}