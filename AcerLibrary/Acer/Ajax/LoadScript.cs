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
	/// 載入 Javascript 元件
	/// </summary>
	public class LoadScript
	{
		/// <summary>
		/// 前端呼叫使用方法
		/// </summary>
		public static void DoCall()
		{
			HttpRequest	request		=	FormUtil.Request;
			HttpResponse	response	=	FormUtil.Response;

			try
			{
				//=== 設定編碼 === 
				request.ContentEncoding	=	System.Text.Encoding.UTF8;
				response.ContentType	=	"text/html;charset=UTF-8";

				string		scriptName	=	request["scriptName"].ToString();
				Hashtable	tmpJScript	=	new Hashtable();

				//=== 判斷 Jscript 已載入過直接回傳暫存紀錄, 有變更則重載 ===
				if (APConfig.GetProperty("DATA_PROJECT").Equals("東吳大學二期") || APConfig.GetProperty("DATA_PROJECT").Equals("東吳大學一期")
					|| APConfig.GetProperty("DATA_PROJECT").Equals("KNUE4") || APConfig.GetProperty("DATA_PROJECT").Equals("海洋大學"))
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

				//=== 取得參數 === 
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
					//=== 載入記憶體 ===
					if (APConfig.GetProperty("DATA_PROJECT").Equals("東吳大學二期") || APConfig.GetProperty("DATA_PROJECT").Equals("東吳大學一期")
						|| APConfig.GetProperty("DATA_PROJECT").Equals("KNUE4") || APConfig.GetProperty("DATA_PROJECT").Equals("海洋大學"))
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
					//=== 測試用 ===
					//=== 載入記憶體 ===
					if (APConfig.GetProperty("DATA_PROJECT").Equals("東吳大學二期") || APConfig.GetProperty("DATA_PROJECT").Equals("東吳大學一期")
						|| APConfig.GetProperty("DATA_PROJECT").Equals("KNUE4") || APConfig.GetProperty("DATA_PROJECT").Equals("海洋大學"))
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
				MyLogger.Log(MyLogger.Error, Utility.GetIP() + "### LoadScript ###", "參數: " + request["scriptName"].ToString() + "\r\n" + ErrUtil.ErrToStr(ex), "", 0);
				//response.Write("alert('" + request["scriptName"].ToString() + " 載入失敗');");
                response.Write("alert('載入失敗');");
			}
		}

		/// <summary>
		/// 初始化 LoadScript 原件
		/// </summary>
		public static void Init()
		{
			if (!(APConfig.GetProperty("DATA_PROJECT").Equals("東吳大學二期") || APConfig.GetProperty("DATA_PROJECT").Equals("東吳大學一期")
				|| APConfig.GetProperty("DATA_PROJECT").Equals("KNUE4") || APConfig.GetProperty("DATA_PROJECT").Equals("海洋大學")))
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
