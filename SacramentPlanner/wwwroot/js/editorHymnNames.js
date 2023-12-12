import names from "../js/HymnNames-eng.min.json" assert {type: 'json'};
// I wanted to try out jQuery but ironically this is easier

const hymnsUrl = "https://www.churchofjesuschrist.org/music/library/hymns/";

// You can link to a hymn from its number!
function makeHymnAnchor(num) {
    return `<a href="${hymnsUrl}${num}">${names[num]}</a>`;
}

document.querySelectorAll(".hymn-group").forEach((group) => {
    let field = group.querySelector(".hymn-field");
    let name = group.querySelector(".hymn-name");

    // Update hymn name if it's valid
    field.oninput = () => {
        // console.log(names[field.value]);
        if (!names[field.value])
            name.textContent = "";
        else
            name.innerHTML = makeHymnAnchor(field.value);
    };

    if (names[field.value])
        name.innerHTML = makeHymnAnchor(field.value);
});