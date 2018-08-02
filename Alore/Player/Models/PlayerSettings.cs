namespace Alore.Player.Models
{
    using Alore.API.Player.Models;
    using System.Data.Common;

    internal class PlayerSettings : IPlayerSettings
    {
        internal PlayerSettings(DbDataReader reader)
        {
            NaviX = (int)reader["navi_x"];
            NaviY = (int)reader["navi_y"];
            NaviWidth = (int)reader["navi_width"];
            NaviHeight = (int)reader["navi_height"];
            NaviHideSearches = (bool)reader["navi_hide_searches"];
        }
        
        public int NaviX { get; set; }
        public int NaviY { get; set; }
        public int NaviWidth { get; set; }
        public int NaviHeight { get; set; }
        public bool NaviHideSearches { get; set; }
    }
}
