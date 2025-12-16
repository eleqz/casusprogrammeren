using casusprogrammeren.Services.Handlers;
using casusprogrammeren.utils;
using Terminal.Gui;

namespace casusprogrammeren.Services.Tui;

public class RoomsWindow : Window
{
    private int days;

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
                    var dialog = new Dialog("", 60, 8);

                    var label = new Label("Benodigde Capaciteit:") { X = 1, Y = 1 };
                    var input = new TextField("") { X = 1, Y = 2, Width = Dim.Fill() };

                    string result;

                    var ok = new Button("OK") { IsDefault = true };
                    ok.Clicked += () =>
                    {
                        result = input.Text.ToString();
                        MessageBox.ErrorQuery("", $"Ruimte(s) beschikbaar: " +
                                                      $"{ActionRoomsHandler.HandleSearchRoom
                                                          (Convert.ToInt16(result))}", "OK");
                        
                        Application.RequestStop();
                    };

                    var cancel = new Button("Cancel");
                    cancel.Clicked += () =>
                    {
                        result = null;
                        Application.RequestStop();
                    };

                    dialog.Add(label, input);
                    dialog.AddButton(ok);
                    dialog.AddButton(cancel);

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