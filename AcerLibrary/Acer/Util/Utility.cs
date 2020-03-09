using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Security.Cryptography;
using Acer.Apps;
using Acer.Form;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;

namespace Acer.Util
{
	#region 不分大小寫比對物件
	/// <summary>
	/// EntityColumnCompare 覆寫
	/// </summary>
	public class EntityColumnCompare : IEqualityComparer
	{
		/// <summary>
		/// 實作 Equals
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public new bool Equals(object x, object y)
		{
			return x.Equals(y);
		}

		/// <summary>
		/// 實作 GetHashCode
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int GetHashCode(object obj)
		{
			return obj.ToString().ToLower().GetHashCode();
		}

	}
	#endregion

	/// <summary>
	/// 處理一般的共用函式
	/// </summary>
	public class Utility
	{
		#region 字串處理
		#region Substring 依據索引取字串值
		/// <summary>
		/// 依據索引取字串值
		/// </summary>
		/// <param name="content">要處理資料</param>
		/// <param name="startIndex">起始索引</param>
		/// <param name="endIndex">結束索引</param>
		/// <returns>取得的字串</returns>
		public static string Substring(string content, int startIndex, int endIndex)
		{
			if (content == null)
				throw new ArgumentNullException("content");
			return content.Substring(startIndex, endIndex - startIndex);
		}
		#endregion

		#region StrToFullSize 將傳入的字串中，有半形的英文或數字改為全形後傳出
		/// <summary>
		/// 將傳入的字串中，有半形的英文或數字改為全形後傳出
		/// </summary>
		/// <param name="str">原始的字串內容</param>
		/// <returns>處理後字串</returns>
		public static string StrToFullSize(string str)
		{
			if (str == null)
				throw new ArgumentNullException("str");

			if (string.IsNullOrEmpty(str.Trim()))	
				return "";

			StringBuilder	strBuffer	=	new StringBuilder();
			char[]		charAry		=	str.ToCharArray();

			for(int i = 0; i < charAry.Length; i++)
			{
				strBuffer.Append(CharToFullSize(charAry[i]));
			}

			return strBuffer.ToString();
		}
		#endregion

		#region CharToFullSize 將含有半形的字元改為全形的傳回
		/// <summary>
		/// 將含有半形的字元改為全形的傳回
		/// </summary>
		/// <param name="str">含有半形的字元</param>
		/// <returns>處理後字串</returns>
		public static string CharToFullSize(char str)
		{
			string	oStr	=	"0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string	nStr	=	"０１２３４５６７８９ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚＡＢＣＤＥＦＧＨＩＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ";
			if (oStr.IndexOf(str) == -1)
				return str.ToString();
			return nStr.Substring(oStr.IndexOf(str), 1);
		}
		#endregion

		#region ConvertStr 將字串反向
		/// <summary>
		/// 將字串反向, 例如: 傳入 '1234', 傳回 '4321'
		/// </summary>
		/// <param name="str">欲反向的字串</param>
		/// <returns>處理後的字串</returns>
		public static string ConvertStr(string str)
		{
			if (str == null)
				throw new ArgumentNullException("str");

			StringBuilder	resultStr	=	new StringBuilder();
			for(int i = str.Length - 1; i >= 0; i--)
				resultStr.Append(str.Substring(i, 1));

			return resultStr.ToString();
		}
		#endregion

		#region Replace 處理置換某字串動作
		[Obsolete]
		///// <summary>
		///// 處理置換某字串動作
		///// </summary>
		///// <param name="str">原始的字串內容</param>
		///// <param name="oldStr">要被置換的字串內容</param>
		///// <param name="newStr">置換後的字串內容</param>
		///// <returns>處理後字串</returns>
		public static string Replace(string str, string oldStr, string newStr)
		{
			if (str == null)
				throw new ArgumentNullException("str");
			if (oldStr == null)
				throw new ArgumentNullException("oldStr");
			if (newStr == null)
				throw new ArgumentNullException("newStr");

			//=== 解決傳空字串會照成死結 Bug ===
			if (string.IsNullOrEmpty(oldStr))
				return str;

			string		tmpStr		=	CheckNull(str, "");
			StringBuilder	strBuffer	=	new StringBuilder();
			int		pos1		=	0;
			int		pos2		=	0;

			while (tmpStr.IndexOf(oldStr) != -1)
			{
				pos1	=	tmpStr.IndexOf(oldStr);
				pos2	=	pos1 + oldStr.Length;
				strBuffer.Append(tmpStr.Substring(0, pos1));
				strBuffer.Append(newStr);
				tmpStr	=	tmpStr.Substring(pos2);
			}
			strBuffer.Append(tmpStr);

			return strBuffer.ToString();
		}
		#endregion

