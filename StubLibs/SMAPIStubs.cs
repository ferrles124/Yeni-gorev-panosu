using System;

namespace StardewModdingAPI {
    public enum SButton {
        MouseLeft, MouseRight, ControllerA,
        LeftAlt, RightAlt, LeftControl, RightControl, LeftShift, RightShift
    }
    public abstract class Mod {
        public IModHelper Helper { get; set; }
        public IMonitor Monitor { get; set; }
        public IManifest ModManifest { get; set; }
        public abstract void Entry(IModHelper helper);
        public virtual object GetApi() => null;
    }
    public interface IModHelper {
        IModEvents Events { get; }
        IGameContentHelper GameContent { get; }
        IDataHelper Data { get; }
        ITranslationHelper Translation { get; }
        IModRegistry ModRegistry { get; }
        T ReadConfig<T>() where T : class, new();
        void WriteConfig<T>(T config) where T : class, new();
    }
    public interface ITranslationHelper {
        Translation Get(string key, object tokens = null);
    }
    public class Translation {
        public bool HasValue() => false;
        public override string ToString() => "";
        public static implicit operator string(Translation t) => t?.ToString() ?? "";
    }
    public interface IModRegistry {
        T GetApi<T>(string uniqueId) where T : class;
        bool IsLoaded(string uniqueId);
    }
    public static class Context {
        public static bool IsWorldReady { get; set; }
        public static bool IsPlayerFree { get; set; }
        public static bool IsMainPlayer { get; set; }
    }
    public static class Constants {
        public static string CurrentSavePath => "";
        public static string SavesPath => "";
    }
    public interface IMonitor { void Log(string message, LogLevel level = 0); }
    public interface IManifest { string UniqueID { get; } }
    public interface IModEvents {
        Events.IGameLoopEvents GameLoop { get; }
        Events.IInputEvents Input { get; }
        Events.IPlayerEvents Player { get; }
        Events.IContentEvents Content { get; }
    }
    public interface IGameContentHelper {
        T Load<T>(string assetName);
        void InvalidateCache(string assetName);
    }
    public interface IDataHelper {
        T ReadJsonFile<T>(string path) where T : class;
        void WriteJsonFile<T>(string path, T data);
        T ReadSaveData<T>(string key) where T : class;
        void WriteSaveData<T>(string key, T data);
    }
    public enum LogLevel { Trace, Debug, Info, Warn, Error, Alert }
    public static class SButtonExtensions {
        public static bool IsActionButton(this SButton button) => true;
    }
    public interface IKeyboardSubscriber {
        void RecieveTextInput(char inputChar);
        void RecieveTextInput(string text);
        void RecieveCommandInput(char command);
        void RecieveSpecialInput(Microsoft.Xna.Framework.Input.Keys key);
        bool Selected { get; set; }
    }
    public class KeybindList {
        public static KeybindList Parse(string s) => new KeybindList();
        public override string ToString() => "";
    }
}

namespace StardewModdingAPI.Utilities {
    public class PerScreen<T> {
        public T Value { get; set; }
        public PerScreen() { }
        public PerScreen(Func<T> init) { Value = init(); }
    }
}

namespace StardewModdingAPI.Events {
    public interface IGameLoopEvents {
        event EventHandler<GameLaunchedEventArgs> GameLaunched;
        event EventHandler<UpdateTickedEventArgs> UpdateTicked;
        event EventHandler<SavingEventArgs> Saving;
    }
    public interface IInputEvents {
        event EventHandler<ButtonPressedEventArgs> ButtonPressed;
    }
    public interface IPlayerEvents { }
    public interface IContentEvents {
        event EventHandler<AssetsInvalidatedEventArgs> AssetsInvalidated;
        event EventHandler<AssetRequestedEventArgs> AssetRequested;
    }
    public class GameLaunchedEventArgs : EventArgs { }
    public class UpdateTickedEventArgs : EventArgs { }
    public class SavingEventArgs : EventArgs { }
    public class AssetsInvalidatedEventArgs : EventArgs {
        public System.Collections.Generic.IReadOnlySet<IAssetName> Names { get; }
    }
    public class AssetRequestedEventArgs : EventArgs {
        public IAssetName Name { get; }
        public void LoadFrom<T>(Func<T> load, AssetLoadPriority priority) { }
        public void Edit<T>(Action<IAssetData<T>> apply) { }
    }
    public interface IAssetName {
        string Name { get; }
        bool IsEquivalentTo(string assetName);
    }
    public interface IAssetData<T> {
        T Data { get; set; }
    }
    public enum AssetLoadPriority { Low, Medium, High, Exclusive }
    public class ButtonPressedEventArgs : EventArgs {
        public ICursorPosition Cursor { get; set; }
        public StardewModdingAPI.SButton Button { get; set; }
    }
    public interface ICursorPosition {
        Microsoft.Xna.Framework.Vector2 GrabTile { get; }
        Microsoft.Xna.Framework.Vector2 ScreenPixels { get; }
    }
}
