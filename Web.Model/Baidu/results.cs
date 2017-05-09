using System.Collections.Generic;

namespace Web.Model.Baidu
{
    public class results
    {
        /// <summary>
        /// 区县名称
        /// </summary>
        public string currentCity = "";
        /// <summary>
        /// pm25
        /// </summary>
        public string pm25 = "";
        /// <summary>
        /// mode
        /// </summary>
        public List<index> index = new List<index>();
        /// <summary>
        /// 天气
        /// </summary>
        public List<weather_data> weather_data = new List<weather_data>();
    }
}
