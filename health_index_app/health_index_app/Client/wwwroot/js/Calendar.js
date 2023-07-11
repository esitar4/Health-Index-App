function allowDrop(ev, el) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("text/html", ev.target.id);
}

function dragEnter(ev, el) {
    ev.preventDefault();
    el.parentElement.classList.add("hover");
}

function dragLeave(ev, el) {
    ev.preventDefault();
    el.parentElement.classList.remove("hover");
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

function dropHere(ev, el) {
    alert("dropHere");
    ev.preventDefault();
    console.log(el);
    var numMeals = el.parentElement.childNodes.length - 1;

    if (numMeals > 5) {
        return;
    }

    var oldID = ev.dataTransfer.getData("text/html");
    var element = document.getElementById(oldID);

    var elemDiv = document.createElement('div');

    elemDiv.className = "meal-" + numMeals; elemDiv.id = "day-" + el.id.splice(-2) + "-" + elemDiv.className;

    for (var i = numMeals; i >= el.id.slice(-2); i--) {
        thisElement = document.getElementById(oldID);
        prevElement = document.getElementById(oldID.splice(0,-2))
    }

    el.appendChild(elemDiv);
}

function drop(ev, el) {
    ev.preventDefault();
    el.parentElement.classList.remove("hover");

    var oldID = ev.dataTransfer.getData("text/html");
    var element = document.getElementById(oldID);

    console.log("element.parentElement.id: " + element.parentElement.parentElement.id + " el.id: " + el.id)
    if (element.parentElement.parentElement.id == el.id) {
        return;
    }

    var oldDivID = "";
    var numMealsEv = 0;
    var numMealsEl = el.childNodes.length;
    var day = el.id.slice(4);
    //alert("id: " + oldID);
    var newID = element.textContent + "-" + day;
    //alert("data: " + data);

    if (oldID.includes("menu-draggable")) {
        element = element.cloneNode(true);
    } else {
        oldDivID = element.parentElement.id;
        console.log(element);
        numMealsEv = element.parentElement.parentElement.childNodes.length -1;
    }

    element.id = newID;
    element.ondragstart = startDrag;
    element.ondragend = endDrag;
    element.ondrop = dropHere;
    element.classList.remove("py-3");

    var elemDiv = document.createElement('div');

    console.log("numMealsEl: " + numMealsEl + " numMealsEv: " + numMealsEv);
    
    elemDiv.className = "meal-" + numMealsEl ; elemDiv.id = "day-" + day + "-" + elemDiv.className;
    elemDiv.appendChild(element);

    console.log("OldDivID: " + oldDivID);
    if (numMealsEv != oldDivID.slice(-1)) {
        var NextDivID = oldDivID.slice(0, oldDivID.length - 1) + (Number(oldDivID.slice(-1)) + 1);
        var moved = false;

        for (var j = Number(oldDivID.slice(-1)); j <= numMealsEv && document.getElementById(NextDivID).hasChildNodes(); j++) {
            //console.log(document.getElementById(NextDivID));
            document.getElementById(oldDivID).appendChild(document.getElementById(NextDivID).firstChild);
            moved = true;
            //console.log("ev.target.parentElement.parentElement.childNodes.length: " + ev.target.parentElement.parentElement.childNodes.length);
            if (numMealsEv == j + 1) {
                break;
            }
            oldDivID = NextDivID;
            NextDivID = oldDivID.slice(0, oldDivID.length - 1) + "" + (j + 2);
        }
        if (moved) {
            document.getElementById(NextDivID).remove();
        }

    } else if (oldDivID) {
        document.getElementById(oldDivID).remove();
    }

    el.appendChild(elemDiv);
}

function dropDelete(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text/html");
    document.getElementById(data).remove();
}