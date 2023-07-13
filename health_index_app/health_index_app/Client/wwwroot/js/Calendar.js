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

function dropHere(ev) {
    alert("dropHere");
    ev.preventDefault();

    var el = ev.target;
    var oldID = ev.dataTransfer.getData("text/html");
    var element = document.getElementById(oldID);

    var numMeals = el.parentElement.parentElement.childNodes.length - 1;

    console.log("numMeals: " + numMeals);
    console.log("element.parentElement.parentElement.id: " + element.parentElement.parentElement.id);
    console.log("el.parentElement.parentElement.id: " + el.parentElement.parentElement.id);
    if (numMeals == 5 && element.parentElement.parentElement.id != el.parentElement.parentElement.id) {
        return;
    }
    
    var currElement = element;
    var nextDiv; var tempNextDiv;

    var day = el.id.slice(-2);
    var mealNumberTarget = el.parentElement.id.slice(-1);

    console.log(element);
    console.log(el);
    console.log(el.parentElement);
    console.log("element.id: " + element.id + " el.id: " + el.id);

    if (element.parentElement.parentElement.id != el.parentElement.parentElement.id) {
        var elemDiv = document.createElement('div');

        elemDiv.className = "meal-" + (numMeals + 1); elemDiv.id = "day-" + day + "-" + elemDiv.className;
        el.parentElement.parentElement.appendChild(elemDiv);
        nextDiv = elemDiv;

    } else {
        nextDiv = element.parentElement;
        element.parentElement.removeChild(element);
        console.log(element);
        numMeals -= 1;
    }

    var i;
    for (i = numMeals; i > mealNumberTarget; i--) {
        console.log("i: " + i);

        currElement = document.getElementById("day-" + day + "-meal-" + i).firstChild;

        console.log("Moving");
        console.log("currElement.id: " + currElement.id);
        console.log(currElement);
        console.log("to");
        console.log(nextDiv);
        console.log("nextDiv.id: " + nextDiv.id);

        tempNextDiv = currElement.parentElement;
        nextDiv.appendChild(currElement);
        nextDiv = tempNextDiv;
    }

    console.log(el);
    console.log(el.parentElement);
    document.getElementById("day-" + day + "-meal-" + (i+1)).appendChild(element);
    console.log(element);
    console.log(element.parentElement);
}

function drop(ev, el) {
    console.log("drop");
    ev.preventDefault();
    el.parentElement.classList.remove("hover");

    var oldID = ev.dataTransfer.getData("text/html");
    var element = document.getElementById(oldID);
    var numMeals = el.childNodes.length - 1;

    //console.log("element.parentElement.id: " + element.parentElement.parentElement.id + " el.id: " + el.id)
    if (numMeals == 5 || element.parentElement.parentElement.id == el.id) {
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
        //console.log(element);
        numMealsEv = element.parentElement.parentElement.childNodes.length -1;
    }

    element.id = newID;
    element.ondragstart = startDrag;
    element.ondragend = endDrag;
    element.ondrop = dropHere;
    element.classList.remove("py-3");

    var elemDiv = document.createElement('div');

    //console.log("numMealsEl: " + numMealsEl + " numMealsEv: " + numMealsEv);
    
    elemDiv.className = "meal-" + numMealsEl ; elemDiv.id = "day-" + day + "-" + elemDiv.className;
    elemDiv.appendChild(element);

    //console.log("OldDivID: " + oldDivID);
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