		#region Split 將字串依指定符號切割為陣列
		/// <summary>
		/// 將字串依指定符號切割為陣列
		/// </summary>
		/// <param name="str">欲切割的字串</param>
		/// <param name="delim">指定符號</param>
		/// <returns>切割後陣列</returns>
		public static string[] Split(string str, string delim)
		{
			if (str == null)
				throw new ArgumentNullException("str");

			if (delim == null)
				throw new ArgumentNullException("delim");

			int		aryLength	=	1;
			int		strIndex	=	0;
			while (str.IndexOf(delim, strIndex) != -1)
			{
				strIndex	=	str.IndexOf(delim, strIndex) + 1;
				aryLength++;
			}

			string[]	strAry		=	new string[aryLength];
			int		aryIndex	=	0;
			strIndex	=	0;
			if (str.IndexOf(delim) == -1)
				strAry[0]	=	str;
			else
				strAry[0]	=	Utility.Substring(str, 0, str.IndexOf(delim));

			while (str.IndexOf(delim, strIndex) != -1)
			{
				aryIndex++;
				strIndex	=	str.IndexOf(delim, strIndex) + 1;
				if (str.IndexOf(delim, strIndex) == -1)
					strAry[aryIndex]	=	Utility.Substring(str, strIndex + delim.Length - 1, str.Length);
				else
					strAry[aryIndex]	=	Utility.Substring(str, strIndex + delim.Length - 1, str.IndexOf(delim, strIndex));
			}
			return strAry;
		}
		#endregion

		#region CloneStr 將字串複製設定次數
		/// <summary>
		/// 將字串複製設定次數
		/// EX: "abcabcabc" = CloneStr("abc", 3)
		/// </summary>
		/// <param name="str">指定要重覆的字串內容</param>
		/// <param name="len">指定要重覆的次數</param>
		/// <returns>處理後字串</returns>
		public static string CloneStr(string str, int len)
		{
			StringBuilder	strBuffer	=	new StringBuilder();
			
			while (len > 0)
			{
				len--;
				strBuffer.Append(str);
			}
			return strBuffer.ToString();
		}
		#endregion

		#region CloneStr 將字元複製設定次數
		[Obsolete]
		///// <summary>
		///// 將字元複製設定次數
		///// EX: "000" = cloneStr('0', 3)
		///// </summary>
		///// <param name="str">指定要重覆的字元內容</param>
		///// <param name="len">指定要重覆的次數</param>
		///// <returns>處理後字串</returns>
		public static string CloneStr(char str, int len)
		{
			StringBuilder	strBuffer	=	new StringBuilder();
			while (len > 0)
			{
				len--;
				strBuffer.Append(str);
			}
			return strBuffer.ToString();
		}
		#endregion

		#region ChkLen 檢查傳入字串的長度是否未超過設定長度
		/// <summary>
		/// 檢查傳入字串的長度是否未超過設定長度
		/// </summary>
		/// <param name="str">原始字串</param>
		/// <param name="strLen">檢核的長度</param>
		/// <returns>檢查的結果</returns>
		private static Boolean ChkLen(string str, int strLen)
		{
			if(str.Length <= strLen)
				return true;
			else
				return false;
		}
		#endregion

		#region RTrim 清除字串右邊的空白
		/// <summary>
		/// 清除字串右邊的空白
		/// </summary>
		/// <param name="str">要處理的字串</param>
		/// <returns>處理後的字串</returns>
		public static string RTrim(string str)
		{
			if (str == null)
				throw new ArgumentNullException("str");

			if (string.IsNullOrEmpty(str.Trim()))
				return str;

			int	i	=	str.Length;

			while (str.Substring(i - 1, 1).Equals(" "))
				i--;

			return Utility.Substring(str, 0, i);
		}
		#endregion

		#region GetBLen 取得檔案長度(中文為兩碼)
		/// <summary>
		/// 取得檔案長度(中文為兩碼)
		/// </summary>
		/// <param name="str">判斷長度的字串</param>
		/// <returns>傳回長度</returns>
		public static int GetBLen(string str)
		{
			if (str == null)
				throw new ArgumentNullException("str");

			try
			{
				return System.Text.Encoding.Default.GetBytes(str).Length;
			}
			catch (Exception)
			{
				return str.Length;
			}
		}
		#endregion
		#endregion
		
		#region Tag 處理
		#region GetTagStr 取得 Tag 所包含字串 Exp: [abc] --> abc
		/// <summary>
		/// 取得 Tag 所包含字串 Exp: [abc] --> abc
		/// </summary>
		/// <param name="content">要處理的字串</param>
		/// <param name="startTag">起始 Tag 符號</param>
		/// <param name="endTag">結束 Tag 符號</param>
		/// <returns>取得後字串</returns>
		public static string GetTagStr(string content, string startTag, string endTag)
		{
			if (content == null)
				throw new ArgumentNullException("content");
			if (startTag == null)
				throw new ArgumentNullException("startTag");
			if (endTag == null)
				throw new ArgumentNullException("endTag");

			if (content.IndexOf(startTag) == -1 &&  content.IndexOf(startTag) == -1)
				return "";
			else
				return  Utility.Substring(content, content.IndexOf(startTag) + startTag.Length, content.LastIndexOf(endTag));
		}
		#endregion

