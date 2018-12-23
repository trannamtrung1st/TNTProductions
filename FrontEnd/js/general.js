// JavaScript source code
function initComponents() {
    initHeader();
    initFooter();
    initLeftMenu();
    initPages();
}

function initLeftMenu() {

    //call api to get data
    var menus = ['HTML', 'CSS', 'Javascript', 'JQuery', 'Bootstrap'];

    var html = "<ul>";
    for (var i = 0; i < menus.length; i++)
        html += "<li>" + menus[i] + "</li>";
    html += "</ul>";

    innerHTML("#left-menu", html);
}

function initHeader() {
    var content = "<div>This is header</div>" +
        "" +
        "" +
        "" +
        "" +
        "" +
        "" +
        "";

    innerHTML('header', content, 0);
}

function initFooter() {
    var content =
        "<div>This is footer</div>" +
        "" +
        "" +
        "" +
        "" +
        "" +
        "" +
        "";
    innerHTML('footer', content, 0);
}

function initPages() {
    var pageList = by('#page');
    for (var i = 0; i < pagesContent.length; i++) {
        var liElement = document.createElement('li');
        liElement.setAttribute('class', 'page-element');
        liElement.innerHTML = '<span onclick="changePage(' + i + ')">' + i + '</span>';
        pageList.appendChild(liElement);
    }
}

function changePage(page) {
    var content = pagesContent[page];
    innerHTML('#app', content);
}

//run ...........
initComponents();