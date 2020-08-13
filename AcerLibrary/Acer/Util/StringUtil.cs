using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acer.Util
{
    public class StringUtil
    {
        /// <summary>
        /// 空字串轉為NULL
        /// </summary>
        public static object GetNumber(object value)
        {
            if (typeof(string).Equals(value.GetType()))
            {
                if ("".Equals(value.ToString().Trim()))
                {
                    return DBNull.Value;
                }
                else
                {
                    return value.ToString().Trim();
                }
            }
            else
            {
                return value;
            }
        }

        public static object GetNumber(object value, string defaultValue)
        {
            if (typeof(string).Equals(value.GetType()))
            {
                if ("".Equals(value.ToString().Trim()))
                {
                    return defaultValue;
                }
                else
                {
                    return value.ToString().Trim();
                }
            }
            else
            {
                return value;
            }
        }

        public static int GetInt(string value)
        {
            int result = 0;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        public static string BytesToHexString(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                return "";
            }

            StringBuilder hexString = new StringBuilder(byteArray.Length * 2);
            foreach (byte b in byteArray)
            {
                hexString.AppendFormat("{0:x2}", b);
            }
            return hexString.ToString();
        }

        public static byte[] HexStringToBytes(string hexString)
        {
            if (hexString == null || hexString.Length == 0)
            {
                return null;
            }

            if (hexString.StartsWith("0x"))
            {
                hexString = hexString.Replace("0x", "");
            }

            int byteArraySize = hexString.Length;
            byte[] result = new byte[byteArraySize / 2];
            for (int i = 0; i < byteArraySize; i += 2)
            {
                result[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }

            return result;
        }

        public static string ConvertText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }
            int textIndex = 0;
            string text1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789:";
            string text2 = "ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ０１２３４５６７８９：";
            string resultText = "";
            string charText = "";
            for (int i = 0; i < text.Length; i++)
            {
                charText = text.Substring(i, 1);
                textIndex = text1.IndexOf(charText);
                if (textIndex > -1)
                {
                    resultText += text2.Substring(textIndex, 1);
                }
                else
                {
                    resultText += charText;
                }
            }
            return resultText;
        }

        public static string FullLeftText(string text, string charText, int len)
        {
            string result = string.IsNullOrEmpty(text) ? "" : text;
            if (result.Length > len)
            {
                return result.Substring(0, len);
            }
            for (int i = text.Length; i < len; ++i)
            {
                result = charText + result;
            }
            return result;
        }

        public static string FullRightText(string text, string charText, int len)
        {
            string result = string.IsNullOrEmpty(text) ? "" : text;
            if (result.Length > len)
            {
                return result.Substring(0, len);
            }
            for (int i = text.Length; i < len; ++i)
            {
                result = result + charText;
            }
            return result;
        }

        /// <summary>
        /// 取金錢格式自串 (增加每三位逗號)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetMoneyCurrency(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            double tryDouble = 0;
            if (double.TryParse(value, out tryDouble))
            {
                return tryDouble.ToString("###,###,###,##0");
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// 取金錢格式自串 (增加每三位逗號)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetMoneyCurrency(int value)
        {
            return value.ToString("###,###,###,##0");
        }

        /// <summary>
        /// 取金錢值 (移除每三位逗號)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetMoneyValue(string value)
        {
            var result = value.Replace(",", "");
            if (string.IsNullOrEmpty(result))
            {
                return "";
            }
            int tryInt = 0;
            if (int.TryParse(result, out tryInt))
            {
                return result;
            }
            else
            {
                return "";
            }
        }

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
            {
                throw new ArgumentNullException("content");
            }
            return content.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>
        /// 將字串反向, 例如: 傳入 '1234', 傳回 '4321'
        /// </summary>
        /// <param name="str">欲反向的字串</param>
        /// <returns>處理後的字串</returns>
        public static string ConvertStr(string str)
        {
            if (str == null)
                throw new ArgumentNullException("str");

            StringBuilder resultStr = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
                resultStr.Append(str.Substring(i, 1));

            return resultStr.ToString();
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

            StringBuilder cStrNumSection = new StringBuilder();		//中文數字片段
            StringBuilder resultStr = new StringBuilder();		//回傳值
            string chineseNum = "";				//設定用
            string chineseNum0 = "零一二三四五六七八九";		//中文數字型態一
            string chineseNum1 = "零壹貳參肆伍陸柒捌玖";		//中文數字型態二
            string chineseNum2 = "０一二三四五六七八九";		//中文數字型態三
            string chineseNum3 = "０一二三四五六七八九";		//中文數字型態四(直接轉換)

            string tmpStrNum = strNum.ToString();		//暫存傳入的數字
            string tmpIntStrNum = "";				//暫存傳入的數字(整數部份)
            string tmpStrNumSection = "";				//數字片段

            int posOfDecimalPoint = 0;				//小數點位置
            int digit = 0;				//位數
            Boolean inZero = true;				//是否須加"零"
            Boolean minus = true;				//是否負數

            //依種類判別中文數字型態
            if (cNumType == 0)
                chineseNum = chineseNum0;
            if (cNumType == 1)
                chineseNum = chineseNum1;
            if (cNumType == 2)
                chineseNum = chineseNum2;
            if (cNumType == 3)	//專門處理號的轉換
            {
                chineseNum = chineseNum3;

                for (int i = -1; i < tmpStrNum.Length - 1; i++)
                {
                    if (tmpStrNum.Substring(i + 1, 1).Equals("."))
                        resultStr.Append("‧");
                    else
                    {
                        try
                        {
                            digit = Convert.ToInt32(tmpStrNum.Substring(i + 1, 1), 10);
                        }
                        catch (Exception)
                        {
                            throw new ArgumentException("【傳入參數包含非數字型態資料, strNum:" + strNum + "】");
                        }
                        resultStr.Append(chineseNum.Substring(digit, 1));
                    }
                }
                return resultStr.ToString();
            }

            //判別是否負數
            if (tmpStrNum.StartsWith("-"))//負數
            {
                minus = true;
                tmpStrNum = StringUtil.Substring(tmpStrNum, 1, tmpStrNum.Length);
            }
            else	//正數
                minus = false;

            //取得小數點的位置
            posOfDecimalPoint = tmpStrNum.IndexOf(".");

            //先處理整數的部分
            if (posOfDecimalPoint <= 0)
                tmpIntStrNum = ConvertStr(tmpStrNum);
            else
                tmpIntStrNum = ConvertStr(StringUtil.Substring(tmpStrNum, 0, posOfDecimalPoint));

            //從個位數起以每四位數為一小節
            for (int sectionIndex = 0; sectionIndex <= (tmpIntStrNum.Length - 1) / 4; sectionIndex++)
            {
                //取得四位數的字串資料
                if (sectionIndex * 4 + 4 < tmpIntStrNum.Length)
                    tmpStrNumSection = StringUtil.Substring(tmpIntStrNum, sectionIndex * 4, sectionIndex * 4 + 4);
                else
                    tmpStrNumSection = StringUtil.Substring(tmpIntStrNum, sectionIndex * 4, tmpIntStrNum.Length);

                //清空四位數的中文數字資料
                cStrNumSection.Length = 0;

                /* 以下的 i 控制: 個十百千位四個位數 */
                for (int i = 0; i < tmpStrNumSection.Length; i++)
                {
                    digit = Convert.ToInt32(tmpStrNumSection.Substring(i, 1), 10);
                    if (digit == 0)
                    {
                        // 1. 避免 '零' 的重覆出現
                        // 2. 個位數的 0 不必轉成 '零'
                        if (!inZero && i != 0)
                            cStrNumSection.Insert(0, "零");
                        inZero = true;
                    }
                    else
                    {
                        if (cNumType == 1)
                        {
                            switch (i)
                            {
                                case 1:
                                    cStrNumSection.Insert(0, "拾");
                                    break;
                                case 2:
                                    cStrNumSection.Insert(0, "佰");
                                    break;
                                case 3:
                                    cStrNumSection.Insert(0, "仟");
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            switch (i)
                            {
                                case 1:
                                    cStrNumSection.Insert(0, "十");
                                    break;
                                case 2:
                                    cStrNumSection.Insert(0, "百");
                                    break;
                                case 3:
                                    cStrNumSection.Insert(0, "千");
                                    break;
                                default:
                                    break;
                            }
                        }
                        cStrNumSection.Insert(0, chineseNum.Substring(digit, 1));
                        inZero = false;
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
                    switch (sectionIndex)
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
                        default:
                            break;
                    }
                }
            }

            //處理小數點右邊的部分
            if (posOfDecimalPoint > 0)
            {
                resultStr.Append("點");
                for (int i = posOfDecimalPoint; i < tmpStrNum.Length - 1; i++)
                {
                    digit = Convert.ToInt32(tmpStrNum.Substring(i + 1, 1), 10);
                    resultStr.Append(chineseNum.Substring(digit, 1));
                }
            }

            //其他例外狀況的處理
            if (resultStr.Length == 0)
                resultStr.Append("零");
            if (resultStr.Length >= 2 && (resultStr.ToString().Substring(0, 2).Equals("一十") || resultStr.ToString().Substring(0, 2).Equals("壹十")))
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

        ///<summary>
        ///字串轉半形
        ///</summary>
        public static string ToNarrow(string text)
        {
            char[] c = text.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        ///<summary>
        ///中文數字轉阿拉伯數字
        ///</summary>
        public static string CNumTONum(string text)
        {
            string strTemp = "";

            if (!string.IsNullOrEmpty(text))
            {
                strTemp = text;
                strTemp = strTemp.Replace("一", "1");
                strTemp = strTemp.Replace("二", "2");
                strTemp = strTemp.Replace("三", "3");
                strTemp = strTemp.Replace("四", "4");
                strTemp = strTemp.Replace("五", "5");
                strTemp = strTemp.Replace("六", "6");
                strTemp = strTemp.Replace("七", "7");
                strTemp = strTemp.Replace("八", "8");
                strTemp = strTemp.Replace("九", "9");

                //例外處理
                if (text == "十")
                {
                    return "10";
                }

                string[] strArrSplit10 = strTemp.Split('十');
                string[] strArrNum = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                for (int i = 0; i <= strArrSplit10.Length - 2; i++)
                {
                    string strArr10RightChar = "";
                    string strArr10LeftChar = "";

                    try
                    {
                        strArr10RightChar = strArrSplit10[i].Substring(strArrSplit10[i].Length - 1);
                    }
                    catch (Exception ex)
                    {
                        //strArrSplit10(0)為空白，忽略不動作。
                    }

                    try
                    {
                        strArr10LeftChar = strArrSplit10[i + 1].Substring(0, 1);
                    }
                    catch (Exception ex)
                    {
                        if (Array.IndexOf(strArrNum, strArrSplit10[i].Substring(strArrSplit10[i].Length - 1)) == -1)
                        {
                            strArrSplit10[i] = strArrSplit10[i] + "10";
                        }
                        else
                        {
                            strArrSplit10[i] = strArrSplit10[i] + "0";
                        }
                    }

                    if (Array.IndexOf(strArrNum, strArr10RightChar) == -1 & Array.IndexOf(strArrNum, strArr10LeftChar) == -1)
                    {
                        //十的左右都沒值,補１０
                        strArrSplit10[i] = strArrSplit10[i] + "10";
                    }
                    else if (!(Array.IndexOf(strArrNum, strArr10RightChar) == -1) & Array.IndexOf(strArrNum, strArr10LeftChar) == -1)
                    {
                        //十的左有值,右沒值,補０
                        strArrSplit10[i] = strArrSplit10[i] + "0";
                    }
                    else if (Array.IndexOf(strArrNum, strArr10RightChar) == -1 & !(Array.IndexOf(strArrNum, strArr10LeftChar) == -1))
                    {
                        //十的左沒值,右有值,補１
                        strArrSplit10[i] = strArrSplit10[i] + "1";
                    }

                }

                strTemp = "";
                for (int i = 0; i <= strArrSplit10.Length - 1; i++)
                {
                    strTemp += strArrSplit10[i];
                }


                string[] strArrSplit100 = strTemp.Split('百');
                for (int i = 0; i <= strArrSplit100.Length - 2; i++)
                {
                    try
                    {
                            string strArr100RightChar = strArrSplit100[i].Substring(strArrSplit100[i].Length - 1);
                            string strArr100LeftChar = strArrSplit100[i + 1].Substring(0, 1);
                            if (!(Array.IndexOf(strArrNum, strArr100RightChar) == -1) & Array.IndexOf(strArrNum, strArr100LeftChar) == -1)
                            {
                                //百的左有值,右沒值,補００
                                strArrSplit100[i] = strArrSplit100[i] + "00";
                            }
                            else if((Array.IndexOf(strArrNum, strArr100RightChar) == -1) & Array.IndexOf(strArrNum, strArr100LeftChar) == -1)
                            {
                                strArrSplit100[i] = strArrSplit100[i] + "百";
                            }
                    }
                    catch (Exception ex)
                    {
                        if (!string.IsNullOrEmpty(strArrSplit100[0].ToString()))
                        {
                            if (Array.IndexOf(strArrNum, strArrSplit100[i].Substring(strArrSplit100[i].Length - 1)) == -1)
                            {
                                strArrSplit100[i] = strArrSplit100[i] + "100";
                            }
                            else
                            {
                                strArrSplit100[i] = strArrSplit100[i] + "00";
                            }
                        }
                        else
                            strArrSplit100[i] = strArrSplit100[i] + "百";
                    }
                }

                strTemp = "";
                for (int i = 0; i <= strArrSplit100.Length - 1; i++)
                {
                    strTemp += strArrSplit100[i];
                }
            }

            return strTemp.Trim();
        }

        /// <summary>
        /// 功能說明: 將地址切成六個區塊並存至陣列中。
        /// 傳入參數說明: strAddr 傳入地址。
        /// 回傳參數說明: 
        /// string(0) 縣市鄉鎮市區。
        /// string(1) 里村。
        /// string(2) 鄰(數字)。
        /// string(3) 鄰。
        /// string(4) 路街段。
        /// string(5) 巷弄號樓等剩下地址。
        /// </summary>
        public static string CNumTONumAddr(string strAddr)
        {
            string[] addrs = new string[6];

            if (!string.IsNullOrEmpty(strAddr.Trim()))
            {
                //取縣市（含鄉、鎮、區）
                int index = strAddr.IndexOf("區");

                if (-1 == index)
                {
                    index = strAddr.IndexOf("鎮");
                    //檢查是否有鎮市的關鍵字，如平鎮市，若有，則取兩字元長度
                    if (index > 0)
                    {
                        if (strAddr.IndexOf("鎮市") > 0)
                        {
                            index = index + 1;
                        }
                    }
                }
                if (-1 == index)
                {
                    index = strAddr.IndexOf("鄉");
                }
                if (-1 == index)
                {
                    index = strAddr.IndexOf("市");
                }
                if (-1 == index)
                {
                    index = strAddr.IndexOf("縣");
                }
                addrs[0] = strAddr.Substring(0, index + 1).Trim();
                //縣市(含鄉、鎮、區)
                int temp = strAddr.Length;
                strAddr = strAddr.Substring(index + 1);
                //去除縣市後的地址

                //取村里
                index = strAddr.IndexOf("里");
                if (-1 == index)
                {
                    index = strAddr.IndexOf("村");
                }
                addrs[1] = strAddr.Substring(0, index + 1).Trim();
                //村里
                strAddr = strAddr.Substring(index + 1);
                //去除村里後的地址

                //取鄰數、鄰字
                index = strAddr.IndexOf("鄰");
                if (!(-1 == index))
                {
                    addrs[2] = ToNarrow(strAddr.Substring(0, index).Trim());
                    //鄰數
                    addrs[3] = "鄰";
                    //鄰字
                    strAddr = strAddr.Substring(index + 1);
                    //去除鄰後的地址
                }

                //取路、街、村、段
                index = strAddr.LastIndexOf("段");
                if (-1 == index)
                {
                    index = strAddr.LastIndexOf("路");
                }
                if (-1 == index)
                {
                    index = strAddr.LastIndexOf("街");
                }
                addrs[4] = ToNarrow(strAddr.Substring(0, index + 1).Trim());
                //路、街、段
                strAddr = strAddr.Substring(index + 1);
                //去除路、街、段後的地址

                //取地址（含巷、弄、號、樓等）
                try
                {
                    addrs[5] = CNumTONum(ToNarrow(strAddr.Trim()));
                }
                catch(Exception ex)
                {
                    addrs[5] = ToNarrow(strAddr.Trim());
                }
            }

            return addrs[0] + addrs[1] + addrs[2] + addrs[3] + addrs[4] + addrs[5];
        }

        public static int sLen(string WStr)
        { 
            int sCount = 0;

            if (!string.IsNullOrEmpty(WStr))
            {
                foreach (char c in WStr)
                {
                    int i = Convert.ToInt32(c);
                    if ((i >= 0) && (i <= 255))
                        sCount = sCount + 1;
                    else
                        sCount = sCount + 2;
                }
            }

            return sCount;
        }

        public static string ASCVALUE(string strvalue, int iBegin, int iLen)
        {
            string result = string.Empty;
            int iend;
            int icount = 0;
            int iRealLen;
            string strTmp = string.Empty;

            iRealLen = sLen(strvalue);
            if (iBegin > iRealLen)
                result = "";

            foreach (char c in strvalue)
            {
                if (icount >= iBegin)
                    break;

                int i = Convert.ToInt32(c);
                if ((i < 0) || (i > 255))
                    iBegin = iBegin - 1;

                icount++;
            }

            if (iBegin > iRealLen)
                result = "";

            icount = iBegin;
            iend = iBegin + iLen;

            if (iRealLen < iend)
                iend = iRealLen;

            for (int index = icount; index < iend; index++)
            {
                strTmp = strvalue.Substring(index, 1);
                if (string.IsNullOrEmpty(strTmp) || strTmp.Length == 0)
                    strTmp = " ";

                int i = Convert.ToInt32(Convert.ToChar(strTmp));

                result = result + strvalue.Substring(index, 1);
                if ((i < 0) || (i > 255))
                    iend = iend - 1;
            }

            return result;
        }

    }
}