		#region GetTagList 取得 Tag 所包含字串 Exp: [abc]123[456] --> {abc, 456}
		/// <summary>
		/// 取得 Tag 所包含字串 Exp: [abc]123[456] --> {abc, 456}
		/// </summary>
		/// <param name="content">要處理的字串</param>
		/// <param name="startTag">起始 Tag 符號</param>
		/// <param name="endTag">結束 Tag 符號</param>
		/// <returns>取得後字串陣列</returns>
		public static ArrayList GetTagList(string content, string startTag, string endTag)
		{
			if (content == null)
				throw new ArgumentNullException("content");
			if (startTag == null)
				throw new ArgumentNullException("startTag");
			if (endTag == null)
				throw new ArgumentNullException("endTag");

			if (content.IndexOf(startTag) == -1 && content.IndexOf(startTag) == -1)
				return new ArrayList();
			
			string		tmpContent	=	content;
			ArrayList	vt		=	new ArrayList();
			
			while (tmpContent.IndexOf(startTag) != -1)
			{
				tmpContent	=	Utility.Substring(tmpContent, tmpContent.IndexOf(startTag) + startTag.Length, tmpContent.Length);
				vt.Add(tmpContent.Substring(0, tmpContent.IndexOf(endTag)));
				tmpContent	=	Utility.Substring(tmpContent, tmpContent.IndexOf(endTag) + endTag.Length, tmpContent.Length);
			}
			
			return vt;
		}
		#endregion

		#region EncryptTagContent 將 {} 區隔的內容編碼
		/// <summary>
		/// 將 {} 區隔的內容編碼
		/// </summary>
		/// <param name="content">欲編碼內容</param>
		/// <returns>編碼過的內容</returns>
		public static string EncryptTagContent(string content)
		{
			ArrayList	list	=	Utility.GetTagList(content, "{", "}");

			for (int i = 0; i < list.Count; i++)
			{
				content		=	content.Replace("{" + list[i] + "}", "{" + EncryptStr(list[i].ToString()) + "}");
			}
			return content;
		}
		#endregion

		#region DecryptTagContent 將 Tag 解碼
		/// <summary>
		/// 將 Tag 解碼
		/// </summary>
		/// <param name="content">欲解碼內容</param>
		/// <returns>解碼過的內容</returns>
		public static string DecryptTagContent(string content)
		{
			ArrayList	list	=	Utility.GetTagList(content, "{", "}");

			for (int i = 0; i < list.Count; i++)
			{
				//2011/06/24 nono 加上避免驅動程式造成誤判
				if (!list[i].ToString().ToUpper().Contains("IBM DB2 ODBC DRIVER"))
					content		=	content.Replace("{" + list[i] + "}", DecryptStr(list[i].ToString()));
			}
			return content;
		}
		#endregion
		#endregion

		#region 加解密
		#region TripleDesEncrypt 將字串加密
		/// <summary>
		/// TripleDesEncrypt 將字串加密
		/// </summary>
		/// <param name="str">要加密的字串</param>
		/// <returns>加密後字串</returns>
		public static string TripleDesEncrypt(string str)
		{
			if (String.IsNullOrEmpty(str))
				return "";

			TripleDESCryptoServiceProvider	des	=	new TripleDESCryptoServiceProvider();
			string				keyStr	=	APConfig.GetProperty("pwdkey1");
			string				ivStr	=	APConfig.GetProperty("pwdkey2");
			
			des.Key		=	Convert.FromBase64String(keyStr);
			des.IV		=	Convert.FromBase64String(ivStr);
			des.Mode	=	CipherMode.ECB;
			des.Padding	=	PaddingMode.PKCS7;
			
			MemoryStream	ms	=	new MemoryStream();
			CryptoStream	cs	=	new CryptoStream(ms, des.CreateEncryptor(des.Key, des.IV), CryptoStreamMode.Write);
			StreamWriter	sw	=	new StreamWriter(cs);

			sw.Write(str);
			sw.Flush();
			cs.FlushFinalBlock();
			ms.Flush();

			string	result	=	System.Convert.ToBase64String(ms.GetBuffer(), 0, System.Convert.ToInt32(ms.Length));

			sw.Close();
			cs.Close();
			ms.Close();
		
			return result;
		}
		#endregion

