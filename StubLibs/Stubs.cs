using System;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework {
    public class GameTime {
        public TimeSpan TotalGameTime;
        public TimeSpan ElapsedGameTime;
    }
    public struct Vector2 {
        public float X, Y;
        public Vector2(float x, float y) { X = x; Y = y; }
        public static Vector2 Zero = new Vector2(0, 0);
        public static float Distance(Vector2 a, Vector2 b) => 0f;
        public static bool operator ==(Vector2 a, Vector2 b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Vector2 a, Vector2 b) => !(a == b);
        public override bool Equals(object obj) => obj is Vector2 other && this == other;
        public override int GetHashCode() => (X, Y).GetHashCode();
    }
    public struct Color {
        public static Color White;
        public static Color Black;
        public static Color Gray;
        public static Color Red;
        public Color(int r, int g, int b, int a = 255) { }
        public static Color operator *(Color c, float f) => c;
    }
    public struct Rectangle {
        public int X, Y, Width, Height;
        public int Bottom => Y + Height;
        public Rectangle(int x, int y, int w, int h) { X=x; Y=y; Width=w; Height=h; }
        public bool Contains(int x, int y) => false;
        public bool Contains(Point p) => false;
        public static Rectangle Empty = new Rectangle();
    }
    public struct Point {
        public int X, Y;
        public Point(int x, int y) { X = x; Y = y; }
    }
}

namespace Microsoft.Xna.Framework.Graphics {
    public class Texture2D {
        public int Width; public int Height;
        public Texture2D(GraphicsDevice device, int w, int h) { }
        public void SetData<T>(T[] data) { }
    }
    public class SpriteFont { public Microsoft.Xna.Framework.Vector2 MeasureString(string s) => new(); }
    public class SpriteBatch {
        public void Draw(Texture2D t, Microsoft.Xna.Framework.Rectangle r, Microsoft.Xna.Framework.Color c) { }
        public void Draw(Texture2D t, Microsoft.Xna.Framework.Vector2 pos, Microsoft.Xna.Framework.Rectangle? sourceRect, Microsoft.Xna.Framework.Color c, float rotation, Microsoft.Xna.Framework.Vector2 origin, float scale, SpriteEffects effects, float depth) { }
        public void DrawString(SpriteFont f, string s, Microsoft.Xna.Framework.Vector2 pos, Microsoft.Xna.Framework.Color c) { }
        public void Begin() { }
        public void End() { }
    }
    public class GraphicsDevice {
        public Viewport Viewport;
        public RenderTargetBinding[] GetRenderTargets() => new RenderTargetBinding[0];
        public void SetRenderTarget(RenderTarget2D target) { }
    }
    public struct RenderTargetBinding { }
    public struct Viewport {
        public Microsoft.Xna.Framework.Rectangle Bounds;
        public int Width, Height;
    }
    public class RenderTarget2D : Texture2D {
        public RenderTarget2D(GraphicsDevice device, int w, int h) : base(device, w, h) { }
    }
    public enum SpriteEffects { None }
}

namespace Microsoft.Xna.Framework.Input {
    public struct KeyboardState {
        public bool IsKeyDown(Keys key) => false;
    }
    public enum Keys { Enter, Escape, Back, Tab, A, C, V, X, Z, Y, Left, Right, Home, End, Delete, LeftControl, RightControl, LeftShift, RightShift }
}

namespace Microsoft.Xna.Framework.Content {
    public class ContentManager {
        public IServiceProvider ServiceProvider => null;
        public string RootDirectory { get; set; }
        public ContentManager() { }
        public ContentManager(IServiceProvider serviceProvider, string rootDirectory) { RootDirectory = rootDirectory; }
        public T Load<T>(string assetName) => default;
    }
}

