function by(query) {
    if (query.startsWith('#'))
        return document.getElementById(query.substring(1));
    else if (query.startsWith('.'))
        return document.getElementsByClassName(query.substring(1));
    return document.getElementsByTagName(query);
}

function appendTo(node, elementName, inlineAttrs = '', innerHtml = '') {
    var newE = document.createElement(elementName);
    var attr = inlineAttrs.split(' ');
    for (var i = 0; i < attr.length; i++) {
        var kvp = attr[i].split('=');
        newE.setAttribute(kvp[0], kvp[1].substring(1, kvp[1].length - 1));
    }
    newE.innerHTML = innerHtml;
    node.appendChild(newE);
}

function innerHTML(query, content, idx = undefined) {
    var eles = by(query);
    if (!eles.length) {
        eles.innerHTML = content;
    } else {
        if (idx !== undefined) {
            eles[idx].innerHTML = content;
            return;
        }
        for (var i = 0; i < eles.length; i++)
            eles[i].innerHTML = content;
    }
}

function removeClass(query, removeClass, idx = undefined) {
    if (!removeClass || removeClass.indexOf(' ') > -1)
        return;

    function _removeClass(element, removeClass) {
        if (element.hasAttribute('class')) {
            var classAttr = element.getAttribute('class');
            var classArr = classAttr.split(' ');
            if (classArr.indexOf(removeClass) > -1)
                classAttr = classAttr.replace(removeClass, '');
            element.setAttribute('class', classAttr.trim());
        }
    }
    var eles = by(query);
    if (!eles.length) {
        _removeClass(eles, removeClass);
    } else {
        if (idx !== undefined) {
            _removeClass(eles[idx], removeClass);
            return;
        }
        for (var i = 0; i < eles.length; i++)
            _removeClass(eles[i], removeClass);
    }
}

function addClass(query, newClass, idx = undefined) {
    if (!newClass || newClass.indexOf(' ') > -1)
        return;

    function _addClass(element, newClass) {
        if (!element.hasAttribute('class'))
            element.setAttribute('class', '');
        var classAttr = element.getAttribute('class');
        if (!classAttr.indexOf(newClass) > -1)
            classAttr += ' ' + newClass;
        element.setAttribute('class', classAttr);
    }
    var eles = by(query);
    if (!eles.length) {
        _addClass(eles, newClass);
    } else {
        if (idx !== undefined) {
            _addClass(eles[idx], newClass);
            return;
        }
        for (var i = 0; i < eles.length; i++)
            _addClass(eles[i], newClass);
    }
}