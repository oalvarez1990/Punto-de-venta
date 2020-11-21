﻿Imports System.Data.SqlClient
Public Class Registro_clientes
    Public indicador As String
    Private Sub GuardarRegistro_Click(sender As Object, e As EventArgs) Handles GuardarRegistro.Click
        Try
            Dim cmd As New SqlCommand
            If txtnombrecliente.Text <> "" Then
                If txtdirecciondefactura.Text = "" Then txtdirecciondefactura.Text = "-"
                If txtrucdefactura.Text = "" Then txtdirecciondefactura.Text = "0"
                If txtcelular.Text = "" Then txtdirecciondefactura.Text = "0"
                abrir()
                cmd = New SqlCommand("insertar_cliente", conexion)
                cmd.CommandType = 4
                cmd.Parameters.AddWithValue("@Nombre", txtnombrecliente.Text)
                cmd.Parameters.AddWithValue("@Direccion_para_factura", txtdirecciondefactura.Text)
                cmd.Parameters.AddWithValue("@Ruc ", txtrucdefactura.Text)
                cmd.Parameters.AddWithValue("@movil", txtcelular.Text)

                cmd.Parameters.AddWithValue("@Cliente ", "SI")
                cmd.Parameters.AddWithValue("@Proveedor", "NO")


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
        txtrucdefactura.Text = ""
        txtcelular.Text = ""


    End Sub
    Private Sub Registro_clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LIMPIAR()

    End Sub

    Private Sub VOLVERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VOLVERToolStripMenuItem.Click
        Dispose()

    End Sub
End Class