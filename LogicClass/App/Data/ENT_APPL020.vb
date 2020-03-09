'----------------------------------------------------------------------------------
'File Name		: APPL020
'Author			:  
'Description		: APPL020  
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2017/11/20	 		Source Create
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports System.Reflection.MethodBase

Namespace App.Data
    ' <summary>
    ' APPL020  
    ' </summary>
    Public Class ENT_APPL020
        Inherits Acer.Base.EntityBase
        Implements Acer.Base.IEntityInterface

#Region "�غc�l"
        ' <summary>
        ' �غc�l/�B�z�ݩʹ����B�z
        ' </summary>
        ' <param name="dt">DataTable ����</param>
        Public Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub

        ' <summary>
        ' �غc�l/�B�z���ʳB�z
        ' </summary>
        ' <param name="dbManager">DBManager ����</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.TableName = "APPL020"
            Me.SysName = "APP"
            Me.ConnName = "TSBA"
            Me.LONG_FIELD_NAME = "CASE_NO,RESULT1_DESC,RESULT2_DESC,RESULT3_DESC,CREATE_USER,UPDATE_USER"
            Me.SET_NULL_FIELD = "CREATE_DATE,UPDATE_DATE,RESULT1_DATE,RESULT2_DATE,RESULT3_DATE"
        End Sub
#End Region

#Region "�ݩ�"
#Region "CASE_NO �ץ�s��"
        '  �s�W�ɵ���,�ץ�s���s�X�榡�GWWWWYYYNNNNNR,
        '  WWWW�G4�X�A��ܷ~�ȥN��, 
        '  AA01�G�ӳ]-�����ìP, 
        '�@AA02�G�ӳ]-�ҥ~�����ìP, 
        '�@AA03�G�ӳ]-�`�ب����Ʒ~-�@���W�D, 
        '�@AA04�G�ӳ]-�`�ب����Ʒ~-�ʪ��W�D, 
        '�@AA05�G�ӳ]-�ҥ~�`�ب����Ʒ~-�@���W�D, 
        '�@AA06�G�ӳ]-�ҥ~�`�ب����Ʒ~-�ʪ��W�D, 
        '�@AB01�G�ӳ]-�L�u�q��, 
        '�@AC01�G�ӳ]-�ϰ�ʼs���Ʒ~, 
        '�@AC02�G�ӳ]-���ϩʼs���Ʒ~, 
        '�@AC03�G�ӳ]-����q�O�ΰ]�Ϊk�H, 
        '�@BA01�G��Ų-�����ìP, 
        '�@BA02�G��Ų-�ҥ~�����ìP, 
        '�@BA03�G��Ų-�`�ب����Ʒ~-�@���W�D, 
        '�@BA04�G��Ų-�`�ب����Ʒ~-�ʪ��W�D, 
        '�@BA05�G��Ų-�ҥ~�`�ب����Ʒ~-�@���W�D, 
        '�@BA06�G��Ų-�ҥ~�`�ب����Ʒ~-�ʪ��W�D, 
        '�@BB01�G��Ų-�L�u�q��, 
        '�@BC01�G��Ų-�ϰ�ʼs���Ʒ~, 
        '�@BC02�G��Ų-���ϩʼs���Ʒ~, 
        '�@BC03�G��Ų-����q�O�ΰ]�Ϊk�H, 
        '�@CA01�G����-�����ìP, 
        '�@CA02�G����-�ҥ~�����ìP, 
        '�@CA03�G����-�`�ب����Ʒ~-�@���W�D, 
        '�@CA04�G����-�`�ب����Ʒ~-�ʪ��W�D, 
        '�@CA05�G����-�ҥ~�`�ب����Ʒ~-�@���W�D, 
        '�@CA06�G����-�ҥ~�`�ب����Ʒ~-�ʪ��W�D, 
        '�@CB01�G����-�L�u�q��, 
        '�@CC01�G����-�ϰ�ʼs���Ʒ~, 
        '�@CC02�G����-���ϩʼs���Ʒ~, 
        '�@CC03�G����-����q�O�ΰ]�Ϊk�H, 
        'YYY�G3�X�A������~3�X, 
        'NNNNN�G5�X�Ǹ��A��00001�}�l�A�C����1���[1�A�C�~���m, 
        'R�G1�X�ˮֽX�A�W�h�p�U�G
        'YY(��2�X)/(�Ǹ���4�X�ϧǸ���5�X+1)�A�p�⵲�G����ƪ��Ӧ�ơC
        '' <summary>
        '' CASE_NO �ץ�s��
        '' </summary>
        Public Property CASE_NO() As String
            Get
                Return Me.ColumnyMap("CASE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_NO") = value
            End Set
        End Property
