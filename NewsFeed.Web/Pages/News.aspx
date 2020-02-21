<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="NewsFeed.Web.Pages.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">

        <div class="row">
            <div class="col-md-12">
                <h1>
                    Sport News
                </h1>
            </div>
        </div>


 

        
        <div class="row">
            <div class="col-md-1">
               <h4>
                   Url :
               </h4>
            </div>

            <div class="col-md-9 text-left">         

                  <asp:TextBox ID="txtUrl" runat="server"  Width="680px"></asp:TextBox>
            
            </div>
            
            <div class="col-md-2">
                <asp:Button ID="btnSearch" runat="server"  Text="Search" OnClick="btnSearch_Click"/>
             </div>

        </div>


        <div class="row">

            <div class="col-md-12 col-offset-1">

                       <asp:GridView ID="gvNews" runat="server"
                    AutoGenerateColumns="false" Width="100%"
                    BorderStyle="None" BorderColor="#cacbcc">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True" />
                        <asp:BoundField DataField="Summary" HeaderText="Summary" ReadOnly="True" />
                          <asp:BoundField DataField="PublishDate"  HeaderStyle-Width="150px" HeaderText="PublishDate" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="100px">
                          <ItemTemplate>
                                <label style="cursor:pointer; color:#080dfc" onclick="news.subscribeNews(<%# DataBinder.Eval(Container.DataItem, "NewsId") %>, '<%# DataBinder.Eval(Container.DataItem, "Title") %>')">
                                    Subscribe
                                </label>
                          </ItemTemplate> 
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

        </div>


        <div style="display:none">
            <asp:Button ID="btnSubscribe" ClientIDMode="Static" runat="server" OnClick="btnSubscribe_Click" />
            <asp:HiddenField ID="hdfTitle" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="hdfNewsId" ClientIDMode="Static" runat="server" />
        </div>

        <script src="../Scripts/Customs/news.js"></script>


    </div>

</asp:Content>
