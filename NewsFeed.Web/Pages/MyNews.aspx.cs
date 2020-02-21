using NewsFeed.Entity.Models;
using NewsFeed.Presenter.Interfaces;
using NewsFeed.Presenter.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsFeed.Web.Pages
{
    public partial class MyNews : System.Web.UI.Page, IMyNews
    {

        private MyNewsPresenter presenter;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Presenter.LoadMyNews();
            }
        }


        #region Interface 

        public MyNewsPresenter Presenter
        {
            get
            {
                if (presenter == null) presenter = new MyNewsPresenter(this);
                return presenter;
            }
        }

        public List<Entity.Models.News> DataSource
        {
            set
            {
                this.gvNews.DataSource = value;
                this.gvNews.DataBind();
            }
        }

        public int NewsId
        {
            get
            {
                int newId = 0;
                int.TryParse(hdfNewsId.Value, out newId);
                return newId;
            }
            set
            {

                hdfNewsId.Value = value.ToString();
            }
        }

        public List<Comments> CommentsDataSource
        {
            set
            {
                this.gvComments.DataSource = value;
                this.gvComments.DataBind();
            }
        }

        public string Comment { 
         
            get
            {
                return this.txtComment.Text;
            }
            set
            {
                this.txtComment.Text = value;
            }
        }

        public int CommentId {
        
            get
            {
                int commentId = 0;
                int.TryParse(hdfCommentId.Value, out commentId);
                return commentId;
            }
            set
            {
                hdfCommentId.Value = value.ToString();
            }
        }

        public void OnError(string errorMessage)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Javascript", "javascript:alert('" + errorMessage + "'); ", true);
        }        
        #endregion

        protected void btnGetComments_Click(object sender, EventArgs e)
        {
            Presenter.LoadViewComments();
        }

        protected void btnNewComment_Click(object sender, EventArgs e)
        {
            ShowModal("New Comment");
          
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            Presenter.AddComment();
        }

        protected void btnDeleteComment_Click(object sender, EventArgs e)
        {
            Presenter.DeleComment();
        }

        protected void btnUpdateComment_Click(object sender, EventArgs e)
        {
            ShowModal("Update Comment");
        }

        void ShowModal(string title) {

            lblModalTitle.Text = title;
            this.txtComment.Focus();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }
    }
}