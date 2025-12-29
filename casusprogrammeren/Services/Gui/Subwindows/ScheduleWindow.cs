using casusprogrammeren.Services.Handlers;
using Terminal.Gui;

namespace casusprogrammeren.Services.Gui;

public class ScheduleWindow : Window {

    public ScheduleWindow ()
    {
        Title = "Beheerders Applicatie - Planning";
        
        var items = new List<string> 
        {
            "Maak planning", 
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
                    MessageBox.Query("", ActionScheduleHandler.HandleScheduleRequests(), "OK");
                    break;
                }
                case 1:
                {
                    Application.RequestStop();
                    break;
                }
            }
        };

        Add(listView);
    }
}