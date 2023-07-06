function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("text/html", ev.target.id);
}

function startDrag(ev) {
    ev.dataTransfer.setData("text/html", ev.target.id);
    let element = ev.target;

    element.classList.add('hide');
}

function endDrag(ev) {
    let element = ev.srcElement;

    

    element.classList.remove('hide');
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
    var oldID = ev.dataTransfer.getData("text/html");
    var element = document.getElementById(oldID);
    var oldDivID = "";
    alert("id: " + oldID);
    var newID = element.textContent + "-" + day;
    //alert("data: " + data);

    if (oldID.includes("menu-draggable")) {
        element = element.cloneNode(true);
    } else {
        oldDivID = element.parentElement.id;
    }

    element.id = newID;
    element.ondragstart = startDrag;
    element.ondragend = endDrag;
    var elemDiv = document.createElement('div');

    var i = el.childNodes.length;
    //alert(el.childNodes.length);
    elemDiv.className = "meal-" + i; elemDiv.id = "day-" + day + "-" + elemDiv.className;
    elemDiv.appendChild(element);

    if (oldDivID != "") {
        var NextDivID = oldDivID.slice(0, oldDivID.length - 1) + (Number(oldDivID.slice(-1)) + 1);
        var moved = false;
        console.log("NextDivID: " + NextDivID);
        console.log("OldDivID: " + oldDivID);
        console.log("j: " + j + " i:" + i + " has children: " + document.getElementById(NextDivID).hasChildNodes());
        for (var j = Number(oldDivID.slice(-1)); j <= i && document.getElementById(NextDivID).hasChildNodes(); j++) {
            NextDivID = oldDivID.slice(0, oldDivID.length - 1) + "" + (j + 1);
            console.log(document.getElementById(NextDivID));
            document.getElementById(oldDivID).appendChild(document.getElementById(NextDivID).firstChild);
            moved = true;
        }
        if (moved) {
            document.getElementById(NextDivID).remove();
        }

    }

    el.appendChild(elemDiv);
}

function dropDelete(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text/html");
    document.getElementById(data).remove();
}