/**
 * Sets the class of a selection box based on the selection index (NOTE: The index must be an integer)
 * @param {any} element The selection element to perform the colorization on
 * @param {string} baseClass The class value that defines the css classes that should not be affected
 * @param {string[]} classDef The range of classes to pick from
 */
function matchClass(element, baseClass, classDef) {
    var index = element.value;
    var el = element;
    var classString = baseClass;

    if (index >= 0 || index < classDef.length) {
        classString += (" " + classDef[index]);
    }

    el.className = classString;
}

/**
 * Toggles the display attribute of the alement with the given id
 * @param {any} id The ID of the element to toggle
 */
function toggleElement(id) {
    var element = document.getElementById(id);

    if (element.className.includes("d-none")) { //  If the element is currently hidden
        element.className = element.className.replace("d-none", "");

        return;
    }

    element.className += "d-none";
}

/**
 * Triggers the confirmation partial view and pushes data to a hidden field within it
 * @param {any} trigger The button that triggered the view
 * @param {any} popupID The ID of the view to trigger
 * @param {any} packageID the ID of the hidden field within the view
 * @param {any} datakey The key that identifies the data attribute
 */
function triggerConfWindow(trigger, popupID, packageID, datakey) {
    var data = trigger.getAttribute('data-' + datakey);

    var hiddenInput = document.getElementById(packageID);   //  The element that should hold the data
    hiddenInput.value = data;

    toggleElement(popupID);
}

/**
 * Sets the focus to be the element with the given id
 * @param {any} id the id of the element to focus
 */
function focus(id) {
    var el;
    el = document.getElementById(id);
    el.focus()
}

/**
 * Redirects to the monitor view based on the value of the selection element
 * Example: If the value of the selection element is A for Automatics; the rendered Url would result in: /Montior/prefix/A
 * @param {HTMLSelectElement} element the selection box element used in the context
 */
function redirectToMonitor(element) {
    var currentUrl = window.location.href;
    var baseUrl = currentUrl.split('Monitor')[0];
    var usableUrl = baseUrl + 'Monitor/';

    //var valueInLowerCase = element.value.toLocaleLowerCase();

    //if (valueInLowerCase.includes("prefix")) {
    //    var prefix = element.value;
    //    usableUrl += 'prefix/' + prefix;
    //}

    //if (element.value != '-1') {
    //    var prefix = element.value;
    //    usableUrl += 'prefix/' + prefix;
    //}
    //else if (element.value) {

    //}

    window.location = usableUrl + element.value;
}

/**
 * Used to show comments on TicketPage. Initially only 5 comments are displayed. This function shows the rest and creates a new button to hide them again (See: hideComments below).
 * @param {any} containerID
 * @param {any} buttonContainerID
 */
function showComments(containerID, buttonContainerID) {
    var container = document.getElementById(containerID);

    container.className = container.className.replace('d-none', '');

    var buttonContainer = document.getElementById(buttonContainerID);

    var oldButton = buttonContainer.getElementsByTagName('button')[0];

    const newButton = createButton('text-center border-0 cust-button-outline-none', 'button', function () { hideComments(containerID, buttonContainerID) }, 'Skjul kommentarer');

    buttonContainer.replaceChild(newButton, oldButton);
}

/**
 * Used to hide comments on TicketPage. Initially only 5 comments are displayed. This function hides the rest and creates a new button to show them again (See: showComments above).
 * @param {any} containerID
 * @param {any} buttonContainerID
 */
function hideComments(containerID, buttonContainerID) {
    var container = document.getElementById(containerID);

    container.className += ' d-none';

    var buttonContainer = document.getElementById(buttonContainerID);

    var oldButton = buttonContainer.getElementsByTagName('button')[0];

    const newButton = createButton('text-center border-0 cust-button-outline-none', 'button', function () { showComments(containerID, buttonContainerID) }, 'Se alle kommentarer');

    buttonContainer.replaceChild(newButton, oldButton);
}

/**
 * Creates and returns a button with the 'arguments' settings
 * @param {any} className
 * @param {any} type
 * @param {any} clickEvent
 * @param {any} innerHTML
 */
function createButton(className, type, clickEvent, innerHTML) {
    const button = document.createElement('button');
    button.className = className;
    button.addEventListener('click', clickEvent);
    button.innerHTML = innerHTML;
    button.setAttribute('type', type);

    return button;
}

function toggleElement(id) {
    var element = document.getElementById(id);

    console.log(element.id);

    if (element.className == "d-none") {
        element.className = element.className.replace("d-none", "");

        return;
    }

    element.className += "d-none";
}