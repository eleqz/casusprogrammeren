using casusprogrammeren.Services.Handlers;
using Terminal.Gui;
namespace casusprogrammeren.Services.Gui;

public class OxygenWindow : Window {

    public OxygenWindow ()
    {
        Title = "Beheerders Applicatie - Zuurstof";
        
        var items = new List<string> 
        { 
            "Zuurstof gebruik berekenen bij 27 personen voor 2 uur",
            "Maximale consumptie aan zuurstof berekenen",
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
                    
                    MessageBox.Query("Zuurstof Gebruik",
                        ActionOxygenHandler.HandleOxygenUsedCalculator(), "OK");
                    break;
                }
                case 1:
                {
                    MessageBox.Query("Maximale Zuurstof Consumptie",
                        ActionOxygenHandler.HandleMaximumOxygenConsumptionCalculator(), "OK");
                    break;
                }
                case 2:
                {
                    Application.RequestStop();
                    break;
                }
            }
        };

        Add(listView);
    }
}