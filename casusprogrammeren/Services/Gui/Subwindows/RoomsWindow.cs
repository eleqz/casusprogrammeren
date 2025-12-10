using casusprogrammeren.Services.Handlers;
using casusprogrammeren.utils;
using Terminal.Gui;

namespace casusprogrammeren.Services.Tui;

public class RoomsWindow : Window {

    public RoomsWindow ()
    {
        Title = "Beheerders Applicatie - Ruimtes";
        
        var items = new List<string>
        {
            "Zie Ruimtes", 
            "Voeg ruimtes toe", 
            "Reserveer een ruimte", 
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
                    var deserializer = new DeserializeFromFile();
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
                    /*MessageBox.Query("Action", ActionRoomsHandler.HandlePseudoCode(), "OK");*/
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