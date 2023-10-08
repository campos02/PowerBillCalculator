using System;
using System.IO;
using System.Text.Json;

namespace ConsumptionCalculator.Models;

public class SettingsManager
{
    public static string FileName => "settings.json";
    public static string FileDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Power Bill Calculator");
    public static string FilePath => Path.Combine(FileDirectory, FileName);

    // Default settings, static so as they change for all objects when modified
    public static Settings Settings { get; set; } = new Settings()
    {
        EnergyCost = 0,
        Taxes = 0
    };

    public SettingsManager() 
    {
        ReadFile();
    }

    /// <summary>
    /// Create file and directory if they don't exist and save serialized settings
    /// </summary>
    public void SaveToFile()
    {
        if (!Directory.Exists(FileDirectory))
            Directory.CreateDirectory(FileDirectory);

        var options = new JsonSerializerOptions() { WriteIndented = true };
        File.WriteAllText(FilePath, JsonSerializer.Serialize(Settings, options));
    }

    /// <summary>
    /// Read file, if it exists, and assign deserialized settings
    /// </summary>
    public void ReadFile()
    {
        if (!File.Exists(FilePath))
            return;

        var json = File.ReadAllText(FilePath);
        Settings = JsonSerializer.Deserialize<Settings>(json) ?? Settings;
    }
}
