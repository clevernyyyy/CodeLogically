Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace ChatRoom.HubCommon
    Public Class Users
        Public Property Connection() As String
            Get
                Return m_Connection
            End Get
            Set(value As String)
                m_Connection = Value
            End Set
        End Property
        Private m_Connection As String
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(value As String)
                m_Name = Value
            End Set
        End Property
        Private m_Name As String
    End Class
End Namespace