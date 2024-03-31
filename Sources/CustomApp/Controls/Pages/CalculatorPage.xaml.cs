
using CustomApp.Models.Pages;
using System.Data;

namespace CustomApp.Controls.Pages;

public partial class CalculatorPage : ContentPage
{
	public CalculatorPage()
	{
		InitializeComponent();

		BindingContext = CalculatorPageModel.Instance;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        inputText.Text += button.Text;
    }

    private void Clear_Clicked(object sender, EventArgs e)
    {
        inputText.Text = "";
    }

    private void Equals_Clicked(object sender, EventArgs e)
    {
        try
        {
            
            //DataTabel ... can be used to evaluate mathematical expressions
            string expression = inputText.Text;
            var dataTable = new DataTable();
            var result = dataTable.Compute(expression, "");
            // Relace , with . so that result can be computed further
            string resultTostring = result.ToString().Replace(',', '.');
            inputText.Text = resultTostring;
        }
        catch (Exception ex)
        {
            inputText.Text = "Error while computing the matehmatical expression";
        }

    }

   
}