		#region TripleDesDecrypt 將字串解密
		/// <summary>
		/// TripleDesDecrypt 將字串解密
		/// </summary>
		/// <param name="str">要解密的字串</param>
		/// <returns>解密後字串</returns>
		public static string TripleDesDecrypt(string str)
		{
			if (String.IsNullOrEmpty(str))
				return "";

			string				keyStr	=	APConfig.GetProperty("pwdkey1");
			string				ivStr	=	APConfig.GetProperty("pwdkey2");
			TripleDESCryptoServiceProvider	des	=	new TripleDESCryptoServiceProvider();

			des.Key		=	Convert.FromBase64String(keyStr);
			des.IV		=	Convert.FromBase64String(ivStr);
			des.Mode	=	CipherMode.ECB;
			des.Padding	=	PaddingMode.PKCS7;

			byte[]		buffer		=	Convert.FromBase64String(str);
			MemoryStream	ms		=	new MemoryStream(buffer);
			CryptoStream	cs		=	new CryptoStream(ms, des.CreateDecryptor(des.Key, des.IV), CryptoStreamMode.Read);
			StreamReader	sr		=	new StreamReader(cs);
			string		result		=	sr.ReadToEnd();
			sr.Close();
			cs.Close();
			ms.Close();

			return result;

		}
		#endregion

		#region GenerateTripleDesKey 產生 3Des 的 Key
		/// <summary>
		/// 產生 3Des 的 Key
		/// </summary>
		/// <returns></returns>
		public static string GenerateTripleDesKey()
		{
			//Create an instance of Symetric Algorithm. Key and IV is generated automatically.
			TripleDESCryptoServiceProvider	desCrypto	=	(TripleDESCryptoServiceProvider)TripleDESCryptoServiceProvider.Create();

			//Use the Automatically generated key for Encryption. 
			return Convert.ToBase64String(desCrypto.Key);
		}
		#endregion

		#region GenerateTripleDesKey 產生 3Des 的 IV
		/// <summary>
		/// 產生 3Des 的 IV
		/// </summary>
		/// <returns></returns>
		public static string GenerateTripleDesIV()
		{
			//Create an instance of Symetric Algorithm. Key and IV is generated automatically.
			TripleDESCryptoServiceProvider	desCrypto	=	(TripleDESCryptoServiceProvider)TripleDESCryptoServiceProvider.Create();

			//Use the Automatically generated key for Encryption. 
			return Convert.ToBase64String(desCrypto.IV);
		}
		#endregion

		#region EncryptStr 將字串編碼
		/// <summary>
		/// 將字串編碼
		/// </summary>
		/// <param name="str">要編碼的字串</param>
		/// <returns>編碼後字串</returns>
		public static string EncryptStr (string str)
		{
			DESCryptoServiceProvider	des			=	new DESCryptoServiceProvider();
			string				keyStr			=	APConfig.GetProperty("pwdkey");			
			
			des.Key	=	ASCIIEncoding.ASCII.GetBytes(keyStr);
			des.IV	=	ASCIIEncoding.ASCII.GetBytes(keyStr);
			
			MemoryStream	ms	=	new MemoryStream();
			CryptoStream	cs	=	new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
			StreamWriter	sw	=	new StreamWriter(cs);

			sw.Write(str);
			sw.Flush();
			cs.FlushFinalBlock();
			ms.Flush();

			string	result	=	System.Convert.ToBase64String(ms.GetBuffer(), 0, System.Convert.ToInt32(ms.Length));

			sw.Close();
			cs.Close();
			ms.Close();
		
			return result;
		}
		#endregion

		#region DecryptStr 將字串解碼
		/// <summary>
		/// 將字串解碼
		/// </summary>
		/// <param name="str">要解碼的字串</param>
		/// <returns>解碼後的字串</returns>
		public static string DecryptStr (string str)
		{
			if (string.IsNullOrEmpty(str))
				return str;

			string				keyStr	=	APConfig.GetProperty("pwdkey");
			DESCryptoServiceProvider	des	=	new DESCryptoServiceProvider();
			
			des.Key =	ASCIIEncoding.ASCII.GetBytes(keyStr);
			des.IV	=	ASCIIEncoding.ASCII.GetBytes(keyStr);

			byte[]		buffer;
			try
			{
				buffer	=	Convert.FromBase64String(str);
			}
			catch(Exception ex)
			{
				throw new Exception("字串解密錯誤:" + str + "," + ex.Message);
			}
			MemoryStream	ms		=	new MemoryStream(buffer);
			CryptoStream	cs		=	new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read);
			StreamReader	sr		=	new StreamReader(cs);
			string		result		=	sr.ReadToEnd();
			sr.Close();
			cs.Close();
			ms.Close();

			return result;
		}
		#endregion

		#region GenerateKey 產生 Des 的 Key
		/// <summary>
		/// 產生 Des 的 Key
		/// </summary>
		/// <returns></returns>
		public static string GenerateKey()
		{
			//Create an instance of Symetric Algorithm. Key and IV is generated automatically.
			DESCryptoServiceProvider	desCrypto	=	(DESCryptoServiceProvider)DESCryptoServiceProvider.Create();

			//Use the Automatically generated key for Encryption. 
			return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
		}
		#endregion
		#endregion