#End Region

#Region "CASE_SEQ �ɥ�����"
        '��ס]�L�ɥ��^��0�A�ɥ���1����1�A�̦�����"
        '' <summary>
        '' CASE_SEQ �ɥ�����
        '' </summary>
        Public Property CASE_SEQ() As String
            Get
                Return Me.ColumnyMap("CASE_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_SEQ") = value
            End Set
        End Property
#End Region

#Region "COM_PKNO �~��PKNO"
        'REF. APPL010.PKNO, 
        '�ΨӬ����O���a�~�̪��ץ�A���ϥβνs�����p�O�Ҷq���~�̬��w�]���L�νs�A�H�η~�̲νs�i��|�ܧ�C
        '' <summary>
        '' COM_PKNO �~��PKNO
        '' </summary>
        Public Property COM_PKNO() As String
            Get
                Return Me.ColumnyMap("COM_PKNO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("COM_PKNO") = value
            End Set
        End Property
#End Region

#Region "CASE_CODE �~�ȥN��"
        '�ץ�s���e4�X, 
        'REF. SYST010.SYS_KEY=CASE_CODE
        '' <summary>
        '' CASE_CODE �~�ȥN��
        '' </summary>
        Public Property CASE_CODE() As String
            Get
                Return Me.ColumnyMap("CASE_CODE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_CODE") = value
            End Set
        End Property
#End Region

#Region "DEL_FLAG �R�����O"
        '0�G���`, 
        '1�G�w�R��"
        '' <summary>
        '' DEL_FLAG �R�����O
        '' </summary>
        Public Property DEL_FLAG() As String
            Get
                Return Me.ColumnyMap("DEL_FLAG")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEL_FLAG") = value
            End Set
        End Property
#End Region

#Region "CASE_STATUS �ץ�i��"
        'REF. SYST010, SYS_KEY=CASE_STATUS"
        '' <summary>
        '' CASE_STATUS �ץ�i��
        '' </summary>
        Public Property CASE_STATUS() As String
            Get
                Return Me.ColumnyMap("CASE_STATUS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CASE_STATUS") = value
            End Set
        End Property
#End Region

#Region "RESULT1 ��f�f�d���G"
        'REF. SYST010
        '' <summary>
        '' RESULT1 ��f�f�d���G
        '' </summary>
        Public Property RESULT1() As String
            Get
                Return Me.ColumnyMap("RESULT1")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT1") = value
            End Set
        End Property
#End Region

#Region "RESULT1_DATE ��f�f�d�������"
        '' <summary>
        '' RESULT1_DATE ��f�f�d�������
        '' </summary>
        Public Property RESULT1_DATE() As String
            Get
                Return Me.ColumnyMap("RESULT1_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT1_DATE") = value
            End Set
        End Property
#End Region

#Region "RESULT1_DESC ��f�N��"
        '' <summary>
        '' RESULT1_DESC ��f�N��
        '' </summary>
        Public Property RESULT1_DESC() As String
            Get
                Return Me.ColumnyMap("RESULT1_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT1_DESC") = value
            End Set
        End Property
#End Region

#Region "RESULT2 �Ըߩe���|ĳ�f�d���G"
        'REF.SYST010
        '' <summary>
        '' RESULT2 �Ըߩe���|ĳ�f�d���G 
        '' </summary>
        Public Property RESULT2() As String
            Get
                Return Me.ColumnyMap("RESULT2")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT2") = value
            End Set
        End Property
#End Region

#Region "RESULT2_DATE �Ըߩe���|ĳ�f�d�������"
        '' <summary>
        '' RESULT2_DATE �Ըߩe���|ĳ�f�d�������
        '' </summary>
        Public Property RESULT2_DATE() As String
            Get
                Return Me.ColumnyMap("RESULT2_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT2_DATE") = value
            End Set
        End Property
#End Region

#Region "RESULT2_DESC �Ըߩe���|ĳ�f�d�N��"
        '' <summary>
        '' RESULT2_DESC �Ըߩe���|ĳ�f�d�N��
        '' </summary>
        Public Property RESULT2_DESC() As String
            Get
                Return Me.ColumnyMap("RESULT2_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT2_DESC") = value
            End Set
        End Property
#End Region

#Region "RESULT3 ���|�e���|ĳ�f�d���G"
        'REF. SYST010
        '' <summary>
        '' RESULT3 ���|�e���|ĳ�f�d���G 
        '' </summary>
        Public Property RESULT3() As String
            Get
                Return Me.ColumnyMap("RESULT3")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT3") = value
            End Set
        End Property
#End Region

#Region "RESULT3_DATE ���|�e���|ĳ�f�d�������"
        '' <summary>
        '' RESULT3_DATE ���|�e���|ĳ�f�d�������
        '' </summary>
        Public Property RESULT3_DATE() As String
            Get
                Return Me.ColumnyMap("RESULT3_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT3_DATE") = value
            End Set
        End Property
#End Region

#Region "RESULT3_DESC ���|�e���|ĳ�f�d�N��"
        '' <summary>
        '' RESULT3_DESC ���|�e���|ĳ�f�d�N��
        '' </summary>
        Public Property RESULT3_DESC() As String
            Get
                Return Me.ColumnyMap("RESULT3_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("RESULT3_DESC") = value
            End Set
        End Property
#End Region

#Region "CREATE_USER ��ƫإߪ�"
        '' <summary>
        '' CREATE_USER ��ƫإߪ�
        '' </summary>
        Public Property CREATE_USER() As String
            Get
                Return Me.ColumnyMap("CREATE_USER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CREATE_USER") = value
            End Set
        End Property
#End Region

#Region "CREATE_DATE ��ƫإߤ��"
        '' <summary>
        '' CREATE_DATE ��ƫإߤ��
        '' </summary>
        Public Property CREATE_DATE() As String
            Get
                Return Me.ColumnyMap("CREATE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CREATE_DATE") = value
            End Set
        End Property
#End Region

#Region "UPDATE_USER ��ƺ��@��"
        '' <summary>
        '' UPDATE_USER ��ƺ��@��
        '' </summary>
        Public Property UPDATE_USER() As String
            Get
                Return Me.ColumnyMap("UPDATE_USER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UPDATE_USER") = value
            End Set
        End Property
#End Region

#Region "UPDATE_DATE ��ƺ��@���"
        '' <summary>
        '' UPDATE_DATE ��ƺ��@���
        '' </summary>
        Public Property UPDATE_DATE() As String
            Get
                Return Me.ColumnyMap("UPDATE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UPDATE_DATE") = value
            End Set
        End Property
#End Region

#Region "LICENSE_NO ���Ӹ��X"
        '' <summary>
        '' LICENSE_NO ���Ӹ��X
        '' </summary>
        Public Property LICENSE_NO() As String
            Get
                Return Me.ColumnyMap("LICENSE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("LICENSE_NO") = value
            End Set
        End Property
#End Region

#Region "CHANG_LICENSE_DATE ���Ӥ��"
        '' <summary>
        '' CHANG_LICENSE_DATE ���Ӥ��
        '' </summary>
        Public Property CHANG_LICENSE_DATE() As String
            Get
                Return Me.ColumnyMap("CHANG_LICENSE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CHANG_LICENSE_DATE") = value
            End Set
        End Property
#End Region

#Region "OTHER_UNIT_DESC �|��N��"
        '' <summary>
        '' OTHER_UNIT_DESC �|��N��
        '' </summary>
        Public Property OTHER_UNIT_DESC() As String
            Get
                Return Me.ColumnyMap("OTHER_UNIT_DESC")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("OTHER_UNIT_DESC") = value
            End Set
        End Property
#End Region

#Region "APV_DATE �즸�e�fNCC�ɶ�"
        '' <summary>
        '' APV_DATE �즸�e�fNCC�ɶ�
        '' </summary>
        Public Property APV_DATE() As String
            Get
                Return Me.ColumnyMap("APV_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("APV_DATE") = value
            End Set
        End Property
#End Region
#End Region

#Region "�ۭq��k"
#Region "Query �d�� "
        ''' <summary>
        ''' �d�� 
        ''' </summary>
        Public Overrides Function Query() As DataTable
            Return Me.Query(0, 0)
        End Function

        ''' <summary>
        ''' �d�� 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1   �s�W��k
        ''' </remarks>
        Public Overrides Function Query(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �ˮ����_�l ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
                End If
                '=== �ˮ���쵲�� ===

                '=== �B�z�O�W === 
                Me.TableCoumnInfo.Add(New String() {"APPL020", "M", "CASE_CODE", "", "DEL_FLAG", "CASE_STATUS", "COM_PKNO"})
                Me.TableCoumnInfo.Add(New String() {"APP1010", "A", "APP_PERSON_NM"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "B", "CASE_CODE"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "C", "CASE_STATUS"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.* ")
                'If APConfig.GetProperty("ENCODE_COLUMN").ToString.Length > 0 Then
                '    sql.AppendLine(" , dbo.TripleDesDecrypt(A.APP_PERSON_NM) AS 'APP_PERSON_NM'  ")
                'Else
                '    sql.AppendLine(" , A.APP_PERSON_NM AS 'APP_PERSON_NM' ")
                'End If
                sql.AppendLine(" , (ROW_NUMBER() OVER (ORDER BY M.PKNO) ) AS ROW_NUM ")
                sql.AppendLine(" , A.APP_PERSON_NM AS 'APP_PERSON_NM' ")
                sql.AppendLine(" , B.SYS_NAME AS 'CASE_CODE_NM', C.SYS_NAME AS 'CASE_STATUS_NM', C.SYS_RSV1 AS 'IMG_LIGHT', D.SYS_NAME AS 'CASE_STATUS_NM2' ")
                sql.AppendLine("  , CASE ")
                sql.AppendLine(" 		WHEN M.CASE_CODE IN ('AA03', 'AA04', 'AA05', 'AA06', 'CA03', 'CA04', 'CA05', 'CA06') THEN  ")
                sql.AppendLine(" 			(SELECT APP1010.SYS_CNAME FROM APP1010 WHERE M.CASE_NO = APP1010.CASE_NO) ")
                sql.AppendLine(" 		WHEN M.CASE_CODE IN ('BA03', 'BA04', 'BA05', 'BA06')  THEN ")
                sql.AppendLine(" 			(SELECT APP1170.CHANNEL_NAME FROM APP1170 WHERE M.CASE_NO = APP1170.CASE_NO) ")
                sql.AppendLine(" 		ELSE '' ")
                sql.AppendLine("    END AS THIS_CASE_CHANNEL_NAME ")
                sql.AppendLine(" FROM APPL020 M ")
                sql.AppendLine(" LEFT JOIN APP1010 A ON M.CASE_NO = A.CASE_NO ")
                sql.AppendLine(" LEFT JOIN SYST010 B ON (B.SYS_ID = M.CASE_CODE AND B.SYS_KEY='CASE_CODE') ")
                sql.AppendLine(" LEFT JOIN SYST010 C ON (C.SYS_ID = M.CASE_STATUS AND C.SYS_KEY='CASE_STATUS') ")
                sql.AppendLine(" LEFT JOIN SYST010 D ON (D.SYS_ID = C.SYS_RSV2 AND D.SYS_KEY='CASE_STATUS2') ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.CASE_NO ")
                    Else
                        sql.AppendLine(" ORDER BY M.CASE_NO ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        ''' <summary>
        ''' Web Service Query
        ''' </summary>
        ''' <returns></returns>
        Public Function Query_WS(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== �ˮ����_�l ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("�ݩʸ�Ƥ��i����", Utility.ArrayListToString(faileArguments))
                End If
                '=== �ˮ���쵲�� ===

                '=== �B�z�O�W === 
                Me.TableCoumnInfo.Add(New String() {"APPL020", "M", "CASE_CODE", "", "DEL_FLAG", "CASE_STATUS", "COM_PKNO"})
                Me.TableCoumnInfo.Add(New String() {"APP1010", "A", "APP_PERSON_NM"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "B", "CASE_CODE"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "C", "CASE_STATUS"})
                Me.ParserAlias()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT M.* ")
                'sql.AppendLine(" , HIS010.CREATE_TIME AS HIS010_CREATE_TIME")
                sql.AppendLine(" , ( select   ")
                sql.AppendLine("        CREATE_TIME as HIS_CREATE_TIME ")
                sql.AppendLine("     from HIS010")
                sql.AppendLine("     where CASE_NO = '" + Me.CASE_NO + "' ")
                sql.AppendLine("     and CASE_STATUS = '10' ")
                sql.AppendLine("     and TBL_RECID = (select min(TBL_RECID) from HIS010 where CASE_NO = '" + Me.CASE_NO + "')")
                sql.AppendLine("    ) AS HIS010_CREATE_TIME ")
                If APConfig.GetProperty("ENCODE_COLUMN").ToString.Length > 0 Then
                    sql.AppendLine(" , dbo.TripleDesDecrypt(A.APP_PERSON_NM)   ")
                Else
                    sql.AppendLine(" , A.APP_PERSON_NM ")
                End If
                'sql.AppendLine(" , A.APP_PERSON_NM AS 'APP_PERSON_NM' ")
                sql.AppendLine(" , B.SYS_NAME AS 'CASE_CODE_NM', C.SYS_NAME AS 'CASE_STATUS_NM', C.SYS_RSV1 AS 'IMG_LIGHT', D.SYS_NAME AS 'CASE_STATUS_NM2' ")
                sql.AppendLine(" FROM APPL020 M ")
                sql.AppendLine(" LEFT JOIN APP1010 A ON M.CASE_NO = A.CASE_NO ")
                'sql.AppendLine(" LEFT JOIN HIS010 ON M.CASE_NO = HIS010.CASE_NO AND HIS010.TBL_RECID = (SELECT MIN(TBL_RECID) FROM HIS010 WHERE CASE_NO = '" + Me.CASE_NO + "' GROUP BY CASE_NO ) ")
                sql.AppendLine(" LEFT JOIN SYST010 B ON (B.SYS_ID = M.CASE_CODE AND B.SYS_KEY='CASE_CODE') ")
                sql.AppendLine(" LEFT JOIN SYST010 C ON (C.SYS_ID = M.CASE_STATUS AND C.SYS_KEY='CASE_STATUS') ")
                sql.AppendLine(" LEFT JOIN SYST010 D ON (D.SYS_ID = C.SYS_RSV2 AND D.SYS_KEY='CASE_STATUS2') ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                If Me.OrderBys <> "" Then
                    sql.AppendLine(" ORDER BY  " & Me.OrderBys)
                Else
                    If pageNo = 0 Then
                        sql.AppendLine(" ORDER BY M.CASE_NO ")
                    Else
                        sql.AppendLine(" ORDER BY M.CASE_NO ")
                    End If
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function


        Public Function QueryCaseList() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Me.TableCoumnInfo.Add(New String() {"APPL020", "M", "CASE_CODE", "DEL_FLAG", "CASE_STATUS", "COM_PKNO"})
                Me.TableCoumnInfo.Add(New String() {"APP1010", "A", "APP_PERSON_NM"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "B", "CASE_CODE"})
                Me.TableCoumnInfo.Add(New String() {"SYST010", "C", "CASE_STATUS"})
                Me.ParserAlias()

                '�Y��줺�e���w�[�K�A�h����SQL�ɥi��|�]���S��Ÿ��ɭP�������~�A�ݦ�ѱKFunction
                Dim sql As New StringBuilder
                'sql.AppendLine(" SELECT M.*, dbo.TripleDesDecrypt(A.APP_PERSON_NM), B.SYS_NAME AS 'CASE_CODE_NM', C.SYS_NAME AS 'CASE_STATUS_NM', C.SYS_RSV1 AS 'IMG_LIGHT', D.SYS_NAME AS 'CASE_STATUS_NM2' ")
                sql.AppendLine(" SELECT M.* ")
                If APConfig.GetProperty("ENCODE_COLUMN").ToString.Length > 0 Then
                    sql.AppendLine(" , dbo.TripleDesDecrypt(A.APP_PERSON_NM) ")
                Else
                    sql.AppendLine(" , A.APP_PERSON_NM ")
                End If
                sql.AppendLine(" , B.SYS_NAME AS 'CASE_CODE_NM', C.SYS_NAME AS 'CASE_STATUS_NM', C.SYS_RSV1 AS 'IMG_LIGHT', D.SYS_NAME AS 'CASE_STATUS_NM2' ")
                sql.AppendLine(" , ( select   ")
                sql.AppendLine("        CREATE_TIME as HIS_CREATE_TIME ")
                sql.AppendLine("     from HIS010")
                sql.AppendLine("     where CASE_NO = '" + Me.CASE_NO + "' ")
                sql.AppendLine("     and CASE_STATUS = '10' ")
                sql.AppendLine("     and TBL_RECID = (select min(TBL_RECID) from HIS010 where CASE_NO = '" + Me.CASE_NO + "')")
                sql.AppendLine("    ) AS HIS010_CREATE_TIME ")
                sql.AppendLine(" FROM APPL020 M ")
                sql.AppendLine(" LEFT JOIN APP1010 A ON M.CASE_NO = A.CASE_NO ")
                sql.AppendLine(" LEFT JOIN SYST010 B ON (B.SYS_ID = M.CASE_CODE AND B.SYS_KEY='CASE_CODE') ")
                sql.AppendLine(" LEFT JOIN SYST010 C ON (C.SYS_ID = M.CASE_STATUS AND C.SYS_KEY='CASE_STATUS') ")
                sql.AppendLine(" LEFT JOIN SYST010 D ON (D.SYS_ID = C.SYS_RSV2 AND D.SYS_KEY='CASE_STATUS2') ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" WHERE " & Me.ProcessCondition(Me.SqlRetrictions))
                End If

                sql.AppendLine(" ORDER BY M.CASE_NO ")

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#Region "���^�ץ��T"
        Public Function QueryByCaseNo(Optional ByVal CaseNo As String = "") As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" SELECT R1.SYS_NAME, R1.SYS_ID, M.CASE_NO, M.CASE_STATUS, R2.SYS_NAME AS 'CASE_STATUS_NM', R3.APP_PERSON_NM, M.CASE_SEQ, R4.SYS_NAME AS 'CASE_STATUS_NM2' ")
                sql.AppendLine("    , M.APV_DATE ")
                sql.AppendLine(" FROM APPL020 M ")
                sql.AppendLine(" LEFT JOIN SYST010 R1 ON R1.SYS_ID = M.CASE_CODE ")
                sql.AppendLine(" LEFT JOIN SYST010 R2 ON (R2.SYS_ID = M.CASE_STATUS AND R2.SYS_KEY = 'CASE_STATUS') ")
                sql.AppendLine(" LEFT JOIN SYST010 R4 ON (R4.SYS_ID = R2.SYS_RSV2 AND R4.SYS_KEY='CASE_STATUS2') ")
                sql.AppendLine(" LEFT JOIN APP1010 R3 ON R3.CASE_NO = M.CASE_NO ")
                sql.AppendLine(" WHERE M.CASE_NO ='" & CaseNo & "'")
                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#Region "�ή׸��d�߾��c���� QueryOrgTypeByCaseNo"
        ''' <summary>
        ''' �ή׸��d�߾��c����
        ''' </summary>
        Public Function QueryOrgTypeByCaseNo() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" select A010.ORG_TYPE ")
                sql.AppendLine(" from APPL020 A020 ")
                sql.AppendLine(" join APPL010 A010 on A010.PKNO = A020.COM_PKNO ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" where " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

#End Region


#Region "�d�X���q�������BY CASE_NO"
        ''' <summary>
        ''' �d�X���q�������BY CASE_NO
        ''' type = APP120324:���W�D�W��
        ''' type = APP120705:�¬d�νs
        ''' </summary>
        Public Function GetCompanyDataByCASE_NO(ByVal type As String) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder

                Select Case type.ToUpper
                    Case "APP120324"
                        sql.AppendLine(" select A010.BUS_NO, A1170.CHANNEL_NAME, A010.COM_CNAM  ")
                        sql.AppendLine(" from APPL020 A020 ")
                        sql.AppendLine(" inner join APPL010 A010 on A010.PKNO = A020.COM_PKNO ")
                        sql.AppendLine(" inner join APP1170 A1170 on A020.CASE_NO = A1170.CASE_NO ")
                    Case "CA03", "CA04", "CA05", "CA06"
                        sql.AppendLine(" select A010.BUS_NO, A1010.SYS_CNAME, A010.COM_CNAM  ")
                        sql.AppendLine(" from APPL020 A020 ")
                        sql.AppendLine(" inner join APPL010 A010 on A010.PKNO = A020.COM_PKNO ")
                        sql.AppendLine(" inner join APP1010 A1010 on A020.CASE_NO = A1010.CASE_NO  ")
                    Case Else
                        sql.AppendLine(" select A010.BUS_NO, A010.COM_CNAM  ")
                        sql.AppendLine(" from APPL020 A020 ")
                        sql.AppendLine(" inner join APPL010 A010 on A010.PKNO = A020.COM_PKNO ")
                End Select

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" where " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "�ꤽ�夶���׸����D��"
        ''' <summary>
        ''' �ꤽ�夶���׸����D��
        ''' </summary>
        Public Function GetSYSID() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" select top 1 S010.SYS_ID ")
                sql.AppendLine(" from APPL020 A020 ")
                sql.AppendLine(" join SYST010 S010 on S010.SYS_KEY = 'CASE_CODE' AND S010.SYS_ID = A020.CASE_CODE  ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" where " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        ''' <summary>
        ''' �ꤽ�夶���׸����D�� Type01
        ''' </summary>
        Public Function GetSubject_Type01() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" select A010.COM_CNAM, S010.SYS_NAME, A1010.SYS_CNAME ")
                sql.AppendLine(" from APPL020 A020 ")
                sql.AppendLine(" join APPL010 A010 on A010.PKNO = A020.COM_PKNO ")
                sql.AppendLine(" join SYST010 S010 on S010.SYS_KEY = 'CASE_CODE' AND S010.SYS_ID = A020.CASE_CODE  ")
                sql.AppendLine(" join APP1010 A1010 on A1010.CASE_NO = A020.CASE_NO ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" where " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        ''' <summary>
        ''' �ꤽ�夶���׸����D�� Type02
        ''' </summary>
        Public Function GetSubject_Type02() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" select A010.COM_CNAM, S010.SYS_NAME, A1170.CHANNEL_NAME ")
                sql.AppendLine(" from APPL020 A020 ")
                sql.AppendLine(" join APPL010 A010 on A010.PKNO = A020.COM_PKNO ")
                sql.AppendLine(" join SYST010 S010 on S010.SYS_KEY = 'CASE_CODE' AND S010.SYS_ID = A020.CASE_CODE  ")
                sql.AppendLine(" join APP1170 A1170 on A020.CASE_NO = A1170.CASE_NO  ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" where " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Me.ResetColumnProperty()

                Return dt

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        ''' <summary>
        ''' �ꤽ�夶���׸����D�� Type03
        ''' </summary>
        Public Function GetSubject_Type03() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                Dim sql As New StringBuilder
                sql.AppendLine(" select A010.COM_CNAM, S010.SYS_NAME ")
                sql.AppendLine(" from APPL020 A020 ")
                sql.AppendLine(" join APPL010 A010 on A010.PKNO = A020.COM_PKNO ")
                sql.AppendLine(" join SYST010 S010 on S010.SYS_KEY = 'CASE_CODE' AND S010.SYS_ID = A020.CASE_CODE  ")

                If Not String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    sql.AppendLine(" where " & Me.ProcessCondition(Me.SqlRetrictions).Replace("$.", " "))
                End If

                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

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

