
using System;
using System.Collections.Generic;
using System.Text;
namespace Web.UI.baby
{
    /// <summary>
    /// 身高
    /// </summary>
    public class height
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="monthage"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public static string View(string monthage, string sex)
        {
            DAL.baby.height hDAL = new DAL.baby.height();
            return hDAL.View(UI.Sys.SiteInfo.GetPageSize(), monthage, sex);
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public static string ViewChart(string weight)
        {
            StringBuilder strXml = new StringBuilder();
            StringBuilder Dstr = new StringBuilder();
            StringBuilder str1 = new StringBuilder();
            StringBuilder str2 = new StringBuilder();
            DAL.baby.height hDAL = new DAL.baby.height();
            List<Model.baby.height> hList = hDAL.ReadList();
            if (hList.Count > 0)
            {
                str1.Append("<dataset seriesName='最小值' color='1D8BD1' anchorBorderColor='1D8BD1' anchorBgColor='1D8BD1'>");
                str2.Append("<dataset seriesName='最大值' color='F1683C' anchorBorderColor='F1683C' anchorBgColor='F1683C'>");
                Dstr.Append("<categories>");
                double minnum = 1000000;
                double maxnum = 0;
                foreach (Model.baby.height h in hList)
                {
                    if (h.sex.Equals(weight))
                    {
                        Dstr.Append("<category name='" + h.monthage + "月' />");
                        str1.Append("<set value='" + h.minnum + "'/>");
                        str2.Append("<set value='" + h.maxnum + "'/>");
                        if (double.Parse(h.maxnum) > maxnum)
                        {
                            maxnum = double.Parse(h.maxnum);
                        }
                        if (double.Parse(h.minnum) < minnum)
                        {
                            minnum = double.Parse(h.minnum);
                        }
                    }
                }
                str2.Append("</dataset>");
                str1.Append("</dataset>");
                Dstr.Append("</categories>");
                strXml.Append("<graph lineThickness='0' canvasBorderThickness='0' baseFontSize='12' alternateHGridAlpha='5' canvasBorderColor='666666' divLineColor='ff5904' divLineAlpha='20' showAlternateHGridColor='1' AlternateHGridColor='ff5904' hovercapbg='FFECAA' hovercapborder='F47E00' formatNumberScale='0' decimalPrecision='0' decimals='2' numberSuffix='cm' showvalues='0' numdivlines='4' yAxisMinValue='" + minnum.ToString().Split('.')[0] + "' yAxisMaxValue='" + Math.Ceiling(maxnum) + "' numVdivlines='0' rotateNames='0'>");
                strXml.Append(Dstr.ToString() + str1.ToString() + str2.ToString() + "</graph>");
            }
            return strXml.ToString();
        }
    }
}