		#region 數字轉大寫
		/// <summary>
		/// 將數字字串轉換為中文的數字資料格式
		/// Exp: 12345.06
		/// 種類 0:一萬二千零四十五點零六,
		/// 1:壹萬貳仟零肆拾伍點零陸,
		/// 2:一萬二千零四十五點０六, 1234506
		/// 3:一二０四五０六
		/// 須注意種類'3'一般為轉換號的數字不可輸入非數字型態資料
		/// </summary>
		/// <param name="strNum">要轉換的數字</param>
		/// <param name="cNumType">轉換格式</param>
		/// <returns>轉換後字串</returns>
		public static string GetCNum(int strNum, int cNumType)
		{
			return GetCNum(Convert.ToString(strNum, 10), cNumType);
		}

		/// <summary>
		/// 將數字字串轉換為中文的數字資料格式
		/// Exp: 12345.06
		/// 種類 0:一萬二千零四十五點零六,
		/// 1:壹萬貳仟零肆拾伍點零陸,
		/// 2:一萬二千零四十五點０六, 1234506
		/// 3:一二０四五０六
		/// 須注意種類'3'一般為轉換號的數字不可輸入非數字型態資料
		/// </summary>
		/// <param name="strNum">要轉換的數字</param>
		/// <param name="cNumType">轉換格式</param>
		/// <returns>轉換後字串</returns>
		public static string GetCNum(double strNum, int cNumType)
		{
			return GetCNum(Convert.ToString(strNum), cNumType);
		}

		/// <summary>
		/// 將數字字串轉換為中文的數字資料格式
		/// Exp: 12345.06
		/// 種類 0:一萬二千零四十五點零六,
		/// 1:壹萬貳仟零肆拾伍點零陸,
		/// 2:一萬二千零四十五點０六, 1234506
		/// 3:一二０四五０六
		/// 須注意種類'3'一般為轉換號的數字不可輸入非數字型態資料
		/// </summary>
		/// <param name="strNum">要轉換的數字</param>
		/// <param name="cNumType">轉換格式</param>
		/// <returns>轉換後字串</returns>
		public static string GetCNum(long strNum, int cNumType)
		{
			return GetCNum(Convert.ToString(strNum, 10), cNumType);
		}

