using System;
using System.Text;
using System.Collections;
using System.Web;
using Acer.Form;
using Acer.Log;
using Acer.Util;
using Acer.Err;
using System.IO;
using Acer.Apps;

namespace Acer.Ajax
{
	/// <summary>
	/// ���J Javascript ����
	/// </summary>
	public class LoadScript
	{
		/// <summary>
		/// �e�ݩI�s�ϥΤ�k
		/// </summary>
		public static void DoCall()
		{
			HttpRequest	request		=	FormUtil.Request;
			HttpResponse	response	=	FormUtil.Response;

			try
			{
				//=== �]�w�s�X === 
				request.ContentEncoding	=	System.Text.Encoding.UTF8;
				response.ContentType	=	"text/html;charset=UTF-8";

				string		scriptName	=	request["scriptName"].ToString();
				Hashtable	tmpJScript	=	new Hashtable();

				//=== �P�_ Jscript �w���J�L�����^�ǼȦs����, ���ܧ�h���� ===
				if (APConfig.GetProperty("DATA_PROJECT").Equals("�F�d�j�ǤG��") || APConfig.GetProperty("DATA_PROJECT").Equals("�F�d�j�Ǥ@��")
					|| APConfig.GetProperty("DATA_PROJECT").Equals("KNUE4") || APConfig.GetProperty("DATA_PROJECT").Equals("���v�j��"))
				{
					if (FormUtil.Cache.Get("TMP_JSCRIPT_" + scriptName) != null)
					{
						response.Write(FormUtil.Cache.Get("TMP_JSCRIPT_" + scriptName).ToString());
						return;
					}
				}
				else
				{
					tmpJScript	=	(Hashtable)MultiProcess.GetDelayGlobalValue("TMP_JSCRIPT", scriptName);
					if (tmpJScript[scriptName] != null && !tmpJScript[scriptName].ToString().Equals(""))
					{
						response.Write(tmpJScript[scriptName].ToString());
						return;
					}
				}

				//=== ���o�Ѽ� === 
				ArrayList	ac	=	LoadScript.ReadResourceFile(scriptName, System.Text.Encoding.GetEncoding("BIG5"));
				StringBuilder	strBuff	=	new StringBuilder();
				strBuff		=	new StringBuilder();

				for (int i = 0; i < ac.Count; i++)
				{
					if (string.IsNullOrEmpty(strBuff.ToString()))
						strBuff.Append(ac[i]);
					else
						strBuff.Append("\r\n" + ac[i]);
				}
				string	content	=	strBuff.ToString();
				try
				{
					byte[]	bytes	=	Convert.FromBase64String(content);
					content		=	System.Text.Encoding.GetEncoding("BIG5").GetString(bytes);
					//=== ���J�O���� ===
					if (APConfig.GetProperty("DATA_PROJECT").Equals("�F�d�j�ǤG��") || APConfig.GetProperty("DATA_PROJECT").Equals("�F�d�j�Ǥ@��")
						|| APConfig.GetProperty("DATA_PROJECT").Equals("KNUE4") || APConfig.GetProperty("DATA_PROJECT").Equals("���v�j��"))
						FormUtil.Cache.Insert("TMP_JSCRIPT_" + scriptName, content, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero);
					else
					{
						tmpJScript[scriptName]	=	content;
						MultiProcess.SetGlobalValue("TMP_JSCRIPT", tmpJScript);
					}

					response.Write(System.Text.Encoding.GetEncoding("BIG5").GetString(bytes));
				}
				catch (Exception)
				{
					//=== ���ե� ===
					//=== ���J�O���� ===
					if (APConfig.GetProperty("DATA_PROJECT").Equals("�F�d�j�ǤG��") || APConfig.GetProperty("DATA_PROJECT").Equals("�F�d�j�Ǥ@��")
						|| APConfig.GetProperty("DATA_PROJECT").Equals("KNUE4") || APConfig.GetProperty("DATA_PROJECT").Equals("���v�j��"))
						FormUtil.Cache.Insert("TMP_JSCRIPT_" + scriptName, content, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero);
					else
					{
						tmpJScript[scriptName]	=	content;
						MultiProcess.SetGlobalValue("TMP_JSCRIPT", tmpJScript);
					}
					response.Write(content);
				}
			}
			catch (System.Exception ex)
			{
				MyLogger.Log(MyLogger.Error, Utility.GetIP() + "### LoadScript ###", "�Ѽ�: " + request["scriptName"].ToString() + "\r\n" + ErrUtil.ErrToStr(ex), "", 0);
				//response.Write("alert('" + request["scriptName"].ToString() + " ���J����');");
                response.Write("alert('���J����');");
			}
		}

		/// <summary>
		/// ��l�� LoadScript ���
		/// </summary>
		public static void Init()
		{
			if (!(APConfig.GetProperty("DATA_PROJECT").Equals("�F�d�j�ǤG��") || APConfig.GetProperty("DATA_PROJECT").Equals("�F�d�j�Ǥ@��")
				|| APConfig.GetProperty("DATA_PROJECT").Equals("KNUE4") || APConfig.GetProperty("DATA_PROJECT").Equals("���v�j��")))
				MultiProcess.SetGlobalValue("TMP_JSCRIPT", new Hashtable());
		}

		private static ArrayList ReadResourceFile(string fileName, System.Text.Encoding ecoding) 
		{
			StreamReader	reader	=	null;

			try
			{
				reader		=	new System.IO.StreamReader(System.Reflection.Assembly.GetAssembly(new LoadScript().GetType()).GetManifestResourceStream("AcerLibrary.Acer.Ajax.Script." + fileName), ecoding);
				
				ArrayList	content =	new ArrayList();
				string		lineStr	=	"";

				while (lineStr != null)
				{
					lineStr	=	reader.ReadLine();
					{
						if (lineStr == null)
							continue;
						else
							content.Add(lineStr);
					}
				}
				return content;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (reader != null)
					reader.Dispose();
			}
		}
	}
}
