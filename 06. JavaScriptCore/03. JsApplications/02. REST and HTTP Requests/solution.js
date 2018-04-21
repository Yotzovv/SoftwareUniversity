function attachEvents() {
    $('#refresh').click(downloadChat);
    $('#submit').click(send);

    function send() {
        let data = {
            author: $('#author').val(),
            content: $('#content').val(),
            timestamp: Date.now()
        };

        $.ajax({
            method: 'POST',
            url: 'https://messanger-5c7fb.firebaseio.com/messanger/.json',
            data: JSON.stringify(data),
            success: downloadChat
        });
    }

    function downloadChat() {
        $.get('https://messanger-5c7fb.firebaseio.com/messanger/.json')
            .then(refresh);
    }

    function refresh(messages) {
        $('#messages').empty();

        for (let msg in messages) {
            $('#messages').append(`${messages[msg]["author"]}: ${messages[msg]["content"]}\n`);
        }
    }
}