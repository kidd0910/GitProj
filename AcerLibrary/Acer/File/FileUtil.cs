using System;
using System.Text;
using System.Collections;
using System.IO;
using Acer.Util;

namespace Acer.File
{
	/// <summary>
	/// �ɮ׳B�z�����@�Τ�k
	/// </summary>
	public class FileUtil
	{
		/// <summary>
		/// ���o�ڥؿ����|
		/// </summary>
		/// <returns></returns>
		public static string RootPath
		{
			get{return FileUtil.LastSeparator(System.AppDomain.CurrentDomain.BaseDirectory);}
		}

		/// <summary>
		/// �P�_���|���c�O�_���̫�@�X "\" �Y�S���ɤW�Ǧ^
		/// </summary>
		/// <param name="filePath">���P�_�����|</param>
		/// <returns>�ɤW�����|���c</returns>
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
		/// �P�_�ɮשΥؿ��O�_�s�b
		/// </summary>
		/// <param name="path">���P�_�����|</param>
		/// <returns>�O - �s�b, �_ - ���s�b</returns>
		public static Boolean FileExists(string path)
		{
			if (path == null)
				throw new ArgumentNullException("path");

			return System.IO.File.Exists(path) || Directory.Exists(path);
		}

		/// <summary>
		/// �̾ڶǤJ���ɮ׸��|���X�ɮץؿ�
		/// Exp: c:\xx\x1\x2\xx.txt --> c:\xx\x1\x2\
		/// </summary>
		/// <param name="path">�ɮ׸��|</param>
		/// <returns>�ɮץؿ�</returns>
		public static string GetFolderName(string path)
		{
			if (path == null)
				throw new ArgumentNullException("path");
			
			return path.Substring(0, path.LastIndexOf("\\") + 1);
		}

		/// <summary>
		/// �ھڶǤJ���ɮצ�m, �P�_���ؿ��O�_�s�b, �Y���s�b, �h�إߦ��@�ؿ�
		/// �i�إ� N �h�����c
		/// </summary>
		/// <param name="path">�w�إߪ��ؿ����|</param>
		public static void CreateDir(string path)
		{
			//=== nono 2009/04/16 add, fix unc ���|�|�����D Bug ===
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
		/// �ھڶǤJ���ɮצ�m, �P�_���ؿ��O�_�s�b, �Y���s�b, �h�إߦ��@�ؿ��ɮ�
		/// �i�إ� N �h�����c
		/// </summary>
		/// <param name="path">�w�إߪ��ɮ׸��|</param>
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
        /// �ھڶǤJ���ɮצ�m, �P�_���ؿ��O�_�s�b, �Y���s�b, �h�إߦ��@�ؿ��ɮ�
        /// �i�إ� N �h�����c
        /// </summary>
        /// <param name="path">�w�إߪ��ɮ׸��|</param>
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
        /// �̾ڶǤJ���ɮ׸��|���X�ɮצW��
        /// Exp: c:\xx\x1\x2\xx.txt --> xx.txt
        /// </summary>
        /// <param name="path">�ɮ׸��|</param>
        /// <returns>�ɮצW��</returns>
        public static string GetFileName(string path)
		{
			return path.Substring(path.LastIndexOf("\\") + 1);
		}

		/// <summary>
		/// �����ɮ�(�]�t�l�ؿ�)
		/// </summary>
		/// <param name="sourcePath">�ӷ��ɮ׸��|</param>
		/// <param name="targetPath">�n���ʦܪ��ɮ׸��|</param>
		public static void MoveFile(string sourcePath, string targetPath)
		{
			if (!System.IO.File.Exists(sourcePath))
			{
				return;
				//throw new FileNotFoundException("�䤣����ɮ� sourcePath: " + sourcePath);
			}
			
			try
			{
				System.IO.File.Move(sourcePath, targetPath);
			}
			catch (Exception ex)
			{
				if (ex.Message.Contains("�B�z��"))
				{
					System.Threading.Thread.Sleep(200);
					MoveFile(sourcePath, targetPath);
				}
				else
					throw;
			}
		}

		/// <summary>
		/// �R���ؿ����ɮ�(�]�t�l�ؿ�)
		/// </summary>
		/// <param name="path">�n�R�����ɮשΥؿ����|</param>
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
		/// Ū���ɮפ��e�� ArrayList
		/// </summary>
		/// <param name="filePath">�ɮ׸��|</param>
		/// <param name="skipStr">�ư����r���r��</param>
		/// <param name="ecoding">�s�X�覡</param>
		/// <returns>�ɮפ��e</returns>
		public static ArrayList ReadFile(string filePath, string skipStr, System.Text.Encoding ecoding)
		{
			if (!System.IO.File.Exists(filePath))
				throw new FileNotFoundException("�䤣���Ū�����ɮ� filePath: " + filePath);

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
		/// Ū���ɮפ��e�� ArrayList
		/// </summary>
		/// <param name="filePath">�ɮ׸��|</param>
		/// <param name="ecoding">�s�X�覡</param>
		/// <returns>�ɮפ��e</returns>
		public static ArrayList ReadFile(string filePath, System.Text.Encoding ecoding)
		{
			return FileUtil.ReadFile(filePath, "", ecoding);
		}

		/// <summary>
		/// �g�J ArrayList ���e�ܩҫ��w���ɮ�
		/// </summary>
		/// <param name="path">�ɮ׸��|</param>
		/// <param name="content">�ɮפ��e</param>
		/// <param name="ecoding">�s�X�覡</param>
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
		/// �s�W���e�ܩҫ��w���ɮ�
		/// </summary>
		/// <param name="path">�ɮ׸��|</param>
		/// <param name="content">�ɮפ��e</param>
		/// <param name="ecoding">�s�X�覡</param>
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
					if (ex.Message.Contains("�B�z��"))
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
        /// ���o�ɮפj�p-�줸, �ɮפ��s�b�^�� 0 �줸
        /// </summary>
        /// <param name="path">�ɮ׸��|</param>
        /// <returns>�ɮפj�p (�줸)</returns>
        public static long GetFileSize(string path)
		{
			if (System.IO.File.Exists(path))
				return new FileInfo(path).Length;
			else
				return 0;
		}
	}
}
