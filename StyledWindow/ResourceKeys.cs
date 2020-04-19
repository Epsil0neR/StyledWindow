namespace StyledWindow
{
    public class ResourceKeys
    {
        public static class Brushes
        {
            public static string Background { get; } = "Epsiloner.Brushes.Background";
            public static string Highlight { get; } = "Epsiloner.Brushes.Highlight";

            /// <summary>
            /// Brush used for highlight active elements (window itself, action buttons)
            /// </summary>
            public static string Active { get; } = "Epsiloner.Brushes.Active";
            public static string Critical { get; } = "Epsiloner.Brushes.Critical";
            public static string Foreground { get; } = "Epsiloner.Brushes.Foreground";
        }

        public static class Colors
        {
            public static string Background { get; } = "Epsiloner.Colors.Background";
            public static string Highlight { get; } = "Epsiloner.Colors.Highlight";
            public static string Active { get; } = "Epsiloner.Colors.Active";
            public static string Critical { get; } = "Epsiloner.Colors.Critical";
            public static string Foreground { get; } = "Epsiloner.Colors.Foreground";
        }

        /// <summary>
        /// Brush used for title bar.
        /// </summary>
        public static string TitleBackgroundKey { get; } = "WindowStyle.TitleBackground";

        public static string WindowStyleKey { get; } = "Epsiloner.Styles.Window";

    }
}
