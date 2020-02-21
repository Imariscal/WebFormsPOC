using NewsFeed.Entity.Dto;
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
    public partial class News : System.Web.UI.Page, IRssNews
    {
        private RssNewsPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                this.RssUrl = "https://www.espn.com/espn/rss/soccer/news";  
                Presenter.LoadNews();
            }
        }

        #region Interface 


        public RssNewsPresenter Presenter
        {
            get
            {
                if (presenter == null) presenter = new RssNewsPresenter(this);
                return presenter;
            }
        }

        public List<NewsDto> DataSource
        {
            set
            {
                this.gvNews.DataSource = value;
                this.gvNews.DataBind();
            }
        }

        public int NewsId { 
           
            set {
                this.hdfNewsId.Value = value.ToString();
            } 
            get {

                int id = 0;
                int.TryParse(this.hdfNewsId.Value, out id);
                return id;
            }
        }

        public string NewsTitle { 
            
            get {
                return this.hdfTitle.Value;
            } 
            set {
                this.hdfTitle.Value = value;
            }
        
        }

        public string RssUrl { 
        
            get
            {
                return txtUrl.Text;
            }
            set
            {
                txtUrl.Text = value;
            }
        }

        public void OnError(string errorMessage)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Javascript", "javascript:alert('" + errorMessage + "'); ", true);

        }


        #endregion

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            Presenter.SubscribeNews();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Presenter.LoadNews();
        }
    }
}