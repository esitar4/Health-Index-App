function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("text/html", ev.target.id);
}
/*
function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    ev.target.appendChild(document.getElementById(data));
}
*/
function drop(ev, el, day) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text/html");
    var element = document.getElementById(data);
    var newID = element.textContent + "-" + day;
    alert("data: " + data);

    if (~data.indexOf("menu")) {
        element = element.cloneNode(true);
    }
    element.id = newID;
    element.ondrop = "";
    var elemDiv = document.createElement('div');

    var i = el.childNodes.length;
    alert(el.childNodes.length);
    elemDiv.className = "meal-" + i; elemDiv.id = "day-" + i;
    elemDiv.appendChild(element);

    el.appendChild(elemDiv);
}

function dropDelete(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text/html");
    document.getElementById(data).remove();
  
}