namespace Alore.Player.Models
{
    using Alore.API.Player.Models;
    using Alore.API.Sql;
    using System.Data.Common;

    internal class PlayerSettings : IPlayerSettings
    {
        internal PlayerSettings(DbDataReader reader)
        {
            NaviX = reader.Read<int>("navi_x");
            NaviY = reader.Read<int>("navi_y");
            NaviWidth = reader.Read<int>("navi_width");
            NaviHeight = reader.Read<int>("navi_height");
            NaviHideSearches = reader.Read<bool>("navi_hide_searches");
        }
        
        public int NaviX { get; set; }
        public int NaviY { get; set; }
        public int NaviWidth { get; set; }
        public int NaviHeight { get; set; }
        public bool NaviHideSearches { get; set; }
    }
}
