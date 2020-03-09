'----------------------------------------------------------------------------------
'File Name		: EntSqlSeverConn
'Author			: Charles
'Description		: EntSqlSeverConn SQLSEVER連線ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2009/11/03	Charles		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common 
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util 
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace Comm.Data
    '' <summary>
    '' EntSqlSeverConn SQLSEVER連線ENT
    '' </summary>
    Public Class EntSqlSeverConn
        Inherits Acer.Base.EntityBase
        Implements Acer.Base.IEntityInterface

#Region "建構子"
        '' <summary>
        '' 建構子/處理屬性對應處理
        '' </summary>
        '' <param name="dt">DataTable 物件</param>
        Public Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub

        '' <summary>
        '' 建構子/處理異動處理
        '' </summary>
        '' <param name="dbManager">DBManager 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.TableName = ""
            Me.SysName = "common"
            Me.ConnName = "NTOUSQL"

            '=== 關聯 Class ===

            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"

#End Region

#Region "自訂方法"
#Region "GetOldAdminDate 取得舊行政資料 "
        ''' <summary>
        ''' 取得舊行政資料 
        ''' </summary>
        Public Function GetOldAdminDate() As DataTable
            Return Me.GetOldAdminDate(0, 0)
        End Function

        ''' <summary>
        ''' 取得舊行政資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetOldAdminDate(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'Select  '0'+a.cos_smtr, a.cos_id, a.cos_class, a.teacher_name, a.tch_hours,b.all_hours
                'From  dbo.cos_smtrcos_dup a,
                '(SELECT     cos_smtr, cos_id, cos_class,SUM(tch_hours) as all_hours
                'FROM         dbo.cos_smtrcos_dup
                'GROUP BY cos_smtr, cos_id, cos_class
                'HAVING      (COUNT('a') > 1)) b 
                'where a.cos_smtr=b. cos_smtr and 
                'a.cos_id=b.cos_id and a.cos_class=b.cos_class

                Dim Sql As String = _
                "SELECT  " & _
                "B04IDNO AS IDNO,  " & _
                "B04NAME AS CH_NAME,  " & _
                "'0' + B04ADUCOD AS DEP_CODE,  " & _
                "B04ADUNA AS DEP_NAME,  " & _
                "B04TITLE AS JOBTITLE_NAME,  " & _
                "B04ADDATB AS ACTU_DATES,  " & _
                "B04ADDATE AS ACTU_DATEE " & _
                "FROM DBO.V_AIS_TEAHIST "
                Dim dt As DataTable = Me.QueryBySql(Sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#End Region

    End Class
End Namespace
 
