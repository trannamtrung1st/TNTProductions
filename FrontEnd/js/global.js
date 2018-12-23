var root = "file:///T:/TNT/Workspace/TNTProductions/FrontEnd/";

var pagesContent = [];
for (var i = 0; i < 10; i++) {
    pagesContent[i] =
        '<h1 style="color:' + (i % 2 == 0 ? 'red' : 'blue') + '">' +
        'Content of page ' + i +
        '</h1>';
}