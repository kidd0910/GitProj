using System;
using System.Text;
using System.Collections;
using System.IO;
using Acer.Util;

namespace Acer.File
{
	/// <summary>
	/// 檔案處理相關共用方法
	/// </summary>
	public class FileUtil
	{
		/// <summary>
		/// 取得根目錄路徑
		/// </summary>
		/// <returns></returns>
		public static string RootPath
		{
			get{return FileUtil.LastSeparator(System.AppDomain.CurrentDomain.BaseDirectory);}
		}

		/// <summary>
		/// 判斷路徑結構是否有最後一碼 "\" 若沒有補上傳回
		/// </summary>
		/// <param name="filePath">欲判斷的路徑</param>
		/// <returns>補上的路徑結構</returns>
		public static string LastSeparator(string filePath)
		{
			if (filePath == null)
				throw new ArgumentNullException("filePath");

			if (filePath.Substring(filePath.Length - 1).Equals("\\"))
				return filePath;
			else
				return filePath + "\\";
		}

		/// <summary>
		/// 判斷檔案或目錄是否存在
		/// </summary>
		/// <param name="path">欲判斷的路徑</param>
		/// <returns>是 - 存在, 否 - 不存在</returns>
		public static Boolean FileExists(string path)
		{
			if (path == null)
				throw new ArgumentNullException("path");

			return System.IO.File.Exists(path) || Directory.Exists(path);
		}

		/// <summary>
		/// 依據傳入的檔案路徑取出檔案目錄
		/// Exp: c:\xx\x1\x2\xx.txt --> c:\xx\x1\x2\
		/// </summary>
		/// <param name="path">檔案路徑</param>
		/// <returns>檔案目錄</returns>
		public static string GetFolderName(string path)
		{
			if (path == null)
				throw new ArgumentNullException("path");
			
			return path.Substring(0, path.LastIndexOf("\\") + 1);
		}

