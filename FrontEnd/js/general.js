// JavaScript source code
function initComponents() {
    initHeader();
    initFooter();
    initLeftMenu();
}

function initLeftMenu() {
    var leftMenu = document.getElementById("left-menu");
    leftMenu.innerHTML =
        "<div>" +
        "<ul>" +
        "<li>Menu 1</li>" +
        "<li>Menu 2</li>" +
        "<li>Menu 3</li>" +
        "<li>Menu 4</li>" +
        "</ul>" +
        "</div>";
}

function initHeader() {
    var header = document.getElementsByTagName("header")[0];
    header.innerHTML = 
        "<div>This is header</div>" +
        "" +
        "" +
        "" +
        "" +
        "" +
        "" +
        "";
}

function initFooter() {
    var footer = document.getElementsByTagName("footer")[0];
    footer.innerHTML =
        "<div>This is footer</div>" +
        "" +
        "" +
        "" +
        "" +
        "" +
        "" +
        "";
}

function loadScripts(url, callback) {
    // Adding the script tag to the head as suggested before
    var head = document.head;
    var script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = url;

    // Then bind the event to the callback function.
    // There are several events for cross browser compatibility.
    script.onreadystatechange = callback;
    script.onload = callback;

    // Fire the loading
    head.appendChild(script);
}

//run ...........
loadScripts(root + "js/helpers.js", initComponents);