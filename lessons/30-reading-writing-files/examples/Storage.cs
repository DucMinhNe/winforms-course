using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HelloForms;

// Saves/loads a list as JSON under %AppData%\WinFormsCourse\.
public class Storage
{
    private static readonly string Dir =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WinFormsCourse");

    private static readonly string FilePath = Path.Combine(Dir, "todos.json");

    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public void Save(List<Todo> todos)
    {
        try
        {
            Directory.CreateDirectory(Dir);                 // ensure the folder exists
            File.WriteAllText(FilePath, JsonSerializer.Serialize(todos, Options));
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            // surface this to the user in the form (MessageBox), don't crash
            throw;
        }
    }

    public List<Todo> Load()
    {
        if (!File.Exists(FilePath)) return new List<Todo>();
        try
        {
            return JsonSerializer.Deserialize<List<Todo>>(File.ReadAllText(FilePath)) ?? new();
        }
        catch (Exception ex) when (ex is IOException or JsonException)
        {
            return new List<Todo>();   // corrupt/missing → start fresh
        }
    }
}
