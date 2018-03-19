namespace Alore.API.Player.Models
{
    public interface IPlayerSettings
    {
        /// <summary>
        /// The prefered X coordinate for the navigator.
        /// </summary>
        int NaviX { get; set; }

        /// <summary>
        /// The prefered Y coordinate for the navigator.
        /// </summary>
        int NaviY { get; set; }

        /// <summary>
        /// The prefered width for the navigator.
        /// </summary>
        int NaviWidth { get; set; }

        /// <summary>
        /// The prefered height for the navigator.
        /// </summary>
        int NaviHeight { get; set; }

        /// <summary>
        /// Wether or not you want to show the saved searches by default.
        /// </summary>
        bool NaviHideSearches { get; set; }
    }
}
