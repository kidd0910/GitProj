using System;
using System.Collections.Generic;
using System.Text;
using Acer.DB;
using System.Collections;
using Acer.DB.Query;
using System.Data.Common;
using Acer.Log;
using Acer.Apps;
using System.Threading;
using System.Data;
using Acer.Util;
using Acer.Base;

namespace Acer.Form
{
	/// <summary>
	/// �B�z�y�t
	/// </summary>
	public class LangUtil
	{
		private		Hashtable	pProperty	=	new Hashtable();

		private Hashtable PropertyMap
		{
			get { return pProperty; }
		}
		
		private MyLogger Logger
		{
			get{return (MyLogger)this.PropertyMap["Logger"];}
			set{this.PropertyMap["Logger"]		=	value;}
		}

		private DBManager dbManager
		{
			get{return (DBManager)this.PropertyMap["dbManager"];}
			set{this.PropertyMap["dbManager"]	=	value;}
		}

		/// <summary>
		/// �غc�l
		/// </summary>
		/// <param name="logger">MyLogger ����</param>
		/// <param name="dbManager">DBManager ����</param>
		public LangUtil(MyLogger logger, DBManager dbManager)
		{
			this.Logger	=	logger;
			this.dbManager	=	dbManager;
		}

		/// <summary>
		/// ���o�y�t�������
		/// </summary>
		/// <param name="mapName">�����W��</param>
		/// <returns>���G���</returns>
		public string LangMap(string mapName)
		{
            
			Hashtable	langMap	=	this.Logger.MULTI_LANGUAGE;

			//string	langType	=	Thread.CurrentThread.CurrentCulture.ToString().ToUpper();
            string langType = "ZH-TW";

			if (langType.Equals("EN-US"))
			{
				//=== �B�z�T�w�r�� ===
				switch (mapName)
				{
					case "COMMON.MSG.�s�W���A":
						return "�s�W";
					case "COMMON.MSG.�s�説�A":
						return "�s��";
					case "COMMON.MSG.���Ӫ��A":
						return "����";
					case "COMMON.MSG.��ƳQ���ʹL�T��":
						return "��Ƥw�R��/����, ���i�ק�!!";
                    case "�ϥήɶ��O��,�t�Τw�N�z�۰ʵn�X,�ЦA���s�n�J�ϥΥ��t��!!":
                        {
                            string		timeoutMsg	=	null;
                            if (langMap[langType + ".COMMON." + mapName] == null)
                                timeoutMsg = mapName;
                            else
                                timeoutMsg = (string)langMap[langType + ".COMMON." + mapName].ToString();
                            return timeoutMsg;
                        }
					default:
						break;
				}

				//=== ��l�^�ǭ����� ===
                if(mapName.IndexOf("COMMON") != -1)
                {
                    if (mapName.Split('.').Length == 2)
                        return mapName.Split('.')[1];
                    if (mapName.Split('.').Length == 3)
                        return mapName.Split('.')[2];
                }

                if (mapName.IndexOf("PAGE") != -1)
                {
                    return mapName.Split('.')[1];
                }

                if (mapName.IndexOf("MENU") != -1)
                {
                    return mapName.TrimStart("MENU".ToCharArray());
                }

                //if (mapName.Split('.').Length == 2)
                //    return mapName.Split('.')[1];
                //if (mapName.Split('.').Length == 3)
                //    return mapName.Split('.')[2];
                //else
                //    return mapName.TrimStart("MENU".ToCharArray());
			}
			else
			{
				if (mapName.IndexOf(".") == -1)
					mapName	=	"COMMON." + mapName;
			}

			string		result	=	null;
			string[]	map	=	mapName.Split('.');

			//���D COMMON ��
			if (!map[0].ToUpper().Equals("COMMON"))
			{
				//�@�X�ɧ����T��
				if (map.Length == 1)
                    result = (string)langMap[langType + ".COMMON." + map[0].ToString().ToUpper()];

                if (result == null && map[0].ToUpper().Equals("PAGE") && langMap[langType + "." + mapName.ToString().ToUpper()] != null)
                    result = (string)langMap[langType + "." + mapName.ToUpper()];

                //��ӭ����]�w Exp: APP0101_01.XXX -> APP0101_01.XXX
                if (result == null && langMap[langType + "." + map[0].ToString().ToUpper() + "." + map[map.Length - 1].ToString().ToUpper()] != null)
                {
                    result = (string)langMap[langType + "." + map[0].ToString().ToUpper() + "." + map[map.Length - 1].ToString().ToUpper()];
                }
                //��ӧ@�~�]�w Exp: APP0101_01.XXX -> APP0101.XXX
                if (result == null && map[0].ToString().ToUpper().IndexOf('_') > 0 && langMap[langType + "." + map[0].ToString().ToUpper().Substring(0, map[0].ToString().ToUpper().IndexOf('_')) + "." + map[map.Length - 1].ToString().ToUpper()] != null)
                {
                    result = (string)langMap[langType + "." + map[0].ToString().ToUpper().Substring(0, map[0].ToString().ToUpper().IndexOf('_')) + "." + map[map.Length - 1].ToString().ToUpper()];
                }
                //��Өt�ΧO�]�w Exp: APP0101_01.XXX -> APP.XXX
                if (result == null && langMap[langType + "." + map[0].ToString().ToUpper().Substring(0, 3) + "." + map[map.Length - 1].ToString().ToUpper()] != null)
                {
                    result = (string)langMap[langType + "." + map[0].ToString().ToUpper().Substring(0, 3) + "." + map[map.Length - 1].ToString().ToUpper()];
                }
			}
			else
			{
				//�� COMMON �ɪ��������^��
				if (map.Length == 2)
                    result = (string)langMap[langType + "." + mapName.ToString().ToUpper()];
				else
                    result = (string)langMap[langType + ".COMMON." + map[2].ToString().ToUpper()];
			}
			
			if (result == null)
			{
                try
				{
                    string mapTemp = mapName.ToUpper().Split('.')[0];
                    string mapVal = mapName.Split('.')[mapName.Split('.').Length - 1];
                    //if (mapTemp.Equals("COMMON"))
                    //    mapTemp = "COMMON";
                    //else if (mapTemp.Equals("MENU"))
                    //    mapTemp = "MENU";
                    //else if (mapTemp.Equals("PAGE"))
                    //    mapTemp = "PAGE";
                    //else
                    //    mapTemp = mapTemp.Substring(0, 3);

                    //���ˬdDB���S�����
                    DbConnection conn1 = this.dbManager.GetIConnection(APConfig.GetProperty("LANGUAGE_DATASOURCE"));
                    bool flag = false;
                    string sql = "SELECT COUNT(1) FROM LANGUAGE WITH (NOLOCK) WHERE LANG_TYPE = '" + langType + "' AND PAGE_NM = '" + mapTemp + "' AND MAP_NM = N'" + mapVal + "' ";
                    IDBResult rs = this.dbManager.GetResultSet(conn1);
                    rs.NoLog();
                    rs.ExecuteQuery(sql);
                    if(rs.Next())
                    {
                        if (rs.GetInt(0) > 0)
                        {
                            flag = true;
                        }
                    }
                    rs.Close();
                    conn1.Close();
                    conn1.Dispose();

                    //DB�S���~�s�W
                    if (!flag)
                    {
                        DataTable dt = null;

                        DbConnection conn = this.dbManager.GetIConnection(APConfig.GetProperty("LANGUAGE_DATASOURCE"), "LANG");
                        //=== �۰ʻ`�� TAG For �t�� ===
                        DBAccess dba = this.dbManager.GetDBAccess(conn);
              
                        EntityBase ent = new EntityBase(dt);
                        dba.SetTableName("LANGUAGE");
                        dba.SetColumn("LANG_TYPE", langType);
                        dba.SetColumn("PAGE_NM", mapTemp);
                        dba.SetColumn("MAP_NM", "N'" + mapVal + "'", true);

                        //if (langType == "ZH-CN")
                        //    dba.SetColumn("MAP_VALUE", "N'" + Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter.ChineseConverter.Convert(mapVal, Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter.ChineseConversionDirection.TraditionalToSimplified) + "'", true);
                        //else
                        //    dba.SetColumn("MAP_VALUE", "N'" + mapVal + "'", true);

                        dba.SetColumn("PKNO", ent.GetSequence());
                        dba.Insert();

                        this.dbManager.Commit("LANG");
                    }
                    
				}
				catch (Exception ex)
				{
					this.Logger.Append(ex.ToString());
				}
                finally
                {
                    this.InitLanguage();
                }
                
				this.Logger.Append("���w�q�ӻy�t���, " + langType + "." + mapName);
				mapName	=	mapName.Substring(mapName.IndexOf(".") + 1);
				return mapName;
			}

			return result;
		}

