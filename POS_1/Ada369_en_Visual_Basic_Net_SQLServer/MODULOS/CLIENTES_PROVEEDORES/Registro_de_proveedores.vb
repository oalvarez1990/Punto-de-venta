﻿Imports System.Data.SqlClient
Public Class Rregistro_de_proveedores
    Public indicador As String
    Private Sub GuardarRegistro_Click(sender As Object, e As EventArgs) Handles GuardarRegistro.Click
        Try
            Dim cmd As New SqlCommand
            If txtnombrecliente.Text <> "" Then
                If txtdirecciondefactura.Text = "" Then txtdirecciondefactura.Text = "-"
                If txtcelular.Text = "" Then txtdirecciondefactura.Text = "0"
                abrir()
                cmd = New SqlCommand("insertar_cliente", conexion)
                cmd.CommandType = 4
                cmd.Parameters.AddWithValue("@Nombre", txtnombrecliente.Text)
                cmd.Parameters.AddWithValue("@Direccion_para_factura", txtdirecciondefactura.Text)
                cmd.Parameters.AddWithValue("@Ruc ", "-")
                cmd.Parameters.AddWithValue("@movil", txtcelular.Text)

                cmd.Parameters.AddWithValue("@Cliente ", "NO")
                cmd.Parameters.AddWithValue("@Proveedor", "SI")


                cmd.Parameters.AddWithValue("@Estado", "ACTIVO")
                cmd.Parameters.AddWithValue("@Saldo", 0)
                cmd.ExecuteNonQuery()
                Cerrar()
                If indicador = "APERTURA DE CREDITOS" Then
                    APERTURA_DE_CREDITOS.Timer1.Start()
                Else
                    MEDIOS_DE_PAGO.Timer2.Start()

                End If
                Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dispose()
    End Sub
    Sub LIMPIAR()


        txtnombrecliente.Text = ""
        txtdirecciondefactura.Text = ""


        txtcelular.Text = ""


    End Sub
    Private Sub Rregistro_de_proveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LIMPIAR()

    End Sub

    Private Sub VOLVERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VOLVERToolStripMenuItem.Click
        Dispose()
    End Sub
End Class