		/// <summary>
		/// 將數字字串轉換為中文的數字資料格式
		/// Exp: 12345.06
		/// 種類 0:一萬二千零四十五點零六,
		/// 1:壹萬貳仟零肆拾伍點零陸,
		/// 2:一萬二千零四十五點０六, 1234506
		/// 3:一二０四五０六
		/// 須注意種類'3'一般為轉換號的數字不可輸入非數字型態資料
		/// </summary>
		/// <param name="strNum">字串格式的數字內容</param>
		/// <param name="cNumType">轉換格式</param>
		/// <returns>傳回中文的數字字碼</returns>
		public static string GetCNum(string strNum, int cNumType)
		{
			if (strNum == null)
				throw new ArgumentNullException("strNum");

			if (cNumType > 3 || cNumType < 0)
				throw new ArgumentException("cNumType 參數必須為 0, 1, 2, 3 其中一種, 目前傳入值為: " + cNumType);

			if (string.IsNullOrEmpty(strNum))
				return "";

			StringBuilder	cStrNumSection		=	new StringBuilder();		//中文數字片段
			StringBuilder	resultStr		=	new StringBuilder();		//回傳值
			string		chineseNum		=	"";				//設定用
			string		chineseNum0		=	"零一二三四五六七八九";		//中文數字型態一
			string		chineseNum1		=	"零壹貳參肆伍陸柒捌玖";		//中文數字型態二
			string		chineseNum2		=	"０一二三四五六七八九";		//中文數字型態三
			string		chineseNum3		=	"０一二三四五六七八九";		//中文數字型態四(直接轉換)

			string		tmpStrNum		=	strNum.ToString();		//暫存傳入的數字
			string		tmpIntStrNum		=	"";				//暫存傳入的數字(整數部份)
			string		tmpStrNumSection	=	"";				//數字片段

			int		posOfDecimalPoint	=	0;				//小數點位置
			int		digit			=	0;				//位數
			Boolean		inZero			=	true;				//是否須加"零"
			Boolean		minus			=	true;				//是否負數

			//依種類判別中文數字型態
			if(cNumType == 0)
				chineseNum	=	chineseNum0;
			if(cNumType == 1)
				chineseNum	=	chineseNum1;
			if(cNumType == 2)
				chineseNum	=	chineseNum2;
			if(cNumType == 3)	//專門處理號的轉換
			{
				chineseNum	=	chineseNum3;

				for(int i = -1; i < tmpStrNum.Length - 1; i++)
				{
					if (tmpStrNum.Substring(i + 1, 1).Equals("."))
						resultStr.Append("‧");
					else
					{
						try
						{
							digit	=	Convert.ToInt32(tmpStrNum.Substring(i + 1, 1), 10);
						}
						catch(Exception)
						{
							throw new ArgumentException("【傳入參數包含非數字型態資料, strNum:" + strNum + "】");
						}
						resultStr.Append(chineseNum.Substring(digit, 1));
					}
				}
				return	resultStr.ToString();
			}

			//判別是否負數
			if (tmpStrNum.StartsWith("-"))//負數
			{
				minus		=	true;
				tmpStrNum	=	Utility.Substring(tmpStrNum, 1, tmpStrNum.Length);
			}
			else	//正數
				minus	=	false;

			//取得小數點的位置
			posOfDecimalPoint	=	tmpStrNum.IndexOf(".");

			//先處理整數的部分
			if (posOfDecimalPoint <= 0)
				tmpIntStrNum	=	ConvertStr(tmpStrNum);
			else
				tmpIntStrNum	=	ConvertStr(Utility.Substring(tmpStrNum, 0, posOfDecimalPoint));

			//從個位數起以每四位數為一小節
			for(int sectionIndex = 0; sectionIndex <= (tmpIntStrNum.Length - 1) / 4; sectionIndex++)
			{
				//取得四位數的字串資料
				if(sectionIndex * 4 + 4 < tmpIntStrNum.Length)
					tmpStrNumSection	=	Utility.Substring(tmpIntStrNum, sectionIndex * 4, sectionIndex * 4 + 4);
				else
					tmpStrNumSection	=	Utility.Substring(tmpIntStrNum, sectionIndex * 4, tmpIntStrNum.Length);

				//清空四位數的中文數字資料
				cStrNumSection.Length	=	0;

				/* 以下的 i 控制: 個十百千位四個位數 */
				for(int i = 0; i < tmpStrNumSection.Length; i++)
				{
					digit	= Convert.ToInt32(tmpStrNumSection.Substring(i, 1), 10);
					if (digit == 0)
					{
						// 1. 避免 '零' 的重覆出現
						// 2. 個位數的 0 不必轉成 '零'
						if (!inZero && i != 0)
							cStrNumSection.Insert(0, "零");
						inZero	=	true;
					}
					else
					{
						if(cNumType == 1)
						{
							switch(i)
							{
								case 1 :
									cStrNumSection.Insert(0, "拾");
									break;
								case 2 :
									cStrNumSection.Insert(0, "佰");
									break;
								case 3 :
									cStrNumSection.Insert(0, "仟");
									break;
								default :
									break;
							}
						}
						else
						{
							switch(i)
							{
								case 1 :
									cStrNumSection.Insert(0, "十");
									break;
								case 2 :
									cStrNumSection.Insert(0, "百");
									break;
								case 3 :
									cStrNumSection.Insert(0, "千");
									break;
								default :
									break;
							}
						}
						cStrNumSection.Insert(0, chineseNum.Substring(digit, 1));
						inZero	=	false;
					}
				}

				//加上該小節的位數
				if (cStrNumSection.Length == 0)
				{
					if (resultStr.Length > 0 && resultStr.ToString().Substring(0, 1).Equals("零"))
						resultStr.Insert(0, "零");
				}
				else
				{
					switch(sectionIndex)
					{
						case 0:
							resultStr.Append(cStrNumSection.ToString());
							break;
						case 1:
							resultStr.Insert(0, cStrNumSection.ToString() + "萬");
							break;
						case 2:
							resultStr.Insert(0, cStrNumSection.ToString() + "億");
							break;
						case 3:
							resultStr.Insert(0, cStrNumSection.ToString() + "兆");
							break;
						default :
							break;
					}
				}
			}

			//處理小數點右邊的部分
			if (posOfDecimalPoint > 0)
			{
				resultStr.Append("點");
				for(int i = posOfDecimalPoint; i < tmpStrNum.Length - 1; i++)
				{
					digit		=	Convert.ToInt32(tmpStrNum.Substring(i + 1, 1), 10);
					resultStr.Append(chineseNum.Substring(digit, 1));
				}
			}

			//其他例外狀況的處理
			if (resultStr.Length == 0)
				resultStr.Append("零");
			if (resultStr.Length>= 2 && (resultStr.ToString().Substring(0, 2).Equals("一十") || resultStr.ToString().Substring(0, 2).Equals("壹十")))
			{
				resultStr.Remove(0, 1);
			}
			if (resultStr.ToString().Substring(0, 1).Equals("點"))
				resultStr.Insert(0, "零");

			/* 是否為負數 */
			if (minus)
				resultStr.Insert(0, "負");

			return resultStr.ToString();
		}
		#endregion

		#region 填滿字串處理
		#region FillStr 將字串依設定長度填滿某字串(往前補)
		[Obsolete]
		///// <summary>
		///// 將字串依設定長度填滿某字串(往前補)
		///// Exp: Utility.FillStr("A", 10, '*'); --> '*********A'
		///// </summary>
		///// <param name="str">欲處理字串</param>
		///// <param name="strLen">指定長度</param>
		///// <param name="fill">欲補滿字元</param>
		///// <returns>處理後字串</returns>
		public static string FillStr(string str, int strLen, char fill)
		{
			if(ChkLen(str, strLen))
				return CloneStr(fill, strLen - GetBLen(str)) + str;
			else
				return str;
		}
		#endregion

