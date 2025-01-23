using UnityEngine;

namespace FreschGames.Core
{
    public static class GameTime
    {
        public static float GameSpeed { get; set; } = 1;
        public static float DeltaTime { get => Time.deltaTime * GameTime.GameSpeed; }
    }
}