		/// <summary>
		/// 根據傳入之檔案位置, 判斷此目錄是否存在, 若不存在, 則建立此一目錄
		/// 可建立 N 層的結構
		/// </summary>
		/// <param name="path">預建立的目錄路徑</param>
		public static void CreateDir(string path)
		{
			//=== nono 2009/04/16 add, fix unc 路徑會有問題 Bug ===
			path	=	path.Replace(@"\/", @"\").Replace("/", @"\");
			if (FileUtil.FileExists(path))
				return;

			string[]	pathAry		=	Utility.Split(path, "\\");
			StringBuilder	filePath	=	new StringBuilder();

			for (int i = 0; i < pathAry.Length; i++)
			{
				if (!string.IsNullOrEmpty(filePath.ToString()))
					filePath.Append("\\" + pathAry[i]);
				else
					filePath.Append(pathAry[i]);

				if (string.IsNullOrEmpty(filePath.ToString()))
					continue;

				if (!FileUtil.FileExists(filePath.ToString()))
					Directory.CreateDirectory(filePath.ToString());
			}
		}

		/// <summary>
		/// 根據傳入之檔案位置, 判斷此目錄是否存在, 若不存在, 則建立此一目錄檔案
		/// 可建立 N 層的結構
		/// </summary>
		/// <param name="path">預建立的檔案路徑</param>
		public static void CreateFile(string path)
		{
			if (path == null)
				throw new ArgumentNullException("path");

			if (FileUtil.FileExists(path))
				return;

			FileUtil.CreateDir(FileUtil.GetFolderName(path));
			
			FileStream file	=	System.IO.File.Create(path);
			file.Close();
		}

        /// <summary>
        /// 根據傳入之檔案位置, 判斷此目錄是否存在, 若不存在, 則建立此一目錄檔案
        /// 可建立 N 層的結構
        /// </summary>
        /// <param name="path">預建立的檔案路徑</param>
        public static void CreateFileUTF8(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            if (FileUtil.FileExists(path))
                return;

            FileUtil.CreateDir(FileUtil.GetFolderName(path));

           StreamWriter   file = System.IO.File.CreateText(path);
            file.Close();
        }

        /// <summary>
        /// 依據傳入的檔案路徑取出檔案名稱
        /// Exp: c:\xx\x1\x2\xx.txt --> xx.txt
        /// </summary>
        /// <param name="path">檔案路徑</param>
        /// <returns>檔案名稱</returns>
        public static string GetFileName(string path)
		{
			return path.Substring(path.LastIndexOf("\\") + 1);
		}

		/// <summary>
		/// 移動檔案(包含子目錄)
		/// </summary>
		/// <param name="sourcePath">來源檔案路徑</param>
		/// <param name="targetPath">要移動至的檔案路徑</param>
		public static void MoveFile(string sourcePath, string targetPath)
		{
			if (!System.IO.File.Exists(sourcePath))
			{
				return;
				//throw new FileNotFoundException("找不到該檔案 sourcePath: " + sourcePath);
			}
			
			try
			{
				System.IO.File.Move(sourcePath, targetPath);
			}
			catch (Exception ex)
			{
				if (ex.Message.Contains("處理序"))
				{
					System.Threading.Thread.Sleep(200);
					MoveFile(sourcePath, targetPath);
				}
				else
					throw;
			}
		}

		/// <summary>
		/// 刪除目錄或檔案(包含子目錄)
		/// </summary>
		/// <param name="path">要刪除的檔案或目錄路徑</param>
		public static void DelFile(string path)
		{
		        if (Directory.Exists(path))
		        {
		                string[]	tmpfiles	=	Directory.GetFiles(path);
				for(int i = 0; i < tmpfiles.Length; i++)
		                       System.IO.File.Delete(tmpfiles[i]);
				
				string[]	tmpDirs		=	Directory.GetDirectories(path);
				for(int i = 0; i < tmpDirs.Length; i++)
					DelFile(tmpDirs[i]);

				Directory.Delete(path);
		        }
		        else
				System.IO.File.Delete(path);
		}
		
		/// <summary>
		/// 讀取檔案內容至 ArrayList
		/// </summary>
		/// <param name="filePath">檔案路徑</param>
		/// <param name="skipStr">排除的字首字串</param>
		/// <param name="ecoding">編碼方式</param>
		/// <returns>檔案內容</returns>
		public static ArrayList ReadFile(string filePath, string skipStr, System.Text.Encoding ecoding)
		{
			if (!System.IO.File.Exists(filePath))
				throw new FileNotFoundException("找不到欲讀取的檔案 filePath: " + filePath);

			StreamReader	reader	=	null;

			try
			{
				ArrayList	content =	new ArrayList();
				string		lineStr	=	"";

				reader	=	new StreamReader(filePath, ecoding);

				while (lineStr != null)
				{
					lineStr	=	reader.ReadLine();
					{
						if (string.IsNullOrEmpty(lineStr) || (!string.IsNullOrEmpty(skipStr) && lineStr.StartsWith(skipStr)))
							continue;
						else
							content.Add(lineStr);
					}
				}
				reader.Close();

				return content;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				reader.Dispose();
				reader = null;
			}
		}

		/// <summary>
		/// 讀取檔案內容至 ArrayList
		/// </summary>
		/// <param name="filePath">檔案路徑</param>
		/// <param name="ecoding">編碼方式</param>
		/// <returns>檔案內容</returns>
		public static ArrayList ReadFile(string filePath, System.Text.Encoding ecoding)
		{
			return FileUtil.ReadFile(filePath, "", ecoding);
		}

		/// <summary>
		/// 寫入 ArrayList 內容至所指定的檔案
		/// </summary>
		/// <param name="path">檔案路徑</param>
		/// <param name="content">檔案內容</param>
		/// <param name="ecoding">編碼方式</param>
		public static void WriteFile(string path, ArrayList content, System.Text.Encoding ecoding)
		{
			FileUtil.CreateFile(path);

			StreamWriter	writer	=	null;
			try
			{
				writer	=	new StreamWriter(path, false, ecoding);
				
				for(int i = 0; i < content.Count; i++)
				{
					writer.WriteLine(content[i].ToString());
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (writer != null)
					writer.Dispose();
			}
		}

		private	static	Object appendFileLockObject	=	new Object();

		/// <summary>
		/// 新增內容至所指定的檔案
		/// </summary>
		/// <param name="path">檔案路徑</param>
		/// <param name="content">檔案內容</param>
		/// <param name="ecoding">編碼方式</param>
		public static void AppendFile(string path, string content, System.Text.Encoding ecoding)
		{
            if (!System.IO.File.Exists(path))
            {
                FileUtil.CreateFileUTF8(path); //Tim
            }

			lock(appendFileLockObject)
			{
				StreamWriter	writer	=	null;
				try
				{
					writer	=	new StreamWriter(path, true, ecoding);
					writer.WriteLine(content);
					writer.Flush();
				}
				catch (Exception ex)
				{
					if (ex.Message.Contains("處理序"))
					{
						System.Threading.Thread.Sleep(200);
					        AppendFile(path, content, ecoding);
					}
					else
						throw;
				}
				finally
				{
					writer.Dispose();
				}
			}
		}              

        /// <summary>
        /// 取得檔案大小-位元, 檔案不存在回傳 0 位元
        /// </summary>
        /// <param name="path">檔案路徑</param>
        /// <returns>檔案大小 (位元)</returns>
        public static long GetFileSize(string path)
		{
			if (System.IO.File.Exists(path))
				return new FileInfo(path).Length;
			else
				return 0;
		}
	}
}
