namespace Code.Gameplay.Windows.Windows.HomeScreen
{
    public static class Extensions
    {
        public static string FinishIn(this float value) =>
            $"Finish in: {value:#}s";

        public static string HoldAmount(this float value) =>
            $"Hold this amount for {value:#}";
    }
}