using casusprogrammeren.Services.Handlers;
using Terminal.Gui;

namespace casusprogrammeren.Services.Gui.Subwindows;

public class PricingWindow : Window {
    int capacity;
    int dagen;

    public PricingWindow ()
    {
        Title = "Beheerders Applicatie - Prijzen";
        
        var items = new List<string> 
        {
            "Kosten van lokaal", 
            "Winst lokaal berekenen", 
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
                    var ruimte = MessageBox.Query("Waar en wat voor lokaal", 
                        "selecteer locatie en type lokaal", 
                        "Spectrum Ruimte", "Prisma Ruimte", 
                        "Spectrum Werkruimte", "Prisma Werkruimte", "Publieke Ruimte");
                    if (ruimte == 0 || ruimte == 1)
                    {
                        var m = MessageBox.Query("Selecteer capaciteit",
                            "Selecteer wat voor capaciteit lokaal je wil",
                            "27", "60");
                        if (m == 0)
                            capacity = 27;
                        else
                            capacity = 60;
                    }
                    var n = MessageBox.Query("Selecteer periode", 
                        "Wat voor periode wilt u berekenen?", 
                        "Dag", "Week");
                    if (n == 0)
                    {
                        dagen = 1;
                    }
                    else
                    {
                        dagen = 5;
                    }

                    int kosten = ActionPricingHandler.HandleCosts(capacity, ruimte);
                    MessageBox.Query("", 
                        "Kosten: €" + Convert.ToString(kosten * dagen), "OK");
                    break;
                }
                case 1:
                {
                    var ruimte = MessageBox.Query("Waar en wat voor lokaal", 
                        "selecteer locatie en type lokaal", 
                        "Spectrum Ruimte", "Prisma Ruimte", 
                        "Spectrum Werkruimte", "Prisma Werkruimte", "Publieke Ruimte");
                    if (ruimte == 0 || ruimte == 1)
                    {
                        var m = MessageBox.Query("Selecteer capaciteit",
                            "Selecteer wat voor capaciteit lokaal je wil",
                            "27", "60");
                        if (m == 0)
                            capacity = 27;
                        else
                            capacity = 60;
                    }
                    var n = MessageBox.Query("Selecteer periode", 
                        "Wat voor periode wilt u berekenen?", 
                        "Dag", "Week");
                    if (n == 0)
                    {
                        dagen = 1;
                    }
                    else
                    {
                        dagen = 5;
                    }
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