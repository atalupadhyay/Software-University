$(function () {
    $('#btnLoad').click(loadContacts);
    $('#btnCreate').click(createContact);

    let baseServiceUrl = 'https://phonebook-demo-60777.firebaseio.com/phonebook';

    function loadContacts() {
        $('#phonebook').empty();
        $.get(baseServiceUrl + '.json')
            .then(displayContacts)
            .catch(displayError);
    }

    function displayContacts(contacts) {
        for(let key in contacts){
            let person = contacts[key]['name'];
            let phone = contacts[key]['phone'];
            let li = $('<li>');
            li.text(`${person}: ${phone} `);
            $('#phonebook').append(li);
            li.append($('<button>Delete</button>').click(deleteContact.bind(this,key)));
        }
    }

    function displayError(err) {
        $('#phonebook').append($('<li>Error</li>'))
    }

    function createContact() {
        let newContactJSON = JSON.stringify({
            name: $('#person').val(),
            phone: $('#phone').val(),
        });
        $.post(baseServiceUrl+'.json',newContactJSON)
            .then(loadContacts)
            .catch(displayError);
        $('#person').val('');
        $('#phone').val('');
    }

    function deleteContact(key) {
        let request = {
            url:`${baseServiceUrl}/${key}.json`,
            method:'DELETE',
        }
        $.ajax(request).then(loadContacts).catch(displayError)

    }
});