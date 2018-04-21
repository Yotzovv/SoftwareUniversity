function attachEvents() {
    $('#btnCreate').click(create);
    $('#btnLoad').click(getPhones);
    
    function getPhones() {
        $.get('https://phonebook-nakov.firebaseio.com/phonebook.json')
            .then(refresh);
    }

    function refresh(phones) {

        $('#phonebook').empty();
        for (var phone in phones) {
            let obj = phones[phone];
            let id = phone;

            let delBtn = $(` <button id="btnDelete">[Delete]</button>`);

            $('#phonebook').append($(`<li>${obj.person}: ${obj.phone}</li>`)
                .append($(` <button id="btnDelete">[Delete]</button>`).click(() => onClick(id)))
            );
        }
    }

    function deletePhone(phone) {
        console.log($(phone.data));
    }

    function onClick(phone) {
        let url = 'https://phonebook-nakov.firebaseio.com/phonebook/' + `${phone}` + '.json';
            
        $.ajax({
                method: 'DELETE',
                url: url,
            }).then(refresh)
                .catch(handleError)
    }

    function create() {
        let data = {
            person: $('#person').val(),
            phone: $('#phone').val()
        };

        $.ajax({
            method: 'POST',
            url: 'https://phonebook-nakov.firebaseio.com/phonebook.json',
            data: JSON.stringify(data),
            success: getPhones
        });

        $('#person').val('');
        $('#phone').val('');
    }

    function handleError(err) {
        console.log(err);
        $('#phonebook')
            .append($('<li>')
                .text('ERROR'));
    }
}