using casusprogrammeren.Services.Gui.Subwindows;
using casusprogrammeren.Services.Tui;
using Terminal.Gui;
namespace casusprogrammeren.Services.Gui;

public class MainWindow : Window {

    public MainWindow ()
    {
        Title = "Beheerders Applicatie";
       
        var items = new List<string> 
        {
            "Ruimtes", 
            "Prijzen",
            "Zuurstof Ruimtes", 
            "Algoritme"
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
                    Application.Run<RoomsWindow>();
                    break;
                }
                case 1:
                {
                    Application.Run<PricingWindow>();
                    
                    break;
                }
                case 2:
                {
                    Application.Run<OxygenWindow>();
                    
                    break;
                }
                case 3:
                {
                    Application.Run<AlgorithmWindow>();
                    break;
                }
            }
        };

        Add(listView);
    }
}