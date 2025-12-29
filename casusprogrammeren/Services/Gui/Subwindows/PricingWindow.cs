using casusprogrammeren.Services.Handlers;
using Terminal.Gui;

namespace casusprogrammeren.Services.Gui.Subwindows;

public class PricingWindow : Window {
    private int capacity;
    private int days;

    public PricingWindow ()
    {
        Title = "Beheerders Applicatie - Prijzen";
        
        var items = new List<string> 
        {
            "Kosten van lokaal", 
            "Kosten en opbrengsten berekenen",
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
                    var room = MessageBox.Query("Waar en wat voor lokaal", 
                        "selecteer locatie en type lokaal", 
                        "Spectrum Ruimte", "Prisma Ruimte", 
                        "Spectrum Werkruimte", "Prisma Werkruimte", "Publieke Ruimte");
                    if (room == 0 || room == 1)
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
                        days = 1;
                    }
                    else
                    {
                        days = 5;
                    }

                    float costs = ActionPricingHandler.HandleCosts(capacity, room);
                    
                    MessageBox.Query("", 
                        "Kosten: €" + Convert.ToString(costs * days), "OK");
                    break;
                }
                case 1:
                {
                    var room = MessageBox.Query("Waar en wat voor lokaal", 
                        "selecteer locatie en type lokaal", 
                        "Spectrum Ruimte", "Prisma Ruimte", 
                        "Spectrum Werkruimte", "Prisma Werkruimte", "Publieke Ruimte");
                    if (room == 0 || room == 1)
                    {
                        var m = MessageBox.Query("Selecteer capaciteit",
                            "Selecteer wat voor capaciteit lokaal je wil",
                            "27", "60");
                        if (m == 0)
                            capacity = 27;
                        else
                            capacity = 60;
                    }
                    var dialog = new Dialog("Aantal dagen", 60, 8);
                    var label = new Label("Aantal dagen:") { X = 1, Y = 1 };
                    var input = new TextField("") { X = 1, Y = 2, Width = Dim.Fill() };
                    var ok = new Button("OK") { X = 1, Y = 4 };

                    ok.Clicked += () => 
                    {
                        if (int.TryParse(input.Text.ToString(), out int parsedDays) && parsedDays > 0)
                        {
                            days = parsedDays;
                            Application.RequestStop();
                        }
                        else
                        {
                            MessageBox.ErrorQuery("Fout", "Voer een geldig getal in", "OK");
                        }
                    };

                    dialog.Add(label, input, ok);
                    Application.Run(dialog);
                    
                    float costs = ActionPricingHandler.HandleCosts(capacity, room);
                    costs *= days;

                    float yield = ActionPricingHandler.HandlePrices(capacity, room);
                    yield *= days;
                    
                    float result = yield - costs;
                    
                    MessageBox.Query("", 
                        $"Kosten: €{Convert.ToString(costs)}\nOpbrengst: €{Convert.ToString(yield)}\nWinst: €{Convert.ToString(result)}", "OK");
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