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
	#region �����j�p�g��磌��
	/// <summary>
	/// EntityColumnCompare �мg
	/// </summary>
	public class EntityColumnCompare : IEqualityComparer
	{
		/// <summary>
		/// ��@ Equals
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public new bool Equals(object x, object y)
		{
			return x.Equals(y);
		}

		/// <summary>
		/// ��@ GetHashCode
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
	/// �B�z�@�몺�@�Ψ禡
	/// </summary>
	public class Utility
	{
		#region �r��B�z
		#region Substring �̾گ��ި��r���
		/// <summary>
		/// �̾گ��ި��r���
		/// </summary>
		/// <param name="content">�n�B�z���</param>
		/// <param name="startIndex">�_�l����</param>
		/// <param name="endIndex">��������</param>
		/// <returns>���o���r��</returns>
		public static string Substring(string content, int startIndex, int endIndex)
		{
			if (content == null)
				throw new ArgumentNullException("content");
			return content.Substring(startIndex, endIndex - startIndex);
		}
		#endregion

		#region StrToFullSize �N�ǤJ���r�ꤤ�A���b�Ϊ��^��μƦr�אּ���Ϋ�ǥX
		/// <summary>
		/// �N�ǤJ���r�ꤤ�A���b�Ϊ��^��μƦr�אּ���Ϋ�ǥX
		/// </summary>
		/// <param name="str">��l���r�ꤺ�e</param>
		/// <returns>�B�z��r��</returns>
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

		#region CharToFullSize �N�t���b�Ϊ��r���אּ���Ϊ��Ǧ^
		/// <summary>
		/// �N�t���b�Ϊ��r���אּ���Ϊ��Ǧ^
		/// </summary>
		/// <param name="str">�t���b�Ϊ��r��</param>
		/// <returns>�B�z��r��</returns>
		public static string CharToFullSize(char str)
		{
			string	oStr	=	"0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string	nStr	=	"������������������������������������������������������@�A�B�C�ϢТѢҢӢԢբ֢ע٢ڢۢܢݢޢߢ���������";
			if (oStr.IndexOf(str) == -1)
				return str.ToString();
			return nStr.Substring(oStr.IndexOf(str), 1);
		}
		#endregion

		#region ConvertStr �N�r��ϦV
		/// <summary>
		/// �N�r��ϦV, �Ҧp: �ǤJ '1234', �Ǧ^ '4321'
		/// </summary>
		/// <param name="str">���ϦV���r��</param>
		/// <returns>�B�z�᪺�r��</returns>
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

		#region Replace �B�z�m���Y�r��ʧ@
		[Obsolete]
		///// <summary>
		///// �B�z�m���Y�r��ʧ@
		///// </summary>
		///// <param name="str">��l���r�ꤺ�e</param>
		///// <param name="oldStr">�n�Q�m�����r�ꤺ�e</param>
		///// <param name="newStr">�m���᪺�r�ꤺ�e</param>
		///// <returns>�B�z��r��</returns>
		public static string Replace(string str, string oldStr, string newStr)
		{
			if (str == null)
				throw new ArgumentNullException("str");
			if (oldStr == null)
				throw new ArgumentNullException("oldStr");
			if (newStr == null)
				throw new ArgumentNullException("newStr");

			//=== �ѨM�ǪŦr��|�Ӧ����� Bug ===
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

		#region Split �N�r��̫��w�Ÿ����ά��}�C
		/// <summary>
		/// �N�r��̫��w�Ÿ����ά��}�C
		/// </summary>
		/// <param name="str">�����Ϊ��r��</param>
		/// <param name="delim">���w�Ÿ�</param>
		/// <returns>���Ϋ�}�C</returns>
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

		#region CloneStr �N�r��ƻs�]�w����
		/// <summary>
		/// �N�r��ƻs�]�w����
		/// EX: "abcabcabc" = CloneStr("abc", 3)
		/// </summary>
		/// <param name="str">���w�n���Ъ��r�ꤺ�e</param>
		/// <param name="len">���w�n���Ъ�����</param>
		/// <returns>�B�z��r��</returns>
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

		#region CloneStr �N�r���ƻs�]�w����
		[Obsolete]
		///// <summary>
		///// �N�r���ƻs�]�w����
		///// EX: "000" = cloneStr('0', 3)
		///// </summary>
		///// <param name="str">���w�n���Ъ��r�����e</param>
		///// <param name="len">���w�n���Ъ�����</param>
		///// <returns>�B�z��r��</returns>
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

		#region ChkLen �ˬd�ǤJ�r�ꪺ���׬O�_���W�L�]�w����
		/// <summary>
		/// �ˬd�ǤJ�r�ꪺ���׬O�_���W�L�]�w����
		/// </summary>
		/// <param name="str">��l�r��</param>
		/// <param name="strLen">�ˮ֪�����</param>
		/// <returns>�ˬd�����G</returns>
		private static Boolean ChkLen(string str, int strLen)
		{
			if(str.Length <= strLen)
				return true;
			else
				return false;
		}
		#endregion

		#region RTrim �M���r��k�䪺�ť�
		/// <summary>
		/// �M���r��k�䪺�ť�
		/// </summary>
		/// <param name="str">�n�B�z���r��</param>
		/// <returns>�B�z�᪺�r��</returns>
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

		#region GetBLen ���o�ɮת���(���嬰��X)
		/// <summary>
		/// ���o�ɮת���(���嬰��X)
		/// </summary>
		/// <param name="str">�P�_���ת��r��</param>
		/// <returns>�Ǧ^����</returns>
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
		
		#region Tag �B�z
		#region GetTagStr ���o Tag �ҥ]�t�r�� Exp: [abc] --> abc
		/// <summary>
		/// ���o Tag �ҥ]�t�r�� Exp: [abc] --> abc
		/// </summary>
		/// <param name="content">�n�B�z���r��</param>
		/// <param name="startTag">�_�l Tag �Ÿ�</param>
		/// <param name="endTag">���� Tag �Ÿ�</param>
		/// <returns>���o��r��</returns>
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

		#region GetTagList ���o Tag �ҥ]�t�r�� Exp: [abc]123[456] --> {abc, 456}
		/// <summary>
		/// ���o Tag �ҥ]�t�r�� Exp: [abc]123[456] --> {abc, 456}
		/// </summary>
		/// <param name="content">�n�B�z���r��</param>
		/// <param name="startTag">�_�l Tag �Ÿ�</param>
		/// <param name="endTag">���� Tag �Ÿ�</param>
		/// <returns>���o��r��}�C</returns>
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

		#region EncryptTagContent �N {} �Ϲj�����e�s�X
		/// <summary>
		/// �N {} �Ϲj�����e�s�X
		/// </summary>
		/// <param name="content">���s�X���e</param>
		/// <returns>�s�X�L�����e</returns>
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

		#region DecryptTagContent �N Tag �ѽX
		/// <summary>
		/// �N Tag �ѽX
		/// </summary>
		/// <param name="content">���ѽX���e</param>
		/// <returns>�ѽX�L�����e</returns>
		public static string DecryptTagContent(string content)
		{
			ArrayList	list	=	Utility.GetTagList(content, "{", "}");

			for (int i = 0; i < list.Count; i++)
			{
				//2011/06/24 nono �[�W�קK�X�ʵ{���y���~�P
				if (!list[i].ToString().ToUpper().Contains("IBM DB2 ODBC DRIVER"))
					content		=	content.Replace("{" + list[i] + "}", DecryptStr(list[i].ToString()));
			}
			return content;
		}
		#endregion
		#endregion

		#region �[�ѱK
		#region TripleDesEncrypt �N�r��[�K
		/// <summary>
		/// TripleDesEncrypt �N�r��[�K
		/// </summary>
		/// <param name="str">�n�[�K���r��</param>
		/// <returns>�[�K��r��</returns>
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

		#region TripleDesDecrypt �N�r��ѱK
		/// <summary>
		/// TripleDesDecrypt �N�r��ѱK
		/// </summary>
		/// <param name="str">�n�ѱK���r��</param>
		/// <returns>�ѱK��r��</returns>
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

		#region GenerateTripleDesKey ���� 3Des �� Key
		/// <summary>
		/// ���� 3Des �� Key
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

		#region GenerateTripleDesKey ���� 3Des �� IV
		/// <summary>
		/// ���� 3Des �� IV
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

		#region EncryptStr �N�r��s�X
		/// <summary>
		/// �N�r��s�X
		/// </summary>
		/// <param name="str">�n�s�X���r��</param>
		/// <returns>�s�X��r��</returns>
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

		#region DecryptStr �N�r��ѽX
		/// <summary>
		/// �N�r��ѽX
		/// </summary>
		/// <param name="str">�n�ѽX���r��</param>
		/// <returns>�ѽX�᪺�r��</returns>
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
				throw new Exception("�r��ѱK���~:" + str + "," + ex.Message);
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

		#region GenerateKey ���� Des �� Key
		/// <summary>
		/// ���� Des �� Key
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

		#region �Ʀr��j�g
		/// <summary>
		/// �N�Ʀr�r���ഫ�����媺�Ʀr��Ʈ榡
		/// Exp: 12345.06
		/// ���� 0:�@�U�G�d�s�|�Q���I�s��,
		/// 1:���U�L�a�s�v�B���I�s��,
		/// 2:�@�U�G�d�s�|�Q���I����, 1234506
		/// 3:�@�G���|������
		/// ���`�N����'3'�@�묰�ഫ�����Ʀr���i��J�D�Ʀr���A���
		/// </summary>
		/// <param name="strNum">�n�ഫ���Ʀr</param>
		/// <param name="cNumType">�ഫ�榡</param>
		/// <returns>�ഫ��r��</returns>
		public static string GetCNum(int strNum, int cNumType)
		{
			return GetCNum(Convert.ToString(strNum, 10), cNumType);
		}

		/// <summary>
		/// �N�Ʀr�r���ഫ�����媺�Ʀr��Ʈ榡
		/// Exp: 12345.06
		/// ���� 0:�@�U�G�d�s�|�Q���I�s��,
		/// 1:���U�L�a�s�v�B���I�s��,
		/// 2:�@�U�G�d�s�|�Q���I����, 1234506
		/// 3:�@�G���|������
		/// ���`�N����'3'�@�묰�ഫ�����Ʀr���i��J�D�Ʀr���A���
		/// </summary>
		/// <param name="strNum">�n�ഫ���Ʀr</param>
		/// <param name="cNumType">�ഫ�榡</param>
		/// <returns>�ഫ��r��</returns>
		public static string GetCNum(double strNum, int cNumType)
		{
			return GetCNum(Convert.ToString(strNum), cNumType);
		}

		/// <summary>
		/// �N�Ʀr�r���ഫ�����媺�Ʀr��Ʈ榡
		/// Exp: 12345.06
		/// ���� 0:�@�U�G�d�s�|�Q���I�s��,
		/// 1:���U�L�a�s�v�B���I�s��,
		/// 2:�@�U�G�d�s�|�Q���I����, 1234506
		/// 3:�@�G���|������
		/// ���`�N����'3'�@�묰�ഫ�����Ʀr���i��J�D�Ʀr���A���
		/// </summary>
		/// <param name="strNum">�n�ഫ���Ʀr</param>
		/// <param name="cNumType">�ഫ�榡</param>
		/// <returns>�ഫ��r��</returns>
		public static string GetCNum(long strNum, int cNumType)
		{
			return GetCNum(Convert.ToString(strNum, 10), cNumType);
		}

		/// <summary>
		/// �N�Ʀr�r���ഫ�����媺�Ʀr��Ʈ榡
		/// Exp: 12345.06
		/// ���� 0:�@�U�G�d�s�|�Q���I�s��,
		/// 1:���U�L�a�s�v�B���I�s��,
		/// 2:�@�U�G�d�s�|�Q���I����, 1234506
		/// 3:�@�G���|������
		/// ���`�N����'3'�@�묰�ഫ�����Ʀr���i��J�D�Ʀr���A���
		/// </summary>
		/// <param name="strNum">�r��榡���Ʀr���e</param>
		/// <param name="cNumType">�ഫ�榡</param>
		/// <returns>�Ǧ^���媺�Ʀr�r�X</returns>
		public static string GetCNum(string strNum, int cNumType)
		{
			if (strNum == null)
				throw new ArgumentNullException("strNum");

			if (cNumType > 3 || cNumType < 0)
				throw new ArgumentException("cNumType �Ѽƥ����� 0, 1, 2, 3 �䤤�@��, �ثe�ǤJ�Ȭ�: " + cNumType);

			if (string.IsNullOrEmpty(strNum))
				return "";

			StringBuilder	cStrNumSection		=	new StringBuilder();		//����Ʀr���q
			StringBuilder	resultStr		=	new StringBuilder();		//�^�ǭ�
			string		chineseNum		=	"";				//�]�w��
			string		chineseNum0		=	"�s�@�G�T�|�����C�K�E";		//����Ʀr���A�@
			string		chineseNum1		=	"�s���L�Ѹv��m�èh";		//����Ʀr���A�G
			string		chineseNum2		=	"���@�G�T�|�����C�K�E";		//����Ʀr���A�T
			string		chineseNum3		=	"���@�G�T�|�����C�K�E";		//����Ʀr���A�|(�����ഫ)

			string		tmpStrNum		=	strNum.ToString();		//�Ȧs�ǤJ���Ʀr
			string		tmpIntStrNum		=	"";				//�Ȧs�ǤJ���Ʀr(��Ƴ���)
			string		tmpStrNumSection	=	"";				//�Ʀr���q

			int		posOfDecimalPoint	=	0;				//�p���I��m
			int		digit			=	0;				//���
			Boolean		inZero			=	true;				//�O�_���["�s"
			Boolean		minus			=	true;				//�O�_�t��

			//�̺����P�O����Ʀr���A
			if(cNumType == 0)
				chineseNum	=	chineseNum0;
			if(cNumType == 1)
				chineseNum	=	chineseNum1;
			if(cNumType == 2)
				chineseNum	=	chineseNum2;
			if(cNumType == 3)	//�M���B�z�����ഫ
			{
				chineseNum	=	chineseNum3;

				for(int i = -1; i < tmpStrNum.Length - 1; i++)
				{
					if (tmpStrNum.Substring(i + 1, 1).Equals("."))
						resultStr.Append("�E");
					else
					{
						try
						{
							digit	=	Convert.ToInt32(tmpStrNum.Substring(i + 1, 1), 10);
						}
						catch(Exception)
						{
							throw new ArgumentException("�i�ǤJ�Ѽƥ]�t�D�Ʀr���A���, strNum:" + strNum + "�j");
						}
						resultStr.Append(chineseNum.Substring(digit, 1));
					}
				}
				return	resultStr.ToString();
			}

			//�P�O�O�_�t��
			if (tmpStrNum.StartsWith("-"))//�t��
			{
				minus		=	true;
				tmpStrNum	=	Utility.Substring(tmpStrNum, 1, tmpStrNum.Length);
			}
			else	//����
				minus	=	false;

			//���o�p���I����m
			posOfDecimalPoint	=	tmpStrNum.IndexOf(".");

			//���B�z��ƪ�����
			if (posOfDecimalPoint <= 0)
				tmpIntStrNum	=	ConvertStr(tmpStrNum);
			else
				tmpIntStrNum	=	ConvertStr(Utility.Substring(tmpStrNum, 0, posOfDecimalPoint));

			//�q�Ӧ�ư_�H�C�|��Ƭ��@�p�`
			for(int sectionIndex = 0; sectionIndex <= (tmpIntStrNum.Length - 1) / 4; sectionIndex++)
			{
				//���o�|��ƪ��r����
				if(sectionIndex * 4 + 4 < tmpIntStrNum.Length)
					tmpStrNumSection	=	Utility.Substring(tmpIntStrNum, sectionIndex * 4, sectionIndex * 4 + 4);
				else
					tmpStrNumSection	=	Utility.Substring(tmpIntStrNum, sectionIndex * 4, tmpIntStrNum.Length);

				//�M�ť|��ƪ�����Ʀr���
				cStrNumSection.Length	=	0;

				/* �H�U�� i ����: �ӤQ�ʤd��|�Ӧ�� */
				for(int i = 0; i < tmpStrNumSection.Length; i++)
				{
					digit	= Convert.ToInt32(tmpStrNumSection.Substring(i, 1), 10);
					if (digit == 0)
					{
						// 1. �קK '�s' �����ХX�{
						// 2. �Ӧ�ƪ� 0 �����ন '�s'
						if (!inZero && i != 0)
							cStrNumSection.Insert(0, "�s");
						inZero	=	true;
					}
					else
					{
						if(cNumType == 1)
						{
							switch(i)
							{
								case 1 :
									cStrNumSection.Insert(0, "�B");
									break;
								case 2 :
									cStrNumSection.Insert(0, "��");
									break;
								case 3 :
									cStrNumSection.Insert(0, "�a");
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
									cStrNumSection.Insert(0, "�Q");
									break;
								case 2 :
									cStrNumSection.Insert(0, "��");
									break;
								case 3 :
									cStrNumSection.Insert(0, "�d");
									break;
								default :
									break;
							}
						}
						cStrNumSection.Insert(0, chineseNum.Substring(digit, 1));
						inZero	=	false;
					}
				}

				//�[�W�Ӥp�`�����
				if (cStrNumSection.Length == 0)
				{
					if (resultStr.Length > 0 && resultStr.ToString().Substring(0, 1).Equals("�s"))
						resultStr.Insert(0, "�s");
				}
				else
				{
					switch(sectionIndex)
					{
						case 0:
							resultStr.Append(cStrNumSection.ToString());
							break;
						case 1:
							resultStr.Insert(0, cStrNumSection.ToString() + "�U");
							break;
						case 2:
							resultStr.Insert(0, cStrNumSection.ToString() + "��");
							break;
						case 3:
							resultStr.Insert(0, cStrNumSection.ToString() + "��");
							break;
						default :
							break;
					}
				}
			}

			//�B�z�p���I�k�䪺����
			if (posOfDecimalPoint > 0)
			{
				resultStr.Append("�I");
				for(int i = posOfDecimalPoint; i < tmpStrNum.Length - 1; i++)
				{
					digit		=	Convert.ToInt32(tmpStrNum.Substring(i + 1, 1), 10);
					resultStr.Append(chineseNum.Substring(digit, 1));
				}
			}

			//��L�ҥ~���p���B�z
			if (resultStr.Length == 0)
				resultStr.Append("�s");
			if (resultStr.Length>= 2 && (resultStr.ToString().Substring(0, 2).Equals("�@�Q") || resultStr.ToString().Substring(0, 2).Equals("���Q")))
			{
				resultStr.Remove(0, 1);
			}
			if (resultStr.ToString().Substring(0, 1).Equals("�I"))
				resultStr.Insert(0, "�s");

			/* �O�_���t�� */
			if (minus)
				resultStr.Insert(0, "�t");

			return resultStr.ToString();
		}
		#endregion

		#region �񺡦r��B�z
		#region FillStr �N�r��̳]�w���׶񺡬Y�r��(���e��)
		[Obsolete]
		///// <summary>
		///// �N�r��̳]�w���׶񺡬Y�r��(���e��)
		///// Exp: Utility.FillStr("A", 10, '*'); --> '*********A'
		///// </summary>
		///// <param name="str">���B�z�r��</param>
		///// <param name="strLen">���w����</param>
		///// <param name="fill">���ɺ��r��</param>
		///// <returns>�B�z��r��</returns>
		public static string FillStr(string str, int strLen, char fill)
		{
			if(ChkLen(str, strLen))
				return CloneStr(fill, strLen - GetBLen(str)) + str;
			else
				return str;
		}
		#endregion

		#region FillBackStr �N�r��̳]�w���׶񺡬Y�r��(�����)
		[Obsolete]
		///// <summary>
		///// �N�r��̳]�w���׶񺡬Y�r��(�����)
		///// Exp: Utility.FillBackStr("A", 10, '*'); --> 'A*********'
		///// </summary>
		///// <param name="str">���B�z�r��</param>
		///// <param name="strLen">���w����</param>
		///// <param name="fill">���ɺ��r��</param>
		///// <returns>�B�z��r��</returns>
		public static string FillBackStr(string str, int strLen, char fill)
		{
			if(ChkLen(str, strLen))
				return str + CloneStr(fill, strLen - GetBLen(str));
			else
				return str;
		}
		#endregion

		#region FillZero �N�r��̳]�w���׶� 0(���e��)
		///// <summary>
		///// �N�r��̳]�w���׶� 0(���e��)
		///// </summary>
		///// <param name="str">���B�z�r��</param>
		///// <param name="len">���w����</param>
		///// <returns>�B�z��r��</returns>
		[Obsolete]
		public static string FillZero(string str, int len)
		{
			return Utility.FillStr(str, len, '0');
		}
		#endregion
		
		#region FillBackZero �N�r��̳]�w���׶� 0(�����)
		[Obsolete]
		///// <summary>
		///// �N�r��̳]�w���׶� 0(�����)
		///// </summary>
		///// <param name="str">���B�z�r��</param>
		///// <param name="len">���w����</param>
		///// <returns>�B�z��r��</returns>
		public static string FillBackZero(string str, int len)
		{
			return Utility.FillBackStr(str, len, '0');
		}
		#endregion
		#endregion

		#region �ˬd��k
		#region IsIPFormat �O�_ IP �榡
		/// <summary>
		/// �O�_ IP �榡
		/// </summary>
		/// <param name="ip">���ˬd�r��</param>
		/// <returns>�O/�_</returns>
		public static bool IsIPFormat(string ip)
		{
			string[]	ipAry	=	ip.Split('.');
			//=== �D x.x.x.x �^�ǧ_ ===
			if (ipAry.Length != 4)
				return false;

			Regex	reg	=	null;
			for (int i = 0; i < ipAry.Length; i++)
			{
				reg	=	new Regex("[^0-9]");
				//=== �D '�Ʀr'�^�ǧ_ ===
				if (reg.IsMatch(ipAry[i]))
					return false;
				//=== 0 or > 255 �^�ǧ_ ===
				if (int.Parse(ipAry[i]) == 0 || int.Parse(ipAry[i]) > 255)
					return false;
			}

			return true;
		}
		#endregion
		#endregion

		#region GetIP ���o Client IP ��}, �� Session("IP") ���ȫh�H Session ���D
		/// <summary>
		/// ���o Client IP ��}, �� Session("IP") ���ȫh�H Session ���D
		/// </summary>
		/// <returns>IP ��}</returns>
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

		#region �r���ഫ�B�z
		#region FormStr �ഫ Client �� Script �B�z���S��Ÿ�(', \r\n, \n, \r)
		/// <summary>
		/// �ഫ Client �� Script �B�z���S��Ÿ�(', \r\n, \n, \r)
		/// </summary>
		/// <param name="str">��J�r��</param>
		/// <returns>�B�z��r��</returns>
		public static string FormStr(Object str)
		{
			return NullToSpace(str).Replace("\\", "\\\\").Replace("'", "\\'").Replace("\r\n", "\\r\\n").Replace("\n", "\\n").Replace("\r", "\\r");
		}
		#endregion

		#region InputStr �ഫ Input �B�z���S��Ÿ�, �N ' �ഫ�� ���������F
		/// <summary>
		/// �ഫ Input �B�z���S��Ÿ�, �N ' �ഫ�� ���������F
		/// </summary>
		/// <param name="str">��J�r��</param>
		/// <returns>����᪺�r��</returns>
		public static string InputStr(Object str)
		{
			return NullToSpace(str).Replace("'", "&#39;");
		}
		#endregion

		#region DBStr �ഫ�n�g�Jdb ���r��, ' �ഫ�� ''
		/// <summary>
		/// �ഫ�n�g�Jdb ���r��, ' �ഫ�� ''
		/// </summary>
		/// <param name="str">��J�r��</param>
		/// <returns>�B�z�᪺�r��</returns>
		public static string DBStr(Object str)
		{
			//return Replace(CheckNull(str, ""), "'", "''");
			return CheckNull(str, "").Replace("'", "''");
		}
		#endregion

		#region NullToSpace �N Null �ഫ���ť�
		/// <summary>
		/// �N Null �ഫ���ť�
		/// </summary>
		/// <param name="str">��J����</param>
		/// <returns>�B�z��r��</returns>
		public static string NullToSpace(Object str)
		{
			return CheckNull(str, "");
		}
		#endregion

		#region NullToSpace �N Null �ഫ���ť�
		/// <summary>
		/// �Y�� Null, �h�Ǧ^�]�w��
		/// </summary>
		/// <param name="obj">��l������</param>
		/// <param name="defaultvalue">�]�w��</param>
		/// <returns>�B�z�᪺�r��</returns>
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

		#region DateStr �ഫ�n�g�Jdb ���r��, ������ yyymmdd �ഫ�� TO_DATE('yyyy/mm/dd', 'yyyy/MM/dd') For Oracle
		/// <summary>
		/// �ഫ�n�g�Jdb ���r��, ������ yyymmdd �ഫ�� TO_DATE('yyyy/mm/dd', 'yyyy/MM/dd') For Oracle
		/// </summary>
		/// <param name="str">��J����r�� yyymmdd</param>
		/// <returns>�B�z�᪺�r��</returns>
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

		#region DateTimeStr �ഫ�n�g�J db ���r��, �褸����ɶ� yyyy/mm/dd hh:mm:ss �ഫ�� TO_DATE('yyyy/mm/dd hh:mm:ss', 'yyyy/MM/dd HH:MI:SS')
		/// <summary>
		/// �ഫ�n�g�J db ���r��, �褸����ɶ� yyyy/mm/dd hh:mm:ss �ഫ�� TO_DATE('yyyy/mm/dd hh:mm:ss', 'yyyy/MM/dd HH:MI:SS')
		/// </summary>
		/// <param name="str">��J�r�� yyyy/mm/dd hh:mm:ss</param>
		/// <returns>�B�z�᪺�r��</returns>
		public static string DateTimeStr(Object str)
		{
			string	result	=	Utility.CheckNull(str, "");
			if (!string.IsNullOrEmpty(result))
				result	=	"TO_DATE('" + result + "', 'yyyy/MM/dd HH24:MI:SS')";
			return result;
		}
		#endregion

		#region CsvConvert �ഫ CVS �ɮת��S��Ÿ� "	
		/// <summary>
		/// �ഫ CVS �ɮת��S��Ÿ� 
		/// </summary>
		/// <param name="str">�n�B�z���r��</param>
		/// <returns>�B�z�᪺�r��</returns>
		public static string CsvConvert(object str)
		{
			return CsvConvert(str, true);
		}

		/// <summary>
		/// �ഫ CVS �ɮת��S��Ÿ� 001->="001"
		/// </summary>
		/// <param name="str">�n�B�z���r��</param>
		/// <param name="isZeroStart">�O�_ 0 �}�Y�r�� Exp: 000123</param>
		/// <returns>�B�z�᪺�r��</returns>
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

		#region ArrayListToString �ഫ ArrayList ���r��	
		/// <summary>
		/// �ഫ ArrayList ���r�� 
		/// </summary>
		/// <param name="al">�n�B�z�� ArrayList</param>
		/// <returns>�B�z�᪺�r��</returns>
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
