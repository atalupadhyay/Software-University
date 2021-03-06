function startApp() {
   localStorage.clear();

    $('header').find('a').show();
    const adsDiv = $('#ads');

    function showView(view) {
        $('section').hide();
        switch (view) {
            case 'home':
                $('#viewHome').show();
                break;
            case 'login':
                $('#viewLogin').show();
                break;
            case 'register':
                $('#viewRegister').show();
                break;
            case 'ads':
                $('#viewAds').show();
                loadAds();
                break;
            case 'create':
                $('#viewCreateAd').show();
                break;
            case 'details':
                $('#viewDetailsAd').show();
                break;
            case 'edit':
                $('#viewEditAd').show();
                break;

        }
    }

    function navigateTo(e) {
        $('section').hide();
        let target = $(e.target).attr('data-target');
        $('#' + target).show();
    }


    //Attach event listeners
    $('#linkHome').click(() => showView('home'));
    $('#linkLogin').click(() => showView('login'));
    $('#linkListAds').click(() => showView('ads'));
    $('#linkRegister').click(() => showView('register'));
    $('#linkCreateAd').click(() => showView('create'));
    $('#linkLogout').click(logout);

    $('#buttonLoginUser').click(login);
    $('#buttonRegisterUser').click(register);
    $('#buttonCreateAd').click(createAd);

    //Notifications
    $(document).on({
        ajaxStart: () => $('#loadingBox').show(),
        ajaxStop: () => $('#loadingBox').fadeOut()
    });

    $('#infoBox').click((event) => $(event.target).hide());
    $('#errorBox').click((event) => $(event.target).hide());

    function showInfo(message) {
        $('#infoBox').text(message);
        $('#infoBox').show();
        setTimeout(() => $('#infoBox').fadeOut(), 3000);
    }

    function showError(message) {
        $('#errorBox').text(message);
        $('#errorBox').show();
    }

    function handleError(reason) {
        showError(reason.responseJSON.description);
    }

    let requester = (() => {
        const baseUrl = 'https://baas.kinvey.com/';
        const appKey = 'kid_HJafHtsNQ';
        const appSecret = 'e159a72b96494db281f8564ab6935d03';

        function makeAuth(type) {
            if (type === 'basic') {
                return 'Basic ' + btoa(appKey + ':' + appSecret);
            } else {
                return 'Kinvey ' + localStorage.getItem('authtoken');
            }
        }

        function makeRequest(method, module, url, auth) {
            return {
                url: baseUrl + module + '/' + appKey + '/' + url,
                method: method,
                headers: {
                    'Authorization': makeAuth(auth)
                }
            };
        }

        function get(module, url, auth) {
            return $.ajax(makeRequest('GET', module, url, auth));
        }

        function post(module, url, data, auth) {
            let req = makeRequest('POST', module, url, auth);
            req.data = JSON.stringify(data);
            req.headers['Content-Type'] = 'application/json';
            return $.ajax(req);
        }

        function update(module, url, data, auth) {
            let req = makeRequest('PUT', module, url, auth);
            req.data = JSON.stringify(data);
            req.headers['Content-Type'] = 'application/json';
            return $.ajax(req);
        }

        function remove(module, url, auth) {
            return $.ajax(makeRequest('DELETE', module, url, auth));
        }

        return {
            get, post, update, remove
        }
    })();

    if (localStorage.getItem('authtoken') !== null &&
        localStorage.getItem('username') !== null) {
        userLoggedIn();
    } else {
        userLoggedOut();
    }
    showView('home');


    function saveSession(data) {
        localStorage.setItem('username', data.username);
        localStorage.setItem('id', data._id);
        localStorage.setItem('authtoken', data._kmd.authtoken);
        userLoggedIn();

    }

    function userLoggedIn() {
        $('#loggedInUser').text(`Welcome, ${localStorage.getItem('username')}!`);
        $('#loggedInUser').show();
        $('#linkLogin').hide();
        $('#linkRegister').hide();
        $('#linkLogout').show();
        $('#linkCreateAd').show();
        $('#linkListAds').show();
    }

    function userLoggedOut() {
        $('#loggedInUser').text(``);
        $('#loggedInUser').hide();
        $('#linkLogin').show();
        $('#linkRegister').show();
        $('#linkLogout').hide();
        $('#linkCreateAd').hide();
        $('#linkListAds').hide();
    }

    async function login() {
        let form = $('#formLogin');
        let username = form.find('input[name="username"]').val();
        let password = form.find('input[name="passwd"]').val();

        try {
            let data = await requester.post('user', 'login', {username, password}, 'basic');
            saveSession(data);
            showView('ads');
            showInfo('Logged In.')
        } catch (err) {
            handleError(err)
        }

    }

    async function register() {
        let form = $('#formRegister');
        let username = form.find('input[name="username"]').val();
        let password = form.find('input[name="passwd"]').val();

        try {
            let data = await requester.post('user', '', {username, password}, 'basic');
            saveSession(data);
            showView('ads')
            showInfo('Registered.')
        } catch (err) {
            handleError(err)
        }

    }

    async function logout() {
        try {
            let data = await requester.post('user', '_logout', {authtoken: localStorage.getItem('authtoken')});
            localStorage.clear();
            userLoggedOut();
            showView('home');
            showInfo('Logged Out.')
        } catch (err) {
            handleError(err)
        }
    }

    async function loadAds() {
        let data = await requester.get('appdata', 'posts');
        adsDiv.empty();
        if (data.length === 0) {
            adsDiv.append('<p>No ads in database</p>');
            return;
        }
        for (let ad of data) {
            let html = $('<div>');
            html.addClass('ad-box');
            let title = $(`<div class="ad-title">${ad.title}</div>`);

            if (ad._acl.creator === localStorage.getItem('id')) {
                let deleteBtn = $('<button>&#10006;</button>').click(() => deleteAd(ad._id));
                deleteBtn.addClass('ad-control');
                deleteBtn.appendTo(title);

                let editBtn = $('<button>&#9998;</button>').click(() => openEditAd(ad));
                editBtn.addClass('ad-control');
                editBtn.appendTo(title);
            }

            html.append(title);
            html.append(`<div><img src="${ad.imageUrl}"></div>`);
            html.append(`<div>Price: ${Number(ad.price).toFixed(2)} | By ${ad.publisher} </div>`);
            adsDiv.append(html);
        }
    }

    async function deleteAd(id) {
        await requester.remove('appdata', 'posts/' + id);
        showInfo('Add Deleted!');
        showView('ads');
    }

    function openEditAd(ad) {
        let form = $('#formEditAd');
        form.find('input[name="title"]').val(ad.title);
        form.find('textarea[name="description"]').val(ad.description);
        form.find('input[name="price"]').val(Number(ad.price));
        form.find('input[name="image"]').val(ad.imageUrl);

        let date = ad.date;
        let publisher = ad.publisher;
        let id = ad._id;

        form.find('#buttonEditAd').click(()=> editAd(id,date,publisher));
        showView('edit');
    }

    async function editAd(id,date,publisher) {
        let form = $('#formEditAd');
        let title = form.find('input[name="title"]').val();
        let description = form.find('textarea[name="description"]').val();
        let price =form.find('input[name="price"]').val();
        let imageUrl = form.find('input[name="image"]').val();

        if (title.length === 0) {
            showError('Title cannot be empty!');
            return;
        }
        if (Number.isNaN(price)) {
            showError('Price cannot be empty!');
            return;
        }

        let editedAd = {
            title, description, price, imageUrl, date, publisher
        };

        try {
            await requester.update('appdata', 'posts/'+id,editedAd);
            showInfo('Ad Edited.');
            showView('ads');
        } catch (e) {
            handleError(e)
        }
    }

    async function createAd() {
        let form = $('#formCreateAd');
        let title = form.find('input[name=title]').val();
        let description = form.find('textarea[name=description]').val();
        let price = Number(form.find('input[name=price]').val());
        let imageUrl = form.find('input[name=image]').val();
        let date = (new Date()).toString('yyyy-MM-dd');
        let publisher = localStorage.getItem('username');

        if (title.length === 0) {
            showError('Title cannot be empty!');
            return;
        }
        if (Number.isNaN(price)) {
            showError('Price cannot be empty!');
            return;
        }

        let newAd = {
            title, description, price, imageUrl, date, publisher
        };

        try {
            await requester.post('appdata', 'posts', newAd);
            showView('ads');
            showInfo('Ad Created.')
        } catch (e) {
            handleError(e)
        }
    }
}