namespace StardewValley {
    public enum Season { Spring, Summer, Fall, Winter }
    public enum Gender { Male, Female, Undefined }
    public class WorldDate {
        public int Year; public string Season; public int DayOfMonth;
        public int TotalDays => 0;
        public WorldDate(int year, string season, int day) { }
        public WorldDate() { }
    }
    public class LocalizedContentManager : Microsoft.Xna.Framework.Content.ContentManager {
        public enum LanguageCode { en, de, es, fr, hu, it, ja, ko, pt, ru, tr, zh, th }
        public new T LoadLocalized<T>(string assetName) => default;
        public string LoadString(string path) => "";
        public string LoadString(string path, params object[] args) => "";
    }
    public static class Utility {
        public static string getDateString() => "";
        public static string getSeasonNameFromNumber(int number) => "";
        public static int getSeasonNumber(string season) => 0;
    }
    public class DialogueLine {
        public string Text;
        public DialogueLine(string text) { Text = text; }
    }
    public class Response {
        public string responseKey, responseText;
        public Response(string key, string text) { responseKey = key; responseText = text; }
    }
    public class MarriageDialogueReference {
        public MarriageDialogueReference(string file, string key, bool gendered = false, params string[] args) { }
        public Dialogue GetDialogue(NPC n) => null;
    }
    public class Friendship {
        public int Points;
        public int DaysMarried;
        public bool IsMarried() => false;
        public bool IsDating() => false;
        public bool IsEngaged() => false;
        public bool IsRoommate() => false;
    }
    public class Crop { public string indexOfHarvest; }
    public class FarmAnimal { public string displayName; public string type; }
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue> { }
    public class Options { public bool hardwareCursor; }
    public class InputState {
        public Microsoft.Xna.Framework.Input.KeyboardState GetKeyboardState() => new();
    }
    public class KeyboardDispatcher {
        public object Subscriber { get; set; }
    }
    public static class ArgUtility {
        public static string Get(string[] arr, int index, string defaultVal = "") => defaultVal;
        public static int GetInt(string[] arr, int index, int defaultVal = 0) => defaultVal;
        public static bool GetBool(string[] arr, int index, bool defaultVal = false) => defaultVal;
        public static string[] SplitBySpace(string s) => s?.Split(' ') ?? new string[0];
    }
    public class Game1 {
        public static Farmer player;
        public static List<GameLocation> locations = new List<GameLocation>();
        public static GameLocation currentLocation;
        public static string currentSeason;
        public static string season;
        public static int year = 1;
        public static int dayOfMonth = 1;
        public static int timeOfDay = 600;
        public static int pixelZoom = 4;
        public static WorldDate Date = new WorldDate();
        public static Microsoft.Xna.Framework.Graphics.SpriteFont dialogueFont;
        public static Microsoft.Xna.Framework.Graphics.SpriteFont smallFont;
        public static Microsoft.Xna.Framework.Graphics.Texture2D mouseCursors;
        public static Microsoft.Xna.Framework.Graphics.Texture2D fadeToBlackRect;
        public static Microsoft.Xna.Framework.Graphics.Texture2D staminaRect;
        public static Microsoft.Xna.Framework.Graphics.GraphicsDevice graphics = new Microsoft.Xna.Framework.Graphics.GraphicsDevice();
        public static Options options = new Options();
        public static InputState input = new InputState();
        public static Microsoft.Xna.Framework.Input.KeyboardState oldKBState;
        public static Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch;
        public static Menus.IClickableMenu activeClickableMenu;
        public static Microsoft.Xna.Framework.Color textColor;
        public static LocalizedContentManager content = new LocalizedContentManager();
        public static Dictionary<string, GameData.CharacterData> characterData = new Dictionary<string, GameData.CharacterData>();
        public static Dictionary<string, string> NPCGiftTastes = new Dictionary<string, string>();
        public static Dictionary<string, GameData.Objects.ObjectData> objectData = new Dictionary<string, GameData.Objects.ObjectData>();
        public static xna.Viewport uiViewport;
        public static KeyboardDispatcher keyboardDispatcher = new KeyboardDispatcher();
        public static Random random = new Random();
        public static void drawDialogue(NPC n) { }
        public static void DrawDialogue(NPC n) { }
        public static void drawDialogueBox(int x, int y, int w, int h, bool speaker, bool drawOnlyBox) { }
        public static void exitActiveMenu() { }
        public static void playSound(string sound) { }
        public static int getMouseX() => 0;
        public static int getMouseY() => 0;
        public static Microsoft.Xna.Framework.Rectangle getSourceRectForStandardTileSheet(Microsoft.Xna.Framework.Graphics.Texture2D sheet, int whichTile, int w = -1, int h = -1) => new Microsoft.Xna.Framework.Rectangle();
        public static NPC getCharacterFromName(string name) => null;
        public static Farmer getPlayerOrEventFarmer() => player;
        public static bool IsRainingHere(GameLocation location = null) => false;
        public static bool IsSnowingHere(GameLocation location = null) => false;
        public static bool IsLightningHere(GameLocation location = null) => false;
        public static bool IsGreenRainingHere(GameLocation location = null) => false;
    }
    public class Farmer {
        public string Name;
        public GameLocation currentLocation;
        public Gender gender;
        public Dictionary<string, Friendship> friendshipData = new Dictionary<string, Friendship>();
        public List<Characters.Child> getChildren() => new List<Characters.Child>();
        public int getFriendshipHeartLevelForNPC(string name) => 0;
    }
    public class GameLocation {
        public string Name;
        public List<NPC> characters = new List<NPC>();
        public virtual Dialogue GetLocationOverrideDialogue(NPC n) => null;
    }
    public class NPC : Character {
        public string Name;
        public string displayName;
        public Dialogue CurrentDialogue;
        public Dictionary<string, string> Dialogue = new Dictionary<string, string>();
        public Gender gender;
        public Gender Gender;
        public int Age;
        public Microsoft.Xna.Framework.Vector2 Tile;
        public GameLocation currentLocation;
        public bool CanReceiveGifts() => true;
        public GameData.CharacterData GetData() => null;
        public void setNewDialogue(string text, bool add = false, bool clear = false) { }
        public Microsoft.Xna.Framework.Vector2 getTileLocation() => new Microsoft.Xna.Framework.Vector2();
        public virtual void checkAction(Farmer f, GameLocation l) { }
        public virtual void addMarriageDialogue(string file, string key, bool gendered = false, params string[] args) { }
        public virtual void PushTemporaryDialogue(Dialogue d) { }
        public virtual Dialogue TryGetDialogue(string key) => null;
        public virtual Dialogue TryToRetrieveDialogue(string key) => null;
        public virtual Dialogue tryToRetrieveDialogue(string key) => null;
        public virtual Dialogue TryToGetMarriageSpecificDialogue(string key) => null;
        public virtual Dialogue tryToGetMarriageSpecificDialogue(string key) => null;
        public virtual void CheckForNewCurrentDialogue(int hearts, bool onlyCheck = false) { }
        public virtual void checkForNewCurrentDialogue(int hearts, bool onlyCheck = false) { }
        public virtual string GetGiftReaction(Object gift) => "";
        public bool isMarried() => false;
        public bool isDivorcedFrom(Farmer f) => false;
        public string getTermOfSpousalEndearment() => "";
        public void grantConversationFriendship(Farmer f, int amount = 20) { }
    }
    public class Character { }
    public class Item { }
    public class Object : Item { public string Name; public string Category; public string DisplayName; }
    public class Dialogue {
        public Dialogue(NPC speaker, string dialogueText) { }
        public Dialogue(NPC speaker, string file, string key) { }
        public NPC speaker;
        public Stack<string> dialogues = new Stack<string>();
        public void Clear() { }
        public void Push(string text) { }
        public bool TryPop(out string result) { result = ""; return false; }
        public virtual string chooseResponse(List<Response> responses) => "";
        public virtual Dialogue TryGetDialogue(string key) => null;
    }
}

