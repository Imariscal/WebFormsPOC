var myNews = (function () {

    var btnGetComments = document.getElementById("btnGetComments");
    var btnNewComment = document.getElementById("btnNewComment");
    var btnAddComment = document.getElementById("btnAddComment");
    var btnDeleteComment = document.getElementById("btnDeleteComment");
    var btnUpdateComment = document.getElementById("btnUpdateComment");
    var hdfNewsId = document.getElementById("hdfNewsId");
    var hdfCommentId = document.getElementById("hdfCommentId");
    var txtComment = document.getElementById("txtComment");

   
    return {
        getComments: function (id) {
            hdfNewsId.value = id; 
            btnGetComments.click();
        },
        addNewComments: function (id) {
            hdfNewsId.value = id;
            btnNewComment.click();
        },
        saveComment: function () {
            btnAddComment.click();
        },
        deleteComment : function (id) {
            hdfCommentId.value = id;
            btnDeleteComment.click();
        },
        updateComment: function (id, comment) {
            txtComment.value = comment;
            hdfCommentId.value = id;
            btnUpdateComment.click();
        }
    }
})();