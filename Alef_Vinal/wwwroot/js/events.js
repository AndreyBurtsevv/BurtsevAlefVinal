
async function GetAllValues() {
    const response = await fetch("/values", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const values = await response.json();
        let rows = document.querySelector("tbody");
        values.forEach(value => {
            rows.append(row(value));
        });
    }
}

async function GetOneValue(id) {
    const response = await fetch("/values/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const value = await response.json();
        const form = document.forms["editForm"];
        form.elements["valueId"].value = value.id;
        form.elements["name"].value = value.name;
        form.elements["description"].value = value.description;
    }
}

async function CreateValue(valueName, valueDesc) {
    const response = await fetch("values", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            name: valueName,
            description: valueDesc
        })
    });
    if (response.ok === true) {
        const value = await response.json(); 
        document.querySelector("tbody").append(row(value));
        location.reload()
    }
}

async function EditValue(valueId, valueName, valueDesc) {
    const response = await fetch("values", {
        method: "PUT",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            id: parseInt(valueId, 10),
            name: valueName,
            description: valueDesc
        })
    });
    if (response.ok === true) {
        const value = await response.json();
        document.querySelector("tr[data-rowid='" + value.id + "']").replaceWith(row(value));        
    }
}

function row(value) {

    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", value.id);

    const idTd = document.createElement("td");
    idTd.append(value.id);
    tr.append(idTd);

    const nameTd = document.createElement("td");
    nameTd.append(value.name);
    tr.append(nameTd);

    const descTd = document.createElement("td");
    descTd.append(value.description);
    tr.append(descTd);

    const linksTd = document.createElement("td");

    const editLink = document.createElement("a");
    editLink.setAttribute("data-id", value.id);
    editLink.setAttribute("style", "cursor:pointer;padding:15px;");
    editLink.append("Изменить");
    editLink.addEventListener("click", e => {

        e.preventDefault();
        GetOneValue(value.id);
    });
    linksTd.append(editLink);


    tr.appendChild(linksTd);

    return tr;
}

document.forms["createForm"].addEventListener("submit", e => {
    e.preventDefault();
    const form = document.forms["createForm"];
    const name = form.elements["name"].value;
    const description = form.elements["description"].value;
    CreateValue(name, description);
});

document.forms["editForm"].addEventListener("submit", e => {
    e.preventDefault();
    const form = document.forms["editForm"];
    const _id = form.elements["valueId"].value;
    const name = form.elements["name"].value;
    const description = form.elements["description"].value;

    EditValue(_id, name, description);
});

GetAllValues();