		#region FillBackStr 將字串依設定長度填滿某字串(往後補)
		[Obsolete]
		///// <summary>
		///// 將字串依設定長度填滿某字串(往後補)
		///// Exp: Utility.FillBackStr("A", 10, '*'); --> 'A*********'
		///// </summary>
		///// <param name="str">欲處理字串</param>
		///// <param name="strLen">指定長度</param>
		///// <param name="fill">欲補滿字元</param>
		///// <returns>處理後字串</returns>
		public static string FillBackStr(string str, int strLen, char fill)
		{
			if(ChkLen(str, strLen))
				return str + CloneStr(fill, strLen - GetBLen(str));
			else
				return str;
		}
		#endregion

		#region FillZero 將字串依設定長度填滿 0(往前補)
		///// <summary>
		///// 將字串依設定長度填滿 0(往前補)
		///// </summary>
		///// <param name="str">欲處理字串</param>
		///// <param name="len">指定長度</param>
		///// <returns>處理後字串</returns>
		[Obsolete]
		public static string FillZero(string str, int len)
		{
			return Utility.FillStr(str, len, '0');
		}
		#endregion
		
		#region FillBackZero 將字串依設定長度填滿 0(往後補)
		[Obsolete]
		///// <summary>
		///// 將字串依設定長度填滿 0(往後補)
		///// </summary>
		///// <param name="str">欲處理字串</param>
		///// <param name="len">指定長度</param>
		///// <returns>處理後字串</returns>
		public static string FillBackZero(string str, int len)
		{
			return Utility.FillBackStr(str, len, '0');
		}
		#endregion
		#endregion

		#region 檢查方法
		#region IsIPFormat 是否 IP 格式
		/// <summary>
		/// 是否 IP 格式
		/// </summary>
		/// <param name="ip">欲檢查字串</param>
		/// <returns>是/否</returns>
		public static bool IsIPFormat(string ip)
		{
			string[]	ipAry	=	ip.Split('.');
			//=== 非 x.x.x.x 回傳否 ===
			if (ipAry.Length != 4)
				return false;

			Regex	reg	=	null;
			for (int i = 0; i < ipAry.Length; i++)
			{
				reg	=	new Regex("[^0-9]");
				//=== 非 '數字'回傳否 ===
				if (reg.IsMatch(ipAry[i]))
					return false;
				//=== 0 or > 255 回傳否 ===
				if (int.Parse(ipAry[i]) == 0 || int.Parse(ipAry[i]) > 255)
					return false;
			}

			return true;
		}
		#endregion
		#endregion

		#region GetIP 取得 Client IP 位址, 當 Session("IP") 有值則以 Session 為主
		/// <summary>
		/// 取得 Client IP 位址, 當 Session("IP") 有值則以 Session 為主
		/// </summary>
		/// <returns>IP 位址</returns>
		public static string GetIP()
		{
			try
			{
				string			result	=	"";
				HttpRequest		request	=	FormUtil.Request;
				HttpSessionState	session	=	FormUtil.Session;

				if (string.IsNullOrEmpty(Utility.CheckNull(session["IP"], "")))
				{
					if (request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null || request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf("unknown") > 0 )
					{
						result	=	request.ServerVariables["REMOTE_ADDR"];
					}
					else if (request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(",") > 0)
					{
						result	=	Utility.Substring(request.ServerVariables["HTTP_X_FORWARDED_FOR"], 0, request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(","));
					}
					else if (request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(";") > 0)
					{
						result	=	Utility.Substring(request.ServerVariables["HTTP_X_FORWARDED_FOR"], 0, request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(";"));
					}
					else
					{
						result	=	request.ServerVariables["HTTP_X_FORWARDED_FOR"];
					}
				}
				else
					result	=	session["IP"].ToString();
				return result;
			}
			catch (Exception)
			{
				return "get ip error";
			}
		}
		#endregion

		#region 字串轉換處理
		#region FormStr 轉換 Client 端 Script 處理的特殊符號(', \r\n, \n, \r)
		/// <summary>
		/// 轉換 Client 端 Script 處理的特殊符號(', \r\n, \n, \r)
		/// </summary>
		/// <param name="str">輸入字串</param>
		/// <returns>處理後字串</returns>
		public static string FormStr(Object str)
		{
			return NullToSpace(str).Replace("\\", "\\\\").Replace("'", "\\'").Replace("\r\n", "\\r\\n").Replace("\n", "\\n").Replace("\r", "\\r");
		}
		#endregion

		#region InputStr 轉換 Input 處理的特殊符號, 將 ' 轉換成 ＆＃３９；
		/// <summary>
		/// 轉換 Input 處理的特殊符號, 將 ' 轉換成 ＆＃３９；
		/// </summary>
		/// <param name="str">輸入字串</param>
		/// <returns>號轉後的字串</returns>
		public static string InputStr(Object str)
		{
			return NullToSpace(str).Replace("'", "&#39;");
		}
		#endregion

