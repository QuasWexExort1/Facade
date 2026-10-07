using GameEngine.Subsystems;

namespace GameEngine.Facades;

public class GameFacade
{
    private readonly GraphicsSystem _graphics = new();
    private readonly AudioSystem _audio = new();
    private readonly InputSystem _input = new();
    private readonly SaveSystem _save = new();
    private readonly PlayerSystem _player = new();
    private readonly InventorySystem _inventory = new();
    private readonly QuestSystem _quest = new();
    private readonly NetworkSystem _network = new();

    public void StartGame()
    {
        Console.WriteLine("ЗАПУСК СУЩЕСТВУЮЩЕЙ ИГРЫ");
        _graphics.Initialize();
        _audio.Initialize();
        _input.Initialize();
        _inventory.Initialize();
        _quest.Initialize();
        _network.Connect();
        _save.Load();
        _player.Create();
        _player.Spawn();
        Console.WriteLine("-> Игра успешно запущена!");
    }


    public void StartNewGame()
    {
        Console.WriteLine("ЗАПУСК НОВОЙ ИГРЫ");
        _graphics.Initialize();
        _audio.Initialize();
        _input.Initialize();
        _inventory.Initialize();
        _quest.Initialize();
        _network.Connect();

        _save.ClearCurrentSave(); 
        _inventory.Reset();     
        _quest.Reset();           

        _player.Create();
        _player.Spawn();
        Console.WriteLine("-> Новая игра успешно создана и запущена!");
    }

    public void LoadGame()
    {
        Console.WriteLine("ПЕРЕЗАГРУЗКА ИЗ СОХРАНЕНИЯ");
        _input.Disable();
        _save.Load();
        _player.Spawn();
        _input.Enable();
        Console.WriteLine("-> Сохранение успешно загружено!");
    }

    public void PauseGame()
    {
        Console.WriteLine("ПАУЗА ИГРЫ");
        _input.Disable();
        _audio.Mute();
        _graphics.Freeze();
        _player.Freeze();
        Console.WriteLine("-> Игра поставлена на паузу.");
    }

    public void SaveGame()
    {
        Console.WriteLine("СОХРАНЕНИЕ ПРОГРЕССА");
        _save.Save();
    }

    public void ExitGame()
    {
        Console.WriteLine("ВЫХОД ИЗ ИГРЫ");
        _save.Save();
        _player.Freeze();
        _input.Shutdown();
        _audio.Shutdown();
        _graphics.Shutdown();
        _network.Disconnect();
        Console.WriteLine("-> Работа приложения завершена. До встречи!");
    }
}
