Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace dxSample
    Public Class Person
        Public Sub New()

        End Sub
        ' Fields...
        Private _Birthdate As Date
        Private _Name As String
        Private _ID As Integer

        Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property


        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Public Property Birthday() As Date
            Get
                Return _Birthdate
            End Get
            Set(ByVal value As Date)
                _Birthdate = value
            End Set
        End Property
    End Class
End Namespace
