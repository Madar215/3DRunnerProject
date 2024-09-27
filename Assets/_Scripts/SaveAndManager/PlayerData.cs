
namespace _Scripts.SaveAndManager
{
    public class PlayerData
    {
        public string Name;
        public int Score;
        public ControlSchemeE ControlScheme;

        public PlayerData(string name, int score, ControlSchemeE controlScheme)
        {
            Name = name;
            Score = score;
            ControlScheme = controlScheme;
        }
    }
    
    public enum ControlSchemeE
    {
        Touch,
        Button,
    }
}