		/// <summary>
		/// ��l�Ʀh��y�t����
		/// </summary>
		public void InitLanguage()
		{
			Hashtable	langMap	=	new Hashtable();
			DbConnection	conn	=	this.dbManager.GetIConnection(APConfig.GetProperty("LANGUAGE_DATASOURCE"));
			IDBResult	rs	=	this.dbManager.GetResultSet(conn);

			//string		sql	=	"SELECT LANG_TYPE, PAGE_NM, MAP_NM, MAP_VALUE FROM LANGUAGE WITH (NOLOCK) WHERE LANG_TYPE <> 'ZH-TW' ";
            string sql = "SELECT LANG_TYPE, PAGE_NM, MAP_NM, MAP_VALUE FROM LANGUAGE WITH (NOLOCK) ";

			rs.NoLog();
			rs.ExecuteQuery(sql);
			while (rs.Next())
			{
				langMap[rs.GetString("LANG_TYPE").ToUpper().Trim() + "." +
					rs.GetString("PAGE_NM").ToUpper().Trim() + "." +
					rs.GetString("MAP_NM").ToUpper().Trim()]	=	rs.GetString("MAP_VALUE");
			}
			rs.Close();
			MultiProcess.SetCrossSiteValue("MULTI_LANGUAGE", (Object)langMap);

		}
	}
}
 