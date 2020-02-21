using NewsFeed.Presenter.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Presenter.Interfaces
{
    public interface ITest
    {
        TestPresenter Presenter { get;  }

        void Test();
    }
}
