using UnityEngine;

namespace Mark.Ballinger.GAM405
{
    public static class MarbleConstants
    {
        // Sounds
        public const int CoinSound = 0;
        public const int CollisionSound = 1;
        public const int LoseSound = 2;
        public const int WinSound = 3;

        // Tags / Layers
        public const string CoinTag = "Coin";
        public const string FinishAreaTag = "FinishArea";
        public static string FloorLayer = "Floor";

        // Physics Settings
        public const float IsMarbleGroundedRayDistance = 1f;
        public const float MarbleMaxSpeed = 10f;

        // Tweakable values
        public static Vector3 CoinRotationPerFrame = new Vector3(0, 2f, 0);
        public static float CoinDestroyEndSize = 0.01f;
        public static float CoinDestroyEndDuration = 0.25f;
        public static float MarbleAngularDragAtFinishArea = 5;

        public static int MaxTime = 30;
        public static int PointsPerCoin = 1;

        public static string WinText = "You Win!";
        public static string LoseText = "You Lose!";
    }
}