		#region DBStr 轉換要寫入db 的字串, ' 轉換成 ''
		/// <summary>
		/// 轉換要寫入db 的字串, ' 轉換成 ''
		/// </summary>
		/// <param name="str">輸入字串</param>
		/// <returns>處理後的字串</returns>
		public static string DBStr(Object str)
		{
			//return Replace(CheckNull(str, ""), "'", "''");
			return CheckNull(str, "").Replace("'", "''");
		}
		#endregion

		#region NullToSpace 將 Null 轉換成空白
		/// <summary>
		/// 將 Null 轉換成空白
		/// </summary>
		/// <param name="str">輸入物件</param>
		/// <returns>處理後字串</returns>
		public static string NullToSpace(Object str)
		{
			return CheckNull(str, "");
		}
		#endregion

		#region NullToSpace 將 Null 轉換成空白
		/// <summary>
		/// 若為 Null, 則傳回設定值
		/// </summary>
		/// <param name="obj">原始的物件</param>
		/// <param name="defaultvalue">設定值</param>
		/// <returns>處理後的字串</returns>
		public static string CheckNull(Object obj, string defaultvalue)
		{
			if (obj == null)
				return defaultvalue;
			else if (Convert.IsDBNull(obj))
				return defaultvalue;
			else
				return obj.ToString();
		}
		#endregion

		#region DateStr 轉換要寫入db 的字串, 民國日期 yyymmdd 轉換成 TO_DATE('yyyy/mm/dd', 'yyyy/MM/dd') For Oracle
		/// <summary>
		/// 轉換要寫入db 的字串, 民國日期 yyymmdd 轉換成 TO_DATE('yyyy/mm/dd', 'yyyy/MM/dd') For Oracle
		/// </summary>
		/// <param name="str">輸入日期字串 yyymmdd</param>
		/// <returns>處理後的字串</returns>
		public static string DateStr(Object str)
		{
			if (str == null)
				throw new ArgumentNullException("str");

			if (string.IsNullOrEmpty(str.ToString()))
				return	"NULL";
			else
				return	"TO_DATE('" + DateUtil.ConvertCDate(str.ToString(), "yyyy/MM/dd") + "', 'yyyy/MM/dd')";
		}
		#endregion

		#region DateTimeStr 轉換要寫入 db 的字串, 西元日期時間 yyyy/mm/dd hh:mm:ss 轉換成 TO_DATE('yyyy/mm/dd hh:mm:ss', 'yyyy/MM/dd HH:MI:SS')
		/// <summary>
		/// 轉換要寫入 db 的字串, 西元日期時間 yyyy/mm/dd hh:mm:ss 轉換成 TO_DATE('yyyy/mm/dd hh:mm:ss', 'yyyy/MM/dd HH:MI:SS')
		/// </summary>
		/// <param name="str">輸入字串 yyyy/mm/dd hh:mm:ss</param>
		/// <returns>處理後的字串</returns>
		public static string DateTimeStr(Object str)
		{
			string	result	=	Utility.CheckNull(str, "");
			if (!string.IsNullOrEmpty(result))
				result	=	"TO_DATE('" + result + "', 'yyyy/MM/dd HH24:MI:SS')";
			return result;
		}
		#endregion

		#region CsvConvert 轉換 CVS 檔案的特殊符號 "	
		/// <summary>
		/// 轉換 CVS 檔案的特殊符號 
		/// </summary>
		/// <param name="str">要處理的字串</param>
		/// <returns>處理後的字串</returns>
		public static string CsvConvert(object str)
		{
			return CsvConvert(str, true);
		}

		/// <summary>
		/// 轉換 CVS 檔案的特殊符號 001->="001"
		/// </summary>
		/// <param name="str">要處理的字串</param>
		/// <param name="isZeroStart">是否 0 開頭字串 Exp: 000123</param>
		/// <returns>處理後的字串</returns>
		public static string CsvConvert(object str, bool isZeroStart)
		{
			if (!isZeroStart)
				return str.ToString();

			str	=	NullToSpace(str);

			if (str.ToString().IndexOf("\r\n") != -1)
				return "\"" + str.ToString() + "\"";
			else if (str.ToString().IndexOf(",") == -1)
				return "=\"" + str.ToString() + "\"";
			else
				return "\"" + str.ToString() + "\"";
		}
		#endregion

		#region ArrayListToString 轉換 ArrayList 成字串	
		/// <summary>
		/// 轉換 ArrayList 成字串 
		/// </summary>
		/// <param name="al">要處理的 ArrayList</param>
		/// <returns>處理後的字串</returns>
		public static string ArrayListToString(ArrayList al)
		{
			StringBuilder	buff	=	new StringBuilder();
			for (int i = 0; i < al.Count; i++)
			{
				if (i == 0)
					buff.Append(al[i].ToString());
				else
					buff.Append(", " + al[i].ToString());
			}
			
			return buff.ToString();
		}
		#endregion
		#endregion
	}
}
