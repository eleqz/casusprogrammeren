using casusprogrammeren.Services.Handlers;
using Terminal.Gui;

namespace casusprogrammeren.Services.Gui;

public class PricingWindow : Window {

    public PricingWindow ()
    {
        Title = "Beheerders Applicatie - Prijzen";
        
        var items = new List<string> 
        {
            "Pseudocode Algoritme", 
            "-", 
            "-", 
            "← Terug"
        };
        var listView = new ListView(items)
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill(),
            AllowsMarking = true,
            AllowsMultipleSelection = false,
        };
        
        
        listView.OpenSelectedItem += (args) =>
        {
            int selection = listView.SelectedItem;
            switch (selection)
            {
                case 0:
                { 
                    MessageBox.Query("", ActionAlgorithmHandler.HandlePseudoCode(), "OK");
                    break;
                }
                case 1:
                {
                    /*MessageBox.Query("Action", ActionHandler.HandleOxygenCalculator(), "OK");*/
                    break;
                }
                case 2:
                {
                    /*MessageBox.Query("Action", ActionHandler.HandlePseudoCode(), "OK");*/
                    break;
                }
                case 3:
                {
                    Application.RequestStop();
                    break;
                }
            }
        };

        Add(listView);
    }
}