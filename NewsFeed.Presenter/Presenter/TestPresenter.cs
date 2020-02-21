using NewsFeed.Model.IRepository;
using NewsFeed.Model.Repository;
using NewsFeed.Presenter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Presenter.Presenter
{
    public class TestPresenter
    {
        private ITest _view; 

        public TestPresenter(ITest view)
        {
            _view = view; 
        } 


        public void Test()
        {
         
        }
    }
}
