using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;

namespace Acer.DB.Query
{
	/// <summary>
	/// db �d�ߪ��󤶭�
	/// </summary>
	public interface IDBResult
	{
		/// <summary>
		/// ���i��O�� Log �ʧ@
		/// </summary>
		void NoLog();

		/// <summary>
		/// �����d�ߨ������s�u
		/// </summary>
		/// <returns>True/False</returns>
		Boolean Close();

		/// <summary>
		/// ����d��
		/// </summary>
		/// <param name="sql">�d�߻y�k</param>
		void ExecuteQuery(string sql);

		/// <summary>
		/// ���o DataSet
		/// </summary>
		/// <param name="sql">�d�߻y�k</param>
		/// <returns>DataSet</returns>
		DataSet GetDataSet(string sql);

		/// <summary>
		/// ���o DataReader
		/// </summary>
		/// <param name="sql">�d�߻y�k</param>
		/// <returns>DataReader</returns>
		DbDataReader GetDataReader(string sql);

		/// <summary>
		/// ����d��
		/// </summary>
		/// <param name="sql">�d�߻y�k</param>
		/// <param name="hasBinary">�O�_�]�t�G�i���ƫ��A</param>
		void ExecuteQuery(string sql, Boolean hasBinary);

		/// <summary>
		/// ���o���ƥ�
		/// </summary>
		/// <returns>���ƥ�</returns>
		int GetColumnCount();

		/// <summary>
		/// ���ܤU�@��
		/// </summary>
		/// <returns>true/false</returns>
		Boolean Next();

		/// <summary>
		/// �����W�٨��o����
		/// </summary>
		/// <param name="columnName">���W��</param>
		/// <returns>����(string), �Y DBNull �h�Ǧ^�ť�</returns>
		string GetString(string columnName);

		/// <summary>
		/// �������ި��o����
		/// </summary>
		/// <param name="columnIndex">���Ǹ�, �q 0 �}�l</param>
		/// <returns>����(string), �Y DBNull �h�Ǧ^�ť�</returns>
		string GetString(int columnIndex);

		/// <summary>
		/// �����W�٨��o����
		/// </summary>
		/// <param name="columnName">���W��</param>
		/// <returns>����(int), �Y DBNull �h�Ǧ^ 0</returns>
		int GetInt(string columnName);

		/// <summary>
		/// �������ި��o����
		/// </summary>
		/// <param name="columnIndex">���Ǹ�, �q 0 �}�l</param>
		/// <returns>����(int), �Y DBNull �h�Ǧ^ 0</returns>
		int GetInt(int columnIndex);

		/// <summary>
		/// �����W�٨��o����
		/// </summary>
		/// <param name="columnName">���Ǹ�,�q1�}�l</param>
		/// <returns>����(long), �Y DBNull �h�Ǧ^ 0</returns>
		long GetLong(string columnName);

		/// <summary>
		/// �������ި��o����
		/// </summary>
		/// <param name="columnIndex">���Ǹ�, �q 0 �}�l</param>
		/// <returns>����(int), �Y DBNull �h�Ǧ^ 0</returns>
		long GetLong(int columnIndex);

		/// <summary>
		/// �����W�٨��o����
		/// </summary>
		/// <param name="columnName">���W��</param>
		/// <returns>����(double), �Y DBNull �h�Ǧ^ 0</returns>
		double GetDouble(string columnName);

		/// <summary>
		/// �������ި��o����
		/// </summary>
		/// <param name="columnIndex">���Ǹ�, �q 0 �}�l</param>
		/// <returns>����(double), �Y DBNull �h�Ǧ^ 0</returns>
		double GetDouble(int columnIndex);
		
		/// <summary>
		/// �������ި��o����
		/// </summary>
		/// <param name="columnIndex">���Ǹ�, �q 0 �}�l</param>
		/// <returns>���W��</returns>
		string GetColumnName(int columnIndex);

		/// <summary>
		/// �N�G�줸����ন�ɮ�
		/// </summary>
		/// <param name="columnIndex">���Ǹ�, �q 0 �}�l</param>
		/// <param name="filePath">��s���|</param>
		void BinaryToFile(int columnIndex, string filePath);

		/// <summary>
		/// �G�i���ƿ�X�� Web
		/// </summary>
		/// <param name="columnIndex">���Ǹ�, �q 0 �}�l</param>
		void BinaryToWeb(int columnIndex);
	}
}
