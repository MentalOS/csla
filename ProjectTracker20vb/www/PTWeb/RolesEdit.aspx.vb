Option Strict On

Imports ProjectTracker.Library.Admin

Partial Class RolesEdit
  Inherits System.Web.UI.Page

  Protected Sub AddRoleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddRoleButton.Click

    Me.DetailsView1.DefaultMode = DetailsViewMode.Insert
    MultiView1.ActiveViewIndex = 1

  End Sub

  Protected Sub DetailsView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewInsertedEventArgs) Handles DetailsView1.ItemInserted

    MultiView1.ActiveViewIndex = 0
    Me.GridView1.DataBind()

  End Sub

  Protected Sub DetailsView1_ModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetailsView1.ModeChanged

    MultiView1.ActiveViewIndex = 0

  End Sub

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    Me.GridView1.DataKeyNames = New String() {"Id"}

  End Sub

  Protected Sub RolesDataSource_DeleteObject(ByVal sender As Object, ByVal e As Csla.Web.DeleteObjectArgs) Handles RolesDataSource.DeleteObject

    Dim obj As Roles = CType(Session("currentObject"), Roles)
    Dim id As Integer = CInt(e.Keys.Item("Id"))
    obj.Remove(id)
    Session("currentObject") = obj.Save

  End Sub

  Protected Sub RolesDataSource_InsertObject(ByVal sender As Object, ByVal e As Csla.Web.InsertObjectArgs) Handles RolesDataSource.InsertObject

    Dim obj As Roles = CType(Session("currentObject"), Roles)
    Dim role As Role = obj.AddNew
    role.Id = CInt(e.Values.Item("Id"))
    role.Name = e.Values.Item("Name").ToString
    Session("currentObject") = obj.Save

  End Sub

  Protected Sub RolesDataSource_SelectObject(ByVal sender As Object, ByVal e As Csla.Web.SelectObjectArgs) Handles RolesDataSource.SelectObject

    Dim obj As ProjectTracker.Library.Admin.Roles
    obj = ProjectTracker.Library.Admin.Roles.GetRoles
    Session("currentObject") = obj
    e.BusinessObject = obj

  End Sub

  Protected Sub RolesDataSource_UpdateObject(ByVal sender As Object, ByVal e As Csla.Web.UpdateObjectArgs) Handles RolesDataSource.UpdateObject

    Dim obj As Roles = CType(Session("currentObject"), Roles)
    Dim role As Role = obj.GetRoleById(CInt(e.Keys.Item("Id")))
    role.Name = e.Values.Item("Name").ToString
    Session("currentObject") = obj.Save

  End Sub

End Class
