using casusprogrammeren.Services.Handlers;
using casusprogrammeren.utils;
using Terminal.Gui;

namespace casusprogrammeren.Services.Gui.Subwindows;

public class RoomsWindow : Window
{

    public RoomsWindow ()
    {
        Title = "Beheerders Applicatie - Ruimtes";
        
        var items = new List<string>
        {
            "Zie alle Ruimtes", 
            "Voeg ruimtes toe", 
            "Ruimte opzoeken", 
            "Zie hoeveelheid aanwezige in CHE",
            "Zie bezettingsgraad CHE per maand",
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
        
        var textView = new TextView()
        {
            X = 0,
            Y = 7,
            Width = Dim.Fill(),
            Height = Dim.Fill(),
        };
        var saveButton = new Button("Opslaan en sluiten")
        {
            X = 0,
            Y = 6,
        };
        
        listView.OpenSelectedItem += (args) =>
        {
            int selection = listView.SelectedItem;
            switch (selection)
            {
                case 0:
                { 
                    MessageBox.Query("Ruimtes", ActionRoomsHandler.HandleAction(), "OK");
                    break;
                }
                case 1:
                {
                    Add(textView, saveButton);
                    var deserializer = new JsonUtil();
                    deserializer.Deserialize<Rooms>();
                    string filePath = deserializer.filePath;
                    
                    textView.LoadFile(filePath);
                    
                    saveButton.Clicked += () =>
                    {
                        try
                        {
                            string content = textView.Text.ToString();
                
                            if (content != null)
                            {
                                File.WriteAllText(filePath, content);
                                MessageBox.Query("Opgeslagen", "Bestand succesvol opgeslagen!", "OK");
                                Remove(textView);
                                Remove(saveButton);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.ErrorQuery("Fout", $"Kon niet opslaan: {ex.Message}", "OK");
                        }
                    };
                    break;
                }
                case 2:
                {
                    var dialog = new Dialog("", 60, 8);

                    var label = new Label("Benodigde Capaciteit:") { X = 1, Y = 1 };
                    var input = new TextField("") { X = 1, Y = 2, Width = Dim.Fill() };

                    var ok = new Button("OK") { X = 1, Y = 4 };
                    ok.Clicked += () =>
                    {
                        if (int.TryParse(input.Text.ToString(), out int parsedCapacity) && parsedCapacity > 0)
                        {
                            MessageBox.ErrorQuery("", $"Ruimte(s) beschikbaar: " +
                                                      $"{ActionRoomsHandler.HandleSearchRoom
                                                          (parsedCapacity)}", "OK");
                            Application.RequestStop();
                        }
                        else
                        {
                            MessageBox.ErrorQuery("Fout", "Voer een geldig getal in", "OK");
                        }
                    };
                    
                    dialog.Add(label, input, ok);
                    

                    Application.Run(dialog);
                    break;
                }
                case 3:
                {
                    MessageBox.Query("Aanwezige Personen in CHE", 
                        ActionRoomsHandler.HandleAmountPeoplePresent(), "OK");
                    break;
                }
                case 4:
                {
                    MessageBox.Query("Bezettingsgraad gebouwen", 
                        ActionRoomsHandler.HandleBuildingsOccupance(), "OK");
                    break;
                }
                case 5:
                {
                    Application.RequestStop();
                    break;
                }
            }
        };

        Add(listView);
    }
}