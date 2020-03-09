using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Acer.Util
{
	/// <summary>
	/// �M���B�z��������@�Τ�k
	/// </summary>
	public class DateUtil
	{
		/// <summary>
		/// ���o����M�ɶ�����׼ƥ�
		/// </summary>
		/// <returns>����M�ɶ�����׼ƥ�</returns>
		public static long GetCurrTimeMillis()
		{
			return DateTime.Now.Ticks / 10000;
		}

		/// <summary>
		/// ���o�t�ήɶ���L��
		/// </summary>
		/// <returns>�t�ήɶ� hhmmssmms</returns>
		public static string GetNowTimeMS()
  		{
			return System.DateTime.Now.ToString("HHmmss") + System.DateTime.Now.Millisecond.ToString();
   		}

		/// <summary>
		/// ���o�t�Τ���A�榡���褸��� yyyyMMdd
		/// </summary>
		/// <returns>�褸��� yyyyMMdd</returns>
   		public static string GetNowDate() 
  		{
			return System.DateTime.Now.ToString ("yyyyMMdd");
   		}

		/// <summary>
		/// �N�褸����榡�� yyyyMMdd --> yyyy/MM/dd
		/// </summary>
		/// <param name="dateStr">�K�X�褸��� yyyyMMdd</param>
		/// <returns>�褸��� yyyy/MM/dd</returns>
   		public static string FormatDate(string dateStr) 
   		{
      			if (dateStr.Length != 8)
      				return dateStr;
      			else
				return dateStr.Substring(0, 4) + "/" + dateStr.Substring(4, 2) + "/" + dateStr.Substring(6);
   		}

        /// <summary>
		/// �N�褸����榡�� yyyyMMdd hh:mm:ss --> yyyy/MM/dd hh:mm:ss
		/// </summary>
		/// <param name="dateStr">���a�ɶ����褸��� yyyyMMdd hh:mm:ss</param>
		/// <returns>�褸��� yyyy/MM/dd</returns>
   		public static string FormatDateDetail(string dateStr)
        {
            if (dateStr.Length > 0)
            {
                //Parsing Type
                bool error = false;
                DateTime tmpDate = new DateTime();
                try
                {
                    //DB�榡,ex:2010/6/01 �W�� 11:11:11
                    tmpDate = DateTime.ParseExact(dateStr, "yyyy/M/dd tt hh:mm:ss", null);
                    error = false;
                }
                catch {
                    error = true;
                }

                if (error) { 
                    try
                    {
                        //DB�榡,ex:2010/6/1 �W�� 11:11:11
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
                    //�@��榡,ex:2010/06/01  14/11/11
                    tmpDate = DateTime.ParseExact(dateStr, "yyyy/MM/dd HH:mm:ss", null);
                }
                
                return tmpDate.ToString("yyyy/MM/dd HH:mm:ss");
            }
            else
                return dateStr;
        }

        /// <summary>
        /// �N�褸����榡�Ƭ��C�X������ yyyyMMdd(yyyy/MM/dd) --> yyyMMdd
        /// </summary>
        /// <param name="dateStr">�褸��� yyyyMMdd</param>
        /// <returns>�C�X������ yyyMMdd</returns>
        public static string ConvertDate(string dateStr) 
   		{
			//=== nono add �P�_�Y�w�O�褸����h���B�z ===
			if (dateStr.Length == 9 && IsDate(dateStr))
				return dateStr;

      			if (dateStr.Length < 8)
      				return dateStr;
      			else
      			{
				//=== �N��� / ������榡�Ʀ��� / ���榡 ===
				string[]	strAry	=	Utility.Split(DateUtil.FormatDate(dateStr.Replace("/", "")), "/");
	      			string		year	=	Convert.ToString(Convert.ToInt32(strAry[0]) - 1911).PadLeft(3, '0');
	      			string		month	=	strAry[1];
	      			string		day	=	strAry[2];

	      			return	year + month + day;
	      		}
   		}

        /// <summary>
		/// �N�褸����榡�Ƭ��C�X������ �[�W�ɤ���hh:mm:ss yyyyMMdd(yyyy/MM/dd) hh:mm:ss --> yyy/MM/dd hh:mm:ss
		/// </summary>
		/// <param name="dateStr">�褸��� yyyyMMdd tt hh:mm:ss</param>
		/// <returns>�C�X������ yyy/MM/dd hh:mm:ss</returns>
   		public static string ConvertDateDetail(string dateStr)
        {
            //=== nono add �P�_�Y�w�O���إ������h���B�z ===
            if (dateStr.Length == 9 && IsDate(dateStr))
                return dateStr;

            if (dateStr.Length < 8)
                return dateStr;
            else
            {
                //=== �N��� / ������榡�Ʀ��� / ���榡 ===
                string formatedDate = DateUtil.FormatDateDetail(dateStr);
                string year = Convert.ToString(Convert.ToInt32(formatedDate.Substring(0,4)) - 1911).PadLeft(3, '0');
                string month = formatedDate.Substring(5, 2);
                string day = formatedDate.Substring(8, 2);
                string time = formatedDate.Substring(11).Trim();

                return year + "/" +  month +"/"+ day +" "+ time;
            }
        }
               

        /// <summary>
        /// �N�褸����榡�Ƭ�����榡��� yyyyMMdd(yyyy/MM/dd) --> yyy/MM/dd
        /// </summary>
        /// <param name="dateStr">�褸��� yyyyMMdd</param>
        /// <returns>����榡��� yyy/MM/dd</returns>
        public static string ConvertFormatDate(string dateStr) 
   		{
			if (string.IsNullOrEmpty(dateStr))
				return "";
			return DateUtil.FormatCDate(DateUtil.ConvertDate(Convert.ToDateTime(dateStr).ToString("yyyy/MM/dd")));
   		}

		/// <summary>
		/// ���o����t�Τ���A�榡���C�X������ yyyMMdd
		/// </summary>
		/// <returns>�C�X������ yyyMMdd</returns>
		public static string GetNowCDate() 
  		{
			return DateUtil.ConvertDate(DateUtil.GetNowDate());
   		}
		
		/// <summary>
		/// �N�C�X�������榡�Ƭ��褸���
		/// </summary>
		/// <param name="dateStr">�C�X������ yyyMMdd</param>
		/// <param name="formatType">�榡�ƺ��� Exp: yyyy/MM/dd</param>
		/// <returns>�榡�ƫ᪺�褸���</returns>
   		public static string ConvertCDate(string dateStr, string formatType) 
   		{
			if (string.IsNullOrEmpty(dateStr))
				return dateStr;

			//=== nono add �P�_�Y�w�O�褸����h���B�z ===
			if (dateStr.Length == 10 && IsDate(dateStr))
				return dateStr;

			dateStr	=	dateStr.Replace("/", "");
			if (dateStr.Length != 7)
				throw new FormatException("�������榡���~, ������ yyymmdd �榡, �ثe�ǤJ��: " + dateStr);

      			string	year	=	Convert.ToString(Convert.ToInt32(dateStr.Substring(0, 3)) + 1911);
      			string	month	=	dateStr.Substring(3, 2);
      			string	day	=	dateStr.Substring(5);
			
      			return Convert.ToDateTime(year + "-" + month + "-" + day).ToString(formatType);
   		}
		
		/// <summary>
		/// ���o�t�Τ���ɶ��A�榡���褸����ɶ�
		/// </summary>
		/// <returns>�褸��� yyyy/mm/dd hh:mm</returns>
   		public static string GetNowDateTime() 
  		{
			return DateUtil.FormatDate(GetNowDate()) + " " + FormatTime(GetNowTime());
   		}
		
		/// <summary>
		/// �N�ɶ��榡�� hhmm --> hh:mm, hhmmss --> hh:mm:ss
		/// </summary>
		/// <param name="timeStr">�|�X�Τ��X�ɶ� mmss</param>
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
		/// �Ǧ^���e���Y�Ӱ�Ǥ���[�W�ƭӮɶ����j���᪺����C
		/// Exp: DateUtil.DateAdd("m", 1, "2003/2/28") --> 2003/3/7
		/// </summary>
		/// <param name="interval">���� d(��), w(�P��), m(��), yyyy(�~)</param>
		/// <param name="number">�ۥ[���ƥ�</param>
		/// <param name="dateStr">�r�ꫬ�A��� yyyy/MM/dd or yyyyMMdd</param>
		/// <returns>����᪺��� yyyy/MM/dd</returns>
		public static string DateAdd(string interval, double number, string dateStr) 
  		{
			DateTime	addDate	=	Microsoft.VisualBasic.DateAndTime.DateAdd(interval, number, Convert.ToDateTime(FormatDate(dateStr)));
			return addDate.ToString("yyyy/MM/dd");
   		}
		
		/// <summary>
		/// �Ǧ^���e���Y�Ӱ�ǤC�X�������[�W�ƭӮɶ����j���᪺����C
		/// Exp: DateUtil.CDateAdd("ww", 1, "920228") --> 920307
		/// </summary>
		/// <param name="interval">���� d(��), w(�P��), m(��), yyyy(�~)</param>
		/// <param name="number">�ۥ[���ƥ�</param>
		/// <param name="dateStr">�r�ꫬ�A���</param>
		/// <returns>����᪺��� yyyMMdd</returns>
		public static string CDateAdd(string interval, int number, string dateStr) 
  		{
			return DateUtil.ConvertDate(DateUtil.DateAdd(interval, number, DateUtil.ConvertCDate(dateStr, "yyyy/MM/dd")));
   		}
		
		/// <summary>
		/// �Ǧ^��Ӥ�����ۮt���ɶ����j���ƥ� Exp: DateUtil.DateDiff("d", "2003/5/1", "2003/5/2") --> 1
		/// </summary>
		/// <param name="interval">���� d(��), w(�P��), m(��), yyyy(�~)</param>
		/// <param name="dateStr1">�r�ꫬ�A����@</param>
		/// <param name="dateStr2">�r�ꫬ�A����G</param>
		/// <returns>����᪺�ɶ��t</returns>
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
		/// �Ǧ^��ӤC�X���������ۮt���ɶ����j���ƥ� Exp: DateUtil.CDateDiff("d", "0920501", "0920502") --> 1
		/// </summary>
		/// <param name="interval">���� d(��), w(�P��), m(��), yyyy(�~)</param>
		/// <param name="dateStr1">�r�ꫬ�A����@</param>
		/// <param name="dateStr2">�r�ꫬ�A����G</param>
		/// <returns>����᪺�ɶ��t</returns>
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
		/// ���o�t�ήɶ��A�榡�� hhmm
		/// </summary>
		/// <returns>hhmm</returns>
   		public static string GetNowTime() 
  		{
			return System.DateTime.Now.ToString("HHmm");
   		}

		/// <summary>
		/// ����C�X���������P��
		/// </summary>
		/// <param name="dateStr">�C�X������</param>
		/// <returns>�@ ~ ��</returns>
		public static string GetCWeek(string dateStr) 
		{
			DateTime	dt	=	Convert.ToDateTime(ConvertCDate(dateStr, "yyyy/MM/dd"));
			string		weekStr	=	"��@�G�T�|����";
			
			return weekStr.Substring(Convert.ToInt16(dt.DayOfWeek), 1);
		}

		/// <summary>
		/// �N�C�X�������榡��
		/// </summary>
		/// <param name="dateStr">�C�X������</param>
		/// <returns>������ yyy/MM/dd</returns>
		public static string FormatCDate(string dateStr) 
		{
			if (dateStr.Length != 7)
				return dateStr;
			else
				return dateStr.Substring(0, 3) + "/" + dateStr.Substring(3, 2) + "/" + dateStr.Substring(5);
		}
       
        /// <summary>
        /// �N����榡�Ƭ������� Exp: 0920101 --> �E�Q�G�~�@��@��
        /// </summary>
        /// <param name="dateStr">��� yyyMMdd</param>
        /// <returns>������</returns>
        public static string FormatCDateForPrint(string dateStr) 
		{
			if (dateStr.Length != 7)
				return dateStr;

			string	yy	=	Utility.GetCNum(Convert.ToInt32(dateStr.Substring(0, 3), 10), 2);
			string	mm	=	Utility.GetCNum(Convert.ToInt32(dateStr.Substring(3, 2), 10), 2);
			string	dd	=	Utility.GetCNum(Convert.ToInt32(dateStr.Substring(5), 10), 2);

			return yy + "�~" + mm + "��" + dd + "��";
		}

		/// <summary>
		/// �N����榡�Ƭ��褸��� Exp: 20060101 --> �G�ݢݤ��~�@��@��
		/// </summary>
		/// <param name="dateStr">��� yyyyMMdd</param>
		/// <returns>������</returns>
		public static string FormatDateForPrint(string dateStr) 
		{
			if (dateStr.Length < 8)
				return dateStr;

			string	yy	=	Utility.GetCNum(Convert.ToInt32(dateStr.Substring(0, 4)), 3);
			string	mm	=	Utility.GetCNum(Convert.ToInt32(dateStr.Substring(4, 2)), 2);
			string	dd	=	Utility.GetCNum(Convert.ToInt32(dateStr.Substring(6)), 2);

			return yy + "�~" + mm + "��" + dd + "��";
		}

		/// <summary>
		/// �P�_�O�_����榡
		/// </summary>
		/// <param name="dateStr">����r��, ���� Or �褸</param>
		/// <returns>�O�_����榡, �ťլ� true</returns>
		public static bool IsDate(string dateStr)
		{
			//=== �N / - ���� ===
			dateStr 	=	dateStr.Replace("/", "").Replace("-", "");

			//=== �ť� return true ===
			if (string.IsNullOrEmpty(dateStr))
				return true;

			//=== �D�褸�Υ���~���׮ɦ^�ǿ��~ ===
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
		/// �P�_�O�_�ɶ��榡
		/// </summary>
		/// <param name="timeStr">�ɶ��r��</param>
		/// <returns>�O�_�ɶ��榡, �ťլ� true</returns>
		public static bool IsTime(string timeStr)
		{
			try
			{
				//=== �N : ���� ===
				timeStr 	=	timeStr.Replace(":", "");

				//=== �ť� return true ===
				if (string.IsNullOrEmpty(timeStr))
					return true;

				if (!(timeStr.Length == 6 || timeStr.Length == 4))
					return false;

				//=== �ˬd�p�� ===
				int	hh	=	Convert.ToInt32(timeStr.Substring(0, 2));
				if (hh < 0 || hh >= 24)
					return false;

				//=== �ˬd�� ===
				int	mm	=	Convert.ToInt32(timeStr.Substring(2, 2));
				if (mm < 0 || mm >= 60)
					return false;

				//=== �ˬd�� ===
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
