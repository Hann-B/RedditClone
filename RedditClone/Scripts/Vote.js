
let upVote = (postId) => {
    $.ajax({
        url: "/Vote/Up",
        data: JSON.stringify({ id: postId }),
        dataType: "html",
        type: "POST",
        contentType: "application/json",
        success: (newHtml) => {
            $("#voteBox-" + postId).html(newHtml);
        }
    });
}

let downVote = (postId) => {
    $.ajax({
        url: "/Vote/Down",
        data: JSON.stringify({ id: postId }),
        dataType: "html",
        type: "POST",
        contentType: "application/json",
        success: (newHtml) => {
            $("#voteBox-" + postId).html(newHtml);
        }
    });
}
