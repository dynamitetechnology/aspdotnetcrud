<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron rounded-0">

  <div class="row">
    <div class="col">
        <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="fName" class="form-control rounded-0" runat="server"></asp:TextBox>
    </div>
    <div class="col">
     <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="lName" class="form-control rounded-0" runat="server"></asp:TextBox>
    </div>
       <div class="col">
     <asp:Label ID="Label3" runat="server" Text="Upload Image"></asp:Label>
       <asp:FileUpload id="FileUpLoad1" runat="server" />  
    </div>
  </div>
        <asp:Button ID="Button1" class="btn btn-success rounded-0 btn-lg btn-block mt-5" OnClick="insertData" runat="server" Text="Button" />
    </div>




    <table class="table">
         <tbody>  
        <% for (var data = 0; data < TableData.Rows.Count; data++){ %>  
            <tr class="gradeA odd" role="row">  
                <td class="sorting_1">  
                    <%=TableData.Rows[data]["fname"]%>  
                </td>  
                <td>  
                    <%=TableData.Rows[data]["lname"]%>  
                </td>  
                <td>  
                <a href="edit?id=<%=TableData.Rows[data]["id"]%>">Edit</a>
                <a class="deleteButton" data-id = '<%=TableData.Rows[data]["id"]%>'>Delete</a>
                </td>  
            </tr>  
            <% } %>  
    </tbody>  
    </table>




     <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
    <script src="Scripts/bootstrap.bundle.js"></script>
  <script type="text/javascript">
      $(document).ready(function () {
          $(".deleteButton").on('click', function () {
              let id = $(this).attr('data-id');
              console.log('Hello', id)
              $.ajax({
                  type: "POST",
                  contentType: "application/json; charset=utf-8",
                  url: "WebServiceAjax.asmx/deleteRecord",
                  dataType: "json",
                  data: "{'id':'" + id + "'}", 
                  success: function (resp) {
                      console.log('resp', resp)
                  },
                  
              });
          })
      })
  </script>
</asp:Content>
