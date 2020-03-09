using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Acer.Util
{
	/// <summary>
	/// 專門處理日期相關共用方法
	/// </summary>
	public class DateUtil
	{
		/// <summary>
		/// 取得日期和時間的刻度數目
		/// </summary>
		/// <returns>日期和時間的刻度數目</returns>
		public static long GetCurrTimeMillis()
		{
			return DateTime.Now.Ticks / 10000;
		}

		/// <summary>
		/// 取得系統時間到微秒
		/// </summary>
		/// <returns>系統時間 hhmmssmms</returns>
		public static string GetNowTimeMS()
  		{
			return System.DateTime.Now.ToString("HHmmss") + System.DateTime.Now.Millisecond.ToString();
   		}

		/// <summary>
		/// 取得系統日期，格式為西元日期 yyyyMMdd
		/// </summary>
		/// <returns>西元日期 yyyyMMdd</returns>
   		public static string GetNowDate() 
  		{
			return System.DateTime.Now.ToString ("yyyyMMdd");
   		}

		/// <summary>
		/// 將西元日期格式化 yyyyMMdd --> yyyy/MM/dd
		/// </summary>
		/// <param name="dateStr">八碼西元日期 yyyyMMdd</param>
		/// <returns>西元日期 yyyy/MM/dd</returns>
   		public static string FormatDate(string dateStr) 
   		{
      			if (dateStr.Length != 8)
      				return dateStr;
      			else
				return dateStr.Substring(0, 4) + "/" + dateStr.Substring(4, 2) + "/" + dateStr.Substring(6);
   		}

        /// <summary>
		/// 將西元日期格式化 yyyyMMdd hh:mm:ss --> yyyy/MM/dd hh:mm:ss
		/// </summary>
		/// <param name="dateStr">有帶時間的西元日期 yyyyMMdd hh:mm:ss</param>
		/// <returns>西元日期 yyyy/MM/dd</returns>
   		public static string FormatDateDetail(string dateStr)
        {
            if (dateStr.Length > 0)
            {
                //Parsing Type
                bool error = false;
                DateTime tmpDate = new DateTime();
                try
                {
                    //DB格式,ex:2010/6/01 上午 11:11:11
                    tmpDate = DateTime.ParseExact(dateStr, "yyyy/M/dd tt hh:mm:ss", null);
                    error = false;
                }
                catch {
                    error = true;
                }

                if (error) { 
                    try
                    {
                        //DB格式,ex:2010/6/1 上午 11:11:11
                        tmpDate = DateTime.ParseExact(dateStr, "yyyy/M/d tt hh:mm:ss", null);
                        error = false;
                    }
                    catch
                    {
                        error = true;
                    }
                }

                if (error)
                {
                    //一般格式,ex:2010/06/01  14/11/11
                    tmpDate = DateTime.ParseExact(dateStr, "yyyy/MM/dd HH:mm:ss", null);
                }
                
                return tmpDate.ToString("yyyy/MM/dd HH:mm:ss");
            }
            else
                return dateStr;
        }

        /// <summary>
        /// 將西元日期格式化為七碼中文日期 yyyyMMdd(yyyy/MM/dd) --> yyyMMdd
        /// </summary>
        /// <param name="dateStr">西元日期 yyyyMMdd</param>
        /// <returns>七碼中文日期 yyyMMdd</returns>
        public static string ConvertDate(string dateStr) 
   		{
			//=== nono add 判斷若已是西元日期則不處理 ===
			if (dateStr.Length == 9 && IsDate(dateStr))
				return dateStr;

      			if (dateStr.Length < 8)
      				return dateStr;
      			else
      			{
				//=== 將日期 / 拿掉後格式化成有 / 的格式 ===
				string[]	strAry	=	Utility.Split(DateUtil.FormatDate(dateStr.Replace("/", "")), "/");
	      			string		year	=	Convert.ToString(Convert.ToInt32(strAry[0]) - 1911).PadLeft(3, '0');
	      			string		month	=	strAry[1];
	      			string		day	=	strAry[2];

	      			return	year + month + day;
	      		}
   		}

        /// <summary>
		/// 將西元日期格式化為七碼中文日期 加上時分秒hh:mm:ss yyyyMMdd(yyyy/MM/dd) hh:mm:ss --> yyy/MM/dd hh:mm:ss
		/// </summary>
		/// <param name="dateStr">西元日期 yyyyMMdd tt hh:mm:ss</param>
		/// <returns>七碼中文日期 yyy/MM/dd hh:mm:ss</returns>
   		public static string ConvertDateDetail(string dateStr)
        {
            //=== nono add 判斷若已是中華民國日期則不處理 ===
            if (dateStr.Length == 9 && IsDate(dateStr))
                return dateStr;

            if (dateStr.Length < 8)
                return dateStr;
            else
            {
                //=== 將日期 / 拿掉後格式化成有 / 的格式 ===
                string formatedDate = DateUtil.FormatDateDetail(dateStr);
                string year = Convert.ToString(Convert.ToInt32(formatedDate.Substring(0,4)) - 1911).PadLeft(3, '0');
                string month = formatedDate.Substring(5, 2);
                string day = formatedDate.Substring(8, 2);
                string time = formatedDate.Substring(11).Trim();

                return year + "/" +  month +"/"+ day +" "+ time;
            }
        }
               

        /// <summary>
        /// 將西元日期格式化為民國格式日期 yyyyMMdd(yyyy/MM/dd) --> yyy/MM/dd
        /// </summary>
        /// <param name="dateStr">西元日期 yyyyMMdd</param>
        /// <returns>民國格式日期 yyy/MM/dd</returns>
        public static string ConvertFormatDate(string dateStr) 
   		{
			if (string.IsNullOrEmpty(dateStr))
				return "";
			return DateUtil.FormatCDate(DateUtil.ConvertDate(Convert.ToDateTime(dateStr).ToString("yyyy/MM/dd")));
   		}

		/// <summary>
		/// 取得民國系統日期，格式為七碼中文日期 yyyMMdd
		/// </summary>
		/// <returns>七碼中文日期 yyyMMdd</returns>
		public static string GetNowCDate() 
  		{
			return DateUtil.ConvertDate(DateUtil.GetNowDate());
   		}
		
		/// <summary>
		/// 將七碼中文日期格式化為西元日期
		/// </summary>
		/// <param name="dateStr">七碼中文日期 yyyMMdd</param>
		/// <param name="formatType">格式化種類 Exp: yyyy/MM/dd</param>
		/// <returns>格式化後的西元日期</returns>
   		public static string ConvertCDate(string dateStr, string formatType) 
   		{
			if (string.IsNullOrEmpty(dateStr))
				return dateStr;

			//=== nono add 判斷若已是西元日期則不處理 ===
			if (dateStr.Length == 10 && IsDate(dateStr))
				return dateStr;

			dateStr	=	dateStr.Replace("/", "");
			if (dateStr.Length != 7)
				throw new FormatException("中文日期格式錯誤, 必須為 yyymmdd 格式, 目前傳入為: " + dateStr);

      			string	year	=	Convert.ToString(Convert.ToInt32(dateStr.Substring(0, 3)) + 1911);
      			string	month	=	dateStr.Substring(3, 2);
      			string	day	=	dateStr.Substring(5);
			
      			return Convert.ToDateTime(year + "-" + month + "-" + day).ToString(formatType);
   		}
		
		/// <summary>
		/// 取得系統日期時間，格式為西元日期時間
		/// </summary>
		/// <returns>西元日期 yyyy/mm/dd hh:mm</returns>
   		public static string GetNowDateTime() 
  		{
			return DateUtil.FormatDate(GetNowDate()) + " " + FormatTime(GetNowTime());
   		}
		
		/// <summary>
		/// 將時間格式化 hhmm --> hh:mm, hhmmss --> hh:mm:ss
		/// </summary>
		/// <param name="timeStr">四碼或六碼時間 mmss</param>
		/// <returns>mm:ss</returns>
   		public static string FormatTime(string timeStr) 
   		{
			timeStr	=	timeStr.Trim();
      			if (timeStr.Length == 4)
				return timeStr.Substring(0, 2) + ":" + timeStr.Substring(2);
			else if (timeStr.Length == 6)
				return timeStr.Substring(0, 2) + ":" + timeStr.Substring(2, 2) + ":" + timeStr.Substring(4);
			else
				return timeStr;
   		}
		
		/// <summary>
		/// 傳回內容為某個基準日期加上數個時間間隔單位後的日期。
		/// Exp: DateUtil.DateAdd("m", 1, "2003/2/28") --> 2003/3/7
		/// </summary>
		/// <param name="interval">種類 d(日), w(星期), m(月), yyyy(年)</param>
		/// <param name="number">相加的數目</param>
		/// <param name="dateStr">字串型態日期 yyyy/MM/dd or yyyyMMdd</param>
		/// <returns>比較後的日期 yyyy/MM/dd</returns>
		public static string DateAdd(string interval, double number, string dateStr) 
  		{
			DateTime	addDate	=	Microsoft.VisualBasic.DateAndTime.DateAdd(interval, number, Convert.ToDateTime(FormatDate(dateStr)));
			return addDate.ToString("yyyy/MM/dd");
   		}
		
		/// <summary>
		/// 傳回內容為某個基準七碼中文日期加上數個時間間隔單位後的日期。
		/// Exp: DateUtil.CDateAdd("ww", 1, "920228") --> 920307
		/// </summary>
		/// <param name="interval">種類 d(日), w(星期), m(月), yyyy(年)</param>
		/// <param name="number">相加的數目</param>
		/// <param name="dateStr">字串型態日期</param>
		/// <returns>比較後的日期 yyyMMdd</returns>
		public static string CDateAdd(string interval, int number, string dateStr) 
  		{
			return DateUtil.ConvertDate(DateUtil.DateAdd(interval, number, DateUtil.ConvertCDate(dateStr, "yyyy/MM/dd")));
   		}
		
		/// <summary>
		/// 傳回兩個日期間相差的時間間隔單位數目 Exp: DateUtil.DateDiff("d", "2003/5/1", "2003/5/2") --> 1
		/// </summary>
		/// <param name="interval">種類 d(日), w(星期), m(月), yyyy(年)</param>
		/// <param name="dateStr1">字串型態日期一</param>
		/// <param name="dateStr2">字串型態日期二</param>
		/// <returns>比較後的時間差</returns>
   		public static long DateDiff(string interval, string dateStr1, string dateStr2) 
  		{
			return Microsoft.VisualBasic.DateAndTime.DateDiff
				(
					interval, 
					Convert.ToDateTime(FormatDate(dateStr1)), 
					Convert.ToDateTime(FormatDate(dateStr2)), 
					Microsoft.VisualBasic.FirstDayOfWeek.Sunday, 
					Microsoft.VisualBasic.FirstWeekOfYear.Jan1
				);
   		}
		
		/// <summary>
		/// 傳回兩個七碼中文日期間相差的時間間隔單位數目 Exp: DateUtil.CDateDiff("d", "0920501", "0920502") --> 1
		/// </summary>
		/// <param name="interval">種類 d(日), w(星期), m(月), yyyy(年)</param>
		/// <param name="dateStr1">字串型態日期一</param>
		/// <param name="dateStr2">字串型態日期二</param>
		/// <returns>比較後的時間差</returns>
   		public static long CDateDiff(string interval, string dateStr1, string dateStr2) 
  		{
			return DateUtil.DateDiff
				(
					interval, 
					DateUtil.ConvertCDate(dateStr1, "yyyy/MM/dd"), 
					DateUtil.ConvertCDate(dateStr2, "yyyy/MM/dd")
				);
   		}

		/// <summary>
		/// 取得系統時間，格式為 hhmm
		/// </summary>
		/// <returns>hhmm</returns>
   		public static string GetNowTime() 
  		{
			return System.DateTime.Now.ToString("HHmm");
   		}

		/// <summary>
		/// 抓取七碼中文日期的星期
		/// </summary>
		/// <param name="dateStr">七碼中文日期</param>
		/// <returns>一 ~ 日</returns>
		public static string GetCWeek(string dateStr) 
		{
			DateTime	dt	=	Convert.ToDateTime(ConvertCDate(dateStr, "yyyy/MM/dd"));
			string		weekStr	=	"日一二三四五六";
			
			return weekStr.Substring(Convert.ToInt16(dt.DayOfWeek), 1);
		}

		/// <summary>
		/// 將七碼中文日期格式化
		/// </summary>
		/// <param name="dateStr">七碼中文日期</param>
		/// <returns>中文日期 yyy/MM/dd</returns>
		public static string FormatCDate(string dateStr) 
		{
			if (dateStr.Length != 7)
				return dateStr;
			else
				return dateStr.Substring(0, 3) + "/" + dateStr.Substring(3, 2) + "/" + dateStr.Substring(5);
		}
       
        /// <summary>
        /// 將日期格式化為中文日期 Exp: 0920101 --> 九十二年一月一日
        /// </summary>
        /// <param name="dateStr">日期 yyyMMdd</param>
        /// <returns>中文日期</returns>
        public static string FormatCDateForPrint(string dateStr) 
		{
			if (dateStr.Length != 7)
				return dateStr;

			string	yy	=	Utility.GetCNum(Convert.ToInt32(dateStr.Substring(0, 3), 10), 2);
			string	mm	=	Utility.GetCNum(Convert.ToInt32(dateStr.Substring(3, 2), 10), 2);
			string	dd	=	Utility.GetCNum(Convert.ToInt32(dateStr.Substring(5), 10), 2);

			return yy + "年" + mm + "月" + dd + "日";
		}

		/// <summary>
		/// 將日期格式化為西元日期 Exp: 20060101 --> 二ＯＯ六年一月一日
		/// </summary>
		/// <param name="dateStr">日期 yyyyMMdd</param>
		/// <returns>中文日期</returns>
		public static string FormatDateForPrint(string dateStr) 
		{
			if (dateStr.Length < 8)
				return dateStr;

			string	yy	=	Utility.GetCNum(Convert.ToInt32(dateStr.Substring(0, 4)), 3);
			string	mm	=	Utility.GetCNum(Convert.ToInt32(dateStr.Substring(4, 2)), 2);
			string	dd	=	Utility.GetCNum(Convert.ToInt32(dateStr.Substring(6)), 2);

			return yy + "年" + mm + "月" + dd + "日";
		}

		/// <summary>
		/// 判斷是否日期格式
		/// </summary>
		/// <param name="dateStr">日期字串, 民國 Or 西元</param>
		/// <returns>是否日期格式, 空白為 true</returns>
		public static bool IsDate(string dateStr)
		{
			//=== 將 / - 拿掉 ===
			dateStr 	=	dateStr.Replace("/", "").Replace("-", "");

			//=== 空白 return true ===
			if (string.IsNullOrEmpty(dateStr))
				return true;

			//=== 非西元或民國年長度時回傳錯誤 ===
			if (dateStr.Length != 8 && dateStr.Length != 7)
				return false;

			int	year	=	(dateStr.Length == 8) ? Convert.ToInt32(dateStr.Substring(0, 4)) : Convert.ToInt32(dateStr.Substring(0, 3)) + 1911;
			int	month	=	(dateStr.Length == 8) ? Convert.ToInt32(dateStr.Substring(4, 2)) : Convert.ToInt32(dateStr.Substring(3, 2));
			int	day	=	(dateStr.Length == 8) ? Convert.ToInt32(dateStr.Substring(6, 2)) : Convert.ToInt32(dateStr.Substring(5, 2));

			if (month < 1 || month > 12)
				return false;
			if (day < 1 || day > 31)
				return false;
			if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31)
				return false;
			if (month == 2)
			{
				var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
				if (day > 29 || (day==29 && !isleap))
					return false;
			}
			return true;
		}

		/// <summary>
		/// 判斷是否時間格式
		/// </summary>
		/// <param name="timeStr">時間字串</param>
		/// <returns>是否時間格式, 空白為 true</returns>
		public static bool IsTime(string timeStr)
		{
			try
			{
				//=== 將 : 拿掉 ===
				timeStr 	=	timeStr.Replace(":", "");

				//=== 空白 return true ===
				if (string.IsNullOrEmpty(timeStr))
					return true;

				if (!(timeStr.Length == 6 || timeStr.Length == 4))
					return false;

				//=== 檢查小時 ===
				int	hh	=	Convert.ToInt32(timeStr.Substring(0, 2));
				if (hh < 0 || hh >= 24)
					return false;

				//=== 檢查分 ===
				int	mm	=	Convert.ToInt32(timeStr.Substring(2, 2));
				if (mm < 0 || mm >= 60)
					return false;

				//=== 檢查秒 ===
				if (timeStr.Length == 6)
				{
					int	ss	=	Convert.ToInt32(timeStr.Substring(4));
					if (ss < 0 || ss >= 60)
						return false;
				}

				return true;
			}
			catch(Exception)
			{
				return false;
			}
		}
	}
}