namespace xna {
    public struct Viewport { public int Width, Height; }
}

namespace xTile.Display {
    public interface IDisplayDevice { }
}

namespace StardewValley.Events {
    public class SavingEventArgs : EventArgs { }
}

namespace StardewValley.Menus {
    public class IClickableMenu {
        public virtual void draw(Microsoft.Xna.Framework.Graphics.SpriteBatch b) { }
        public virtual void receiveLeftClick(int x, int y, bool playSound = true) { }
        public virtual void receiveRightClick(int x, int y, bool playSound = true) { }
        public virtual void receiveKeyPress(Microsoft.Xna.Framework.Input.Keys key) { }
        public virtual void update(Microsoft.Xna.Framework.GameTime time) { }
        public virtual void gameWindowSizeChanged(Microsoft.Xna.Framework.Rectangle oldBounds, Microsoft.Xna.Framework.Rectangle newBounds) { }
        public virtual void emergencyShutDown() { }
        protected virtual void cleanupBeforeExit() { }
        public virtual bool overrideSnappyMenuCursorMovementBan() => false;
        public bool destroy;
        public int xPositionOnScreen, yPositionOnScreen, width, height;
        public static void drawTextureBox(Microsoft.Xna.Framework.Graphics.SpriteBatch b, int x, int y, int w, int h, Microsoft.Xna.Framework.Color c) { }
    }
    public class ClickableTextureComponent {
        public Microsoft.Xna.Framework.Rectangle bounds;
        public bool visible = true;
        public string name;
        public string hoverText;
        public ClickableTextureComponent(Microsoft.Xna.Framework.Rectangle bounds, Microsoft.Xna.Framework.Graphics.Texture2D texture, Microsoft.Xna.Framework.Rectangle sourceRect, float scale, bool drawShadow = false) { this.bounds = bounds; }
        public ClickableTextureComponent(string name, Microsoft.Xna.Framework.Rectangle bounds, string label, string hoverText, Microsoft.Xna.Framework.Graphics.Texture2D texture, Microsoft.Xna.Framework.Rectangle sourceRect, float scale, bool drawShadow = false) { this.name = name; this.bounds = bounds; }
        public void draw(Microsoft.Xna.Framework.Graphics.SpriteBatch b) { }
        public bool containsPoint(int x, int y) => false;
    }
    public class DialogueBox : IClickableMenu, IDisposable {
        public DialogueBox(StardewValley.Dialogue dialogue) { }
        public void Dispose() { }
    }
    public class ConfirmationDialog : IClickableMenu {
        public ConfirmationDialog(string message, Action<StardewValley.Farmer> onConfirm, Action<StardewValley.Farmer> onCancel = null) { }
    }
}

namespace StardewValley.Network {
    public class NetCollection<T> : List<T> { }
}

namespace StardewValley.Characters {
    public class Child : StardewValley.NPC {
        public StardewValley.Gender Gender;
    }
}

namespace StardewValley.GameData {
    public class CharacterData {
        public string DisplayName;
        public string Age;
        public string Gender;
        public string HomeRegion;
        public string BirthSeason;
        public int BirthDay;
        public List<string> FestivalAvailability = new List<string>();
    }
}

namespace StardewValley.GameData.Objects {
    public class ObjectData { public string Name; public string Description; public string DisplayName; }
}

namespace StardewValley.GameData.HomeRenovations {
    public class HomeRenovation { }
}

namespace StardewValley.GameData.Characters {
    public class CharacterData { }
}

namespace StardewValley.Objects {
    public class Hat : StardewValley.Object { }
    public class Trinket : StardewValley.Object { }
}

namespace StardewValley.Objects.Trinkets {
    public class Trinket : StardewValley.Object { }
}

namespace StardewValley.Buildings {
    public class Building { public string buildingType; }
}
