namespace Alore.Player.Models
{
    using Alore.API.Player.Models;
    using Alore.API.Sql;

    public class PlayerSettings : AloreModel, IPlayerSettings
    {
        [AloreColumn("navi_x")]
        public int NaviX { get; set; }

        [AloreColumn("navi_y")]
        public int NaviY { get; set; }

        [AloreColumn("navi_width")]
        public int NaviWidth { get; set; }

        [AloreColumn("navi_height")]
        public int NaviHeight { get; set; }

        [AloreColumn("navi_hide_searches")]
        public bool NaviHideSearches { get; set; }
    }
}
