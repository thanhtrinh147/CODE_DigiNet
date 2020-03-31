'#------------------------------------------------------
'#Title: D99C1004
'#CreateUser: NGUYEN NGOC THANH
'#CreateDate: 31/08/2008
'#ModifiedUser: NGUYEN NGOC THANH
'#ModifiedDate: 31/08/2008
'#Description: Xử lý Export to Excel
'#------------------------------------------------------

Imports System

Public Class Field
    Private _iD As String
    Public Property ID() As String
        Get
            Return _iD
        End Get
        Set(ByVal Value As String)
            _iD = Value
        End Set
    End Property

    Private _field As String
    Public Property Field() As String
        Get
            Return _field
        End Get
        Set(ByVal Value As String)
            _field = Value
        End Set
    End Property

    Private _position1 As String
    Public Property Position1() As String
        Get
            Return _position1
        End Get
        Set(ByVal Value As String)
            _position1 = Value
        End Set
    End Property

    Private _position2 As String
    Public Property Position2() As String
        Get
            Return _position2
        End Get
        Set(ByVal Value As String)
            _position2 = Value
        End Set
    End Property

    Private _cell1 As New Point(0, 0)
    Public Property Cell1() As Point
        Get
            Return _cell1
        End Get
        Set(ByVal Value As Point)
            _cell1 = Value
        End Set
    End Property

    Private _cell2 As New Point(0, 0)
    Public Property Cell2() As Point
        Get
            Return _cell2
        End Get
        Set(ByVal Value As Point)
            _cell2 = Value
        End Set
    End Property

    Private _totalFooter As Double = 0
    Public Property TotalFooter() As Double
        Get
            Return _totalFooter
        End Get
        Set(ByVal Value As Double)
            _totalFooter = Value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal mID As String, ByVal mField As String, ByVal mPosition1 As String, ByVal mPosition2 As String)
        _iD = mID
        _field = mField
        _position1 = mPosition1
        _position2 = mPosition2
    End Sub

End Class

Public Class ListFields
    Dim arr() As Field
    Dim _index As Integer = -1

    Private Function FindString(ByVal str As String) As Integer
        For i As Integer = 0 To arr.Length - 1
            If arr(i).ID = str Then
                Return i
            End If
        Next
        Return -1
    End Function

    Public Property Index(ByVal mIndex As Integer) As Field
        Get
            If mIndex > _index Then
                Return Nothing
            Else
                Return arr(_index)
            End If
        End Get
        Set(ByVal value As Field)
            If mIndex <= _index Then
                arr(mIndex) = value
            End If
        End Set
    End Property

    Public Property Index(ByVal str As String) As Field
        Get
            Dim i As Integer = FindString(str)
            If i >= 0 Then
                Return arr(i)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As Field)
            Dim i As Integer = FindString(str)
            If i >= 0 Then
                arr(i) = value
            End If
        End Set
    End Property

    Public ReadOnly Property Items() As Field()
        Get
            Return arr
        End Get
    End Property

    Public Sub Add(ByVal value As Field)
        _index += 1
        ReDim Preserve arr(_index)
        arr(_index) = value
    End Sub

    Public Function FindField(ByVal sField As String) As ArrayList
        Dim arrResult As New ArrayList
        For i As Integer = 0 To arr.Length - 1
            If arr(i).Field = sField Then
                arrResult.Add(arr(i))
            End If
        Next
        Return arrResult
    End Function

End Class
