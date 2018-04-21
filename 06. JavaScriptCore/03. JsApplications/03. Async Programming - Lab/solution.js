function attachEvents() {
    const URL = 'https://baas.kinvey.com/appdata/kid_rk1uKtCtz';
    const username = 'User';
    const pswd = 'user';
    const base_64 = btoa(`${username}:${pswd}`);
    const auth = { 'Authorization': 'Basic' + base_64 };
    let posts = {};

    $('#btnLoadPosts').click(LoadPosts);
    $('#btnViewPost').click(LoadComments);

    function LoadPosts() {
        $.ajax({
            method: 'GET',
            url: `${URL}/posts`,
            headers: auth
        }).then(function (res) {
            $('#posts').empty();

            for (let post of res) {
                $('#posts').append(
                    $(`<option value="${post._id}">${post.title}</option>`)
                );
                posts[post._id] = post.body;
            }
        }).catch(displayError);
    }

    function LoadComments() {
        let postId = $('#posts').val();
        let postTitle = $('#posts').find('option:selected').text();

        $('#post-title').text(postTitle);
        $('#post-body').text(posts[postId]);

        $.ajax({
            method: 'GET',
            url: `${URL}/comments/?query={"post_id":"${postId}`,
            headers: auth
        }).then(function (res) {
            $('#post-comments').empty();
            for (let com of res) {
                $('#post-comments')
                    .append(`<li>${com.text}</li>`);
            }
        }).catch(displayError);
    }

    function displayError(err) {
        let errorDiv = $('<div>').text('Error: ' +
            err.status + ' (' + err.statusText + ')');

        $(document.body).prepend(errorDiv);
        setTImeout(function () {
            $(errorDiv).fadeOut(function () {
                $(errorDiv).remove();
            });
        }, 3000);
    }
}