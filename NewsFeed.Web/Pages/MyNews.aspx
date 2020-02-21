<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyNews.aspx.cs" Inherits="NewsFeed.Web.Pages.MyNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container-fluid">

        <div class="row">
            <div class="col-md-12">
                <h1>My News
                </h1>
            </div>
        </div>


        <div class="row">

            <div class="col-md-6">
                
                <h4>My News Subscriptions </h4>

                <asp:GridView ID="gvNews" runat="server"
                    AutoGenerateColumns="false" Width="100%"
                    BorderStyle="None" BorderColor="#cacbcc">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="100px">
                            <ItemTemplate>                            
                                <label style="cursor: pointer; color: #080dfc" onclick="myNews.getComments(<%# DataBinder.Eval(Container.DataItem, "Id") %>)">
                                    View
                                </label>
                                <label style="cursor: pointer; color: black " onclick="myNews.addNewComments(<%# DataBinder.Eval(Container.DataItem, "Id") %>)">
                                    Add
                                </label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>


            <div class="col-md-6">

                <h4>Comments </h4>

                <asp:GridView ID="gvComments" runat="server"
                    AutoGenerateColumns="false" Width="100%"
                    BorderStyle="None" BorderColor="#cacbcc">
                    <Columns> 
                        <asp:BoundField DataField="Comment" HeaderText="Comment" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <label style="cursor: pointer; color: #ff0000" onclick="myNews.deleteComment(<%# DataBinder.Eval(Container.DataItem, "Id") %>)">
                                    Delete
                                </label>
                                <label style="cursor: pointer; color: #080dfc" onclick="myNews.updateComment(<%# DataBinder.Eval(Container.DataItem, "Id") %>, '<%# DataBinder.Eval(Container.DataItem, "Comment") %>' )">
                                    Update
                                </label>


                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>

        </div>


        <div style="display: none">
            <asp:Button ID="btnGetComments" ClientIDMode="Static" runat="server" OnClick="btnGetComments_Click" />
            <asp:Button ID="btnNewComment" ClientIDMode="Static" runat="server" OnClick="btnNewComment_Click" />           
            <asp:Button ID="btnAddComment" ClientIDMode="Static" runat="server" OnClick="btnAddComment_Click" />
            <asp:Button ID="btnDeleteComment" ClientIDMode="Static" runat="server" OnClick="btnDeleteComment_Click"   />
            <asp:Button ID="btnUpdateComment" ClientIDMode="Static" runat="server" OnClick="btnUpdateComment_Click"   />
            <asp:HiddenField ID="hdfNewsId" ClientIDMode="Static" runat="server" Value="0" />
            <asp:HiddenField ID="hdfCommentId" ClientIDMode="Static" runat="server" Value="0" />
        </div>



        <!-- Bootstrap Modal Dialog -->
        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">
                                    <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                            </div>
                            <div class="modal-body">                                
                                <div class="row">
                                    <div class="col-md-3">
                                        <label>Comment :  </label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtComment" runat="server" ClientIDMode="Static" Width="350px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true" onclick="myNews.saveComment()">Save</button>
                                <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Close</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

    </div>

    <script src="../Scripts/Customs/myNews.js"></script>


</asp:Content>
