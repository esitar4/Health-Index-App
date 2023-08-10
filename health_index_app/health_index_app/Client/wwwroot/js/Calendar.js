function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("text/html", ev.target.id);

    hide(ev.target);
}

var dragSrcChild = null;

function dragEnter(ev, el) {
    ev.preventDefault();
    ev.stopPropagation();
    console.log("entering");
    if (dragSrcChild != null && dragSrcChild.dataset.underlined == "true" && dragSrcChild != el) {
        ununderline(dragSrcChild);
    }

    if (ev.target.dataset.underlined == "false" || ev.target.parentElement.dataset.underlined == "false") {
        dragSrcChild = ev.target.nodeName == "DIV" ? ev.target : ev.target.parentElement;
        if (dragSrcChild.id.slice(-1) > dragSrcChild.parentElement.dataset.nummeals) {
            dragSrcChild = document.getElementById(dragSrcChild.id.slice(0, -1) + (Number(dragSrcChild.parentElement.dataset.nummeals) + 1));
        }

        underline(dragSrcChild);
    }
}

function dragLeave(ev, el) {
    console.log("leaving");
    ev.preventDefault();
    ev.stopPropagation();
    /*if (dragSrcChild != null && dragSrcChild.dataset.underlined == "true" && dragSrcChild != el) {
        ununderline(dragSrcChild);
    }*/
}

/*function startDrag(ev) {
    ev.dataTransfer.setData("text/html", ev.target.id);
    let element = ev.target;

    element.classList.add('hide');
}

function endDrag(ev) {
    let element = ev.srcElement;

    element.classList.remove('hide');
}*/



function hover(element) {
    element.classList.add("hover");
}

function unhover(element) {
    element.classList.remove("hover");
}

function underline(element) {
    var Underline = document.createElement("div");
    Underline.classList.add("hover-underline");

    element.appendChild(Underline);
    element.dataset.underlined = "true";
}

function ununderline(element) {
    element.removeChild(element.childNodes[element.childNodes.length - 1]);
    element.dataset.underlined = "false";
}

function hide(element) {
    element.classList.add('hide');
}

function unhide(element) {
    element.classList.remove('hide');
}

/*
function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    ev.target.appendChild(document.getElementById(data));
}
*/

function drop(ev) {
    //alert("dropHere");
    ev.preventDefault();

    var el = ev.target;
    /*console.log("nodeName: " + el.nodeName);*/
    el = el.nodeName == "DIV" ? el : el.parentElement;
    var oldID = ev.dataTransfer.getData("text/html");
    var element = document.getElementById(oldID);
    unhide(element);

    if (el.id.slice(-1) > el.parentElement.dataset.nummeals) {
        ununderline(document.getElementById(el.id.slice(0, -1) + (Number(el.parentElement.dataset.nummeals) + 1)));
    } else {
        ununderline(el);
    }

    /*console.log("base element:");
    console.log(element);
    console.log("target element:");
    console.log(el);*/

    var numMeals = Number(el.parentElement.dataset.nummeals);
    /*console.log("numMeals: " + numMeals);*/

    //console.log("numMeals: " + numMeals);
    /*console.log("element.parentElement.parentElement.id: " + element.parentElement.parentElement.id);
    console.log("el.parentElement.id: " + el.parentElement.id);*/
    if (el.parentElement.dataset.nummeals == "5" && element.parentElement.parentElement.id != el.parentElement.id) {
        return;
    }
    
    var currElement = element;
    var nextDiv; var tempNextDiv;

    var day = el.parentElement.id.slice(-2);
    var mealNumberTarget = Number(el.id.slice(-1));
    var direction;
    var j;
    var draggedPast;

    //console.log(el.parentElement);
    //console.log("element.id: " + element.id + " el.id: " + el.id);

    if (numMeals >= mealNumberTarget) {
        j = numMeals;
    } else {
        j = mealNumberTarget;
        mealNumberTarget = numMeals;
    }

    if (element.parentElement.parentElement.id != el.parentElement.id) {
        direction = -1;

        el.parentElement.dataset.nummeals = numMeals + 1;

        nextDiv = document.getElementById("day-" + day + "-meal-" + el.parentElement.dataset.nummeals);
        
        element.parentElement.parentElement.dataset.nummeals = Number(element.parentElement.parentElement.dataset.nummeals) - 1;

        collapser(currElement, Number(element.parentElement.parentElement.dataset.nummeals) + 1, Number(element.parentElement.id.slice(-1)), element.parentElement.parentElement.id.slice(-2), 1);

        //console.log("element.parentElement.parentElement.id: " + element.parentElement.parentElement.id);
    } else {
        if (el.id.slice(-1) == element.parentElement.id.slice(-1)) {
            return;
        }
        if (el.id.slice(-1) < element.parentElement.id.slice(-1)) {
            direction = -1;
            j = Number(element.parentElement.id.slice(-1)) - 1;
        } else {
            direction = 1;
            j = Number(element.parentElement.id.slice(-1)) + 1;
            draggedPast = mealNumberTarget;
        }

        nextDiv = document.getElementById("day-" + day + "-meal-" + (j - direction));
        element.parentElement.removeChild(element);
        //console.log(element);
    }

    var i = j;
    i = collapser(currElement, mealNumberTarget, i, day, direction);

    /*console.log("i: " + i);
    console.log(el);
    console.log(el.parentElement);*/

    if (oldID.includes("menu-draggable")) {
        element = element.cloneNode(true);
        element.classList.remove("py-3");
        element.id = element.textContent + "-" + day;
    }

    var placement;
    if (direction == -1) {
        placement = document.getElementById("day-" + day + "-meal-" + (i +1));
        placement.appendChild(element);
    } else {
        document.getElementById("day-" + day + "-meal-" + draggedPast).appendChild(element);
    }

    /*console.log(element);
    console.log(element.parentElement);*/
}

function collapser(currElement, mealNumberTarget, i, day, direction) {
    var nextDiv = null;

    for (i; i > mealNumberTarget && direction == -1 || direction == 1 && i <= mealNumberTarget; i += direction) {
        /*console.log("changed");
        console.log("i: " + i);
        console.log("mealNumberTarget: " + mealNumberTarget)
        console.log("direction: " + direction);*/

        currDiv = document.getElementById("day-" + day + "-meal-" + i);
        currElement = currDiv.firstChild != null ? currDiv.firstChild : currElement;
        /*console.log("Moving");
        console.log("currElement.id: " + currDiv.id);
        console.log(currDiv);
        console.log("to");
        console.log(nextDiv);
        console.log("nextDiv.id: " + nextDiv.id);*/

        tempNextDiv = currElement.parentElement;

        if (currDiv.firstChild != null && nextDiv != null) {
            nextDiv.appendChild(currElement);
        }
        nextDiv = tempNextDiv;
    }

    return i;
}

/*function dropOld(ev, el) {
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
}*/

function dropDelete(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text/html");
    var element = document.getElementById(data);

    console.log(element);


    var day = element.parentElement.parentElement.id.slice(-2);

    element.parentElement.parentElement.dataset.nummeals = Number(element.parentElement.parentElement.dataset.nummeals) - 1;

    console.log("day: " + day);

    collapser(element, Number(element.parentElement.parentElement.dataset.nummeals) + 1, Number(element.parentElement.id.slice(-1)), element.parentElement.parentElement.id.slice(-2), 1);

    element.remove();
}