var news = (function () {
  

    var btnSubscribe = document.getElementById("btnSubscribe");
    var hdfNewsId = document.getElementById("hdfNewsId");
    var hdfTitle = document.getElementById("hdfTitle");

    return {
        subscribeNews: function (id, title) {
            hdfNewsId.value = id;
            hdfTitle.value = title;
            btnSubscribe.click();
        }
    }
})();