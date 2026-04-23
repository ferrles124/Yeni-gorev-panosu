using StardewValley;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using Microsoft.Xna.Framework;

namespace LuuaGorevPanosu
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += OnButtonPressed;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            if (e.Button.IsActionButton())
            {
                Vector2 tile = e.Cursor.GrabTile;
                GameLocation location = Game1.currentLocation;

                if (location.Name == "Town" && tile.X == 11 && tile.Y == 23)
                {
                    Game1.drawDialogueBox(0, 0, 800, 200, false, true, "Buraya yakinda gorevler eklenecek!", null, false);
                }
            }
        }
    }
}
