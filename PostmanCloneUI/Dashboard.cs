namespace PostmanCloneUI;
using PostmanCloneLibrary;
public partial class Dashboard : Form
{
    private readonly IApiAccess api = new ApiAccess();
    public Dashboard()
    {
        InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private async void callApi_Click(object sender, EventArgs e)
    {
        systemStatus.Text = "Calling API...";
        systemStatus.Text = "";
        

        // Validate the API

        if (api.IsValidUrl(apiText.Text) == false)
        {
            systemStatus.Text = "Invalid URL";
            return;
        }

        try
        {
            resultsText.Text = await api.CallApiAsync(apiText.Text);
            systemStatus.Text = "Ready";
        }
        catch (Exception ex)
        {

            resultsText.Text = "Error: " + ex.Message;
            systemStatus.Text = "Error";
        }
    }

    private void Dashboard_Load(object sender, EventArgs e)
    {

    }
}
